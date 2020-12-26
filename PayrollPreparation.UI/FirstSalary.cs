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
    public partial class FirstSalary : Form
    {
        public FirstSalary()
        {
            InitializeComponent();

            bunifuCustomTextbox25.Text = PropertiesBL.Settings.Default.Salary.ToString();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox25.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                PropertiesBL.Settings.Default.Salary = Convert.ToInt32(bunifuCustomTextbox25.Text);
                PropertiesBL.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCustomTextbox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
