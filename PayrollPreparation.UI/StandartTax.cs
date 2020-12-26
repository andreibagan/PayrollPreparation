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
    public partial class StandartTax : Form
    {
        public StandartTax()
        {
            InitializeComponent();
            bunifuCustomTextbox21.Text = PropertiesBL.Settings.Default.SmallSalary.ToString();
            bunifuCustomTextbox20.Text = PropertiesBL.Settings.Default.OneUnder18.ToString();
            bunifuCustomTextbox19.Text = PropertiesBL.Settings.Default.TwoAndMoreUnder18.ToString();
            bunifuCustomTextbox18.Text = PropertiesBL.Settings.Default.OtherCatagory.ToString();
        }

        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox21.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox20.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox19.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox18.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                PropertiesBL.Settings.Default.SmallSalary = Convert.ToInt32(bunifuCustomTextbox21.Text);
                PropertiesBL.Settings.Default.OneUnder18 = Convert.ToInt32(bunifuCustomTextbox20.Text);
                PropertiesBL.Settings.Default.TwoAndMoreUnder18 = Convert.ToInt32(bunifuCustomTextbox19.Text);
                PropertiesBL.Settings.Default.OtherCatagory = Convert.ToInt32(bunifuCustomTextbox18.Text);
                PropertiesBL.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCustomTextbox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
