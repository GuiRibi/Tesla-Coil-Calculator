namespace Tesla_Coil_Calculator
{
    partial class Settings
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxIcon = new PictureBox();
            pictureBoxClose = new PictureBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label10 = new Label();
            label11 = new Label();
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
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            buttonCancel = new Button();
            buttonSaveAndExit = new Button();
            textBoxFont = new TextBox();
            textBoxGraphics = new TextBox();
            trackBarGraphics = new TrackBar();
            trackBarFont = new TrackBar();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGraphics).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFont).BeginInit();
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
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(386, 30);
            tableLayoutPanel1.TabIndex = 0;
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
            pictureBoxClose.Location = new Point(359, 3);
            pictureBoxClose.Name = "pictureBoxClose";
            pictureBoxClose.Size = new Size(24, 24);
            pictureBoxClose.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxClose.TabIndex = 0;
            pictureBoxClose.TabStop = false;
            pictureBoxClose.Click += pictureBoxClose_Click;
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
            // timerCalc
            // 
            timerCalc.Enabled = true;
            timerCalc.Interval = 20;
            // 
            // toolTip10
            // 
            toolTip10.Active = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 11);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 0;
            label1.Text = "Graphics";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label1, 1, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 2);
            tableLayoutPanel2.Controls.Add(panel1, 2, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(386, 253);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 15F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 99.99999F));
            tableLayoutPanel4.Controls.Add(label2, 1, 1);
            tableLayoutPanel4.Controls.Add(label3, 1, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(11, 41);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(107, 209);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 34);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 1;
            label2.Text = "Font";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(18, 118);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 2;
            label3.Text = "Graphics";
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonSaveAndExit);
            panel1.Controls.Add(textBoxFont);
            panel1.Controls.Add(textBoxGraphics);
            panel1.Controls.Add(trackBarGraphics);
            panel1.Controls.Add(trackBarFont);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(124, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(259, 209);
            panel1.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 89);
            label5.Name = "label5";
            label5.Size = new Size(193, 25);
            label5.TabIndex = 7;
            label5.Text = "Calculations per pixel";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 5);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 6;
            label4.Text = "Font size";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.BackColor = Color.White;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Location = new Point(90, 177);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = false;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSaveAndExit
            // 
            buttonSaveAndExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSaveAndExit.BackColor = Color.White;
            buttonSaveAndExit.FlatStyle = FlatStyle.Flat;
            buttonSaveAndExit.Location = new Point(174, 177);
            buttonSaveAndExit.Name = "buttonSaveAndExit";
            buttonSaveAndExit.Size = new Size(75, 23);
            buttonSaveAndExit.TabIndex = 4;
            buttonSaveAndExit.Text = "Save/Exit";
            buttonSaveAndExit.UseVisualStyleBackColor = false;
            buttonSaveAndExit.Click += buttonSaveAndExit_Click;
            // 
            // textBoxFont
            // 
            textBoxFont.Location = new Point(190, 38);
            textBoxFont.Name = "textBoxFont";
            textBoxFont.Size = new Size(52, 23);
            textBoxFont.TabIndex = 3;
            textBoxFont.Text = "7";
            textBoxFont.TextAlign = HorizontalAlignment.Center;
            textBoxFont.TextChanged += textBoxFont_TextChanged;
            textBoxFont.KeyPress += textBoxFont_KeyPress;
            // 
            // textBoxGraphics
            // 
            textBoxGraphics.Location = new Point(190, 120);
            textBoxGraphics.Name = "textBoxGraphics";
            textBoxGraphics.Size = new Size(52, 23);
            textBoxGraphics.TabIndex = 2;
            textBoxGraphics.Text = "1";
            textBoxGraphics.TextAlign = HorizontalAlignment.Center;
            textBoxGraphics.TextChanged += textBoxGraphics_TextChanged;
            textBoxGraphics.KeyPress += textBoxGraphics_KeyPress;
            // 
            // trackBarGraphics
            // 
            trackBarGraphics.LargeChange = 0;
            trackBarGraphics.Location = new Point(3, 117);
            trackBarGraphics.Maximum = 1000;
            trackBarGraphics.Minimum = 1;
            trackBarGraphics.Name = "trackBarGraphics";
            trackBarGraphics.Size = new Size(166, 45);
            trackBarGraphics.TabIndex = 1;
            trackBarGraphics.TickFrequency = 100;
            trackBarGraphics.Value = 1;
            trackBarGraphics.Scroll += trackBarGraphics_Scroll;
            // 
            // trackBarFont
            // 
            trackBarFont.LargeChange = 0;
            trackBarFont.Location = new Point(3, 33);
            trackBarFont.Maximum = 9;
            trackBarFont.Minimum = 7;
            trackBarFont.Name = "trackBarFont";
            trackBarFont.Size = new Size(169, 45);
            trackBarFont.TabIndex = 0;
            trackBarFont.Value = 7;
            trackBarFont.Scroll += trackBarFont_Scroll;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(386, 283);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            TopMost = true;
            Load += Settings_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarGraphics).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarFont).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxIcon;
        private PictureBox pictureBoxClose;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label10;
        private Label label11;
        private System.Windows.Forms.Timer timerCalc;
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
        private ToolTip toolTip10;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private TrackBar trackBarGraphics;
        private TrackBar trackBarFont;
        private TextBox textBoxFont;
        private TextBox textBoxGraphics;
        private Button buttonCancel;
        private Button buttonSaveAndExit;
        private Label label5;
        private Label label4;
    }
}