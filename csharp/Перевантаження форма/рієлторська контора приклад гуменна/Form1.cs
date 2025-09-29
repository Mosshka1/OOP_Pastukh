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
        public enum PropertyType { Квартира, Будинок, Офіс, Ділянка }
        public enum DealStatus { В_продажу, Оренда, Продано, Резерв }
        public enum Currency { UAH, USD, EUR }
        public enum PropertyTypeFilter { Всі, Квартира, Будинок, Офіс, Ділянка }
        public enum DealStatusFilter { Всі, В_продажу, Оренда, Продано, Резерв }
        private List<PropertyItem> properties = new List<PropertyItem>();
        private string lastSortColumn = "";
        private bool lastSortAsc = true;

        public Form1()
        {
            InitializeComponent();
            mnuRoomsPlus.Click += mnuRoomsPlus_Click;
            mnuRoomsMinus.Click += mnuRoomsMinus_Click;
            mnuToggleSold.Click += mnuToggleSold_Click;
            mnuComparePrice.Click += mnuComparePrice_Click;
            mnuEdit.Click += mnuEdit_Click;
            mnuDelete.Click += mnuDelete_Click;
            dataGridView1.SelectionChanged += (s, e) => UpdateMenuState();
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
        private PropertyItem GetSelectedOne()
        {
            if (dataGridView1.CurrentRow == null) return null;
            int index = dataGridView1.CurrentRow.Index;
            if (index < 0 || index >= properties.Count) return null;
            return properties[index];
        }
        private void mnuRoomsPlus_Click(object sender, EventArgs e)
        {
            var it = GetSelectedOne();
            if (it == null) return;
            ++it;
            ApplyView();
        }
        private void mnuRoomsMinus_Click(object sender, EventArgs e)
        {
            var it = GetSelectedOne();
            if (it == null) return;
            --it;
            ApplyView();
        }
        private void mnuToggleSold_Click(object sender, EventArgs e)
        {
            var it = GetSelectedOne();
            if (it == null) return;

            if (!it)
                it.Status = DealStatus.В_продажу;
            else
                it.Status = DealStatus.Продано;

            ApplyView();
        }

        private void mnuComparePrice_Click(object sender, EventArgs e)
        {
            var (a, b) = GetSelectedTwo();
            if (a == null || b == null)
            {
                MessageBox.Show("Вибери рівно 2 записи.");
                return;
            }

            try
            {
                string msg;
                if (a == b) msg = "Об'єкти рівні";
                else if (a > b) msg = $"{a.Address} дорожче за {b.Address}";
                else msg = $"{a.Address} дешевше за {b.Address}";

                MessageBox.Show(msg, "Порівняння");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private (PropertyItem a, PropertyItem b) GetSelectedTwo()
        {
            if (dataGridView1.SelectedRows.Count != 2) return (null, null);
            var row1 = dataGridView1.SelectedRows[0];
            var row2 = dataGridView1.SelectedRows[1];
            return (properties[row1.Index], properties[row2.Index]);
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
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.DataSource = Enum.GetValues(typeof(PropertyType));

            cmbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCurrency.DataSource = Enum.GetValues(typeof(Currency));
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DataSource = new[]
            {
        new { Key = DealStatus.В_продажу, Value = "В продажу" },
        new { Key = DealStatus.Оренда,    Value = "Оренда"     },
        new { Key = DealStatus.Продано,   Value = "Продано"    },
        new { Key = DealStatus.Резерв,    Value = "Резерв"     },
    };
            cmbStatus.DisplayMember = "Value";
            cmbStatus.ValueMember = "Key";
            cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterType.DataSource = Enum.GetValues(typeof(PropertyTypeFilter));

            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.DataSource = Enum.GetValues(typeof(DealStatusFilter));

            ApplyView();
        }

        private void ConfigureGrid()
        {
            var dgv = dataGridView1;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

            var item = new PropertyItem
            {
                Type = (PropertyType)cmbType.SelectedItem,
                Currency = (Currency)cmbCurrency.SelectedItem,
                Status = (DealStatus)cmbStatus.SelectedValue, 

                Address = BuildAddress(),
                Area = numArea.Value,
                Rooms = (int)numRooms.Value,
                YearBuilt = (int)numYear.Value,
                Price = numPrice.Value
            };

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
            if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            if (cmbCurrency.Items.Count > 0) cmbCurrency.SelectedIndex = 0;
            if (cmbFilterType.Items.Count > 0) cmbFilterType.SelectedIndex = 0;
            if (cmbFilterStatus.Items.Count > 0) cmbFilterStatus.SelectedIndex = 0;
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
                    bw.Write((int)it.Type);     
                    bw.Write(it.Address ?? "");
                    bw.Write(it.Area);
                    bw.Write(it.Rooms);
                    bw.Write(it.YearBuilt);
                    bw.Write(it.Price);
                    bw.Write((int)it.Currency); 
                    bw.Write((int)it.Status);   
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
                    it.Type = (PropertyType)br.ReadInt32();
                    it.Address = br.ReadString();
                    it.Area = br.ReadDecimal();
                    it.Rooms = br.ReadInt32();
                    it.YearBuilt = br.ReadInt32();
                    it.Price = br.ReadDecimal();
                    it.Currency = (Currency)br.ReadInt32();
                    it.Status = (DealStatus)br.ReadInt32();

                    properties.Add(it);
                }
            }
        }
        private void ApplyView()
        {
            string searchText = (txtSearch.Text == null) ? "" : txtSearch.Text.Trim().ToLower();

            PropertyTypeFilter typeFilter = PropertyTypeFilter.Всі;
            DealStatusFilter statusFilter = DealStatusFilter.Всі;

            if (cmbFilterType.SelectedItem != null)
                typeFilter = (PropertyTypeFilter)cmbFilterType.SelectedItem;
            if (cmbFilterStatus.SelectedItem != null)
                statusFilter = (DealStatusFilter)cmbFilterStatus.SelectedItem;

            dataGridView1.Rows.Clear();

            foreach (PropertyItem it in properties)
            {
                bool ok = true;
                if (searchText.Length > 0)
                {
                    string addr = (it.Address ?? "").ToLower();
                    if (!addr.Contains(searchText))
                        ok = false;
                }
                if (ok && typeFilter != PropertyTypeFilter.Всі)
                {
                    if (it.Type.ToString() != typeFilter.ToString())
                        ok = false;
                }
                if (ok && statusFilter != DealStatusFilter.Всі)
                {
                    if (it.Status.ToString() != statusFilter.ToString())
                        ok = false;
                }

                if (ok)
                {
                    dataGridView1.Rows.Add(
                        it.Type.ToString(),
                        it.Address,
                        it.Area,
                        it.Rooms,
                        it.YearBuilt,
                        it.Price,
                        it.Currency.ToString(),
                        it.Status.ToString()
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
                    case "colType": r = string.Compare(a.Type.ToString(), b.Type.ToString(), StringComparison.OrdinalIgnoreCase); break;
                    case "colAddress": r = string.Compare(a.Address, b.Address, StringComparison.OrdinalIgnoreCase); break;
                    case "colArea": r = a.Area.CompareTo(b.Area); break;
                    case "colRooms": r = a.Rooms.CompareTo(b.Rooms); break;
                    case "colYear": r = a.YearBuilt.CompareTo(b.YearBuilt); break;
                    case "colPrice": r = a.Price.CompareTo(b.Price); break;
                    case "colCurrency": r = string.Compare(a.Currency.ToString(), b.Currency.ToString(), StringComparison.OrdinalIgnoreCase); break;
                    case "colStatus": r = string.Compare(a.Status.ToString(), b.Status.ToString(), StringComparison.OrdinalIgnoreCase); break;
                }
                if (!lastSortAsc) r = -r;
                return r;
            };

            properties.Sort(cmp);
            ApplyView();
        }
        private void UpdateMenuState()
        {
            bool hasSelection = dataGridView1.SelectedRows.Count > 0;
            mnuEdit.Enabled = hasSelection && dataGridView1.SelectedRows.Count == 1;
            mnuDelete.Enabled = hasSelection;
        }
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1) return;

            var row = dataGridView1.SelectedRows[0];
            var item = properties[row.Index];
            cmbType.SelectedItem = item.Type;
            txtStreetName.Text = item.Address;
            numArea.Value = item.Area;
            numRooms.Value = item.Rooms;
            numYear.Value = item.YearBuilt;
            numPrice.Value = item.Price;
            cmbCurrency.SelectedItem = item.Currency;
            cmbStatus.SelectedItem = item.Status;
            btnAdd.Text = "Зберегти";
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Видалити вибрані записи?", "Підтвердження",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Index >= 0 && row.Index < properties.Count)
                    properties.RemoveAt(row.Index);
            }

            ApplyView();
        }
    }
}
