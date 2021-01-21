using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        Double hasil = 0;
        string operation = "";
        bool value = false;
        String firstnumber, secondnumber;

        public Form1()
        {
            InitializeComponent();
        }

        private void Numbers(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (textBoxDisplay.Text == "0" || (value))
            {
                textBoxDisplay.Text = "";
                value = false;
            }
            if (btn.Text == ".")
            {
                if (!textBoxDisplay.Text.Contains("."))
                {
                    textBoxDisplay.Text = textBoxDisplay.Text + btn.Text;
                }
            }
            else
            {
                textBoxDisplay.Text = textBoxDisplay.Text + btn.Text;
            }
        }

        private void Operators_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (hasil != 0)
            {
                value = true;
                operation = btn.Text;
                labelShow.Text = hasil + " " + operation;
            }
            else
            {
                operation = btn.Text;
                hasil = Double.Parse(textBoxDisplay.Text);
                value = true;
                labelShow.Text = hasil + " " + operation;
            }
            firstnumber = labelShow.Text;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "0";
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = "0";
            hasil = 0;
            labelShow.Text = "";
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        { //setelah dapat hasil, kalau mau hitung  dengan angka baru harus di clear 
            secondnumber = textBoxDisplay.Text;
            labelShow.Text = "";
            switch (operation)
            {
                case "÷":
                    textBoxDisplay.Text = (hasil / Double.Parse(textBoxDisplay.Text)).ToString();
                    break;
                case "x":
                    textBoxDisplay.Text = (hasil * Double.Parse(textBoxDisplay.Text)).ToString();
                    break;
                case "-":
                    textBoxDisplay.Text = (hasil - Double.Parse(textBoxDisplay.Text)).ToString();
                    break;
                case "+":
                    textBoxDisplay.Text = (hasil + Double.Parse(textBoxDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            hasil = Double.Parse(textBoxDisplay.Text);
            operation = "";

            buttonClearHistory.Visible = true;
            richTextBoxHistory.AppendText(firstnumber + "  " + secondnumber + "   =" + "\n");
            richTextBoxHistory.AppendText("\t" + textBoxDisplay.Text + "\n\n");
            labelNoHistory.Text = "";
        }

        private void buttonClearHistory_Click(object sender, EventArgs e)
        {
            if (richTextBoxHistory.Visible == true)
            {
                richTextBoxHistory.Clear();
                if (labelNoHistory.Text == "")
                {
                    labelNoHistory.Text = "There's no history yet";
                }
                buttonClearHistory.Visible = false;
                richTextBoxHistory.ScrollBars = 0;
            }
            else  if (richTextBoxMemory.Visible == true)
            {
                richTextBoxMemory.Clear();
                if (labelNoMemory.Text == "")
                {
                    labelNoMemory.Text = "There's nothing saved in memory";
                }
                buttonClearHistory.Visible = false;
                richTextBoxMemory.ScrollBars = 0;
            }
        }

        private void buttonPositifNegatif_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.StartsWith("-"))
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Substring(1);
            }
            else if (!string.IsNullOrEmpty(textBoxDisplay.Text) && Double.Parse(textBoxDisplay.Text) != 0)
            {
                textBoxDisplay.Text = "-" + textBoxDisplay.Text;
            }
        }

        private void buttonPersen_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = (Double.Parse(textBoxDisplay.Text) / 100).ToString();
        }

        private void buttonSatuPerX_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = (1 / (Double.Parse(textBoxDisplay.Text))).ToString();
        }

        private void buttonKuadrat_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = (Double.Parse(textBoxDisplay.Text) * Double.Parse(textBoxDisplay.Text)).ToString();
        }

        private void buttonAkar_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text = (Math.Sqrt(Double.Parse(textBoxDisplay.Text))).ToString();
        }

        private void labelMemory_Click(object sender, EventArgs e)
        {
            labelNoMemory.Visible = true;
            labelNoHistory.Visible = false;
            richTextBoxHistory.Visible = false;
            richTextBoxMemory.Visible = true;
            if (richTextBoxMemory.Lines.Length != 0)
            {
                labelNoMemory.Text = " ";
            }
        }

        private void labelHistory_Click(object sender, EventArgs e)
        {
            labelNoMemory.Visible = false;
            labelNoHistory.Visible = true;
            richTextBoxHistory.Visible = true;
            richTextBoxMemory.Visible = false;
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            buttonMC.Enabled = true;
            buttonMR.Enabled = true;
            richTextBoxMemory.AppendText(Double.Parse(hasil.ToString()) + "\n");
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            richTextBoxMemory.Clear();
            buttonMR.Enabled = false;
            buttonMC.Enabled = false;
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            richTextBoxMemory.Text += Double.Parse(richTextBoxMemory.Text);
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text = textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
            }

            if (textBoxDisplay.Text == "")
            {
                textBoxDisplay.Text = "0";
            }
        }
    }
}
