using PayrollPreparation.BL;
using PayrollPreparation.BL.Models;
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
    public partial class TariffScaleAdd : Form
    {
        public TariffScale TariffScale { get; set; }

        public TariffScaleAdd()
        {
            InitializeComponent();
            TariffScale = new TariffScale();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            using (var context = new PayrollContext())
            {
                if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text) ||
               String.IsNullOrWhiteSpace(bunifuCustomTextbox3.Text))
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    int Tariffr = (Convert.ToInt32(bunifuCustomTextbox2.Text));
                    if (context.TariffScales.SingleOrDefault(i => i.TariffRate == Tariffr) == null)
                    {
                        TariffScale.TariffRate = Convert.ToInt32(bunifuCustomTextbox2.Text);
                        TariffScale.Сoefficient = Convert.ToInt32(bunifuCustomTextbox3.Text);
                        context.TariffScales.Add(TariffScale);
                        context.SaveChanges();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Возможно похожая запись уже есть в базе данных", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                

            }
        }
    }
}
