using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesBL = PayrollPreparation.BL.Properties;
using System.Windows.Forms;

namespace PayrollPreparation.UI
{
    public partial class Stage : Form
    {
        public Stage()
        {
            InitializeComponent();
            bunifuCustomTextbox14.Text = PropertiesBL.Settings.Default.FromOneToFive.ToString();
            bunifuCustomTextbox15.Text = PropertiesBL.Settings.Default.FromFiveToTen.ToString();
            bunifuCustomTextbox16.Text = PropertiesBL.Settings.Default.FromTenToFifteen.ToString();
            bunifuCustomTextbox17.Text = PropertiesBL.Settings.Default.MoreThanFifteen.ToString();
        }
        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox14.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox15.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox16.Text) ||
                String.IsNullOrWhiteSpace(bunifuCustomTextbox17.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                PropertiesBL.Settings.Default.FromOneToFive = Convert.ToInt32(bunifuCustomTextbox14.Text);
                PropertiesBL.Settings.Default.FromFiveToTen = Convert.ToInt32(bunifuCustomTextbox15.Text);
                PropertiesBL.Settings.Default.FromTenToFifteen = Convert.ToInt32(bunifuCustomTextbox16.Text);
                PropertiesBL.Settings.Default.MoreThanFifteen = Convert.ToInt32(bunifuCustomTextbox17.Text);
                PropertiesBL.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void bunifuCustomTextbox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

    }
}
