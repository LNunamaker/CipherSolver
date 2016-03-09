using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CipherSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            string cipher = Regex.Replace(ciphersBox.SelectedItem.ToString(), @"\s+", "");
            string cipherText = inputText.Text;
            int shift = Convert.ToInt32(shiftText.Text);
            string key = keyText.Text.ToUpper();

            Type cipherType = Type.GetType("CipherSolver."+cipher);
            MethodInfo encodeMethod = cipherType.GetMethod("encode");
            object[] parameters = new object[] {new object[] {cipherText,shift,key}};
            outputText.Text = encodeMethod.Invoke(null, parameters).ToString();
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            string cipher = Regex.Replace(ciphersBox.SelectedItem.ToString(), @"\s+", "");
            string cipherText = inputText.Text;
            int shift = Convert.ToInt32(shiftText.Text);
            string key = keyText.Text.ToUpper();

            Type cipherType = Type.GetType("CipherSolver." + cipher);
            MethodInfo decodeMethod = cipherType.GetMethod("decode");
            object[] parameters = new object[] { new object[] { cipherText, shift, key } };
            outputText.Text = decodeMethod.Invoke(null, parameters).ToString();
        }

        private void shiftText_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(shiftText.Text, out n))
            {
                shiftText.Text = "0";
            }
        }
    }
}
