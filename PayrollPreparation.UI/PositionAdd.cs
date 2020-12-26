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
    public partial class PositionAdd : Form
    {
        public Position Position { get; set; }

        public PositionAdd()
        {
            InitializeComponent();
            Position = new Position();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            using (var context = new PayrollContext())
            {
                if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text))
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Position.PositionName = bunifuCustomTextbox2.Text;
                    context.Positions.Add(Position);
                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
