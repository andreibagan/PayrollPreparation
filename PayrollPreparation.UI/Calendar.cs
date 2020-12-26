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
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
            bunifuCustomTextbox2.Text = PropertiesBL.Settings.Default.January.ToString();
            bunifuCustomTextbox3.Text = PropertiesBL.Settings.Default.February.ToString();
            bunifuCustomTextbox4.Text = PropertiesBL.Settings.Default.March.ToString();
            bunifuCustomTextbox5.Text = PropertiesBL.Settings.Default.April.ToString();
            bunifuCustomTextbox6.Text = PropertiesBL.Settings.Default.May.ToString();
            bunifuCustomTextbox7.Text = PropertiesBL.Settings.Default.June.ToString();
            bunifuCustomTextbox8.Text = PropertiesBL.Settings.Default.July.ToString();
            bunifuCustomTextbox9.Text = PropertiesBL.Settings.Default.August.ToString();
            bunifuCustomTextbox10.Text = PropertiesBL.Settings.Default.September.ToString();
            bunifuCustomTextbox11.Text = PropertiesBL.Settings.Default.October.ToString();
            bunifuCustomTextbox12.Text = PropertiesBL.Settings.Default.November.ToString();
            bunifuCustomTextbox13.Text = PropertiesBL.Settings.Default.December.ToString();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox3.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox4.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox5.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox6.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox7.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox8.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox9.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox10.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox11.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox12.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox13.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                PropertiesBL.Settings.Default.January = Convert.ToInt32(bunifuCustomTextbox2.Text);
                PropertiesBL.Settings.Default.February = Convert.ToInt32(bunifuCustomTextbox3.Text);
                PropertiesBL.Settings.Default.March = Convert.ToInt32(bunifuCustomTextbox4.Text);
                PropertiesBL.Settings.Default.April = Convert.ToInt32(bunifuCustomTextbox5.Text);
                PropertiesBL.Settings.Default.May = Convert.ToInt32(bunifuCustomTextbox6.Text);
                PropertiesBL.Settings.Default.June = Convert.ToInt32(bunifuCustomTextbox7.Text);
                PropertiesBL.Settings.Default.July = Convert.ToInt32(bunifuCustomTextbox8.Text);
                PropertiesBL.Settings.Default.August = Convert.ToInt32(bunifuCustomTextbox9.Text);
                PropertiesBL.Settings.Default.September = Convert.ToInt32(bunifuCustomTextbox10.Text);
                PropertiesBL.Settings.Default.October = Convert.ToInt32(bunifuCustomTextbox11.Text);
                PropertiesBL.Settings.Default.November = Convert.ToInt32(bunifuCustomTextbox12.Text);
                PropertiesBL.Settings.Default.December = Convert.ToInt32(bunifuCustomTextbox13.Text);
                PropertiesBL.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCustomTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
