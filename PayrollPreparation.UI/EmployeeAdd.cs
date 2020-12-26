using PayrollPreparation.BL;
using PayrollPreparation.BL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PayrollPreparation.UI
{
    public partial class EmployeeAdd : Form
    {
        public Employee Employee { get; set; }
        public List<Kindred> Kindreds { get; set; }

        public string Photo { get; set; }

        public EmployeeAdd()
        {
            InitializeComponent();
            Employee = new Employee();
            Kindreds = new List<Kindred>();
        }

        public EmployeeAdd(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            Kindreds = employee.Kindreds.ToList();
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            FillData();
            UpdateKindred();
        }

        private void FillData()
        {
            using (var context = new PayrollContext())
            {
                bunifuDropdown1.Items.Clear();
                bunifuDropdown2.Items.Clear();
                bunifuDropdown3.Items.Clear();
                bunifuDropdown4.Items.Clear();
                bunifuDropdown5.Items.Clear();

                bunifuDropdown1.Items.AddRange(context.Positions.Select(i => i.PositionName).OrderBy(i => i).ToArray());
                bunifuDropdown2.Items.AddRange(context.TariffScales.Select(i => i.TariffRate.ToString()).OrderBy(i => i).ToArray());
                bunifuDropdown3.Items.AddRange(new string[] { "AB", "BM", "HB", "KH", "MP", "MC", "KB", "PP", "SP" });
                bunifuDropdown4.Items.AddRange(context.Educations.Select(i => i.EducationName).OrderBy(i => i).ToArray());
                bunifuDropdown5.Items.AddRange(new string[] { "Мужской", "Женский" });
            }
        }



        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox2.Text) ||
               String.IsNullOrWhiteSpace(bunifuCustomTextbox3.Text) ||
               String.IsNullOrWhiteSpace(bunifuCustomTextbox4.Text) ||
               String.IsNullOrWhiteSpace(bunifuDatePicker1.Text) ||
                   String.IsNullOrWhiteSpace(bunifuDatePicker2.Text) ||
                       String.IsNullOrWhiteSpace(bunifuDatePicker3.Text) ||
                           String.IsNullOrWhiteSpace(bunifuDatePicker4.Text) ||
                                    String.IsNullOrWhiteSpace(bunifuDropdown1.Text) ||
                                       String.IsNullOrWhiteSpace(bunifuDropdown2.Text) ||
                                          String.IsNullOrWhiteSpace(bunifuDropdown3.Text) ||
                                             String.IsNullOrWhiteSpace(bunifuDropdown4.Text) ||
                                                String.IsNullOrWhiteSpace(bunifuDropdown5.Text) ||
                                                         String.IsNullOrWhiteSpace(bunifuCustomTextbox18.Text) ||
                                                                  String.IsNullOrWhiteSpace(bunifuCustomTextbox19.Text) ||
                                                                           String.IsNullOrWhiteSpace(bunifuCustomTextbox1.Text) ||
                                                                                      String.IsNullOrWhiteSpace(Photo) ||
                                                                                    String.IsNullOrWhiteSpace(bunifuCustomTextbox5.Text))

                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                using (var context = new PayrollContext())
                {
                    int tariff = Convert.ToInt32(bunifuDropdown2.Text);
                    Education education = context.Educations.SingleOrDefault(i => i.EducationName == (bunifuDropdown4.Text));
                    Position position = context.Positions.SingleOrDefault(i => i.PositionName == (bunifuDropdown1.Text));
                    TariffScale tariffScale = context.TariffScales.SingleOrDefault(i => i.TariffRate == tariff);

                    Employee.SurName = bunifuCustomTextbox2.Text;
                    Employee.Name = bunifuCustomTextbox3.Text;
                    Employee.MiddleName = bunifuCustomTextbox4.Text;
                    Employee.Birthday = bunifuDatePicker1.Value.Date;
                    Employee.Sex = bunifuDropdown5.Text;
                    Employee.Address = bunifuCustomTextbox19.Text;
                    Employee.Photo = Photo; 
                    Employee.Phone = bunifuCustomTextbox18.Text;
                    Employee.DateOfHiring = bunifuDatePicker2.Value.Date;
                    Employee.SickOfChaes = bunifuCheckBox1.Checked ? "Yes" : "No";
                    Employee.LiquidatorChaes = bunifuCheckBox2.Checked ? "Yes" : "No";
                    Employee.Hero = bunifuCheckBox3.Checked ? "Yes" : "No";
                    Employee.GPW = bunifuCheckBox4.Checked ? "Yes" : "No";
                    Employee.Invalid = bunifuCheckBox5.Checked ? "Yes" : "No";
                    Employee.PassportCode = bunifuDropdown3.Text;
                    Employee.PassportNumber = bunifuCustomTextbox1.Text;
                    Employee.PassportDateFrom = bunifuDatePicker3.Value.Date;
                    Employee.PassportDateTo = bunifuDatePicker4.Value.Date;
                    Employee.PassportGave = bunifuCustomTextbox5.Text;
                    Employee.PositionId = position.PositionId;
                    Employee.EducationId = education.EducationId;
                    Employee.TariffScaleId = tariffScale.TariffScaleId;

                    if (Kindreds != null)
                    {
                        foreach (Kindred kindred in Kindreds)
                        {
                            kindred.Employee = Employee;
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            KindredAdd kindredAdd = new KindredAdd();

            if (kindredAdd.ShowDialog() == DialogResult.OK)
            {
                if (kindredAdd.Kindred != null)
                {
                    Kindreds.Add(kindredAdd.Kindred);
                    MessageBox.Show("Родственник успешно добавлен!", "Родственник добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateKindred();
                    bunifuCustomDataGrid3.Rows[bunifuCustomDataGrid3.Rows.Count - 1].Selected = true;
                }
            }

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            TariffScaleAdd tariffScaleAdd = new TariffScaleAdd();

            if (tariffScaleAdd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Тарифный разряд успешно добавлен!", "Тарифный разряд добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            EducationAdd educationAdd = new EducationAdd();

            if (educationAdd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Образование успешно добавлено!", "Образование добавлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            PositionAdd positionAdd = new PositionAdd();

            if (positionAdd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Должность успешно добавлена!", "Должность добавлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillData();
            }
        }

        private void UpdateKindred()
        {
            bunifuCustomDataGrid3.Rows.Clear();
            bunifuCustomDataGrid3.Columns.Clear();

            bunifuCustomDataGrid3.Columns.Add("FIO", "ФИО");

            foreach (Kindred kindred in Kindreds)
            {
                bunifuCustomDataGrid3.Rows.Add($"{kindred.SurName} {kindred.Name} {kindred.MiddleName}");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Photo = openFileDialog1.SafeFileName;
                pictureBox2.Image = Image.FromFile(".//Photos//" + Photo);
            }
        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
