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

namespace Tesla_Coil_Calculator
{
    public partial class GraphicsCalculator : Form
    {
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

        double CalcT;
        double CalcV;

        bool valueschanged = false;

        Vector3[] Graphcalc3;
        Vector4[] Graphcalc4;
        PointF[] pointFs;
        Vector4[] colors;

        public GraphicsCalculator()
        {
            InitializeComponent();
        }

        private void GraphicsCalculator_Load(object sender, EventArgs e)
        {
            width = pictureBoxImage.Width;
            Graphcalc3 = new Vector3[1000 + 1];
            Graphcalc4 = new Vector4[width + 1];
            pointFs = new PointF[width + 1];
            colors = new Vector4[1000 + 1];
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
            comboBox6.Visible = false;

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
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
            radioButton5.Visible = true;
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

            labelTitle.Text = "Constant Current Charging";

            label1.Text = "C";
            label2.Text = "I";
            label3.Text = "U1";
            label4.Text = "U2";
            label5.Text = "T";
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

            labelTitle.Text = "Constant Current Discharging";

            label1.Text = "C";
            label2.Text = "I";
            label3.Text = "U1";
            label4.Text = "U2";
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

            labelTitle.Text = "Resistive Discharging";

            label1.Text = "C";
            label2.Text = "R";
            label3.Text = "U1";
            label4.Text = "U2";
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

            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;
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
            label5.Visible = true;
            label6.Visible = false;

            labelTitle.Text = "Helical Coil";

            label1.Text = "R";
            label2.Text = "ρ";
            label3.Text = "μ";
            label4.Text = "F";
            label5.Text = "δ";
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
            if(char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !textBox6.Text.Contains(".") || e.KeyChar == (char)Keys.Back)
            {
                if (Graphcalc3 != null || Graphcalc4 != null)
                {
                    valueschanged = true;
                }
            }
        }

        private void timerCalc_Tick(object sender, EventArgs e)
        {
            var penBlack = new Pen(Color.Black, 2);
            penBlack.CustomEndCap = new AdjustableArrowCap(5, 5);
            try
            {
                switch (pictureBoxImage.Tag)
                {
                    case "1":
                        try
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);
                        }
                        catch
                        {
                        }

                        GraphCalc calc1 = new GraphCalc(0, 0, 0, 0, 0);
                        calc1.TimeWindow(d1, d2, d3, d4);
                        d5 = calc1.T;
                        textBox5.Text = d5.ToString("0.0#####E+0");

                        Bitmap btm1 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g1 = Graphics.FromImage(btm1);

                        g1.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g1.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g1.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g1.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g1.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                        g1.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g1.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        pictureBoxImage.Image = btm1;
                        break;
                    case "2":
                        try
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);
                        }
                        catch
                        {
                        }

                        Bitmap btm2 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g2 = Graphics.FromImage(btm2);

                        g2.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g2.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g2.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g2.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g2.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                        g2.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g2.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        pictureBoxImage.Image = btm2;
                        break;
                    case "3":
                        try
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);
                        }
                        catch
                        {
                        }

                        Bitmap btm3 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g3 = Graphics.FromImage(btm3);

                        g3.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        g3.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                        g3.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                        g3.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                        g3.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                        g3.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);

                        if (valueschanged)
                        {
                            g3.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
                        }

                        pictureBoxImage.Image = btm3;
                        break;
                    case "4":
                        try
                        {
                            d1 = Convert.ToDouble(textBox1.Text);
                            d2 = Convert.ToDouble(textBox2.Text);
                            d3 = Convert.ToDouble(textBox3.Text);
                            d4 = Convert.ToDouble(textBox4.Text);
                        }
                        catch
                        {
                        }

                        Bitmap btm4 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                        Graphics g4 = Graphics.FromImage(btm4);

                        g4.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                        foreach (Vector4 calc in colors)
                        {
                            double r = calc.W * pictureBoxImage.Width / d1 / 3;
                            g4.DrawEllipse(new Pen(Color.FromArgb((int)calc.X, (int)calc.Y, (int)calc.Z)), (float)(150 - calc.W), (float)(120 - calc.W), (float)calc.W * 2, (float)calc.W * 2);
                        }

                        if (valueschanged)
                        {
                            g4.DrawImage(Properties.Resources.ChangedValues, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);
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
                        d2 = Convert.ToDouble(textBox2.Text);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(Graphcalc3, 0, Graphcalc3.Length);
                    Array.Clear(Graphcalc4, 0, Graphcalc4.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i1 = 0;

                    GraphCalc calc1 = new GraphCalc(0, 0, 0, 0, 0);
                    calc1.TimeWindow(d1, d2, d3, d4);
                    for (double t = 0; t < calc1.T + calc1.T / pictureBoxImage.Width; t = t + calc1.T / pictureBoxImage.Width)
                    {
                        calc1.Capacitor_Charging(d1, d2, d3, t);
                        if (i1 > width)
                            break;
                        Vector4 vector = new Vector4(i1, pictureBoxImage.Height - (float)calc1.V * pictureBoxImage.Height / (float)d4, (float)calc1.DeltaT, (float)calc1.V);
                        Graphcalc4[i1] = vector;

                        pointFs[i1] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i1++;
                    }
                    CalcT = Graphcalc4.Max(v => v.Z);
                    CalcV = Graphcalc4.Max(v => v.W);
                    break;
                case "2":
                    try
                    {
                        d1 = Convert.ToDouble(textBox1.Text);
                        d2 = Convert.ToDouble(textBox2.Text);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(Graphcalc3, 0, Graphcalc3.Length);
                    Array.Clear(Graphcalc4, 0, Graphcalc4.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i2 = 0;

                    GraphCalc calc2 = new GraphCalc(0, 0, 0, 0, 0);
                    calc2.TimeWindow(d1, -d2, d3, d4);
                    for (double t = 0; t < calc2.T + calc2.T / pictureBoxImage.Width; t = t + calc2.T / pictureBoxImage.Width)
                    {
                        calc2.Capacitor_Discharging(d1, d2, d3, t);
                        if (i2 > width)
                            break;
                        Vector4 vector = new Vector4(i2, pictureBoxImage.Height - (float)(calc2.V * pictureBoxImage.Height / d3), (float)calc2.DeltaT, (float)calc2.V);
                        Graphcalc4[i2] = vector;

                        pointFs[i2] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i2++;
                    }
                    CalcT = Graphcalc4.Max(v => v.Z);
                    CalcV = Graphcalc4.Max(v => v.W);
                    break;
                case "3":
                    try
                    {
                        d1 = Convert.ToDouble(textBox1.Text);
                        d2 = Convert.ToDouble(textBox2.Text);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);

                        if(d4 == 0)
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

                    Array.Clear(Graphcalc3, 0, Graphcalc3.Length);
                    Array.Clear(Graphcalc4, 0, Graphcalc4.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i3 = 0;

                    GraphCalc calc3 = new GraphCalc(0, 0, 0, 0, 0);
                    calc3.TimeWindow_RC(d1, d2, d3, d4);
                    for (double t = 0; t < calc3.T + calc3.T / pictureBoxImage.Width; t = t + calc3.T / pictureBoxImage.Width)
                    {
                        calc3.Resistive_Discharging(d1, d2, d3, t);
                        if (i3 > width)
                            break;
                        Vector4 vector = new Vector4(i3, pictureBoxImage.Height - (float)(calc3.V * pictureBoxImage.Height / d3), (float)calc3.DeltaT, (float)calc3.V);
                        Graphcalc4[i3] = vector;

                        pointFs[i3] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i3++;
                    }
                    CalcT = Graphcalc4.Max(v => v.Z);
                    CalcV = Graphcalc4.Max(v => v.W);
                    break;
                case "4":
                    try
                    {
                        d1 = Convert.ToDouble(textBox1.Text);
                        d2 = Convert.ToDouble(textBox2.Text);
                        d3 = Convert.ToDouble(textBox3.Text);
                        d4 = Convert.ToDouble(textBox4.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not all variables have a defined value. Please intput some value to the missing variables.", "Exception: Unknown value", MessageBoxButtons.OK);
                        break;
                    }

                    Array.Clear(Graphcalc3, 0, Graphcalc3.Length);
                    Array.Clear(Graphcalc4, 0, Graphcalc4.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    double r = d1;
                    int i4 = 0;

                    GraphCalc calc4 = new GraphCalc(0, 0, 0, 0, 0);
                    calc4.Skin_Depth(d2, d4, d3);
                    for (double d = 0; d <= r; d += r / 1001)
                    {
                        calc4.Skin_Effect(d, d4, d3);
                        if (d > r || i4 > 1000)
                            break;

                        double W = (r - d) * pictureBoxImage.Width / d1 / 3;
                        Vector3 vector = new Vector3((float)W, (float)d, (float)calc4.Resistance);
                        Graphcalc3[i4] = vector;

                        //pointFs[i4] = Array.ConvertAll<Vector3, PointF>(new Vector3[] { vector }, v => new PointF(v.Y, v.Z))[0];
                        i4++;
                    }

                    //int c = 0;
                    //foreach (Vector3 vector in Graphcalc3)
                    //{
                    //    double value = vector.Z / Graphcalc3[width].Z;

                    //    int rRed = Color.Red.R;
                    //    int rBlue = Color.Blue.R;
                    //    int gRed = Color.Red.G;
                    //    int gBlue = Color.Blue.G;
                    //    int bRed = Color.Red.B;
                    //    int bBlue = Color.Blue.B;
                    //    // Calculate the weighted average of each component
                    //    int rAverage = (int)Math.Round((1 - value) * rRed + value * rBlue);
                    //    int gAverage = (int)Math.Round((1 - value) * gRed + value * gBlue);
                    //    int bAverage = (int)Math.Round((1 - value) * bRed + value * bBlue);

                    //    colors[c] = new Vector4((float)rAverage, (float)gAverage, (float)bAverage, vector.X);
                    //    c++;
                    //}


                    //Dictionary<double, Color> colorMap = new Dictionary<double, Color>();
                    //colorMap.Add(0.000001, Color.DarkRed);
                    //colorMap.Add(0.001, Color.Red);
                    //colorMap.Add(0.01, Color.Yellow);
                    //colorMap.Add(0.1, Color.Green);
                    //colorMap.Add(1, Color.Blue);

                    //// Find the minimum and maximum values of the Z component
                    //double zMin = Graphcalc3.Min(v => v.Z);
                    //double zMax = Graphcalc3.Max(v => v.Z);

                    //// Iterate through each element in the Graphcalc3 list and assign the corresponding color
                    //for (int i = 0; i < width; i++)
                    //{
                    //    double zValue = Graphcalc3[i].Z;
                    //    double t = (zValue - zMin) / (zMax - zMin);

                    //    if (colorMap.Count > 0 && t >= colorMap.Keys.First() && t <= colorMap.Keys.Last())
                    //    {
                    //        double t1 = colorMap.Keys.Last(k => k <= t);
                    //        double t2 = colorMap.Keys.First(k => k >= t);
                    //        Color color1 = colorMap[t1];
                    //        Color color2 = colorMap[t2];
                    //        double tInterp = (t - t1) / (t2 - t1);
                    //        Color color = InterpolateColor(color1, color2, tInterp);
                    //        colors[i] = new Vector4(color.R, color.G, color.B, Graphcalc3[i].X);
                    //    }
                    //}


                    for (int i = 0; i < 1000 + 1; i++)
                    {
                        if (Graphcalc3[i].Z <= 1.678 * Math.Pow(10, -8))
                        {
                            double zMin = Graphcalc3.Min(v => v.Z);
                            double zMax = 1.678 * Math.Pow(10, -8);

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
                            colors[i] = new Vector4(rAverage, gAverage, bAverage, Graphcalc3[i].X);
                        }
                        if (Graphcalc3[i].Z > 1.678 * Math.Pow(10, -8) && Graphcalc3[i].Z <= 1.678 * Math.Pow(10, -5))
                        {
                            double zMin = 1.678 * Math.Pow(10, -8);
                            double zMax = 1.678 * Math.Pow(10, -5);

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
                            colors[i] = new Vector4(rAverage, gAverage, bAverage, Graphcalc3[i].X);
                        }
                        if(Graphcalc3[i].Z > 1.678 * Math.Pow(10, -5))
                        {
                            double zMin = 1.678 * Math.Pow(10, -5);
                            double zMax = Graphcalc3.Max(v => v.Z);

                            double zvalue = Graphcalc3[i].Z;
                            double value = (zvalue - zMin) / (zMax - zMin);

                            int rRed = Color.Blue.R;
                            int rBlue = Color.DarkBlue.R;
                            int gRed = Color.Blue.G;
                            int gBlue = Color.DarkBlue.G;
                            int bRed = Color.Blue.B;
                            int bBlue = Color.DarkBlue.B;
                            // Calculate the weighted average of each component
                            int rAverage = (int)Math.Round((1 - value) * rRed + value * rBlue);
                            int gAverage = (int)Math.Round((1 - value) * gRed + value * gBlue);
                            int bAverage = (int)Math.Round((1 - value) * bRed + value * bBlue);
                            colors[i] = new Vector4(rAverage, gAverage, bAverage, Graphcalc3[i].X);
                        }
                    }
                    break;
            }
        }
        private Color InterpolateColor(Color color1, Color color2, double t)
        {
            int r = (int)((1 - t) * color1.R + t * color2.R);
            int g = (int)((1 - t) * color1.G + t * color2.G);
            int b = (int)((1 - t) * color1.B + t * color2.B);
            return Color.FromArgb(r, g, b);
        }
    }
}
