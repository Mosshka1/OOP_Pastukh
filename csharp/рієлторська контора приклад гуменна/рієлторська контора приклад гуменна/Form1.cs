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
        private List<PropertyItem> properties = new List<PropertyItem>();

        private string lastSortColumn = "";
        private bool lastSortAsc = true;

        public Form1()
        {
            InitializeComponent();

            this.Load += FormMain_Load;

            txtStreetName.Validating += (s, e) => ValidateStreetName();
            mtxHouse.Validating += (s, e) => ValidateHouse();

            txtSearch.TextChanged += (s, e) => ApplyView();
            cmbFilterType.SelectedIndexChanged += (s, e) => ApplyView();
            cmbFilterStatus.SelectedIndexChanged += (s, e) => ApplyView();
            btnResetFilters.Click += (s, e) =>
            {
                txtSearch.Clear();
                if (cmbFilterType.Items.Count > 0) cmbFilterType.SelectedIndex = 0;
                if (cmbFilterStatus.Items.Count > 0) cmbFilterStatus.SelectedIndex = 0;
                ApplyView();
            };

            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
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

            if (cmbFilterType.Items.Count == 0)
            {
                cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbFilterType.Items.AddRange(new object[] { "всі", "Квартира", "Будинок", "Офіс", "Ділянка" });
                cmbFilterType.SelectedIndex = 0;
            }
            if (cmbFilterStatus.Items.Count == 0)
            {
                cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbFilterStatus.Items.AddRange(new object[] { "всі", "В продажу", "Оренда", "Продано", "Резерв" });
                cmbFilterStatus.SelectedIndex = 0;
            }

            ApplyView();
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
            string text = txtStreetName.Text.Trim();
            bool ok = Regex.IsMatch(text, @"^[\p{L}][\p{L}\-’'\s]{0,}$", RegexOptions.CultureInvariant);

            if (!ok)
                errorProvider1.SetError(txtStreetName, "Тільки літери, пробіли, дефіси, апостроф.");
            else
                errorProvider1.SetError(txtStreetName, "");

            return ok;
        }

        private bool ValidateHouse()
        {
            string raw = mtxHouse.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(raw);

            if (!ok)
                errorProvider1.SetError(mtxHouse, "Вкажіть номер (напр. 12, 12А, 12/3).");
            else
                errorProvider1.SetError(mtxHouse, "");

            return ok;
        }

        private string BuildAddress()
        {
            string type = (cmbStreetType.Text ?? "").Trim();
            string name = Regex.Replace((txtStreetName.Text ?? "").Trim(), @"\s+", " ");
            string house = (mtxHouse.Text ?? "").Trim();
            return type + " " + name + ", " + house;
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

            PropertyItem item = new PropertyItem();
            item.Type = cmbType.Text;
            item.Address = BuildAddress();
            item.Area = numArea.Value;
            item.Rooms = (int)numRooms.Value;
            item.YearBuilt = (int)numYear.Value;
            item.Price = numPrice.Value;
            item.Currency = cmbCurrency.Text;
            item.Status = cmbStatus.Text;

            properties.Add(item);

            ApplyView();
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

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Binary (*.bin)|*.bin";
            sfd.FileName = "properties.bin";
            if (sfd.ShowDialog() != DialogResult.OK) return;

            SaveToBin(sfd.FileName);
            MessageBox.Show("Дані збережено.", "OK");
        }

        private void MnuExport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary (*.bin)|*.bin";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            LoadFromBin(ofd.FileName);
            MessageBox.Show("Дані завантажено.", "OK");
            ApplyView();
        }

        private void SaveToBin(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8))
            {
                bw.Write(properties.Count);
                foreach (PropertyItem it in properties)
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

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs, Encoding.UTF8))
            {
                int count = br.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    PropertyItem it = new PropertyItem();
                    it.Type = br.ReadString();
                    it.Address = br.ReadString();
                    it.Area = br.ReadDecimal();
                    it.Rooms = br.ReadInt32();
                    it.YearBuilt = br.ReadInt32();
                    it.Price = br.ReadDecimal();
                    it.Currency = br.ReadString();
                    it.Status = br.ReadString();

                    properties.Add(it);
                }
            }
        }

        private void ApplyView()
        {

            string q = (txtSearch.Text == null) ? "" : txtSearch.Text.Trim().ToLower();
            string type = (cmbFilterType.SelectedItem as string) ?? "всі";
            string status = (cmbFilterStatus.SelectedItem as string) ?? "всі";

            dataGridView1.Rows.Clear();

            foreach (PropertyItem it in properties)
            {
                bool ok = true;

                if (q.Length > 0)
                {
                    string addr = (it.Address ?? "").ToLower();
                    string t = (it.Type ?? "").ToLower();
                    string st = (it.Status ?? "").ToLower();

                    if (!addr.Contains(q) && !t.Contains(q) && !st.Contains(q))
                        ok = false;
                }

                if (ok && type != "всі")
                {
                    if (!string.Equals(it.Type, type, StringComparison.OrdinalIgnoreCase))
                        ok = false;
                }

                if (ok && status != "всі")
                {
                    if (!string.Equals(it.Status, status, StringComparison.OrdinalIgnoreCase))
                        ok = false;
                }

                if (ok)
                {
                    dataGridView1.Rows.Add(
                        it.Type, it.Address, it.Area, it.Rooms,
                        it.YearBuilt, it.Price, it.Currency, it.Status
                    );
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string col = dataGridView1.Columns[e.ColumnIndex].Name;

            if (lastSortColumn == col)
                lastSortAsc = !lastSortAsc;
            else
            {
                lastSortColumn = col;
                lastSortAsc = true;
            }

            Comparison<PropertyItem> cmp = (a, b) =>
            {
                int r = 0;
                switch (col)
                {
                    case "colType": r = string.Compare(a.Type, b.Type, StringComparison.OrdinalIgnoreCase); break;
                    case "colAddress": r = string.Compare(a.Address, b.Address, StringComparison.OrdinalIgnoreCase); break;
                    case "colArea": r = a.Area.CompareTo(b.Area); break;
                    case "colRooms": r = a.Rooms.CompareTo(b.Rooms); break;
                    case "colYear": r = a.YearBuilt.CompareTo(b.YearBuilt); break;
                    case "colPrice": r = a.Price.CompareTo(b.Price); break;
                    case "colCurrency": r = string.Compare(a.Currency, b.Currency, StringComparison.OrdinalIgnoreCase); break;
                    case "colStatus": r = string.Compare(a.Status, b.Status, StringComparison.OrdinalIgnoreCase); break;
                }
                if (!lastSortAsc) r = -r;
                return r;
            };

            properties.Sort(cmp);
            ApplyView();
        }
    }
}
