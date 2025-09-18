using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace рієлторська_контора_приклад_гуменна
{
    public partial class Form1 : Form
    {
        private readonly List<PropertyItem> properties = new List<PropertyItem>();

        public Form1()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
            txtStreetName.Validating += (_, __) => ValidateStreetName();
            mtxHouse.Validating += (_, __) => ValidateHouse();

        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            ConfigureGrid();

            mtxHouse.Mask = "000>LL/000";
            mtxHouse.PromptChar = ' ';

            if (cmbStreetType.Items.Count == 0)
            {
                cmbStreetType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbStreetType.Items.AddRange(new object[]
                { "вул.", "просп.", "пров.", "бульв.", "пл.", "шосе", "набережна", "узвіз", "тракт", "кв-л", "мікрорайон" });
                cmbStreetType.SelectedIndex = 0;
            }

            if (cmbCurrency.Items.Count == 0)
            {
                cmbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCurrency.Items.AddRange(new object[] { "UAH", "USD", "EUR" });
                cmbCurrency.SelectedIndex = 0;
            }
        }

        private void ConfigureGrid()
        {
            var dgv = dataGridView1;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv.BackgroundColor = Color.White;
            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Тип", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAddress", HeaderText = "Адреса", Width = 260, DefaultCellStyle = { WrapMode = DataGridViewTriState.True } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colArea", HeaderText = "Площа", Width = 80, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRooms", HeaderText = "Кімнат", Width = 70, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colYear", HeaderText = "Рік", Width = 70, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "N0" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "Ціна", Width = 100, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCurrency", HeaderText = "Валюта", Width = 70, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Статус", Width = 110 });
        }
        private bool ValidateStreetName()
        {
            bool ok = Regex.IsMatch(
                txtStreetName.Text.Trim(),
                @"^[\p{L}][\p{L}\-’'\s]{0,}$",
                RegexOptions.CultureInvariant);

            if (!ok) errorProvider1.SetError(txtStreetName, "Тільки літери, пробіли, дефіси, апостроф.");
            else errorProvider1.SetError(txtStreetName, "");
            return ok;
        }

        private bool ValidateHouse()
        {
            string raw = mtxHouse.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(raw);
            if (!ok) errorProvider1.SetError(mtxHouse, "Вкажіть номер (напр. 12, 12А, 12/3).");
            else errorProvider1.SetError(mtxHouse, "");
            return ok;
        }

        private string BuildAddress()
        {
            string type = (cmbStreetType.Text ?? "").Trim();
            string name = Regex.Replace((txtStreetName.Text ?? "").Trim(), @"\s+", " ");
            string house = (mtxHouse.Text ?? "").Trim();
            return $"{type} {name}, {house}";
        }

        private void ClearInputs()
        {
            txtStreetName.Clear();
            mtxHouse.Clear();
            numArea.Value = 0;
            numRooms.Value = 0;
            numYear.Value = DateTime.Now.Year;
            numPrice.Value = 0;
            errorProvider1.SetError(txtStreetName, "");
            errorProvider1.SetError(mtxHouse, "");
            txtStreetName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateStreetName() | !ValidateHouse())
            {
                MessageBox.Show("Перевірте коректність адреси.", "Увага");
                return;
            }

            var item = new PropertyItem
            {
                Type = cmbType.Text,
                Address = BuildAddress(),
                Area = numArea.Value,
                Rooms = (int)numRooms.Value,
                YearBuilt = (int)numYear.Value,
                Price = numPrice.Value,
                Currency = cmbCurrency.Text,
                Status = cmbStatus.Text
            };
            properties.Add(item);

            dataGridView1.Rows.Add(
                item.Type, item.Address, item.Area, item.Rooms,
                item.YearBuilt, item.Price, item.Currency, item.Status
            );

            ClearInputs();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void MnuCreate_Click(object sender, EventArgs e)
        {
            ClearInputs();
            if (cmbStreetType.Items.Count > 0) cmbStreetType.SelectedIndex = 0;
            if (cmbCurrency.Items.Count > 0) cmbCurrency.SelectedIndex = 0;
            if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
        }
        private void MnuSave_Click(object sender, EventArgs e)
        {
            if (properties.Count == 0)
            {
                MessageBox.Show("Немає даних для збереження.");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Binary (*.bin)|*.bin";
                sfd.FileName = "properties.bin";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                SaveToBin(sfd.FileName);
                MessageBox.Show("Дані збережено.", "OK");
            }
        }

        private void MnuExport_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Binary (*.bin)|*.bin";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                LoadFromBin(ofd.FileName);
                MessageBox.Show("Дані завантажено.", "OK");
            }
        }

        private void SaveToBin(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (var bw = new BinaryWriter(fs, Encoding.UTF8))
            {
                bw.Write(properties.Count);
                foreach (var it in properties)
                {
                    bw.Write(it.Type ?? "");
                    bw.Write(it.Address ?? "");
                    bw.Write(it.Area);
                    bw.Write(it.Rooms);
                    bw.Write(it.YearBuilt);
                    bw.Write(it.Price);
                    bw.Write(it.Currency ?? "");
                    bw.Write(it.Status ?? "");
                }
            }
        }

        private void LoadFromBin(string path)
        {
            properties.Clear();
            dataGridView1.Rows.Clear();

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs, Encoding.UTF8))
            {
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    var it = new PropertyItem
                    {
                        Type = br.ReadString(),
                        Address = br.ReadString(),
                        Area = br.ReadDecimal(),
                        Rooms = br.ReadInt32(),
                        YearBuilt = br.ReadInt32(),
                        Price = br.ReadDecimal(),
                        Currency = br.ReadString(),
                        Status = br.ReadString()
                    };

                    properties.Add(it);
                    dataGridView1.Rows.Add(
                        it.Type, it.Address, it.Area, it.Rooms,
                        it.YearBuilt, it.Price, it.Currency, it.Status
                    );
                }
            }
        }
    }
}