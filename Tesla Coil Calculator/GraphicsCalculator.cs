using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace Tesla_Coil_Calculator
{
    public delegate void NotifyEvent();

    public partial class GraphicsCalculator : Form
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

        string[] Resistance_ohms_meter = { "Ω.m", "Ω.cm" };
        string[] Capacitance = { "F", "mF", "µF", "nF", "pF" };
        string[] Frequency = { "Hz", "KHz", "MHz", "GHz" };
        string[] Resistance = { "mΩ", "Ω", "KΩ", "MΩ" };
        string[] Units = { "mm", "in" };

        public NotifyEvent notifyDelegate;
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
        int font = 7;
        int ccp = 1;

        double CalcT;
        double CalcV;
        float DepthInPixels;

        bool valueschanged = false;
        bool MouseisInside = false;

        int mouseX;
        int mouseY;

        PointF[] pointFs;

        List<Vector3> Graphcalc3 = new List<Vector3>();
        List<Vector4> Graphcalc4 = new List<Vector4>();
        List<Vector4> colors = new List<Vector4>();
        List<Vector4> bars = new List<Vector4>();
        List<Vector4> vector4s = new List<Vector4>();
        List<Vector4> Convertedvector4s = new List<Vector4>();

        Settings settings;

        public GraphicsCalculator()
        {
            InitializeComponent();

            notifyDelegate = new NotifyEvent(ChangeValues);
        }

        private void GraphicsCalculator_Load(object sender, EventArgs e)
        {
            width = pictureBoxImage.Width;
            pointFs = new PointF[ccp * (pictureBoxImage.Width - 4) + 1];
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void labelCCCharging_MouseEnter(object sender, EventArgs e)
        {
            labelCCCharging.Font = Bold;
        }

        private void labelCCCharging_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "1")
                labelCCCharging.Font = Normal;
        }

        private void labelCCDischarging_MouseEnter(object sender, EventArgs e)
        {
            labelCCDischarging.Font = Bold;
        }

        private void labelCCDischarging_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "2")
                labelCCDischarging.Font = Normal;
        }

        private void labelResistiveDischarging_MouseEnter(object sender, EventArgs e)
        {
            labelResistiveDischarging.Font = Bold;
        }

        private void labelResistiveDischarging_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "3")
                labelResistiveDischarging.Font = Normal;
        }

        private void labelSkinEffect_MouseEnter(object sender, EventArgs e)
        {
            labelSkinEffect.Font = Bold;
        }

        private void labelSkinEffect_MouseLeave(object sender, EventArgs e)
        {
            if ((string)pictureBoxImage.Tag != "4")
                labelSkinEffect.Font = Normal;
        }

        private void labelCCCharging_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "1";
            labelCCCharging.Font = Bold;
            labelCCDischarging.Font = Normal;
            labelResistiveDischarging.Font = Normal;
            labelSkinEffect.Font = Normal;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
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
            comboBox5.Visible = true;
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

            comboBox1.Items.AddRange(Capacitance);
            comboBox2.Text = "A";
            comboBox3.Text = "V";
            comboBox4.Text = "V";
            comboBox5.Text = "s";

            comboBox1.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = true;
            radioButton6.Checked = false;

            //Label
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;

            labelTitle.Text = "Constant Current Charging";

            label1.Text = "C";
            label2.Text = "I";
            label3.Text = "U1";
            label4.Text = "U2";
            label5.Text = "T";

            //Tooltip
            toolTip1.Active = true;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = false;

            //pictureBox
            pictureBoxImage.Image = null;

            //Lists
            Array.Clear(pointFs);
            Graphcalc4.Clear();
            Graphcalc3.Clear();
            vector4s.Clear();
            Convertedvector4s.Clear();
            colors.Clear();
            bars.Clear();
        }

        private void labelCCDischarging_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "2";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Bold;
            labelResistiveDischarging.Font = Normal;
            labelSkinEffect.Font = Normal;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
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
            comboBox5.Visible = true;
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

            comboBox1.Items.AddRange(Capacitance);
            comboBox2.Text = "A";
            comboBox3.Text = "V";
            comboBox4.Text = "V";
            comboBox5.Text = "s";

            comboBox1.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = false;
            radioButton2.Visible = false;
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
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;

            labelTitle.Text = "Constant Current Discharging";

            label1.Text = "C";
            label2.Text = "I";
            label3.Text = "U1";
            label4.Text = "U2";
            label5.Text = "T";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = true;
            toolTip3.Active = false;
            toolTip4.Active = false;

            //pictureBox
            pictureBoxImage.Image = null;

            //Lists
            Array.Clear(pointFs);
            Graphcalc4.Clear();
            Graphcalc3.Clear();
            vector4s.Clear();
            Convertedvector4s.Clear();
            colors.Clear();
            bars.Clear();
        }

        private void labelResistiveDischarging_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "3";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Normal;
            labelResistiveDischarging.Font = Bold;
            labelSkinEffect.Font = Normal;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
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
            comboBox5.Visible = true;
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

            comboBox1.Items.AddRange(Capacitance);
            comboBox2.Items.AddRange(Resistance);
            comboBox3.Text = "V";
            comboBox4.Text = "V";
            comboBox5.Text = "s";

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = false;
            radioButton2.Visible = false;
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
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;

            labelTitle.Text = "Resistive Discharging";

            label1.Text = "C";
            label2.Text = "R";
            label3.Text = "U1";
            label4.Text = "U2";
            label5.Text = "T";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = true;
            toolTip4.Active = false;

            //pictureBox
            pictureBoxImage.Image = null;

            //Lists
            Array.Clear(pointFs);
            Graphcalc4.Clear();
            Graphcalc3.Clear();
            vector4s.Clear();
            Convertedvector4s.Clear();
            colors.Clear();
            bars.Clear();
        }

        private void labelSkinEffect_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "4";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Normal;
            labelResistiveDischarging.Font = Normal;
            labelSkinEffect.Font = Bold;

            //Textbox
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
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
            comboBox5.Visible = true;
            comboBox6.Visible = false;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            comboBox1.Items.AddRange(Units);
            comboBox2.Items.AddRange(Resistance_ohms_meter);
            comboBox3.Text = null;
            comboBox4.Items.AddRange(Frequency);
            comboBox5.Items.AddRange(Units);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

            //Radiobutton
            radioButton1.Visible = false;
            radioButton2.Visible = false;
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
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;

            labelTitle.Text = "Helical Coil";

            label1.Text = "D";
            label2.Text = "ρ";
            label3.Text = "μ";
            label4.Text = "F";
            label5.Text = "δ";

            //Tooltip
            toolTip1.Active = false;
            toolTip2.Active = false;
            toolTip3.Active = false;
            toolTip4.Active = true;

            //pictureBox
            pictureBoxImage.Image = null;

            //Lists
            Array.Clear(pointFs);
            Graphcalc4.Clear();
            Graphcalc3.Clear();
            vector4s.Clear();
            Convertedvector4s.Clear();
            colors.Clear();
            bars.Clear();
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox1.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox1.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox2.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox2.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox3.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox3.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox4.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox4.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox5.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox5.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
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
                    {
                        if (Graphcalc3 != null || Graphcalc4 != null)
                        {
                            valueschanged = true;
                        }
                        return;
                    }

                }
                if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBox6.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox6.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
            }
        }

        private void timerCalc_Tick(object sender, EventArgs e)
        {
            var pen2Black = new Pen(Color.Black, 2);
            var pen1Black = new Pen(Color.Black);
            pen2Black.CustomEndCap = new AdjustableArrowCap(5, 5);
            pen1Black.CustomStartCap = new AdjustableArrowCap(3, 3);
            pen1Black.CustomEndCap = new AdjustableArrowCap(3, 3);
            try
            {
                switch (pictureBoxImage.Tag)
                {
                    case "1":
                        GraphCalc calc1 = new GraphCalc(0, 0, 0, 0, 0);
                        try
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
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);

                            calc1.TimeWindow(d1, d2, d3, d4);
                            textBox5.Text = calc1.T.ToString("0.0#####E+0");
                        }
                        catch
                        {
                        }

                        Bitmap btm1 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g1 = Graphics.FromImage(btm1);

                        g1.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g1.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g1.DrawLine(pen2Black, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g1.DrawLine(pen2Black, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g1.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", font), new SolidBrush(Color.Black), pictureBoxImage.Width - 80, pictureBoxImage.Height - 20);
                        g1.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", font), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g1.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        if (MouseisInside)
                        {
                            int X;
                            int Y;

                            if (mouseX > pictureBoxImage.Width / 2)
                                X = mouseX - pictureBoxImage.Width / 2 + 15;
                            else
                                X = mouseX + 5;

                            if (mouseY < 20)
                                Y = mouseY + 10;
                            else
                                Y = mouseY - 10;

                            foreach (Vector4 graph in Graphcalc4)
                            {
                                if (graph.X == mouseX)
                                {
                                    g1.DrawLine(Pens.Black, graph.X, graph.Y, 0, graph.Y);
                                    g1.DrawLine(Pens.Black, graph.X, graph.Y, graph.X, pictureBoxImage.Height);

                                    g1.DrawString("(" + graph.Z.ToString("0.0###E+0") + " s, " + graph.W.ToString("0.0###E+0") + " V)", new Font("Segoe UI", font), new SolidBrush(Color.Black), X, Y);

                                    break;
                                }
                            }
                        }

                        pictureBoxImage.Image = btm1;
                        break;
                    case "2":
                        GraphCalc calc2 = new GraphCalc(0, 0, 0, 0, 0);
                        try
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
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);

                            calc2.TimeWindow(d1, -d2, d3, d4);
                            textBox5.Text = calc2.T.ToString("0.0#####E+0");
                        }
                        catch
                        {
                        }

                        Bitmap btm2 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g2 = Graphics.FromImage(btm2);

                        g2.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g2.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g2.DrawLine(pen2Black, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g2.DrawLine(pen2Black, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g2.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", font), new SolidBrush(Color.Black), pictureBoxImage.Width - 80, pictureBoxImage.Height - 20);
                        g2.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", font), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g2.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        if (MouseisInside)
                        {
                            int X;
                            int Y;

                            if (mouseX > pictureBoxImage.Width / 2)
                                X = mouseX - pictureBoxImage.Width / 2 + 15;
                            else
                                X = mouseX + 5;

                            if (mouseY < 20)
                                Y = mouseY + 10;
                            else
                                Y = mouseY - 10;

                            foreach (Vector4 graph in Graphcalc4)
                            {
                                if (graph.X == mouseX)
                                {
                                    g2.DrawLine(Pens.Black, graph.X, graph.Y, 0, graph.Y);
                                    g2.DrawLine(Pens.Black, graph.X, graph.Y, graph.X, pictureBoxImage.Height);

                                    g2.DrawString("(" + graph.Z.ToString("0.0###E+0") + " s, " + graph.W.ToString("0.0###E+0") + " V)", new Font("Segoe UI", font), new SolidBrush(Color.Black), X, Y);

                                    break;
                                }
                            }
                        }

                        pictureBoxImage.Image = btm2;
                        break;
                    case "3":
                        GraphCalc calc3 = new GraphCalc(0, 0, 0, 0, 0);
                        try
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
                            if (comboBox2.SelectedIndex == 0)
                                d2 = d2 * Math.Pow(10, -3);
                            if (comboBox2.SelectedIndex == 2)
                                d2 = d2 * Math.Pow(10, 3);
                            if (comboBox2.SelectedIndex == 3)
                                d2 = d2 * Math.Pow(10, 6);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);

                            calc3.TimeWindow_RC(d1, d2, d3, d4);
                            textBox5.Text = calc3.T.ToString("0.0#####E+0");
                        }
                        catch
                        {
                        }

                        Bitmap btm3 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g3 = Graphics.FromImage(btm3);

                        g3.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g3.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g3.DrawLine(pen2Black, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g3.DrawLine(pen2Black, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g3.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", font), new SolidBrush(Color.Black), pictureBoxImage.Width - 80, pictureBoxImage.Height - 20);
                        g3.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", font), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g3.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        if (MouseisInside)
                        {
                            int X;
                            int Y;

                            if (mouseX > pictureBoxImage.Width / 2)
                                X = mouseX - pictureBoxImage.Width / 2 + 15;
                            else
                                X = mouseX + 5;

                            if (mouseY < 20)
                                Y = mouseY + 10;
                            else
                                Y = mouseY - 10;

                            foreach (Vector4 graph in Graphcalc4)
                            {
                                if (graph.X == mouseX)
                                {
                                    g3.DrawLine(Pens.Black, graph.X, graph.Y, 0, graph.Y);
                                    g3.DrawLine(Pens.Black, graph.X, graph.Y, graph.X, pictureBoxImage.Height);

                                    g3.DrawString("(" + graph.Z.ToString("0.0###E+0") + " s, " + graph.W.ToString("0.0###E+0") + " V)", new Font("Segoe UI", font), new SolidBrush(Color.Black), X, Y);

                                    break;
                                }
                            }
                        }

                        pictureBoxImage.Image = btm3;
                        break;
                    case "4":
                        GraphCalc calc4 = new GraphCalc(0, 0, 0, 0, 0);

                        Bitmap btm4 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g4 = Graphics.FromImage(btm4);

                        int Width = pictureBoxImage.Width;
                        int Height = pictureBoxImage.Height;

                        g4.FillRectangle(Brushes.White, 0, 0, Width, Height);

                        try
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            if (comboBox1.SelectedIndex == 0)
                                d1 = d1 * Math.Pow(10, -3);
                            if (comboBox1.SelectedIndex == 1)
                                d1 = d1 * 25.4 * Math.Pow(10, -3);

                            d2 = Convert.ToDouble(textBox2.Text);
                            if (comboBox2.SelectedIndex == 1)
                                d2 = d2 * Math.Pow(10, -2);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);
                            if (comboBox4.SelectedIndex == 1)
                                d4 = d4 * Math.Pow(10, 3);
                            if (comboBox4.SelectedIndex == 2)
                                d4 = d4 * Math.Pow(10, 6);
                            if (comboBox4.SelectedIndex == 3)
                                d4 = d4 * Math.Pow(10, 9);
                            if (comboBox4.SelectedIndex == 4)
                                d4 = d4 * Math.Pow(10, 12);

                            calc4.Skin_Depth(d2, d4, d3);
                            if (d1 > calc4.Depth)
                            {
                                if (comboBox5.SelectedIndex == 0)
                                    textBox5.Text = (calc4.Depth * Math.Pow(10, 3)).ToString("0.0#####E+0");
                                if (comboBox5.SelectedIndex == 1)
                                    textBox5.Text = (calc4.Depth * Math.Pow(10, 3) / 25.4).ToString("0.0#####E+0");
                            }

                            else
                            {
                                if (comboBox5.SelectedIndex == comboBox1.SelectedIndex)
                                    textBox5.Text = (d1 / 2).ToString("0.0#####E+0");
                                else
                                {
                                    if (comboBox5.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
                                        textBox5.Text = (d1 / (2 * 25.4)).ToString("0.0#####E+0");
                                    if (comboBox5.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
                                        textBox5.Text = (d1 * 25.4 / 2).ToString("0.0#####E+0");
                                }
                            }
                        }
                        catch
                        {
                            pictureBoxImage.Image = btm4;
                        }

                        double usableConductor = 0;
                        if (d1 > calc4.Depth)
                            usableConductor = Math.PI * Math.Pow(d1 / 2, 2) - Math.PI * Math.Pow(d1 / 2 - calc4.Depth, 2);
                        else
                            usableConductor = Math.PI * Math.Pow(d1 / 2, 2);
                        double Percent = usableConductor / (Math.PI * Math.Pow(d1 / 2, 2)) * 100;

                        PointF pointTopMiddle = new PointF((Width / 2 - 50), (Height / 2 - colors.Max(v => v.W)));
                        PointF pointTopRight = new PointF((Width / 2 - 50) + colors.Max(v => v.W) + 20, (Height / 2 - colors.Max(v => v.W)));

                        PointF pointBottomMiddle = new PointF((Width / 2 - 50), (Height / 2 + colors.Max(v => v.W)));
                        PointF pointBottomRight = new PointF((Width / 2 - 50) + colors.Max(v => v.W) + 20, (Height / 2 + colors.Max(v => v.W)));

                        PointF pointTopMiddleDepth = new PointF((Width / 2 - 50), (Height / 2 - colors.Max(v => v.W)) + DepthInPixels);
                        PointF pointTopRightDepth = new PointF((Width / 2 - 50) + colors.Max(v => v.W) + 10, (Height / 2 - colors.Max(v => v.W)) + DepthInPixels);

                        PointF pointBottomMiddleDepth = new PointF((Width / 2 - 50), (Height / 2 + colors.Max(v => v.W)) - DepthInPixels);
                        PointF pointBottomRightDepth = new PointF((Width / 2 - 50) + colors.Max(v => v.W) + 10, (Height / 2 + colors.Max(v => v.W)) - DepthInPixels);

                        foreach (Vector4 calc in colors)
                        {
                            g4.DrawEllipse(new Pen(Color.FromArgb((int)calc.X, (int)calc.Y, (int)calc.Z)), (float)((Width / 2 - 50) - calc.W), (float)(Height / 2 - calc.W), (float)calc.W * 2, (float)calc.W * 2);
                        }
                        g4.DrawLine(Pens.Black, pointTopMiddle, pointTopRight);
                        g4.DrawLine(Pens.Black, pointBottomMiddle, pointBottomRight);
                        g4.DrawLine(pen1Black, pointTopRight, pointBottomRight);

                        g4.DrawString(d1.ToString(), new Font("Segoe UI", font), new SolidBrush(Color.Black), pointTopRight.X + 5, Height / 2);

                        if (d1 > calc4.Depth)
                        {
                            g4.DrawLine(Pens.Black, pointTopMiddleDepth, pointTopRightDepth);
                            g4.DrawLine(Pens.Black, pointBottomMiddleDepth, pointBottomRightDepth);
                            g4.DrawLine(pen1Black, pointTopRight.X - 10, pointTopRight.Y, pointTopRightDepth.X, pointTopRightDepth.Y);
                            g4.DrawLine(pen1Black, pointBottomRight.X - 10, pointBottomRight.Y, pointBottomRightDepth.X, pointBottomRightDepth.Y);

                            g4.DrawString(calc4.Depth.ToString("0.0#E+0"), new Font("Segoe UI", font), new SolidBrush(Color.Black), pointTopRightDepth.X - 40, (pointTopRight.Y + pointTopRightDepth.Y) / 2);
                            g4.DrawString(calc4.Depth.ToString("0.0#E+0"), new Font("Segoe UI", font), new SolidBrush(Color.Black), pointBottomRightDepth.X - 40, (pointBottomRight.Y + pointBottomRightDepth.Y) / 2);
                        }

                        g4.DrawString("Usable area: " + usableConductor + "m\u00b2", new Font("Segoe UI", font), new SolidBrush(Color.Black), 5, Height - 25);
                        g4.DrawString("% of total conductor area: " + Percent + "%", new Font("Segoe UI", font), new SolidBrush(Color.Black), 5, Height - 15);

                        foreach (Vector4 bar in bars)
                        {
                            g4.DrawLine(new Pen(Color.FromArgb((int)bar.X, (int)bar.Y, (int)bar.Z)), pictureBoxImage.Width - 40, bar.W + 40, pictureBoxImage.Width - 30, bar.W + 40);
                        }

                        if (valueschanged)
                        {
                            g4.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        try
                        {
                            for (int i = 0; i <= Convertedvector4s.Count; i++)
                            {
                                LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 10),
           new Point(200, 10),
           Color.FromArgb((int)Convertedvector4s[i].X, (int)Convertedvector4s[i].Y, (int)Convertedvector4s[i].Z),
           Color.FromArgb((int)Convertedvector4s[i + 1].X, (int)Convertedvector4s[i + 1].Y, (int)Convertedvector4s[i + 1].Z));

                                g4.FillRectangle(linGrBrush, (float)(pictureBoxImage.Width - 40), Convertedvector4s[i].W + 20, 10f, Convertedvector4s[i + 1].W - Convertedvector4s[i].W);
                            }
                        }
                        catch
                        {

                        }

                        pictureBoxImage.Image = btm4;
                        break;
                }
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            valueschanged = false;
            switch (pictureBoxImage.Tag)
            {
                case "1":
                    try
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
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(pointFs, 0, pointFs.Length);
                    colors.Clear();
                    Graphcalc3.Clear();
                    Graphcalc4.Clear();
                    vector4s.Clear();
                    Convertedvector4s.Clear();
                    int i1 = 0;

                    GraphCalc calc1 = new GraphCalc(0, 0, 0, 0, 0);
                    calc1.TimeWindow(d1, d2, d3, d4);
                    for (double t = 0; t < calc1.T + calc1.T / ((pictureBoxImage.Width - 4) * ccp); t = t + calc1.T / (ccp * (pictureBoxImage.Width - 4)))
                    {
                        calc1.Capacitor_Charging(d1, d2, d3, t);
                        if (i1 > ccp * (pictureBoxImage.Width - 4))
                            break;
                        Vector4 vector = new Vector4(i1 / ccp + 4, pictureBoxImage.Height - (float)calc1.V * (pictureBoxImage.Height - 4) / (float)d4 - 4, (float)calc1.DeltaT, (float)calc1.V);
                        Graphcalc4.Add(vector);

                        pointFs[i1] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i1++;
                    }

                    try
                    {
                        CalcT = Graphcalc4.Max(v => v.Z);
                        CalcV = Graphcalc4.Max(v => v.W);
                    }
                    catch
                    {
                    }
                    break;
                case "2":
                    try
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
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(pointFs, 0, pointFs.Length);
                    colors.Clear();
                    Graphcalc3.Clear();
                    Graphcalc4.Clear();
                    vector4s.Clear();
                    Convertedvector4s.Clear();
                    int i2 = 0;

                    GraphCalc calc2 = new GraphCalc(0, 0, 0, 0, 0);
                    calc2.TimeWindow(d1, -d2, d3, d4);
                    for (double t = 0; t < calc2.T + calc2.T / ((pictureBoxImage.Width - 4) * ccp); t = t + calc2.T / (ccp * (pictureBoxImage.Width - 4)))
                    {
                        calc2.Capacitor_Discharging(d1, d2, d3, t);
                        if (i2 > ccp * (pictureBoxImage.Width - 4))
                            break;
                        Vector4 vector = new Vector4(i2 / ccp + 4, pictureBoxImage.Height - (float)(calc2.V * (pictureBoxImage.Height - 4) / d3) - 4, (float)calc2.DeltaT, (float)calc2.V);
                        Graphcalc4.Add(vector);

                        pointFs[i2] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i2++;
                    }

                    try
                    {
                        CalcT = Graphcalc4.Max(v => v.Z);
                        CalcV = Graphcalc4.Max(v => v.W);
                    }
                    catch
                    {
                    }
                    break;
                case "3":
                    try
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
                        if (comboBox2.SelectedIndex == 0)
                            d2 = d2 * Math.Pow(10, -3);
                        if (comboBox2.SelectedIndex == 2)
                            d2 = d2 * Math.Pow(10, 3);
                        if (comboBox2.SelectedIndex == 3)
                            d2 = d2 * Math.Pow(10, 6);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);

                        if (d4 == 0)
                        {
                            MessageBox.Show("U2 must be greater than 0.", "Exception: Value aproaches infinity.", MessageBoxButtons.OK);
                            d4 = 0.1;
                            textBox4.Text = "0.1";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(pointFs, 0, pointFs.Length);
                    colors.Clear();
                    Graphcalc3.Clear();
                    Graphcalc4.Clear();
                    vector4s.Clear();
                    Convertedvector4s.Clear();
                    int i3 = 0;

                    GraphCalc calc3 = new GraphCalc(0, 0, 0, 0, 0);
                    calc3.TimeWindow_RC(d1, d2, d3, d4);
                    for (double t = 0; t < calc3.T + calc3.T / ((pictureBoxImage.Width - 4) * ccp); t = t + calc3.T / (ccp * (pictureBoxImage.Width - 4)))
                    {
                        calc3.Resistive_Discharging(d1, d2, d3, t);
                        if (i3 > ccp * (pictureBoxImage.Width - 4))
                            break;
                        Vector4 vector = new Vector4(i3 / ccp + 4, pictureBoxImage.Height - (float)(calc3.V * (pictureBoxImage.Height - 4) / d3) - 4, (float)calc3.DeltaT, (float)calc3.V);
                        Graphcalc4.Add(vector);

                        pointFs[i3] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i3++;
                    }

                    try
                    {
                        CalcT = Graphcalc4.Max(v => v.Z);
                        CalcV = Graphcalc4.Max(v => v.W);
                    }
                    catch
                    {
                    }
                    break;
                case "4":
                    try
                    {
                        d1 = Convert.ToDouble(textBox1.Text);
                        if (comboBox1.SelectedIndex == 0)
                            d1 = d1 * Math.Pow(10, -3);
                        if (comboBox1.SelectedIndex == 1)
                            d1 = d1 * 25.4 * Math.Pow(10, -3);
                        d2 = Convert.ToDouble(textBox2.Text);
                        if (comboBox2.SelectedIndex == 1)
                            d2 = d2 * Math.Pow(10, -2);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                        if (comboBox4.SelectedIndex == 1)
                            d4 = d4 * Math.Pow(10, 3);
                        if (comboBox4.SelectedIndex == 2)
                            d4 = d4 * Math.Pow(10, 6);
                        if (comboBox4.SelectedIndex == 3)
                            d4 = d4 * Math.Pow(10, 9);
                        if (comboBox4.SelectedIndex == 4)
                            d4 = d4 * Math.Pow(10, 12);

                        if (d4 == 0)
                        {
                            MessageBox.Show("For this calculation, F must be greater than 0. When F = 0, δ = ∞ (all of the available conductor is used).", "Exception: Value aproaches infinity.", MessageBoxButtons.OK);
                            d4 = 20;
                            textBox4.Text = "20";
                        }
                        else if (d4 < 20)
                        {
                            MessageBox.Show("The calculations used may not be very accurate for low frequencies (F < 20). Use it at your own risk.", "Exception: questionable accuracy.", MessageBoxButtons.OK);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(pointFs, 0, pointFs.Length);
                    colors.Clear();
                    Graphcalc3.Clear();
                    Graphcalc4.Clear();
                    vector4s.Clear();
                    Convertedvector4s.Clear();
                    double r = d1 / 2;
                    int i4 = 0;

                    GraphCalc calc4 = new GraphCalc(0, 0, 0, 0, 0);
                    calc4.Skin_Depth(d2, d4, d3);
                    DepthInPixels = (float)(calc4.Depth * pictureBoxImage.Width / d1 / 1.5);
                    for (double d = 0; d <= r; d += r / (ccp * pictureBoxImage.Width / 1.5))
                    {
                        calc4.Skin_Effect(d, d4, d3);
                        if (d > r || i4 > ccp * pictureBoxImage.Width / 1.5)
                            break;

                        Vector3 vector = new Vector3((float)(r - d), (float)d, (float)calc4.Resistance);
                        Graphcalc3.Add(vector);

                        i4++;
                    }

                    for (int i = 0; i < Graphcalc3.Count; i++)
                    {
                        if (Graphcalc3[i].Z <= d2)
                        {
                            double zMin = Graphcalc3.Min(v => v.Z);
                            double zMax = d2;

                            double zvalue = Graphcalc3[i].Z;
                            double value = (zvalue - zMin) / (zMax - zMin);

                            int rRed = Color.Red.R;
                            int rBlue = Color.Green.R;
                            int gRed = Color.Red.G;
                            int gBlue = Color.Green.G;
                            int bRed = Color.Red.B;
                            int bBlue = Color.Green.B;

                            // Calculate the weighted average of each component
                            int rAverage = (int)Math.Round((1 - value) * rRed + value * rBlue);
                            int gAverage = (int)Math.Round((1 - value) * gRed + value * gBlue);
                            int bAverage = (int)Math.Round((1 - value) * bRed + value * bBlue);

                            double W = Graphcalc3[i].X * pictureBoxImage.Width / d1 / 1.5;
                            colors.Add(new Vector4(rAverage, gAverage, bAverage, (float)W));
                        }
                        if (Graphcalc3[i].Z > d2 && Graphcalc3[i].Z <= d2 * 50)
                        {
                            double zMin = d2;
                            double zMax = d2 * 50;

                            double zvalue = Graphcalc3[i].Z;
                            double value = (zvalue - zMin) / (zMax - zMin);

                            int rRed = Color.Green.R;
                            int rBlue = Color.Blue.R;
                            int gRed = Color.Green.G;
                            int gBlue = Color.Blue.G;
                            int bRed = Color.Green.B;
                            int bBlue = Color.Blue.B;

                            // Calculate the weighted average of each component
                            int rAverage = (int)Math.Round((1 - value) * rRed + value * rBlue);
                            int gAverage = (int)Math.Round((1 - value) * gRed + value * gBlue);
                            int bAverage = (int)Math.Round((1 - value) * bRed + value * bBlue);

                            double W = Graphcalc3[i].X * pictureBoxImage.Width / d1 / 1.5;
                            colors.Add(new Vector4(rAverage, gAverage, bAverage, (float)W));
                        }
                        if (Graphcalc3[i].Z > d2 * 50)
                        {
                            int rAverage = 0;
                            int gAverage = 0;
                            int bAverage = 255;

                            double W = Graphcalc3[i].X * pictureBoxImage.Width / d1 / 1.5;
                            colors.Add(new Vector4(rAverage, gAverage, bAverage, (float)W));
                        }
                    }

                    float minZ = 0;
                    float maxZ = 0;
                    float minZ2 = 0;
                    float maxZ2 = 0;
                    float minZ3 = 0;
                    float maxZ3 = 0;

                    try
                    {
                        minZ = colors.Where(c => c.X == 255).Min(c => c.W);
                        maxZ = colors.Where(c => c.X == 255).Max(c => c.W);

                        minZ2 = colors.Where(c => c.Y == 128).Min(c => c.W);
                        maxZ2 = colors.Where(c => c.Y == 128).Max(c => c.W);

                        minZ3 = colors.Where(c => c.Z == 255).Min(c => c.W);
                        maxZ3 = colors.Where(c => c.Z == 255).Max(c => c.W);
                    }
                    catch
                    {

                    }

                    int jwhdjwd = 0;

                    foreach (Vector4 color in colors)
                    {
                        if ((color.W <= minZ && color.W >= maxZ2) || (color.W <= minZ2 && color.W >= maxZ3))
                        {
                            Vector4 newVector4 = new Vector4(color.X, color.Y, color.Z, jwhdjwd);
                            vector4s.Add(newVector4);
                            jwhdjwd++;
                        }
                    }

                    for (int i = 0; i < vector4s.Count; i++)
                    {
                        float converted = vector4s[i].W * 200 / vector4s.Max(v => v.W);

                        Vector4 newConvertedvector4s = new Vector4(vector4s[i].X, vector4s[i].Y, vector4s[i].Z, converted);
                        Convertedvector4s.Add(newConvertedvector4s);
                    }

                    break;
            }
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void pictureBoxImage_MouseLeave(object sender, EventArgs e)
        {
            MouseisInside = false;
        }

        private void pictureBoxImage_MouseEnter(object sender, EventArgs e)
        {
            MouseisInside = true;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            settings = new Settings(notifyDelegate, font, ccp);
            settings.Show();
        }

        public void ChangeValues()
        {
            font = settings.FONT;
            ccp = settings.CCP;

            pointFs = new PointF[ccp * (pictureBoxImage.Width - 4) + 1];

            Array.Clear(pointFs);
            Graphcalc3.Clear();
            Graphcalc4.Clear();
            vector4s.Clear();
            Convertedvector4s.Clear();
            colors.Clear();
            bars.Clear();
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
    }
}
