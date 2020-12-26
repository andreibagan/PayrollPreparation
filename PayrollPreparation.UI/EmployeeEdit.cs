using PayrollPreparation.BL;
using PayrollPreparation.BL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PayrollPreparation.UI
{
    public partial class EmployeeEdit : Form
    {
        public List<Kindred> Kindreds { get; set; }
        public Employee Employee { get; set; }

        public EmployeeEdit()
        {
            InitializeComponent();
            Kindreds = new List<Kindred>();
            Employee = new Employee();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (var item in Kindreds)
            {
                item.Employee = Employee;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(".//Photos//" + openFileDialog1.SafeFileName);
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            //using (PayrollContext context = new PayrollContext())
           // {
                KindredAdd kindredAdd = new KindredAdd();

                if (kindredAdd.ShowDialog() == DialogResult.OK)
                {
                    if (kindredAdd.Kindred != null)
                    {
                        Kindreds.Add(kindredAdd.Kindred);
                        MessageBox.Show("Родственник успешно добавлен!", "Родственник добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateKindred();
                    }
                }
            //}
        }

        private void UpdateKindred()
        {
            using (PayrollContext context = new PayrollContext())
            {
                bunifuCustomDataGrid3.Rows.Clear();
                bunifuCustomDataGrid3.Columns.Clear();

                bunifuCustomDataGrid3.Columns.Add("FIO", "ФИО");

                foreach (Kindred kindred in Kindreds)
                {
                    bunifuCustomDataGrid3.Rows.Add($"{kindred.SurName} {kindred.Name} {kindred.MiddleName}");
                }

                foreach (Kindred kindred in context.Kindreds.Where(i => i.EmployeeId == Employee.EmployeeId))
                {
                    bunifuCustomDataGrid3.Rows.Add($"{kindred.SurName} {kindred.Name} {kindred.MiddleName}");
                }
            }     
        }
    }
}
