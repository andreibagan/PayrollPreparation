using PayrollPreparation.BL;
using PayrollPreparation.BL.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SettingsBL = PayrollPreparation.BL.Properties;

namespace PayrollPreparation.UI
{
    public partial class Main : Form
    {
        PayrollContext DataBaseContext;
        public Main()
        {
            InitializeComponent();

            DataBaseContext = new PayrollContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Автоматизация расчётов по заработной плате с персоналом организации | " + Convert.ToString(DateTime.Now.ToLongDateString());
            FillSettings();
            UpdateTariffScale();
            UpdateEmployee();
            UpdateEmployeeFill();
            FillMonth(DateTime.Now.Year, Convert.ToInt32(DateTime.Now.Month.ToString("00")));
            FillMonths1(bunifuDropdown1);
            FillMonths2(bunifuDropdown4);
            FillYear1(bunifuDropdown2);
            FillYear2(bunifuDropdown4);
            FillYear2(bunifuDropdown5);
        
        }

        private void RefreshTableTime(int id, int month, int year)
        {
            var WorkingTimes = DataBaseContext.WorkingTimes.Where(i => i.EmployeeId == id && i.MonthId == month && i.Year == year).ToList();

            bunifuCustomDataGrid4.Rows.Clear();
            bunifuCustomDataGrid4.Rows.Add();

            for (int i = 1; i < bunifuCustomDataGrid4.ColumnCount; i++)
            {
                for (int j = 0; j < WorkingTimes.Count(); j++)
                {
                    if (i == WorkingTimes[j].Day)
                        bunifuCustomDataGrid4.Rows[0].Cells[i - 1].Value = WorkingTimes[j].Count;
                }
            }


            for (int i = 0; i < bunifuCustomDataGrid4.ColumnCount; i++)
            {

                switch (Convert.ToString(bunifuCustomDataGrid4.Rows[0].Cells[i].Value))
                {
                    case "": bunifuCustomDataGrid4.Rows[0].Cells[i].Style.BackColor = Color.White; break;
                    case "В": bunifuCustomDataGrid4.Rows[0].Cells[i].Style.BackColor = Color.Beige; break;
                    case "Б": bunifuCustomDataGrid4.Rows[0].Cells[i].Style.BackColor = Color.Pink; break;
                    case "О": bunifuCustomDataGrid4.Rows[0].Cells[i].Style.BackColor = Color.PowderBlue; break;
                    default: bunifuCustomDataGrid4.Rows[0].Cells[i].Style.BackColor = Color.PaleGreen; break;
                }
            }
        }

        private void FillSettings() // Заполняет настройки
        {
            bunifuCustomTextbox2.Text = SettingsBL.Settings.Default.January.ToString() + " часов";
            bunifuCustomTextbox3.Text = SettingsBL.Settings.Default.February.ToString() + " часов";
            bunifuCustomTextbox4.Text = SettingsBL.Settings.Default.March.ToString() + " часов";
            bunifuCustomTextbox5.Text = SettingsBL.Settings.Default.April.ToString() + " часов";
            bunifuCustomTextbox6.Text = SettingsBL.Settings.Default.May.ToString() + " часов";
            bunifuCustomTextbox7.Text = SettingsBL.Settings.Default.June.ToString() + " часов";
            bunifuCustomTextbox8.Text = SettingsBL.Settings.Default.July.ToString() + " часов";
            bunifuCustomTextbox9.Text = SettingsBL.Settings.Default.August.ToString() + " часов";
            bunifuCustomTextbox10.Text = SettingsBL.Settings.Default.September.ToString() + " часов";
            bunifuCustomTextbox11.Text = SettingsBL.Settings.Default.October.ToString() + " часов";
            bunifuCustomTextbox12.Text = SettingsBL.Settings.Default.November.ToString() + " часов";
            bunifuCustomTextbox13.Text = SettingsBL.Settings.Default.December.ToString() + " часов";
            bunifuCustomTextbox25.Text = SettingsBL.Settings.Default.Salary.ToString() + " руб.";
            bunifuCustomTextbox14.Text = SettingsBL.Settings.Default.FromOneToFive.ToString() + "%";
            bunifuCustomTextbox15.Text = SettingsBL.Settings.Default.FromFiveToTen.ToString() + "%";
            bunifuCustomTextbox16.Text = SettingsBL.Settings.Default.FromTenToFifteen.ToString() + "%";
            bunifuCustomTextbox17.Text = SettingsBL.Settings.Default.MoreThanFifteen.ToString() + "%";
            bunifuCustomTextbox21.Text = SettingsBL.Settings.Default.SmallSalary.ToString() + " руб.";
            bunifuCustomTextbox20.Text = SettingsBL.Settings.Default.OneUnder18.ToString() + " руб.";
            bunifuCustomTextbox19.Text = SettingsBL.Settings.Default.TwoAndMoreUnder18.ToString() + " руб.";
            bunifuCustomTextbox18.Text = SettingsBL.Settings.Default.OtherCatagory.ToString() + " руб.";
            bunifuCustomTextbox22.Text = SettingsBL.Settings.Default.SmallSalaryValue.ToString() + " руб.";
        }

        private void UpdateTariffScale()
        {
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuCustomDataGrid1.Columns.Clear();

            var TariffScales = DataBaseContext.TariffScales.ToList();
    
            for (int i = 0; i < TariffScales.Count(); i++)
            {
                bunifuCustomDataGrid1.Columns.Add(TariffScales[i].TariffRate.ToString(), TariffScales[i].TariffRate.ToString());
            }

            bunifuCustomDataGrid1.Rows.Add();

            for (int i = 0; i < TariffScales.Count(); i++)
            {
                bunifuCustomDataGrid1.Rows[0].Cells[i].Value = TariffScales[i].Сoefficient.ToString();
            }

        }

        private void UpdateEmployee()
        {
            bunifuCustomDataGrid2.Rows.Clear();
            bunifuCustomDataGrid2.Columns.Clear();

            bunifuCustomDataGrid2.Columns.Add("EmployeeId", "EmployeeId");
            bunifuCustomDataGrid2.Columns.Add("Surname", "Фамилия");
            bunifuCustomDataGrid2.Columns.Add("Name", "Имя");
            bunifuCustomDataGrid2.Columns.Add("Middlename", "Отчество");
            bunifuCustomDataGrid2.Columns.Add("YearOld", "Возраст");
            bunifuCustomDataGrid2.Columns.Add("Address", "Адрес");

            bunifuCustomDataGrid2.Columns[0].Visible = false;

            var Employees = DataBaseContext.Employees.ToList();

            foreach (Employee employee in Employees)
            {
                bunifuCustomDataGrid2.Rows.Add(employee.EmployeeId, employee.SurName, employee.Name, employee.MiddleName, (DateTime.Now.Year - employee.Birthday.Year), employee.Address);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 0;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 1;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 2;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 3;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SelectedIndex = 4;
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\Manual\ManualPayroll.html"))
            {
                Process.Start(@".\Manual\ManualPayroll.html");
            }
            else
                MessageBox.Show("Справка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            if (new Calendar().ShowDialog() == DialogResult.OK)
            {
                FillSettings();
                MessageBox.Show("Настройки успешно сохранены!", "Настройки сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            if (new FirstSalary().ShowDialog() == DialogResult.OK)
            {
                FillSettings();
                MessageBox.Show("Настройки успешно сохранены!", "Настройки сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (new Stage().ShowDialog() == DialogResult.OK)
            {
                FillSettings();
                MessageBox.Show("Настройки успешно сохранены!", "Настройки сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            if (new StandartTax().ShowDialog() == DialogResult.OK)
            {
                FillSettings();
                MessageBox.Show("Настройки успешно сохранены!", "Настройки сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            if (new SmallSalary().ShowDialog() == DialogResult.OK)
            {
                FillSettings();
                MessageBox.Show("Настройки успешно сохранены!", "Настройки сохранены", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(bunifuCustomDataGrid1.Columns[bunifuCustomDataGrid1.SelectedCells[0].ColumnIndex].HeaderText);

                TariffScale tariffScale = DataBaseContext.TariffScales.Find(id);

                TariffScaleEdit TariffScaleForm = new TariffScaleEdit();

                TariffScaleForm.TariffScale = tariffScale;

                if (TariffScaleForm.ShowDialog() == DialogResult.OK)
                {
                    DataBaseContext.SaveChanges();
                    UpdateTariffScale();
                    MessageBox.Show("Коэффициент успешно изменён!", "Коэффициент изменён", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Убедитесь, что таблица не пуста", "Ошибка попытки изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            ChangeEmployee();
        }
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEmployee();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveEmployee();
        }

        private void bunifuFlatButton19_Click(object sender, EventArgs e)
        {
            EmployeAbout();
        }

        private void FillMonth(int year, int month)
        {
            int n = DateTime.DaysInMonth(year, month) ;
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];

            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
                column[i].HeaderText = (i+1).ToString();
                column[i].Name = (i+1).ToString();
            }
            bunifuCustomDataGrid4.Columns.Clear();
            bunifuCustomDataGrid4.Columns.AddRange(column);
        }

        private void FillMonths1(Bunifu.Framework.UI.BunifuDropdown combobox)
        {
            var Months = DataBaseContext.Months.Select(i => i.MonthName).ToArray();

            combobox.Items.AddRange(Months);

            combobox.selectedIndex = 0;
        }

        private void FillMonths2(Bunifu.UI.WinForms.BunifuDropdown combobox)
        {
            var Months = DataBaseContext.Months.Select(i => i.MonthName).ToArray();

            combobox.Items.AddRange(Months);

            combobox.SelectedValue = DateTime.Now.Month;
        }

        private void FillYear1(Bunifu.Framework.UI.BunifuDropdown combobox)
        {
            var Years = DataBaseContext.WorkingTimes.Select(i => i.Year.ToString()).ToArray();

            combobox.Items.AddRange(Years);

            combobox.selectedIndex = 0;
        }

        private void FillYear2(Bunifu.UI.WinForms.BunifuDropdown combobox)
        {
            var Years = DataBaseContext.WorkingTimes.Select(i => i.Year.ToString()).ToArray();

            combobox.Items.AddRange(Years);

            combobox.SelectedValue = DateTime.Now.Year;
        }

        private void EmployeAbout()
        {

            if (bunifuCustomDataGrid2.SelectedRows.Count > 0)
            {
                int id = (Convert.ToInt32(bunifuCustomDataGrid2.SelectedRows[0].Cells[0].Value));

                var EA = new EmployeAbout(id);

                EA.ShowDialog();
            }
            else MessageBox.Show("Нечего выводить. Убедитесь, что в таблице есть записи", "Ошибка попытки вывода подробностей", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void AddEmployee()
        {
            EmployeeAdd employeeAdd = new EmployeeAdd();

            employeeAdd.Text = "Добавление работника";

            if (employeeAdd.ShowDialog() == DialogResult.OK)
            {
                DataBaseContext.Employees.Add(employeeAdd.Employee);
                if (employeeAdd.Kindreds != null)
                {
                    DataBaseContext.Kindreds.AddRange(employeeAdd.Kindreds);
                }
                DataBaseContext.SaveChanges();
                UpdateEmployee();
                MessageBox.Show("Работник успешно добавлен!", "Работник добавлен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bunifuCustomDataGrid2.Rows[bunifuCustomDataGrid2.Rows.Count - 1].Selected = true;
            }
        }

        private void RemoveEmployee()
        {
            if (bunifuCustomDataGrid2.SelectedRows.Count > 0)
            {
                int index = bunifuCustomDataGrid2.SelectedRows[0].Index;
                bunifuCustomDataGrid2.ClearSelection();
                bunifuCustomDataGrid2.Rows[index].Selected = true;
                int id = 0;
                bool converted = Int32.TryParse(bunifuCustomDataGrid2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Employee employee = DataBaseContext.Employees.Find(id);

                if (MessageBox.Show($"Вы хотите удалить работника '{employee.SurName}' ?", "Удаление работника", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    return;
                }

                DataBaseContext.Employees.Remove(employee);
                DataBaseContext.SaveChanges();
                bunifuCustomDataGrid2.Rows.Clear();
                UpdateEmployee();
                MessageBox.Show($"Работник '{employee.SurName}' был удален", "Удаление работника");
            }    
        }

        private void ChangeEmployee()
        {
            if (bunifuCustomDataGrid2.SelectedRows.Count > 0)
            {
                int index = bunifuCustomDataGrid2.SelectedRows[0].Index;
                bunifuCustomDataGrid2.ClearSelection();
                bunifuCustomDataGrid2.Rows[index].Selected = true;
                int id = 0;
                bool converted = Int32.TryParse(bunifuCustomDataGrid2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Employee employee = DataBaseContext.Employees.Find(id);

                EmployeeEdit employeeEdit = new EmployeeEdit();

                Education education = DataBaseContext.Educations.FirstOrDefault(i => i.EducationId == employee.EducationId);
                Position position = DataBaseContext.Positions.FirstOrDefault(i => i.PositionId == employee.PositionId); 
                TariffScale tariffScale = DataBaseContext.TariffScales.FirstOrDefault(i => i.TariffScaleId == employee.TariffScaleId); 

                employeeEdit.Employee = employee;

                employeeEdit.bunifuDropdown1.Items.AddRange(DataBaseContext.Positions.Select(i => i.PositionName).OrderBy(i => i).ToArray());
                employeeEdit.bunifuDropdown2.Items.AddRange(DataBaseContext.TariffScales.Select(i => i.TariffRate.ToString()).OrderBy(i => i).ToArray());
                employeeEdit.bunifuDropdown3.Items.AddRange(new string[] { "AB", "BM", "HB", "KH", "MP", "MC", "KB", "PP", "SP" });
                employeeEdit.bunifuDropdown4.Items.AddRange(DataBaseContext.Educations.Select(i => i.EducationName).OrderBy(i => i).ToArray());
                employeeEdit.bunifuDropdown5.Items.AddRange(new string[] { "Мужской", "Женский" });

                employeeEdit.bunifuCustomTextbox2.Text = employee.SurName;
                employeeEdit.bunifuCustomTextbox3.Text = employee.Name;
                employeeEdit.bunifuCustomTextbox4.Text = employee.MiddleName;
                employeeEdit.bunifuDatePicker1.Value = employee.Birthday.Date;
                employeeEdit.bunifuDropdown5.Text = employee.Sex;
                employeeEdit.bunifuCustomTextbox19.Text = employee.Address;
                employeeEdit.pictureBox2.Image = Image.FromFile(".//Photos//" + employee.Photo);
                employeeEdit.openFileDialog1.FileName = employee.Photo;
                employeeEdit.bunifuCustomTextbox18.Text = employee.Phone;
                employeeEdit.bunifuDatePicker2.Value = employee.DateOfHiring.Date;
                employeeEdit.bunifuCheckBox1.Checked = employee.SickOfChaes == "Yes" ? true : false;
                employeeEdit.bunifuCheckBox2.Checked = employee.LiquidatorChaes == "Yes" ? true : false;
                employeeEdit.bunifuCheckBox3.Checked = employee.Hero == "Yes" ? true : false;
                employeeEdit.bunifuCheckBox4.Checked = employee.GPW == "Yes" ? true : false;
                employeeEdit.bunifuCheckBox5.Checked = employee.Invalid == "Yes" ? true : false;
                employeeEdit.bunifuDropdown3.Text = employee.PassportCode;
                employeeEdit.bunifuCustomTextbox1.Text = employee.PassportNumber;
                employeeEdit.bunifuDatePicker3.Value = employee.PassportDateFrom.Date;
                employeeEdit.bunifuDatePicker4.Value = employee.PassportDateTo.Date;
                employeeEdit.bunifuCustomTextbox5.Text = employee.PassportGave;
                employeeEdit.bunifuDropdown1.Text = position.PositionName;
                employeeEdit.bunifuDropdown4.Text = education.EducationName;
                employeeEdit.bunifuDropdown2.Text = tariffScale.TariffRate.ToString();


                employeeEdit.bunifuCustomDataGrid3.Columns.Add("FIO", "ФИО");

                foreach (var kindred in employee.Kindreds)
                {
                    employeeEdit.bunifuCustomDataGrid3.Rows.Add($"{kindred.SurName} {kindred.Name} {kindred.MiddleName}");
                }


                if (employeeEdit.ShowDialog() == DialogResult.OK)
                {
                    if (employeeEdit.Kindreds != null)
                    {
                        DataBaseContext.Kindreds.AddRange(employeeEdit.Kindreds);
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
                        //Education education = context.Educations.SingleOrDefault(i => i.EducationName == (bunifuDropdown4.Text));
                        //Position position = context.Positions.SingleOrDefault(i => i.PositionName == (bunifuDropdown1.Text));
                        //TariffScale tariffScale = context.TariffScales.SingleOrDefault(i => i.TariffRate == tariff);

                        employee.SurName = employeeEdit.bunifuCustomTextbox2.Text;
                        employee.Name = employeeEdit.bunifuCustomTextbox3.Text;
                        employee.MiddleName = employeeEdit.bunifuCustomTextbox4.Text;
                        employee.Birthday = employeeEdit.bunifuDatePicker1.Value.Date;
                        employee.Sex = employeeEdit.bunifuDropdown5.Text;
                        employee.Address = employeeEdit.bunifuCustomTextbox19.Text;
                        employee.Photo = employeeEdit.openFileDialog1.SafeFileName;
                        employee.Phone = employeeEdit.bunifuCustomTextbox18.Text;
                        employee.DateOfHiring = employeeEdit.bunifuDatePicker2.Value.Date;
                        employee.SickOfChaes = employeeEdit.bunifuCheckBox1.Checked ? "Yes" : "No";
                        employee.LiquidatorChaes = employeeEdit.bunifuCheckBox2.Checked ? "Yes" : "No";
                        employee.Hero = employeeEdit.bunifuCheckBox3.Checked ? "Yes" : "No";
                        employee.GPW = employeeEdit.bunifuCheckBox4.Checked ? "Yes" : "No";
                        employee.Invalid = employeeEdit.bunifuCheckBox5.Checked ? "Yes" : "No";
                        employee.PassportCode = employeeEdit.bunifuDropdown3.Text;
                        employee.PassportNumber = employeeEdit.bunifuCustomTextbox1.Text;
                        employee.PassportDateFrom = employeeEdit.bunifuDatePicker3.Value.Date;
                        employee.PassportDateTo = employeeEdit.bunifuDatePicker4.Value.Date;
                        employee.PassportGave = employeeEdit.bunifuCustomTextbox5.Text;
                        employee.PositionId = DataBaseContext.Positions.FirstOrDefault( i => i.PositionName == employeeEdit.bunifuDropdown1.Text).PositionId;
                        employee.EducationId = DataBaseContext.Educations.FirstOrDefault(i => i.EducationName == employeeEdit.bunifuDropdown4.Text).EducationId;
                        employee.TariffScaleId = DataBaseContext.TariffScales.FirstOrDefault(i => i.TariffRate == tariff).TariffScaleId;

                        DataBaseContext.SaveChanges();
                        UpdateEmployee();
                        MessageBox.Show("Работник успешно изменен!", "Работник изменен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuCustomDataGrid2.Rows[bunifuCustomDataGrid2.Rows.Count - 1].Selected = true;
                    }
                }
            }
              
        }
        private void UpdateEmployeeFill()
        {
            bunifuCustomDataGrid3.Columns.Clear();
            bunifuCustomDataGrid3.Rows.Clear();

            bunifuCustomDataGrid3.Columns.Add("EmployeeId", "EmployeeId");
            bunifuCustomDataGrid3.Columns.Add("FIO", "ФИО работника");

            bunifuCustomDataGrid3.Columns[0].Visible = false;

            var Employees = DataBaseContext.Employees;

            foreach (Employee employee in Employees)
            {
                bunifuCustomDataGrid3.Rows.Add(employee.EducationId, $"{employee.SurName} {employee.Name} {employee.MiddleName}");
            }
        }

        private void bunifuCustomDataGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (bunifuCustomDataGrid3.SelectedRows.Count > 0)
            {
                int index = bunifuCustomDataGrid3.SelectedRows[0].Index;
                bunifuCustomDataGrid3.ClearSelection();
                bunifuCustomDataGrid3.Rows[index].Selected = true;
                int id = 0;
                bool converted = Int32.TryParse(bunifuCustomDataGrid3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                RefreshTableTime(Convert.ToInt32(bunifuCustomDataGrid3[0, index].Value), Convert.ToInt32(bunifuDropdown1.selectedIndex) + 1, Convert.ToInt32(bunifuDropdown2.selectedValue));

            }
        }

        private void bunifuCustomDataGrid4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid3.SelectedCells.Count > 0)
            {
                int Time_Day = Convert.ToInt32(bunifuCustomDataGrid4.Columns[bunifuCustomDataGrid4.SelectedCells[0].ColumnIndex].HeaderText);
                int Month_ID = Convert.ToInt32(bunifuDropdown1.selectedIndex) + 1;
                int Time_Year = Convert.ToInt32(bunifuDropdown2.selectedValue);
                int Employee_ID = Convert.ToInt32(bunifuCustomDataGrid3.CurrentRow.Cells[0].Value);
                object current = bunifuCustomDataGrid4.CurrentCell.Value;
                TimeAdd TA = new TimeAdd();
                TA.TD = Time_Day;
                TA.MI = Month_ID;
                TA.TY = Time_Year;
                TA.EI = Employee_ID;
                TA.CURR = current;

                if (TA.ShowDialog() == DialogResult.OK)
                {
                    RefreshTableTime(Convert.ToInt32(bunifuCustomDataGrid4.CurrentRow.Cells[0].Value), Convert.ToInt32(bunifuDropdown1.selectedIndex), Convert.ToInt32(bunifuDropdown2.selectedValue));
                    MessageBox.Show("Отметка успешно добавлена!", "Отметка добавлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Убедитесь, что таблица не пуста", "Ошибка попытки изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void рассчитатьЗПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int total = 0;
            int emplid = Convert.ToInt32(bunifuCustomDataGrid3.CurrentRow.Cells[0].Value);
            int year = Convert.ToInt32(bunifuDropdown2.selectedValue);

            var a = DataBaseContext.WorkingTimes.Where(i => i.EmployeeId == emplid && i.MonthId == bunifuDropdown1.selectedIndex + 1 && i.Year == year).ToList();

            for (int i = 0; i < a.Count(); i++)
            {
                try
                {
                    total += Convert.ToInt32(a[i].Count.ToString());
                }
                catch (Exception)
                {
                }
            }

            var b = DataBaseContext.Kindreds.Where(i => i.EmployeeId == emplid && (DateTime.Now.Year - i.Birthday.Year) < 18).Count();


            //query = "SELECT Employee.Employee_ID, Employee.Employee_LastName & ' ' & Employee.Employee_FirstName & ' ' & Employee.Employee_MiddleName AS FIO, Employee.Employee_Photo, Year(Now()) - Year(Employee.Employee_DateStarted) as [Стаж работы], Employee.Employee_SickOfChaes, Employee.Employee_LiquidatorOfChaes, Employee.Employee_Hero, Employee.Employee_GPW, Employee.Employee_Invalid, [Position].Position_Name, Class.Class_Number, Class.Class_Coefficient  "
            //    + "FROM[Position] INNER JOIN (Class INNER JOIN Employee ON Class.[Class_ID] = Employee.[Class_ID]) ON [Position].[Position_ID] = Employee.[Position_ID] " +
            //    $"WHERE Employee.Employee_ID = {Convert.ToInt32(bunifuCustomDataGrid4.CurrentRow.Cells[0].Value)}";

            string HoursNeed = "3";
            switch (Convert.ToInt32(bunifuDropdown1.selectedIndex))
            {
                case 0: HoursNeed = SettingsBL.Settings.Default.January.ToString(); break;
                case 1: HoursNeed = SettingsBL.Settings.Default.February.ToString(); break;
                case 2: HoursNeed = SettingsBL.Settings.Default.March.ToString(); break;
                case 3: HoursNeed = SettingsBL.Settings.Default.April.ToString(); break;
                case 4: HoursNeed = SettingsBL.Settings.Default.May.ToString(); break;
                case 5: HoursNeed = SettingsBL.Settings.Default.June.ToString(); break;
                case 6: HoursNeed = SettingsBL.Settings.Default.July.ToString(); break;
                case 7: HoursNeed = SettingsBL.Settings.Default.August.ToString(); break;
                case 8: HoursNeed = SettingsBL.Settings.Default.September.ToString(); break;
                case 9: HoursNeed = SettingsBL.Settings.Default.October.ToString(); break;
                case 10: HoursNeed = SettingsBL.Settings.Default.November.ToString(); break;
                case 11: HoursNeed = SettingsBL.Settings.Default.December.ToString(); break;
            }

            var Employee = DataBaseContext.Employees.Include(i => i.Education).Include(i => i.Position).Include(i => i.TariffScale).Include(i => i.Kindreds).Include(i => i.WorkingTimes).FirstOrDefault(i => i.EmployeeId == emplid);

            try
            {
                var SA = new Salary();
                SA.Employee_Number = Employee.EmployeeId.ToString();
                SA.Employee_FIO = $"{Employee.SurName} {Employee.Name} {Employee.MiddleName}";
                SA.Month = bunifuDropdown1.selectedValue.ToString();
                SA.MonthName = bunifuDropdown1.Text;
                SA.Year = bunifuDropdown2.Text;
                SA.Employee_Photo = ".//Photos//" + Employee.Photo;
                SA.Employee_Position = Employee.Position.PositionName;
                SA.Employee_Class = Employee.TariffScale.TariffRate.ToString();
                SA.Employee_Coeff = Employee.TariffScale.Сoefficient.ToString();
                SA.Employee_Experience = (DateTime.Now.Year - Employee.DateOfHiring.Year).ToString();
                SA.Employee_SickOfChaes = Employee.SickOfChaes;
                SA.Employee_LiquidatorOfChaes = Employee.LiquidatorChaes;
                SA.Employee_Hero = Employee.Hero;
                SA.Employee_GPW = Employee.GPW;
                SA.Employee_Invalid = Employee.Invalid;
                SA.HoursDid = total.ToString();
                SA.HoursNeed = HoursNeed.ToString();
                SA.Under18Count = b.ToString();
                SA.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Нечего выводить. Убедитесь, что в таблице есть записи", "Ошибка попытки вывода подробностей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            //Excel excel = new Excel(".//Raports//" + "Report.xlsx", 1);
            //int totalEmploees = 0;
            //excel.WriteToCell(2, 1, "За " + bunifuDropdown4.Text.ToLower() + " " + bunifuDropdown3.Text + " года");
            //var connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            //for (int i = 1; i < bunifuCustomDataGrid3.Rows.Count + 1; i++)
            //{
            //    int total = 0;
            //    string query = $"SELECT Employee.Employee_ID, Employee.Employee_LastName & ' ' & Employee.Employee_FirstName & ' ' & Employee.Employee_MiddleName AS FIO, Class.Class_Number, [Position].Position_Name FROM[Position] INNER JOIN (Class INNER JOIN Employee ON Class.[Class_ID] = Employee.[Class_ID]) ON [Position].Position_ID = Employee.Position_ID WHERE Employee.Employee_ID = {bunifuCustomDataGrid4.Rows[i - 1].Cells[0].Value}";
            //    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connectionString))
            //    {

            //        DataTable dataTable = new DataTable();
            //        adapter.Fill(dataTable);
            //        excel.WriteToCell(5 + i, 1, i.ToString());
            //        excel.WriteToCell(5 + i, 2, dataTable.Rows[0][0].ToString());
            //        excel.WriteToCell(5 + i, 3, dataTable.Rows[0][1].ToString());
            //        excel.WriteToCell(5 + i, 4, dataTable.Rows[0][2].ToString());
            //        excel.WriteToCell(5 + i, 5, dataTable.Rows[0][3].ToString());
            //        totalEmploees++;
            //    }
            //    string query2 = $"SELECT Time_Count, Time_Day FROM [Time] WHERE Employee_ID = {bunifuCustomDataGrid4.Rows[i - 1].Cells[0].Value} AND Month_ID = {bunifuDropdown4.SelectedValue} AND Time_Year = {bunifuDropdown3.Text}";
            //    using (OleDbDataAdapter adapter2 = new OleDbDataAdapter(query2, connectionString))
            //    {
            //        DataTable dataTable2 = new DataTable();
            //        adapter2.Fill(dataTable2);
            //        for (int j = 0; j < dataTable2.Rows.Count; j++)
            //        {
            //            excel.WriteToCell(5 + i, 5 + Convert.ToInt32(dataTable2.Rows[j][1].ToString()), dataTable2.Rows[j][0].ToString());
            //            switch (dataTable2.Rows[j][0].ToString())
            //            {
            //                case "В": excel.DrawCell(5 + i, 5 + Convert.ToInt32(dataTable2.Rows[j][1].ToString()), Color.Beige); break;
            //                case "Б": excel.DrawCell(5 + i, 5 + Convert.ToInt32(dataTable2.Rows[j][1].ToString()), Color.Pink); break;
            //                case "О": excel.DrawCell(5 + i, 5 + Convert.ToInt32(dataTable2.Rows[j][1].ToString()), Color.PowderBlue); break;
            //                default: excel.DrawCell(5 + i, 5 + Convert.ToInt32(dataTable2.Rows[j][1].ToString()), Color.PaleGreen); break;
            //            }

            //            try
            //            {
            //                total += Convert.ToInt32(dataTable2.Rows[j][0].ToString());
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //        excel.WriteToCell(5 + i, 37, total.ToString());
            //        excel.DrawCell(5 + i, 37, Color.LightSkyBlue);
            //    }
            //    excel.DrawBorder("A6", "AK" + (5 + totalEmploees));
            //}
            //excel.SaveAs(".//Raports//" + "Табель за " + bunifuDropdown1.Text.ToLower() + " " + bunifuDropdown2.Text + " года.xlsx");
            //excel.Close();
            //Process.Start(".//Raports//" + "Табель за " + bunifuDropdown1.Text.ToLower() + " " + bunifuDropdown2.Text + " года.xlsx");
        }
    }
}
