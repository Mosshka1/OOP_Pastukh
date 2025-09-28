namespace рієлторська_контора_приклад_гуменна
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.mtxHouse = new System.Windows.Forms.MaskedTextBox();
            this.cmbStreetType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.lblYear = new System.Windows.Forms.Label();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.lblRooms = new System.Windows.Forms.Label();
            this.numArea = new System.Windows.Forms.NumericUpDown();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreate,
            this.mnuSave,
            this.mnuExport,
            this.mnuEdit,
            this.mnuDelete});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCreate
            // 
            this.mnuCreate.Name = "mnuCreate";
            this.mnuCreate.Size = new System.Drawing.Size(88, 24);
            this.mnuCreate.Text = "Створити";
            this.mnuCreate.Click += new System.EventHandler(this.MnuCreate_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(86, 24);
            this.mnuSave.Text = "Зберегти";
            this.mnuSave.Click += new System.EventHandler(this.MnuSave_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(79, 24);
            this.mnuExport.Text = "Вивести";
            this.mnuExport.Click += new System.EventHandler(this.MnuExport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnResetFilters);
            this.panel1.Controls.Add(this.cmbFilterStatus);
            this.panel1.Controls.Add(this.cmbFilterType);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmbCurrency);
            this.panel1.Controls.Add(this.mtxHouse);
            this.panel1.Controls.Add(this.cmbStreetType);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.numPrice);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.numYear);
            this.panel1.Controls.Add(this.lblYear);
            this.panel1.Controls.Add(this.numRooms);
            this.panel1.Controls.Add(this.lblRooms);
            this.panel1.Controls.Add(this.numArea);
            this.panel1.Controls.Add(this.lblArea);
            this.panel1.Controls.Add(this.txtStreetName);
            this.panel1.Controls.Add(this.lblAddress);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 422);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Пошук/фільтрація";
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(122, 336);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(100, 26);
            this.btnResetFilters.TabIndex = 22;
            this.btnResetFilters.Text = "Очистити ";
            this.toolTip1.SetToolTip(this.btnResetFilters, "Очистити поля для фільтрації");
            this.btnResetFilters.UseVisualStyleBackColor = true;
            // 
            // cmbFilterStatus
            // 
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.FormattingEnabled = true;
            this.cmbFilterStatus.Location = new System.Drawing.Point(16, 338);
            this.cmbFilterStatus.Name = "cmbFilterStatus";
            this.cmbFilterStatus.Size = new System.Drawing.Size(100, 24);
            this.cmbFilterStatus.TabIndex = 21;
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(16, 308);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(100, 24);
            this.cmbFilterType.TabIndex = 20;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(122, 308);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 22);
            this.txtSearch.TabIndex = 19;
            this.toolTip1.SetToolTip(this.txtSearch, "Введіть назву обёєкта для фільтрації");
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Items.AddRange(new object[] {
            "UAH",
            "USD",
            "EUR"});
            this.cmbCurrency.Location = new System.Drawing.Point(285, 225);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(65, 24);
            this.cmbCurrency.TabIndex = 18;
            // 
            // mtxHouse
            // 
            this.mtxHouse.Location = new System.Drawing.Point(322, 63);
            this.mtxHouse.Mask = "000>LL/000";
            this.mtxHouse.Name = "mtxHouse";
            this.mtxHouse.PromptChar = ' ';
            this.mtxHouse.Size = new System.Drawing.Size(43, 22);
            this.mtxHouse.TabIndex = 17;
            // 
            // cmbStreetType
            // 
            this.cmbStreetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStreetType.FormattingEnabled = true;
            this.cmbStreetType.Items.AddRange(new object[] {
            "вул",
            "просп",
            "пров",
            "бульв",
            "пл",
            "шосе",
            "набережна",
            "узвіз",
            "тракт",
            "кв-л",
            "мікрорайон"});
            this.cmbStreetType.Location = new System.Drawing.Point(99, 61);
            this.cmbStreetType.Name = "cmbStreetType";
            this.cmbStreetType.Size = new System.Drawing.Size(80, 24);
            this.cmbStreetType.TabIndex = 16;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(282, 286);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Очистити";
            this.toolTip1.SetToolTip(this.btnClear, "Очистити поля вводу");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(281, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 25);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "В продажу",
            "Оренда",
            "Продано",
            "Резерв"});
            this.cmbStatus.Location = new System.Drawing.Point(158, 256);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 24);
            this.cmbStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(16, 264);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 16);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Статус";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(158, 223);
            this.numPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(120, 22);
            this.numPrice.TabIndex = 11;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(16, 225);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 16);
            this.lblPrice.TabIndex = 10;
            this.lblPrice.Text = "Ціна";
            // 
            // numYear
            // 
            this.numYear.Location = new System.Drawing.Point(158, 184);
            this.numYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 22);
            this.numYear.TabIndex = 9;
            this.numYear.Value = new decimal(new int[] {
            2025,
            0,
            0,
            0});
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(16, 190);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(93, 16);
            this.lblYear.TabIndex = 8;
            this.lblYear.Text = "Рік побудови";
            // 
            // numRooms
            // 
            this.numRooms.Location = new System.Drawing.Point(158, 148);
            this.numRooms.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(120, 22);
            this.numRooms.TabIndex = 7;
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Location = new System.Drawing.Point(13, 148);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(109, 16);
            this.lblRooms.TabIndex = 6;
            this.lblRooms.Text = "Кількість кімнат";
            // 
            // numArea
            // 
            this.numArea.DecimalPlaces = 2;
            this.numArea.Location = new System.Drawing.Point(158, 107);
            this.numArea.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numArea.Name = "numArea";
            this.numArea.Size = new System.Drawing.Size(120, 22);
            this.numArea.TabIndex = 5;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(16, 109);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(69, 16);
            this.lblArea.TabIndex = 4;
            this.lblArea.Text = "Площа, м²";
            // 
            // txtStreetName
            // 
            this.txtStreetName.Location = new System.Drawing.Point(185, 64);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(121, 22);
            this.txtStreetName.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 64);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(55, 16);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Адреса";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Квартира",
            "Будинок",
            "Офіс",
            "Ділянка"});
            this.cmbType.Location = new System.Drawing.Point(158, 13);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 24);
            this.cmbType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 16);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Тип об\'єкта";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(368, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(432, 422);
            this.dataGridView1.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(99, 24);
            this.mnuEdit.Text = "Редагувати";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(89, 24);
            this.mnuDelete.Text = "Видалити";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCreate;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.NumericUpDown numArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbStreetType;
        private System.Windows.Forms.MaskedTextBox mtxHouse;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
    }
}

