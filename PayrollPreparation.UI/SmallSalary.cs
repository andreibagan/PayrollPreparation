using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PropertiesBL = PayrollPreparation.BL.Properties;

namespace PayrollPreparation.UI
{
    public partial class SmallSalary : Form
    {
        public SmallSalary()
        {
            InitializeComponent();
            bunifuCustomTextbox22.Text = PropertiesBL.Settings.Default.SmallSalaryValue.ToString();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox22.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                PropertiesBL.Settings.Default.SmallSalaryValue = Convert.ToInt32(bunifuCustomTextbox22.Text);
                PropertiesBL.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCustomTextbox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
