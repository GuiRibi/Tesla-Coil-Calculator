using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
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

        Vector4[] Graphcalc;
        PointF[] pointFs;

        public GraphicsCalculator()
        {
            InitializeComponent();
        }

        private void GraphicsCalculator_Load(object sender, EventArgs e)
        {
            width = pictureBoxImage.Width;
            Graphcalc = new Vector4[width + 1];
            pointFs = new PointF[width + 1];
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
        }

        private void labelCCDischarging_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "2";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Bold;
            labelResistiveDischarging.Font = Normal;
            labelSkinEffect.Font = Normal;

        }

        private void labelResistiveDischarging_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "3";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Normal;
            labelResistiveDischarging.Font = Bold;
            labelSkinEffect.Font = Normal;

        }

        private void labelSkinEffect_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Tag = "4";
            labelCCCharging.Font = Normal;
            labelCCDischarging.Font = Normal;
            labelResistiveDischarging.Font = Normal;
            labelSkinEffect.Font = Bold;
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
            var penBlack = new Pen(Color.Black, 2);
            penBlack.CustomEndCap = new AdjustableArrowCap(5, 5);

            switch (pictureBoxImage.Tag)
            {
                case "1":
                    Bitmap btm1 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                    Graphics g1 = Graphics.FromImage(btm1);

                    g1.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                    g1.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                    g1.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                    g1.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                    g1.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                    g1.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);
                    pictureBoxImage.Image = btm1;
                    break;
                case "2":
                    Bitmap btm2 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                    Graphics g2 = Graphics.FromImage(btm2);

                    g2.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                    g2.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                    g2.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                    g2.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                    g2.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                    g2.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);
                    pictureBoxImage.Image = btm2;
                    break;
                case "3":
                    Bitmap btm3 = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
                    Graphics g3 = Graphics.FromImage(btm3);

                    g3.FillRectangle(Brushes.White, 0, 0, pictureBoxImage.Width, pictureBoxImage.Height);

                    g3.DrawLines(new Pen(Brushes.Red, 2), pointFs);
                    g3.DrawLine(penBlack, new Point(0, pictureBoxImage.Height - 4), new Point(pictureBoxImage.Width - 4, pictureBoxImage.Height - 4));
                    g3.DrawLine(penBlack, new Point(4, pictureBoxImage.Height), new Point(4, 0));
                    g3.DrawString("t = " + CalcT.ToString("0.0##E+0") + " s", new Font("Segoe UI", 7), new SolidBrush(Color.Black), pictureBoxImage.Width - 65, pictureBoxImage.Height - 20);
                    g3.DrawString("U = " + CalcV.ToString("0.0##E+0") + " V", new Font("Segoe UI", 7), new SolidBrush(Color.Black), 10, 10);
                    pictureBoxImage.Image = btm3;
                    break;
                //case "4":
                //    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (pictureBoxImage.Tag)
            {
                case "1":
                    Array.Clear(Graphcalc, 0, Graphcalc.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i1 = 0;

                    GraphCalc calc1 = new GraphCalc(0, 0, 0);
                    calc1.TimeWindow(0.0000001, 0.3, 0, 1000);
                    for (double t = 0; t < calc1.T + calc1.T / pictureBoxImage.Width; t = t + calc1.T / pictureBoxImage.Width)
                    {
                        calc1.Capacitor_Charging(0.0000001, 0.3, 0, t);
                        if ((float)calc1.V * pictureBoxImage.Height / 1000 > 1000)
                            break;
                        Vector4 vector = new Vector4(i1, pictureBoxImage.Height - (float)calc1.V * pictureBoxImage.Height / 1000, (float)calc1.DeltaT, (float)calc1.V);
                        Graphcalc[i1] = vector;

                        pointFs[i1] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i1++;
                    }
                    CalcT = Graphcalc[width].Z;
                    CalcV = Graphcalc[width].W;
                    break;
                case "2":
                    Array.Clear(Graphcalc, 0, Graphcalc.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i2 = 0;

                    GraphCalc calc2 = new GraphCalc(0, 0, 0);
                    calc2.TimeWindow(0.0000001, -0.3, 1000, 0);
                    for (double t = 0; t < calc2.T + calc2.T / pictureBoxImage.Width; t = t + calc2.T / pictureBoxImage.Width)
                    {
                        calc2.Capacitor_Discharging(0.0000001, 0.3, 1000, t);
                        if ((float)calc2.V * pictureBoxImage.Height / 1000 > 1000)
                            break;
                        Vector4 vector = new Vector4(i2, pictureBoxImage.Height - (float)calc2.V * pictureBoxImage.Height / 1000, (float)calc2.DeltaT, (float)calc2.V);
                        Graphcalc[i2] = vector;

                        pointFs[i2] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i2++;
                    }
                    CalcT = Graphcalc[width].Z;
                    CalcV = Graphcalc[0].W;
                    break;
                case "3":
                    Array.Clear(Graphcalc, 0, Graphcalc.Length);
                    Array.Clear(pointFs, 0, pointFs.Length);
                    int i3 = 0;

                    GraphCalc calc3 = new GraphCalc(0, 0, 0);
                    calc3.TimeWindow_RC(0.000000675, 4000000, 3252, 30);
                    for (double t = 0; t < calc3.T + calc3.T / pictureBoxImage.Width; t = t + calc3.T / pictureBoxImage.Width)
                    {
                        calc3.Resistive_Discharging(0.000000675, 4000000, 3252, t);
                        if ((float)calc3.V * pictureBoxImage.Height / 3252 > 3252)
                            break;
                        Vector4 vector = new Vector4(i3, pictureBoxImage.Height - (float)calc3.V * pictureBoxImage.Height / 3252, (float)calc3.DeltaT, (float)calc3.V);
                        Graphcalc[i3] = vector;

                        pointFs[i3] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                        i3++;
                    }
                    CalcT = Graphcalc[width].Z;
                    CalcV = Graphcalc[0].W;
                    break;
                //case "4":
                //    Array.Clear(Graphcalc, 0, Graphcalc.Length);
                //    Array.Clear(pointFs, 0, pointFs.Length);
                //    int i4 = 0;

                //    GraphCalc calc4 = new GraphCalc(0, 0, 0);
                //    calc4.TimeWindow_RC(0.000000675, 4000000, 3252, 30);
                //    for (double t = 0; t < calc4.T + calc4.T / pictureBoxImage.Width; t = t + calc4.T / pictureBoxImage.Width)
                //    {
                //        calc4.Resistive_Discharging(0.000000675, 4000000, 3252, t);
                //        if ((float)calc4.V * pictureBoxImage.Height / 3252 > 3252)
                //            break;
                //        Vector4 vector = new Vector4(i4, pictureBoxImage.Height - (float)calc4.V * pictureBoxImage.Height / 3252, (float)calc4.DeltaT, (float)calc4.V);
                //        Graphcalc[i4] = vector;

                //        pointFs[i4] = Array.ConvertAll<Vector4, PointF>(new Vector4[] { vector }, v => new PointF(v.X, v.Y))[0];
                //        i4++;
                //    }
                //    CalcT = Graphcalc[width].Z;
                //    CalcV = Graphcalc[0].W;
                //    break;
            }
        }

    }
}
