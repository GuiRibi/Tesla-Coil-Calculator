namespace Tesla_Coil_Calculator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxIcon = new PictureBox();
            pictureBoxClose = new PictureBox();
            pictureBoxMinimize = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            labelConical = new Label();
            labelFlat = new Label();
            labelHelical = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            labeldVdt = new Label();
            labelCapacitance = new Label();
            labelVoltage = new Label();
            labelCoils = new Label();
            labelCapacitors = new Label();
            labelOthers = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            labelPowerSupply = new Label();
            labelTopLoad = new Label();
            labelRF = new Label();
            labelPowerDissipation = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label10 = new Label();
            label11 = new Label();
            pictureBoxImage = new PictureBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            labelTitle = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            panel2 = new Panel();
            pictureBoxTorus = new PictureBox();
            pictureBoxSphere = new PictureBox();
            tableLayoutPanel10 = new TableLayoutPanel();
            tableLayoutPanel11 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox4 = new ComboBox();
            comboBox1 = new ComboBox();
            textBox5 = new TextBox();
            comboBox5 = new ComboBox();
            textBox6 = new TextBox();
            comboBox6 = new ComboBox();
            panel1 = new Panel();
            radioButton6 = new RadioButton();
            radioButton5 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton1 = new RadioButton();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            timerCalc = new System.Windows.Forms.Timer(components);
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            toolTip6 = new ToolTip(components);
            toolTip7 = new ToolTip(components);
            toolTip8_1 = new ToolTip(components);
            toolTip8_2 = new ToolTip(components);
            toolTip9 = new ToolTip(components);
            toolTip10 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimize).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTorus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSphere).BeginInit();
            tableLayoutPanel10.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(31, 31, 31);
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Controls.Add(pictureBoxIcon, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBoxClose, 3, 0);
            tableLayoutPanel1.Controls.Add(pictureBoxMinimize, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 30);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.MouseDown += tableLayoutPanel1_MouseDown;
            // 
            // pictureBoxIcon
            // 
            pictureBoxIcon.Dock = DockStyle.Fill;
            pictureBoxIcon.Image = Properties.Resources.IconSpark;
            pictureBoxIcon.Location = new Point(3, 3);
            pictureBoxIcon.Name = "pictureBoxIcon";
            pictureBoxIcon.Size = new Size(24, 24);
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxIcon.TabIndex = 1;
            pictureBoxIcon.TabStop = false;
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Cursor = Cursors.Hand;
            pictureBoxClose.Dock = DockStyle.Fill;
            pictureBoxClose.Image = Properties.Resources.Xwhite;
            pictureBoxClose.Location = new Point(773, 3);
            pictureBoxClose.Name = "pictureBoxClose";
            pictureBoxClose.Size = new Size(24, 24);
            pictureBoxClose.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxClose.TabIndex = 0;
            pictureBoxClose.TabStop = false;
            pictureBoxClose.Click += pictureBoxClose_Click;
            // 
            // pictureBoxMinimize
            // 
            pictureBoxMinimize.Cursor = Cursors.Hand;
            pictureBoxMinimize.Dock = DockStyle.Fill;
            pictureBoxMinimize.Image = Properties.Resources.Minimize;
            pictureBoxMinimize.Location = new Point(743, 3);
            pictureBoxMinimize.Name = "pictureBoxMinimize";
            pictureBoxMinimize.Size = new Size(24, 24);
            pictureBoxMinimize.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMinimize.TabIndex = 2;
            pictureBoxMinimize.TabStop = false;
            pictureBoxMinimize.Click += pictureBoxMinimize_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(31, 31, 31);
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 4);
            tableLayoutPanel2.Controls.Add(labelCoils, 0, 1);
            tableLayoutPanel2.Controls.Add(labelCapacitors, 0, 3);
            tableLayoutPanel2.Controls.Add(labelOthers, 0, 5);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 0, 6);
            tableLayoutPanel2.Dock = DockStyle.Left;
            tableLayoutPanel2.Location = new Point(0, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 8;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 13F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 144F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(155, 420);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(labelConical, 1, 2);
            tableLayoutPanel5.Controls.Add(labelFlat, 1, 1);
            tableLayoutPanel5.Controls.Add(labelHelical, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 38);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(149, 74);
            tableLayoutPanel5.TabIndex = 9;
            // 
            // labelConical
            // 
            labelConical.AutoSize = true;
            labelConical.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelConical.ForeColor = Color.White;
            labelConical.Location = new Point(18, 44);
            labelConical.Name = "labelConical";
            labelConical.Size = new Size(72, 21);
            labelConical.TabIndex = 7;
            labelConical.Text = ">Conical";
            labelConical.Click += labelConical_Click;
            labelConical.MouseEnter += labelConical_MouseEnter;
            labelConical.MouseLeave += labelConical_MouseLeave;
            // 
            // labelFlat
            // 
            labelFlat.AutoSize = true;
            labelFlat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelFlat.ForeColor = Color.White;
            labelFlat.Location = new Point(18, 22);
            labelFlat.Name = "labelFlat";
            labelFlat.Size = new Size(46, 21);
            labelFlat.TabIndex = 8;
            labelFlat.Text = ">Flat";
            labelFlat.Click += labelFlat_Click;
            labelFlat.MouseEnter += labelFlat_MouseEnter;
            labelFlat.MouseLeave += labelFlat_MouseLeave;
            // 
            // labelHelical
            // 
            labelHelical.AutoSize = true;
            labelHelical.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelHelical.ForeColor = Color.White;
            labelHelical.Location = new Point(18, 0);
            labelHelical.Name = "labelHelical";
            labelHelical.Size = new Size(67, 21);
            labelHelical.TabIndex = 2;
            labelHelical.Text = ">Helical";
            labelHelical.Click += labelHelical_Click;
            labelHelical.MouseEnter += labelHelical_MouseEnter;
            labelHelical.MouseLeave += labelHelical_MouseLeave;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(labeldVdt, 1, 2);
            tableLayoutPanel4.Controls.Add(labelCapacitance, 1, 1);
            tableLayoutPanel4.Controls.Add(labelVoltage, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 145);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(149, 72);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // labeldVdt
            // 
            labeldVdt.AutoSize = true;
            labeldVdt.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labeldVdt.ForeColor = Color.White;
            labeldVdt.Location = new Point(18, 44);
            labeldVdt.Name = "labeldVdt";
            labeldVdt.Size = new Size(60, 21);
            labeldVdt.TabIndex = 4;
            labeldVdt.Text = ">dV/dt";
            labeldVdt.Click += labeldVdt_Click;
            labeldVdt.MouseEnter += labeldVdt_MouseEnter;
            labeldVdt.MouseLeave += labeldVdt_MouseLeave;
            // 
            // labelCapacitance
            // 
            labelCapacitance.AutoSize = true;
            labelCapacitance.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapacitance.ForeColor = Color.White;
            labelCapacitance.Location = new Point(18, 22);
            labelCapacitance.Name = "labelCapacitance";
            labelCapacitance.Size = new Size(104, 21);
            labelCapacitance.TabIndex = 5;
            labelCapacitance.Text = ">Capacitance";
            labelCapacitance.Click += labelCapacitance_Click;
            labelCapacitance.MouseEnter += labelCapacitance_MouseEnter;
            labelCapacitance.MouseLeave += labelCapacitance_MouseLeave;
            // 
            // labelVoltage
            // 
            labelVoltage.AutoSize = true;
            labelVoltage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelVoltage.ForeColor = Color.White;
            labelVoltage.Location = new Point(18, 0);
            labelVoltage.Name = "labelVoltage";
            labelVoltage.Size = new Size(73, 21);
            labelVoltage.TabIndex = 6;
            labelVoltage.Text = ">Voltage";
            labelVoltage.Click += labelVoltage_Click;
            labelVoltage.MouseEnter += labelVoltage_MouseEnter;
            labelVoltage.MouseLeave += labelVoltage_MouseLeave;
            // 
            // labelCoils
            // 
            labelCoils.AutoSize = true;
            labelCoils.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCoils.ForeColor = Color.White;
            labelCoils.Location = new Point(3, 13);
            labelCoils.Name = "labelCoils";
            labelCoils.Size = new Size(53, 22);
            labelCoils.TabIndex = 2;
            labelCoils.Text = "Coils";
            // 
            // labelCapacitors
            // 
            labelCapacitors.AutoSize = true;
            labelCapacitors.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCapacitors.ForeColor = Color.White;
            labelCapacitors.Location = new Point(3, 115);
            labelCapacitors.Name = "labelCapacitors";
            labelCapacitors.Size = new Size(102, 25);
            labelCapacitors.TabIndex = 3;
            labelCapacitors.Text = "Capacitors";
            // 
            // labelOthers
            // 
            labelOthers.AutoSize = true;
            labelOthers.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelOthers.ForeColor = Color.White;
            labelOthers.Location = new Point(3, 220);
            labelOthers.Name = "labelOthers";
            labelOthers.Size = new Size(69, 25);
            labelOthers.TabIndex = 10;
            labelOthers.Text = "Others";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(labelPowerSupply, 1, 0);
            tableLayoutPanel6.Controls.Add(labelTopLoad, 1, 1);
            tableLayoutPanel6.Controls.Add(labelRF, 1, 2);
            tableLayoutPanel6.Controls.Add(labelPowerDissipation, 1, 3);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 249);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 4;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(149, 138);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // labelPowerSupply
            // 
            labelPowerSupply.AutoSize = true;
            labelPowerSupply.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPowerSupply.ForeColor = Color.White;
            labelPowerSupply.Location = new Point(18, 0);
            labelPowerSupply.Name = "labelPowerSupply";
            labelPowerSupply.Size = new Size(116, 21);
            labelPowerSupply.TabIndex = 4;
            labelPowerSupply.Text = ">Power Supply";
            labelPowerSupply.Click += labelPowerSupply_Click;
            labelPowerSupply.MouseEnter += labelPowerSupply_MouseEnter;
            labelPowerSupply.MouseLeave += labelPowerSupply_MouseLeave;
            // 
            // labelTopLoad
            // 
            labelTopLoad.AutoSize = true;
            labelTopLoad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTopLoad.ForeColor = Color.White;
            labelTopLoad.Location = new Point(18, 22);
            labelTopLoad.Name = "labelTopLoad";
            labelTopLoad.Size = new Size(75, 21);
            labelTopLoad.TabIndex = 5;
            labelTopLoad.Text = ">Topload";
            labelTopLoad.Click += labelTopLoad_Click;
            labelTopLoad.MouseEnter += labelTopLoad_MouseEnter;
            labelTopLoad.MouseLeave += labelTopLoad_MouseLeave;
            // 
            // labelRF
            // 
            labelRF.AutoSize = true;
            labelRF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRF.ForeColor = Color.White;
            labelRF.Location = new Point(18, 44);
            labelRF.Name = "labelRF";
            labelRF.Size = new Size(96, 42);
            labelRF.TabIndex = 6;
            labelRF.Text = ">Resonance\r\n   Frequency";
            labelRF.Click += labelRF_Click;
            labelRF.MouseEnter += labelRF_MouseEnter;
            labelRF.MouseLeave += labelRF_MouseLeave;
            // 
            // labelPowerDissipation
            // 
            labelPowerDissipation.AutoSize = true;
            labelPowerDissipation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPowerDissipation.ForeColor = Color.White;
            labelPowerDissipation.Location = new Point(18, 91);
            labelPowerDissipation.Name = "labelPowerDissipation";
            labelPowerDissipation.Size = new Size(99, 42);
            labelPowerDissipation.TabIndex = 7;
            labelPowerDissipation.Text = ">Power\r\n   Dissipation";
            labelPowerDissipation.Click += labelPowerDissipation_Click;
            labelPowerDissipation.MouseEnter += labelPowerDissipation_MouseEnter;
            labelPowerDissipation.MouseLeave += labelPowerDissipation_MouseLeave;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label10, 1, 2);
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(18, 0);
            label10.Name = "label10";
            label10.Size = new Size(60, 21);
            label10.TabIndex = 4;
            label10.Text = ">dV/dt";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(18, 0);
            label11.Name = "label11";
            label11.Size = new Size(104, 21);
            label11.TabIndex = 5;
            label11.Text = ">Capacitance";
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Dock = DockStyle.Fill;
            pictureBoxImage.Location = new Point(3, 3);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(214, 267);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.TabIndex = 6;
            pictureBoxImage.TabStop = false;
            pictureBoxImage.Tag = "0";
            pictureBoxImage.MouseMove += pictureBoxImage_MouseMove;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.16279F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 622F));
            tableLayoutPanel7.Controls.Add(labelTitle, 1, 1);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 1, 2);
            tableLayoutPanel7.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel7.Controls.Add(button1, 1, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(155, 30);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 3;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 375F));
            tableLayoutPanel7.Size = new Size(645, 420);
            tableLayoutPanel7.TabIndex = 2;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(26, 21);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(97, 21);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Helical Coil";
            labelTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 61.97183F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.02817F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Controls.Add(tableLayoutPanel9, 1, 0);
            tableLayoutPanel8.Controls.Add(tableLayoutPanel10, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(26, 48);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(616, 369);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 1;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(pictureBoxImage, 0, 0);
            tableLayoutPanel9.Controls.Add(panel2, 0, 1);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(372, 3);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 75.27174F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 24.72826F));
            tableLayoutPanel9.Size = new Size(220, 363);
            tableLayoutPanel9.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBoxTorus);
            panel2.Controls.Add(pictureBoxSphere);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 276);
            panel2.Name = "panel2";
            panel2.Size = new Size(214, 84);
            panel2.TabIndex = 7;
            // 
            // pictureBoxTorus
            // 
            pictureBoxTorus.Image = Properties.Resources.toroid;
            pictureBoxTorus.Location = new Point(103, 17);
            pictureBoxTorus.Name = "pictureBoxTorus";
            pictureBoxTorus.Size = new Size(78, 50);
            pictureBoxTorus.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxTorus.TabIndex = 1;
            pictureBoxTorus.TabStop = false;
            pictureBoxTorus.Visible = false;
            pictureBoxTorus.Click += pictureBoxTorus_Click;
            // 
            // pictureBoxSphere
            // 
            pictureBoxSphere.Image = Properties.Resources.ball;
            pictureBoxSphere.Location = new Point(34, 17);
            pictureBoxSphere.Name = "pictureBoxSphere";
            pictureBoxSphere.Size = new Size(50, 50);
            pictureBoxSphere.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSphere.TabIndex = 0;
            pictureBoxSphere.TabStop = false;
            pictureBoxSphere.Visible = false;
            pictureBoxSphere.Click += pictureBoxSphere_Click;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 3;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 208F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 96F));
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel10.Controls.Add(tableLayoutPanel11, 0, 0);
            tableLayoutPanel10.Controls.Add(panel1, 1, 0);
            tableLayoutPanel10.Dock = DockStyle.Fill;
            tableLayoutPanel10.Location = new Point(3, 3);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 1;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel10.Size = new Size(363, 363);
            tableLayoutPanel10.TabIndex = 8;
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 3;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 59F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tableLayoutPanel11.Controls.Add(label6, 0, 6);
            tableLayoutPanel11.Controls.Add(label5, 0, 5);
            tableLayoutPanel11.Controls.Add(comboBox3, 2, 3);
            tableLayoutPanel11.Controls.Add(comboBox2, 2, 2);
            tableLayoutPanel11.Controls.Add(textBox1, 1, 1);
            tableLayoutPanel11.Controls.Add(textBox2, 1, 2);
            tableLayoutPanel11.Controls.Add(textBox3, 1, 3);
            tableLayoutPanel11.Controls.Add(textBox4, 1, 4);
            tableLayoutPanel11.Controls.Add(label1, 0, 1);
            tableLayoutPanel11.Controls.Add(label2, 0, 2);
            tableLayoutPanel11.Controls.Add(label3, 0, 3);
            tableLayoutPanel11.Controls.Add(label4, 0, 4);
            tableLayoutPanel11.Controls.Add(comboBox4, 2, 4);
            tableLayoutPanel11.Controls.Add(comboBox1, 2, 1);
            tableLayoutPanel11.Controls.Add(textBox5, 1, 5);
            tableLayoutPanel11.Controls.Add(comboBox5, 2, 5);
            tableLayoutPanel11.Controls.Add(textBox6, 1, 6);
            tableLayoutPanel11.Controls.Add(comboBox6, 2, 6);
            tableLayoutPanel11.Dock = DockStyle.Fill;
            tableLayoutPanel11.Location = new Point(3, 3);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 7;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel11.Size = new Size(202, 357);
            tableLayoutPanel11.TabIndex = 0;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 301);
            label6.Name = "label6";
            label6.Size = new Size(53, 26);
            label6.TabIndex = 18;
            label6.Text = "X";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            toolTip3.SetToolTip(label6, "Coil's angle");
            label6.Visible = false;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 248);
            label5.Name = "label5";
            label5.Size = new Size(53, 26);
            label5.TabIndex = 15;
            label5.Text = "W";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            toolTip3.SetToolTip(label5, "Coil's width");
            label5.Visible = false;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(144, 145);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(55, 23);
            comboBox3.TabIndex = 7;
            comboBox3.Visible = false;
            comboBox3.KeyPress += comboBox3_KeyPress;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(144, 92);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(55, 23);
            comboBox2.TabIndex = 6;
            comboBox2.Visible = false;
            comboBox2.KeyPress += comboBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(75, 23);
            textBox1.TabIndex = 0;
            textBox1.Visible = false;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(62, 92);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(75, 23);
            textBox2.TabIndex = 3;
            textBox2.Visible = false;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(62, 145);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(75, 23);
            textBox3.TabIndex = 4;
            textBox3.Visible = false;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(62, 198);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(75, 23);
            textBox4.TabIndex = 5;
            textBox4.Visible = false;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 36);
            label1.Name = "label1";
            label1.Size = new Size(53, 26);
            label1.TabIndex = 9;
            label1.Text = "N";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            toolTip4.SetToolTip(label1, "AC supply voltage");
            toolTip1.SetToolTip(label1, "Coil's number of turns");
            toolTip5.SetToolTip(label1, "Capacitor1's capacitance");
            toolTip9.SetToolTip(label1, "Coil's inductance");
            toolTip8_1.SetToolTip(label1, "Sphere's radius");
            toolTip7.SetToolTip(label1, "Power supply voltage");
            toolTip6.SetToolTip(label1, "AC supply voltage");
            toolTip3.SetToolTip(label1, "Coil's number of turns");
            toolTip10.SetToolTip(label1, "Resistor's resistance");
            toolTip8_2.SetToolTip(label1, "Torus' outer diameter");
            toolTip2.SetToolTip(label1, "Coil's number of turns");
            label1.Visible = false;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 89);
            label2.Name = "label2";
            label2.Size = new Size(53, 26);
            label2.TabIndex = 10;
            label2.Text = "H";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            toolTip4.SetToolTip(label2, "Capacitor max voltage headroom");
            toolTip1.SetToolTip(label2, "Coil's height");
            toolTip5.SetToolTip(label2, "Number of capacitors in series");
            toolTip9.SetToolTip(label2, "Capacitor's capacitance");
            toolTip8_1.SetToolTip(label2, "Topload's capacitance");
            toolTip7.SetToolTip(label2, "Power supply's current");
            toolTip6.SetToolTip(label2, "Resonance frequency");
            toolTip3.SetToolTip(label2, "Coil's height");
            toolTip10.SetToolTip(label2, "The current passing through the resistor");
            toolTip8_2.SetToolTip(label2, "Torus' tube diameter");
            toolTip2.SetToolTip(label2, "Coil's width");
            label2.Visible = false;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 142);
            label3.Name = "label3";
            label3.Size = new Size(53, 26);
            label3.TabIndex = 11;
            label3.Text = "R";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            toolTip4.SetToolTip(label3, "Capacitor's max supply voltage");
            toolTip1.SetToolTip(label3, "Coil's radius");
            toolTip5.SetToolTip(label3, "Number of capacitors in paralel");
            toolTip9.SetToolTip(label3, "Resonance frequency");
            toolTip7.SetToolTip(label3, "Power supply's power");
            toolTip6.SetToolTip(label3, "Capacitor's minimum dV/dt\r\n(How much the voltage can change in one microsecond)");
            toolTip3.SetToolTip(label3, "Coil's radius");
            toolTip10.SetToolTip(label3, "Power dissipated by the resistor");
            toolTip8_2.SetToolTip(label3, "Topload's capacitance");
            toolTip2.SetToolTip(label3, "Coil's radius");
            label3.Visible = false;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 195);
            label4.Name = "label4";
            label4.Size = new Size(53, 26);
            label4.TabIndex = 12;
            label4.Text = "L";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            toolTip1.SetToolTip(label4, "Coil's inductance");
            toolTip5.SetToolTip(label4, "Capacitor bank's total capacitance");
            toolTip3.SetToolTip(label4, "Coil's inductance");
            toolTip2.SetToolTip(label4, "Coil's inductance");
            label4.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "H", "mH", "µH", "nH", "pH" });
            comboBox4.Location = new Point(144, 198);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(55, 23);
            comboBox4.TabIndex = 2;
            comboBox4.Visible = false;
            comboBox4.KeyPress += comboBox4_KeyPress;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(144, 39);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(55, 23);
            comboBox1.TabIndex = 8;
            comboBox1.Visible = false;
            comboBox1.KeyPress += comboBox1_KeyPress;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(62, 251);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(75, 23);
            textBox5.TabIndex = 13;
            textBox5.Visible = false;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(144, 251);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(55, 23);
            comboBox5.TabIndex = 14;
            comboBox5.Visible = false;
            comboBox5.KeyPress += comboBox5_KeyPress;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(62, 304);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(75, 23);
            textBox6.TabIndex = 16;
            textBox6.Visible = false;
            textBox6.KeyPress += textBox6_KeyPress;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(144, 304);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(55, 23);
            comboBox6.TabIndex = 17;
            comboBox6.Visible = false;
            comboBox6.KeyPress += comboBox6_KeyPress;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton6);
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(211, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(90, 357);
            panel1.TabIndex = 1;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(4, 309);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(14, 13);
            radioButton6.TabIndex = 7;
            radioButton6.TabStop = true;
            radioButton6.UseVisualStyleBackColor = true;
            radioButton6.Visible = false;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(4, 256);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(14, 13);
            radioButton5.TabIndex = 6;
            radioButton5.TabStop = true;
            radioButton5.UseVisualStyleBackColor = true;
            radioButton5.Visible = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(4, 150);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.Visible = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(4, 96);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.Visible = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(4, 203);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(14, 13);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.Visible = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(4, 44);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Visible = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Gear1;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(17, 15);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(26, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 15);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timerCalc
            // 
            timerCalc.Enabled = true;
            timerCalc.Interval = 20;
            timerCalc.Tick += timerCalc_Tick;
            // 
            // toolTip10
            // 
            toolTip10.Active = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel7);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMinimize).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxTorus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSphere).EndInit();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxIcon;
        private PictureBox pictureBoxClose;
        private PictureBox pictureBoxMinimize;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelCoils;
        private TableLayoutPanel tableLayoutPanel5;
        private Label labelConical;
        private Label labelFlat;
        private Label labelHelical;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labeldVdt;
        private Label labelCapacitance;
        private Label labelVoltage;
        private Label labelCapacitors;
        private Label labelOthers;
        private TableLayoutPanel tableLayoutPanel6;
        private Label labelPowerSupply;
        private Label labelTopLoad;
        private Label labelRF;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label10;
        private Label label11;
        private PictureBox pictureBoxImage;
        private TableLayoutPanel tableLayoutPanel7;
        private Label labelTitle;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel10;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox1;
        private ComboBox comboBox4;
        private TableLayoutPanel tableLayoutPanel11;
        private Panel panel1;
        private RadioButton radioButton4;
        private RadioButton radioButton1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Timer timerCalc;
        private Label label6;
        private Label label5;
        private TextBox textBox5;
        private ComboBox comboBox5;
        private TextBox textBox6;
        private ComboBox comboBox6;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private Panel panel2;
        private PictureBox pictureBoxTorus;
        private PictureBox pictureBoxSphere;
        private TextBox textBox1;
        private ToolTip toolTip1;
        private ToolTip toolTip3;
        private ToolTip toolTip2;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
        private ToolTip toolTip6;
        private ToolTip toolTip7;
        private ToolTip toolTip8_1;
        private ToolTip toolTip8_2;
        private ToolTip toolTip9;
        private Label labelPowerDissipation;
        private PictureBox pictureBox1;
        private ToolTip toolTip10;
        private Button button1;
    }
}