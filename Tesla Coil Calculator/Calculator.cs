using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tesla_Coil_Calculator
{
    public partial class Calculator : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        string[] Inductance = { "H", "mH", "µH", "nH", "pH" };
        string[] Capacitance = { "F", "mF", "µF", "nF", "pF" };
        string[] Frequency = { "Hz", "KHz", "MHz", "GHz" };
        string[] Resistance = { "mΩ", "Ω", "KΩ", "MΩ" };
        string[] Angle = { "º", "Rad" };
        string[] Units = { "mm", "in" };

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        Font Bold = new Font("Segoe UI", 12, FontStyle.Bold);
        Font Normal = new Font("Segoe UI", 12, FontStyle.Regular);

        double d1;
        double d2;
        double d3;
        double d4;
        double d5;
        double d6;

        int width;

        Vector4[] Graphcalc;
        PointF[] pointFs;

        public Calculator()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            width = pictureBoxImage.Width;
            Graphcalc = new Vector4[width + 1];
            pointFs = new PointF[width + 1];
        }

        private void labelHelical_MouseEnter(object sender, EventArgs e)
        {
            labelHelical.Font = Bold;
        }

        private void labelHelical_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "1")
                labelHelical.Font = Normal;
        }

        private void labelFlat_MouseEnter(object sender, EventArgs e)
        {
            labelFlat.Font = Bold;
        }

        private void labelFlat_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "2")
                labelFlat.Font = Normal;
        }

        private void labelConical_MouseEnter(object sender, EventArgs e)
        {
            labelConical.Font = Bold;
        }

        private void labelConical_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "3")
                labelConical.Font = Normal;
        }

        private void labelVoltage_MouseEnter(object sender, EventArgs e)
        {
            labelVoltage.Font = Bold;
        }

        private void labelVoltage_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "4")
                labelVoltage.Font = Normal;
        }

        private void labelCapacitance_MouseEnter(object sender, EventArgs e)
        {
            labelCapacitance.Font = Bold;
        }

        private void labelCapacitance_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "5")
                labelCapacitance.Font = Normal;
        }

        private void labeldVdt_MouseEnter(object sender, EventArgs e)
        {
            labeldVdt.Font = Bold;
        }

        private void labeldVdt_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "6")
                labeldVdt.Font = Normal;
        }

        private void labelPowerSupply_MouseEnter(object sender, EventArgs e)
        {
            labelPowerSupply.Font = Bold;
        }

        private void labelPowerSupply_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "7")
                labelPowerSupply.Font = Normal;
        }

        private void labelTopLoad_MouseEnter(object sender, EventArgs e)
        {
            labelTopLoad.Font = Bold;
        }

        private void labelTopLoad_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "8")
                labelTopLoad.Font = Normal;
        }

        private void labelRF_MouseEnter(object sender, EventArgs e)
        {
            labelRF.Font = Bold;
        }

        private void labelRF_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "9")
                labelRF.Font = Normal;
        }

        private void labelPowerDissipation_MouseEnter(object sender, EventArgs e)
        {
            labelPowerDissipation.Font = Bold;
        }

        private void labelPowerDissipation_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "10")
                labelPowerDissipation.Font = Normal;
        }

        private void labelGraphicalCalculator_MouseEnter(object sender, EventArgs e)
        {
            labelGraphicalCalculator.Font = Bold;
        }

        private void labelGraphicalCalculator_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "11")
                labelGraphicalCalculator.Font = Normal;
        }

        private void labelGraphicalCalculator_Click(object sender, EventArgs e)
        {
            GraphicsCalculator calculator = new GraphicsCalculator();
            calculator.Show();
        }


        private void labelHelical_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "1";
            labelHelical.Font = Bold;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Helical;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "Turns";
            comboBox2.Items.AddRange(Units);
            comboBox3.Items.AddRange(Units);
            comboBox4.Items.AddRange(Inductance);

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Helical Coil";

            label1.Text = "N";
            label2.Text = "H";
            label3.Text = "R";
            label4.Text = "L";

            //Tooltip
            toolTip1.Active = true;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelFlat_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "2";
            labelHelical.Font = Normal;
            labelFlat.Font = Bold;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Flat;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "Turns";
            comboBox2.Items.AddRange(Units);
            comboBox3.Items.AddRange(Units);
            comboBox4.Items.AddRange(Inductance);

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Flat Coil";

            label1.Text = "N";
            label2.Text = "W";
            label3.Text = "R";
            label4.Text = "L";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = true;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelConical_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "3";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Bold;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Conical;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = true;
            comboBox6.Visible = true;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "Turns";
            comboBox2.Items.AddRange(Units);
            comboBox3.Items.AddRange(Units);
            comboBox4.Items.AddRange(Inductance);
            comboBox5.Items.AddRange(Units);
            comboBox6.Items.AddRange(Angle);

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = true;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;

            labelTitle.Text = "Conical Coil";

            label1.Text = "N";
            label2.Text = "H";
            label3.Text = "R";
            label4.Text = "L";
            label5.Text = "W";
            label6.Text = "X";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = true;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelVoltage_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "4";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Bold;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Capacitor;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "V";
            comboBox2.Text = "%";
            comboBox3.Text = "V";

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Capacitor Voltage";

            label1.Text = "U";
            label2.Text = "%";
            label3.Text = "Uc";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = true;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelCapacitance_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "5";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Bold;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.SPCapacitors;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = true;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Items.AddRange(Capacitance);
            comboBox4.Items.AddRange(Capacitance);

            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Capacitor Capacitance";

            label1.Text = "C1";
            label2.Text = "S";
            label3.Text = "P";
            label4.Text = "TC";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = true;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labeldVdt_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "6";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Bold;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Capacitor;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "V";
            comboBox2.Items.AddRange(Frequency);
            comboBox3.Text = "V/µs";

            comboBox2.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Capacitor dV/dt";

            label1.Text = "U";
            label2.Text = "RF";
            label3.Text = "dV/dt";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = true;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelPowerSupply_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "7";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Bold;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.transformer;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Text = "V";
            comboBox2.Text = "A";
            comboBox3.Text = "W";

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Power Supply";

            label1.Text = "U";
            label2.Text = "I";
            label3.Text = "P";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = true;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelTopLoad_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "8";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Bold;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.sphere;

            pictureBoxSphere.Visible = true;
            pictureBoxTorus.Visible = true;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Items.AddRange(Units);
            comboBox2.Items.AddRange(Capacitance);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Topload Capacitance";

            label1.Text = "R";
            label2.Text = "C";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = true;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = false;
        }

        private void labelRF_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "9";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Bold;
            labelPowerDissipation.Font = Normal;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.LCcircuit;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Items.AddRange(Inductance);
            comboBox2.Items.AddRange(Capacitance);
            comboBox3.Items.AddRange(Frequency);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Resonance Frequency";

            label1.Text = "L";
            label2.Text = "C";
            label3.Text = "RF";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = true;
            toolTip10.Active = false;
        }

        private void pictureBoxSphere_Click(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag == "8")
            {
                //pictureBox
                pictureBoxImage.Image = Properties.Resources.sphere;

                pictureBoxSphere.Visible = true;
                pictureBoxTorus.Visible = true;

                //Textbox
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;

                //Combobox
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;

                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;

                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();

                comboBox1.Items.AddRange(Units);
                comboBox2.Items.AddRange(Capacitance);

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;

                //Radiobutton
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton6.Visible = false;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;

                //Label
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                labelTitle.Text = "Topload Capacitance";

                label1.Text = "R";
                label2.Text = "C";

                //Tooltip
                toolTip1.Active = false;
                toolTip2.Active = false;
                toolTip3.Active = false;
                toolTip4.Active = false;
                toolTip5.Active = false;
                toolTip6.Active = false;
                toolTip7.Active = false;
                toolTip8_1.Active = true;
                toolTip8_2.Active = false;
                toolTip9.Active = false;
                toolTip10.Active = false;
            }
        }

        private void pictureBoxTorus_Click(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag == "8")
            {
                //pictureBox
                pictureBoxImage.Image = Properties.Resources.Torus;

                pictureBoxSphere.Visible = true;
                pictureBoxTorus.Visible = true;

                //Textbox
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;

                //Combobox
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                comboBox6.Visible = false;

                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;
                comboBox6.Enabled = false;

                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                comboBox6.Items.Clear();

                comboBox1.Items.AddRange(Units);
                comboBox2.Items.AddRange(Units);
                comboBox3.Items.AddRange(Capacitance);

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                //Radiobutton
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = true;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                radioButton6.Visible = false;

                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;

                //Label
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                labelTitle.Text = "Topload Capacitance";

                label1.Text = "D1";
                label2.Text = "D2";
                label3.Text = "C";

                //Tooltip
                toolTip1.Active = false;
                toolTip2.Active = false;
                toolTip3.Active = false;
                toolTip4.Active = false;
                toolTip5.Active = false;
                toolTip6.Active = false;
                toolTip7.Active = false;
                toolTip8_1.Active = false;
                toolTip8_2.Active = true;
                toolTip9.Active = false;
                toolTip10.Active = false;
            }
        }

        private void labelPowerDissipation_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "10";
            labelHelical.Font = Normal;
            labelFlat.Font = Normal;
            labelConical.Font = Normal;
            labelVoltage.Font = Normal;
            labelCapacitance.Font = Normal;
            labeldVdt.Font = Normal;
            labelPowerSupply.Font = Normal;
            labelTopLoad.Font = Normal;
            labelRF.Font = Normal;
            labelPowerDissipation.Font = Bold;

            //pictureBox
            pictureBoxImage.Image = Properties.Resources.Resistor;

            pictureBoxSphere.Visible = false;
            pictureBoxTorus.Visible = false;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;

            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

            //Combobox
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Items.AddRange(Resistance);
            comboBox2.Text = "A";
            comboBox3.Text = "W";

            comboBox1.SelectedIndex = 1;

            //Radiobutton
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            labelTitle.Text = "Power Dissipation";

            label1.Text = "R";
            label2.Text = "I";
            label3.Text = "P";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;
            toolTip5.Active = false;
            toolTip6.Active = false;
            toolTip7.Active = false;
            toolTip8_1.Active = false;
            toolTip8_2.Active = false;
            toolTip9.Active = false;
            toolTip10.Active = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox1.Text.Contains("."))
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (textBox1.Text.Contains(".") && clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox1.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        return;
                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox1.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "5")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox2.Text.Contains("."))
                {
                    string clipboardText = Clipboard.GetText();

                    bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                    if (isNumeric && e.KeyChar == '\u0016')
                    {
                        if (textBox2.Text.Contains(".") && clipboardText.Contains("."))
                        {
                            e.Handled = true;
                            MessageBox.Show(textBox2.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                        }
                        else
                            return;
                    }
                    if (!isNumeric && e.KeyChar == '\u0016')
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox2.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        e.Handled = true;

                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003')
                {
                    string clipboardText = Clipboard.GetText();

                    bool isNumeric = int.TryParse(clipboardText, out int intValue) || long.TryParse(clipboardText, out long longValue);

                    if (isNumeric && e.KeyChar == '\u0016')
                    {
                        return;
                    }
                    if (!isNumeric && e.KeyChar == '\u0016')
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox2.Text + clipboardText + " is not a valid number. " + label2.Text + " has to be an integer", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        e.Handled = true;
                }
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "5")
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox3.Text.Contains("."))
                {
                    string clipboardText = Clipboard.GetText();

                    bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                    if (isNumeric && e.KeyChar == '\u0016')
                    {
                        if (textBox3.Text.Contains(".") && clipboardText.Contains("."))
                        {
                            e.Handled = true;
                            MessageBox.Show(textBox3.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                        }
                        else
                            return;
                    }
                    if (!isNumeric && e.KeyChar == '\u0016')
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox3.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003')
                {
                    string clipboardText = Clipboard.GetText();

                    bool isNumeric = int.TryParse(clipboardText, out int intValue) || long.TryParse(clipboardText, out long longValue);

                    if (isNumeric && e.KeyChar == '\u0016')
                    {
                        return;
                    }
                    if (!isNumeric && e.KeyChar == '\u0016')
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox3.Text + clipboardText + " is not a valid number. " + label3.Text + " has to be an integer", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        e.Handled = true;

                }
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox4.Text.Contains("."))
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (textBox4.Text.Contains(".") && clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox4.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        return;
                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox4.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox5.Text.Contains("."))
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (textBox5.Text.Contains(".") && clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox5.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        return;
                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox5.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003' || e.KeyChar == '.' && textBox6.Text.Contains("."))
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (textBox6.Text.Contains(".") && clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBox6.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                    else
                        return;
                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox6.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;

            }
        }

        private void timerCalc_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (pictureBoxImage.Tag)
                {
                    case "1": //Helical Coil
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 / 25.4;

                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, -6);

                            d1 = Math.Sqrt(d4 * (9 * d3 + 10 * d2)) / d3;
                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton4.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 / 25.4;

                            d4 = ((d1 * d3) * (d1 * d3)) / (9 * d3 + 10 * d2);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, -6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, 6);

                            if (d4 >= 1)
                                textBox4.Text = d4.ToString("0.0#####E+0");
                            else
                                textBox4.Text = d4.ToString("0.0#####E0");
                        }
                        break;
                    case "2": //Flat Coil
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 / 25.4;

                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, -6);

                            d1 = Math.Sqrt(d4 * (8 * d3 + 11 * d2)) / d3;
                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton4.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 / 25.4;

                            d4 = ((d1 * d3) * (d1 * d3)) / (8 * d3 + 11 * d2);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, -6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, 6);

                            if (d4 >= 1)
                                textBox4.Text = d4.ToString("0.0#####E+0");
                            else
                                textBox4.Text = d4.ToString("0.0#####E0");
                        }
                        break;
                    case "3": //Conical Coil
                        double L1;
                        double L2;

                        if (radioButton4.Checked)
                        {

                            d1 = Convert.ToDouble(textBox1.Text);

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 / 25.4;

                            d5 = Convert.ToDouble(textBox5.Text);
                            if (comboBox5.SelectedIndex == 0)
                                d5 = d5 / 25.4;

                            d6 = Convert.ToDouble(textBox6.Text);
                            if (comboBox6.SelectedIndex == 0)
                                d6 = d6 / (180 / Math.PI);

                            L1 = ((d1 * d3) * (d1 * d3)) / (9 * d3 + 10 * d2);
                            L2 = ((d1 * d3) * (d1 * d3)) / (8 * d3 + 11 * d2);

                            d4 = Math.Sqrt(((L1 * Math.Sin(d6)) * (L1 * Math.Sin(d6)) + (L2 * Math.Cos(d6)) * (L2 * Math.Cos(d6))) / (Math.Sin(d6) + Math.Cos(d6)));
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, -6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, 6);

                            if (d4 >= 1)
                                textBox4.Text = d4.ToString("0.0#####E+0");
                            else
                                textBox4.Text = d4.ToString("0.0#####E0");
                        }
                        break;
                    case "4": //Capacitor Voltage
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d1 = d3 / (Math.Sqrt(2) * d2 / 100);
                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d2 = (d3 / (d1 * Math.Sqrt(2))) * 100;
                            textBox2.Text = Convert.ToString(d2);
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);

                            d3 = d1 * Math.Sqrt(2) * d2 / 100;
                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                    case "5": //SP Capacitance
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, -6);

                            d1 = d4 * d2 / d3;
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, -6);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, 6);

                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, 6);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, -6);

                            d3 = Convert.ToDouble(textBox3.Text);

                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, -6);

                            d2 = Math.Ceiling(d1 / d4 * d3);
                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, 6);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, -6);

                            d2 = Convert.ToDouble(textBox2.Text);

                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, -6);

                            d3 = Math.Ceiling(d4 * d2 / d1);
                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        if (radioButton4.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, 6);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, -6);

                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d4 = d1 / d2 * d3;
                            if (comboBox4.SelectedIndex == 0)
                                d4 = d4 * Math.Pow(10, -6);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, -3);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, 6);

                            if (d4 >= 1)
                                textBox4.Text = d4.ToString("0.0#####E+0");
                            else
                                textBox4.Text = d4.ToString("0.0#####E0");
                        }
                        break;
                    case "6": //Capacitor dV/dt
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, 3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, 6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, 9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, 12);

                            d3 = Convert.ToDouble(textBox3.Text);

                            d1 = d3 * 1000000 / (Math.Sqrt(2) * 2 * Math.PI * d2);
                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d2 = d3 * 1000000 / (Math.Sqrt(2) * 2 * Math.PI * d1);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, -3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, -6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, -9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, -12);

                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, 3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, 6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, 9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, 12);

                            d3 = d1 * 2 * Math.PI * d2 * Math.Sqrt(2) / 1000000;
                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                    case "7": //Transformer Power
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d1 = d3 / d2;
                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d2 = d3 / d1;
                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);

                            d3 = d1 * d2;
                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                    case "8": //Top Load
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 * Math.Pow(10, 12);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, 9);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, 6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, 3);

                            d1 = d2 * 9 / 1.01;
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 / 25.4;

                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * 25.4;

                            d2 = 1.01 * d1 / 9;
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 * Math.Pow(10, -12);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, -9);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, -6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, -3);

                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 / 25.4;

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 / 25.4;

                            d3 = 2.8 * (1.2781 - (d2 / d1)) * Math.Sqrt(2 * Math.PI * Math.PI * (d1 - d2) * (d2 / 2) / (4 * Math.PI));
                            if (comboBox3.SelectedIndex == 0)
                                d3 = d3 * Math.Pow(10, -12);
                            if (comboBox3.SelectedIndex == 1)
                                d3 = d3 * Math.Pow(10, -9);
                            if (comboBox3.SelectedIndex == 2)
                                d3 = d3 * Math.Pow(10, -6);
                            if (comboBox3.SelectedIndex == 3)
                                d3 = d3 * Math.Pow(10, -3);

                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                    case "9": //Resonance Frequency
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, -3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, -6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, -9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, -12);

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 1)
                                d3 = d3 * Math.Pow(10, 3);
                            if (comboBox3.SelectedIndex == 2)
                                d3 = d3 * Math.Pow(10, 6);
                            if (comboBox3.SelectedIndex == 3)
                                d3 = d3 * Math.Pow(10, 9);
                            if (comboBox3.SelectedIndex == 4)
                                d3 = d3 * Math.Pow(10, 12);

                            d1 = (1 / ((2 * Math.PI * d3) * (2 * Math.PI * d3))) / d2;
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, 6);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, 9);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, 12);

                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, -6);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -9);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, -12);

                            d3 = Convert.ToDouble(textBox3.Text);
                            if (comboBox3.SelectedIndex == 1)
                                d3 = d3 * Math.Pow(10, 3);
                            if (comboBox3.SelectedIndex == 2)
                                d3 = d3 * Math.Pow(10, 6);
                            if (comboBox3.SelectedIndex == 3)
                                d3 = d3 * Math.Pow(10, 9);
                            if (comboBox3.SelectedIndex == 4)
                                d3 = d3 * Math.Pow(10, 12);

                            d2 = (1 / ((2 * Math.PI * d3) * (2 * Math.PI * d3))) / d1;
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, 3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, 6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, 9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, 12);

                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, -6);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -9);
                            if (comboBox1.SelectedIndex == 4)
                                d1 = d1 * Math.Pow(10, -12);

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, -3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, -6);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, -9);
                            if (comboBox2.SelectedIndex == 4)
                                d2 = d2 * Math.Pow(10, -12);

                            d3 = 1 / (2 * Math.PI * Math.Sqrt(d1 * d2));
                            if (comboBox3.SelectedIndex == 1)
                                d3 = d3 * Math.Pow(10, -3);
                            if (comboBox3.SelectedIndex == 2)
                                d3 = d3 * Math.Pow(10, -6);
                            if (comboBox3.SelectedIndex == 3)
                                d3 = d3 * Math.Pow(10, -9);
                            if (comboBox3.SelectedIndex == 4)
                                d3 = d3 * Math.Pow(10, -12);

                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                    case "10"://Resonance Frequency
                        if (radioButton1.Checked)
                        {
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);

                            d1 = d3 / (d2 * d2);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, -6);

                            if (d1 >= 1)
                                textBox1.Text = d1.ToString("0.0#####E+0");
                            else
                                textBox1.Text = d1.ToString("0.0#####E0");
                        }
                        if (radioButton2.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, 6);

                            d3 = Convert.ToDouble(textBox3.Text);

                            d2 = Math.Sqrt(d3 / d1);

                            if (d2 >= 1)
                                textBox2.Text = d2.ToString("0.0#####E+0");
                            else
                                textBox2.Text = d2.ToString("0.0#####E0");
                        }
                        if (radioButton3.Checked)
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 2)
                                d1 = d1 * Math.Pow(10, 3);
                            if (comboBox1.SelectedIndex == 3)
                                d1 = d1 * Math.Pow(10, 6);

                            d2 = Convert.ToDouble(textBox2.Text);

                            d3 = d1 * d2 * d2;

                            if (d3 >= 1)
                                textBox3.Text = d3.ToString("0.0#####E+0");
                            else
                                textBox3.Text = d3.ToString("0.0#####E0");
                        }
                        break;
                }
            }
            catch
            {

            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
        }
    }
}