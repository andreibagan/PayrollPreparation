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
    public partial class EducationAdd : Form
    {
        public Education Education { get; set; }

        public EducationAdd()
        {
            InitializeComponent();
            Education = new Education();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            using (var context = new PayrollContext())
            {
                if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text))
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    Education.EducationName = bunifuCustomTextbox2.Text;
                    context.Educations.Add(Education);
                    context.SaveChanges();
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
