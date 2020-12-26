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
    public partial class KindredAdd : Form
    {
        public Kindred Kindred { get; set; }

        public KindredAdd()
        {
            InitializeComponent();
            Kindred = new Kindred();
        }

        private void KindredAdd_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text) ||
               String.IsNullOrWhiteSpace(bunifuCustomTextbox3.Text) ||
               String.IsNullOrWhiteSpace(bunifuCustomTextbox4.Text) ||
               String.IsNullOrWhiteSpace(bunifuDatePicker1.Text) ||
               String.IsNullOrWhiteSpace(bunifuDropdown2.Text) ||
               String.IsNullOrWhiteSpace(bunifuDropdown1.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                Kindred.SurName = bunifuCustomTextbox2.Text;
                Kindred.Name = bunifuCustomTextbox3.Text;
                Kindred.MiddleName = bunifuCustomTextbox4.Text;
                Kindred.Birthday = bunifuDatePicker1.Value.Date;
                Kindred.Sex = bunifuDropdown2.Text;
                Kindred.Kinsfolk = bunifuDropdown1.Text;
                Kindred.Invalid = bunifuCheckBox2.Checked ? "Yes" : "No";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FillComboBoxes()
        {
            bunifuDropdown2.Items.AddRange(new object[] { "Мужской", "Женский" });
            bunifuDropdown1.Items.AddRange(new object[] { "Сын", "Дочь" });
        }
    }
}
