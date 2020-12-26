using PayrollPreparation.BL;
using PayrollPreparation.BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollPreparation.UI
{
    public partial class EmployeAbout : Form
    {
        public Employee Employee { get; set; }
        public PayrollContext PayrollContext { get; set; }

        public EmployeAbout(int id)
        {
            InitializeComponent();
            PayrollContext = new PayrollContext();
            Employee = PayrollContext.Employees.Find(id);
        }

        private void EmployeAbout_Load(object sender, EventArgs e)
        {
            UpdateEmployee();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@".\Cards\Личная карточка №" + bunifuCustomTextbox13.Text + " " + bunifuCustomTextbox1.Text + " " + bunifuCustomTextbox2.Text + " " + bunifuCustomTextbox3.Text + ".html");
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<title>Личная карточка работника №" + bunifuCustomTextbox13.Text + "</title>");
            sw.WriteLine("<meta charset=\"UTF-8\">");
            sw.WriteLine("<meta name = \"viewport\" content = \"width = device - width, initial - scale = 1\">");
            sw.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"Style.css\" >");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<div class=\"card\">");
            sw.WriteLine("<img src=\"" + "..//..//Photos//" + Employee.Photo + "\" alt=\"Фотография работника\" style=\"width: 100% \">");
            sw.WriteLine("<div class=\"container\">");
            sw.WriteLine("<h4><b>" + bunifuCustomTextbox1.Text + " " + bunifuCustomTextbox2.Text + " " + bunifuCustomTextbox3.Text + ", " + bunifuCustomTextbox5.Text + " лет </b>| <i class=\"positionEmp\">" + bunifuCustomTextbox10.Text + "</i></h4><br>");
            sw.WriteLine("<p><b><i>Основная информация:</i></b></p>");
            sw.WriteLine("<p>Дата рождения: <i>" + bunifuCustomTextbox6.Text + "</i></p>");
            sw.WriteLine("<p>Пол: <i>" + bunifuCustomTextbox4.Text + "</i></p>");
            sw.WriteLine("<p>Адрес: <i>" + bunifuCustomTextbox9.Text + "</i></p>");
            sw.WriteLine("<p>Номер телефона: <i>" + bunifuCustomTextbox8.Text + "</i></p>");
            sw.WriteLine("<p>Образование: <i>" + bunifuCustomTextbox7.Text + "</i></p><br>");
            sw.WriteLine("<p><b><i>Дополнительная информация:</b></i></p>");
            sw.WriteLine("<p>Разряд: <i>" + bunifuCustomTextbox12.Text + "</i></p>");
            sw.WriteLine("<p>Тарифный коэффициент: <i>" + bunifuCustomTextbox11.Text + "</i></p>");
            sw.WriteLine("<p>Табельный номер: <i>" + bunifuCustomTextbox13.Text + "</i></p>");
            sw.WriteLine("<hr>");
            sw.WriteLine("<p>Дата приёма на работу: <i>" + bunifuCustomTextbox15.Text + "</i></p>");
            sw.WriteLine("<p>Стаж работы: <i>" + bunifuCustomTextbox14.Text + "</i></p><br>");
            sw.WriteLine("</div>");
            sw.WriteLine("</div>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html> ");
            sw.Close();
            Process.Start(@".\Cards\Личная карточка №" + bunifuCustomTextbox13.Text + " " + bunifuCustomTextbox1.Text + " " + bunifuCustomTextbox2.Text + " " + bunifuCustomTextbox3.Text + ".html");
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            EmployeeEdit employeeEdit = new EmployeeEdit();

            Education education = PayrollContext.Educations.FirstOrDefault(i => i.EducationId == Employee.EducationId);
            Position position = PayrollContext.Positions.FirstOrDefault(i => i.PositionId == Employee.PositionId);
            TariffScale tariffScale = PayrollContext.TariffScales.FirstOrDefault(i => i.TariffScaleId == Employee.TariffScaleId);

            employeeEdit.Employee = Employee;

            employeeEdit.bunifuDropdown1.Items.AddRange(PayrollContext.Positions.Select(i => i.PositionName).OrderBy(i => i).ToArray());
            employeeEdit.bunifuDropdown2.Items.AddRange(PayrollContext.TariffScales.Select(i => i.TariffRate.ToString()).OrderBy(i => i).ToArray());
            employeeEdit.bunifuDropdown3.Items.AddRange(new string[] { "AB", "BM", "HB", "KH", "MP", "MC", "KB", "PP", "SP" });
            employeeEdit.bunifuDropdown4.Items.AddRange(PayrollContext.Educations.Select(i => i.EducationName).OrderBy(i => i).ToArray());
            employeeEdit.bunifuDropdown5.Items.AddRange(new string[] { "Мужской", "Женский" });

            employeeEdit.bunifuCustomTextbox2.Text = Employee.SurName;
            employeeEdit.bunifuCustomTextbox3.Text = Employee.Name;
            employeeEdit.bunifuCustomTextbox4.Text = Employee.MiddleName;
            employeeEdit.bunifuDatePicker1.Value = Employee.Birthday.Date;
            employeeEdit.bunifuDropdown5.Text = Employee.Sex;
            employeeEdit.bunifuCustomTextbox19.Text = Employee.Address;
            employeeEdit.pictureBox2.Image = Image.FromFile(".//Photos//" + Employee.Photo);
            employeeEdit.openFileDialog1.FileName = Employee.Photo;
            employeeEdit.bunifuCustomTextbox18.Text = Employee.Phone;
            employeeEdit.bunifuDatePicker2.Value = Employee.DateOfHiring.Date;
            employeeEdit.bunifuCheckBox1.Checked = Employee.SickOfChaes == "Yes" ? true : false;
            employeeEdit.bunifuCheckBox2.Checked = Employee.LiquidatorChaes == "Yes" ? true : false;
            employeeEdit.bunifuCheckBox3.Checked = Employee.Hero == "Yes" ? true : false;
            employeeEdit.bunifuCheckBox4.Checked = Employee.GPW == "Yes" ? true : false;
            employeeEdit.bunifuCheckBox5.Checked = Employee.Invalid == "Yes" ? true : false;
            employeeEdit.bunifuDropdown3.Text = Employee.PassportCode;
            employeeEdit.bunifuCustomTextbox1.Text = Employee.PassportNumber;
            employeeEdit.bunifuDatePicker3.Value = Employee.PassportDateFrom.Date;
            employeeEdit.bunifuDatePicker4.Value = Employee.PassportDateTo.Date;
            employeeEdit.bunifuCustomTextbox5.Text = Employee.PassportGave;
            employeeEdit.bunifuDropdown1.Text = position.PositionName;
            employeeEdit.bunifuDropdown4.Text = education.EducationName;
            employeeEdit.bunifuDropdown2.Text = tariffScale.TariffRate.ToString();


            employeeEdit.bunifuCustomDataGrid3.Columns.Add("FIO", "ФИО");

            foreach (var kindred in Employee.Kindreds)
            {
                employeeEdit.bunifuCustomDataGrid3.Rows.Add($"{kindred.SurName} {kindred.Name} {kindred.MiddleName}");
            }


            if (employeeEdit.ShowDialog() == DialogResult.OK)
            {
                if (employeeEdit.Kindreds != null)
                {
                    PayrollContext.Kindreds.AddRange(employeeEdit.Kindreds);
                }
                if (String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox2.Text) ||
           String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox3.Text) ||
           String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox4.Text) ||
           String.IsNullOrWhiteSpace(employeeEdit.bunifuDatePicker1.Text) ||
               String.IsNullOrWhiteSpace(employeeEdit.bunifuDatePicker2.Text) ||
                   String.IsNullOrWhiteSpace(employeeEdit.bunifuDatePicker3.Text) ||
                       String.IsNullOrWhiteSpace(employeeEdit.bunifuDatePicker4.Text) ||
                                String.IsNullOrWhiteSpace(employeeEdit.bunifuDropdown1.Text) ||
                                   String.IsNullOrWhiteSpace(employeeEdit.bunifuDropdown2.Text) ||
                                      String.IsNullOrWhiteSpace(employeeEdit.bunifuDropdown3.Text) ||
                                         String.IsNullOrWhiteSpace(employeeEdit.bunifuDropdown4.Text) ||
                                            String.IsNullOrWhiteSpace(employeeEdit.bunifuDropdown5.Text) ||
                                                     String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox18.Text) ||
                                                              String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox19.Text) ||
                                                                       String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox1.Text) ||
                                                                                  String.IsNullOrWhiteSpace(employeeEdit.openFileDialog1.FileName) ||
                                                                                String.IsNullOrWhiteSpace(employeeEdit.bunifuCustomTextbox5.Text))
                    MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    int tariff = Convert.ToInt32(employeeEdit.bunifuDropdown2.Text);


                    Employee.SurName = employeeEdit.bunifuCustomTextbox2.Text;
                    Employee.Name = employeeEdit.bunifuCustomTextbox3.Text;
                    Employee.MiddleName = employeeEdit.bunifuCustomTextbox4.Text;
                    Employee.Birthday = employeeEdit.bunifuDatePicker1.Value.Date;
                    Employee.Sex = employeeEdit.bunifuDropdown5.Text;
                    Employee.Address = employeeEdit.bunifuCustomTextbox19.Text;
                    Employee.Photo = employeeEdit.openFileDialog1.SafeFileName;
                    Employee.Phone = employeeEdit.bunifuCustomTextbox18.Text;
                    Employee.DateOfHiring = employeeEdit.bunifuDatePicker2.Value.Date;
                    Employee.SickOfChaes = employeeEdit.bunifuCheckBox1.Checked ? "Yes" : "No";
                    Employee.LiquidatorChaes = employeeEdit.bunifuCheckBox2.Checked ? "Yes" : "No";
                    Employee.Hero = employeeEdit.bunifuCheckBox3.Checked ? "Yes" : "No";
                    Employee.GPW = employeeEdit.bunifuCheckBox4.Checked ? "Yes" : "No";
                    Employee.Invalid = employeeEdit.bunifuCheckBox5.Checked ? "Yes" : "No";
                    Employee.PassportCode = employeeEdit.bunifuDropdown3.Text;
                    Employee.PassportNumber = employeeEdit.bunifuCustomTextbox1.Text;
                    Employee.PassportDateFrom = employeeEdit.bunifuDatePicker3.Value.Date;
                    Employee.PassportDateTo = employeeEdit.bunifuDatePicker4.Value.Date;
                    Employee.PassportGave = employeeEdit.bunifuCustomTextbox5.Text;
                    Employee.PositionId = PayrollContext.Positions.FirstOrDefault(i => i.PositionName == employeeEdit.bunifuDropdown1.Text).PositionId;
                    Employee.EducationId = PayrollContext.Educations.FirstOrDefault(i => i.EducationName == employeeEdit.bunifuDropdown4.Text).EducationId;
                    Employee.TariffScaleId = PayrollContext.TariffScales.FirstOrDefault(i => i.TariffRate == tariff).TariffScaleId;

                    PayrollContext.SaveChanges();
                    UpdateEmployee();
                    MessageBox.Show("Работник успешно изменен!", "Работник изменен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateEmployee()
        {
            bunifuCustomDataGrid1.Columns.Clear();
            bunifuCustomDataGrid1.Rows.Clear();

            bunifuCustomTextbox1.Text = Employee.SurName;
            bunifuCustomTextbox2.Text = Employee.Name;
            bunifuCustomTextbox3.Text = Employee.MiddleName;
            bunifuCustomTextbox4.Text = Employee.Sex;
            bunifuCustomTextbox5.Text = (DateTime.Now.Year - Employee.Birthday.Year).ToString();
            bunifuCustomTextbox6.Text = Employee.Birthday.ToShortDateString();
            bunifuCustomTextbox7.Text = Employee.Education.EducationName;
            bunifuCustomTextbox8.Text = Employee.Phone;
            bunifuCustomTextbox9.Text = Employee.Address;
            bunifuCustomTextbox10.Text = Employee.Position.PositionName;
            bunifuCustomTextbox11.Text = Employee.TariffScale.Сoefficient.ToString();
            bunifuCustomTextbox12.Text = Employee.TariffScale.TariffRate.ToString();
            bunifuCustomTextbox13.Text = Employee.EmployeeId.ToString();
            bunifuCustomTextbox14.Text = (DateTime.Now.Year - Employee.DateOfHiring.Year).ToString();
            bunifuCustomTextbox15.Text = Employee.DateOfHiring.ToShortDateString();
            bunifuCustomTextbox16.Text = Employee.PassportCode;
            bunifuCustomTextbox17.Text = Employee.PassportGave;
            bunifuCustomTextbox18.Text = Employee.PassportDateTo.ToShortDateString();
            bunifuCustomTextbox19.Text = Employee.PassportDateFrom.ToShortDateString();
            bunifuCustomTextbox20.Text = Employee.PassportNumber;
            pictureBox2.Image = Image.FromFile(".//Photos//" + Employee.Photo);
            bunifuCheckBox1.Checked = Employee.SickOfChaes == "Yes" ? true : false;
            bunifuCheckBox2.Checked = Employee.LiquidatorChaes == "Yes" ? true : false;
            bunifuCheckBox3.Checked = Employee.Hero == "Yes" ? true : false;
            bunifuCheckBox4.Checked = Employee.GPW == "Yes" ? true : false;
            bunifuCheckBox5.Checked = Employee.Invalid == "Yes" ? true : false;

            bunifuCustomDataGrid1.Columns.Add("KindredId", "KindredId");
            bunifuCustomDataGrid1.Columns.Add("KindredSurName", "Фамилия");
            bunifuCustomDataGrid1.Columns.Add("KindredName", "Имя");
            bunifuCustomDataGrid1.Columns.Add("KindredMiddleName", "Отчество");
            bunifuCustomDataGrid1.Columns.Add("KindredBirthday", "Дата рождения");
            bunifuCustomDataGrid1.Columns.Add("KindredYearOld", "Возраст");
            bunifuCustomDataGrid1.Columns.Add("KindredSex", "Пол");
            bunifuCustomDataGrid1.Columns.Add("KindredFolk", "Родство");

            bunifuCustomDataGrid1.Columns[0].Visible = false;

            foreach (Kindred kindred in Employee.Kindreds)
            {
                bunifuCustomDataGrid1.Rows.Add(kindred.KindredId, kindred.SurName, kindred.Name, kindred.MiddleName, kindred.Birthday, DateTime.Now.Year - kindred.Birthday.Year, kindred.Sex, kindred.Kinsfolk);
            }
        }
    }
}
