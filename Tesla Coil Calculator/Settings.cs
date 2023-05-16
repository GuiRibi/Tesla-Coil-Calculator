using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tesla_Coil_Calculator
{
    public partial class Settings : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        NotifyEvent notifydelegate;
        public int FONT { get; set; }
        public int CCP { get; set; }
        public Settings(NotifyEvent notify, int font, int ccp)
        {
            InitializeComponent();
            FONT = font;
            CCP = ccp;
            notifydelegate = notify;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trackBarFont_Scroll(object sender, EventArgs e)
        {
            textBoxFont.Text = trackBarFont.Value.ToString();
        }

        private void trackBarGraphics_Scroll(object sender, EventArgs e)
        {
            textBoxGraphics.Text = trackBarGraphics.Value.ToString();
        }

        private void buttonSaveAndExit_Click(object sender, EventArgs e)
        {
            CCP = trackBarGraphics.Value;
            FONT = trackBarFont.Value;
            notifydelegate();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            trackBarFont.Value = FONT;
            textBoxFont.Text = FONT.ToString();

            trackBarGraphics.Value = CCP;
            textBoxGraphics.Text = CCP.ToString();
        }

        private void textBoxFont_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003')
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBoxFont.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                }
                else if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBoxFont.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
        }

        private void textBoxGraphics_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '\u0003')
            {
                string clipboardText = Clipboard.GetText();

                bool isNumeric = double.TryParse(clipboardText, out double doubleValue) || long.TryParse(clipboardText, out long longValue);

                if (isNumeric && e.KeyChar == '\u0016')
                {
                    if (clipboardText.Contains("."))
                    {
                        e.Handled = true;
                        MessageBox.Show(textBoxGraphics.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                    }
                }
                else if (!isNumeric && e.KeyChar == '\u0016')
                {
                    e.Handled = true;
                    MessageBox.Show(textBoxGraphics.Text + clipboardText + " is not a valid number.", "Exception: invalid number", MessageBoxButtons.OK);
                }
                else
                    e.Handled = true;
            }
        }

        private void textBoxGraphics_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBoxGraphics.Text) <= 1000 && Convert.ToInt32(textBoxGraphics.Text) > 0)
                    trackBarGraphics.Value = Convert.ToInt32(textBoxGraphics.Text);
                else
                {
                    if (Convert.ToInt32(textBoxGraphics.Text) <= 0)
                        textBoxGraphics.Text = "1";
                    if (Convert.ToInt32(textBoxGraphics.Text) > 1000)
                        textBoxGraphics.Text = "1000";
                }
            }
            catch
            {

            }
        }

        private void textBoxFont_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBoxFont.Text) <= 9 && Convert.ToInt32(textBoxFont.Text) >= 7)
                    trackBarFont.Value = Convert.ToInt32(textBoxFont.Text);
                else
                {
                    if (Convert.ToInt32(textBoxFont.Text) < 7)
                        textBoxFont.Text = "7";
                    if (Convert.ToInt32(textBoxFont.Text) > 9)
                        textBoxFont.Text = "9";
                }
            }
            catch
            {

            }
        }
    }
}
