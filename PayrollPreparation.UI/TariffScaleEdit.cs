using PayrollPreparation.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollPreparation.UI
{
    public partial class TariffScaleEdit : Form
    {
        public TariffScale TariffScale { get; set; }
        public TariffScaleEdit()
        {
            InitializeComponent();
            TariffScale = new TariffScale();
        }

        private void TariffScaleEdit_Load(object sender, EventArgs e)
        {
            bunifuCustomTextbox25.Text = TariffScale.TariffRate.ToString();
            bunifuCustomTextbox1.Text = TariffScale.Сoefficient.ToString();
        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))
                e.Handled = true;
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox1.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                TariffScale.Сoefficient = Convert.ToInt32(bunifuCustomTextbox1.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
