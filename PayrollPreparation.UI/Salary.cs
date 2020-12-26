using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsBL = PayrollPreparation.BL.Properties;

namespace PayrollPreparation.UI
{
    public partial class Salary : Form
    {
        public int idEmployee;
        public string SalaryMonthName;
        public string SalaryMonth;
        public string SalaryYear;
        public double coef;
        public int Hneed;
        public int HDid;
        public int Exp;
        public int Under18Value;
        public string Employee_Number { set { idEmployee = Convert.ToInt32(value); } }
        public string Employee_FIO { set { this.Text = "Расчёт заработной платы для " + value; bunifuCustomTextbox1.Text = value; } }
        public string Month { set { SalaryMonth = value; } }
        public string MonthName { set { this.Text = this.Text + " за " + value; SalaryMonthName = value; } }
        public string Year { set { this.Text = this.Text + " " + value + " года"; SalaryYear = value; } }
        public string Employee_Photo { set { bunifuCustomLabel14.Text = value; pictureBox2.ImageLocation = value; } }
        public string Employee_Position { set { bunifuCustomTextbox10.Text = value; } }
        public string Employee_Class { set { bunifuCustomTextbox12.Text = value; } }
        public string Employee_Coeff { set { bunifuCustomTextbox12.Text = bunifuCustomTextbox12.Text + " (" + value + ")"; coef = Convert.ToDouble(value); } }
        public string Employee_Experience { set { bunifuCustomTextbox14.Text = value; Exp = Convert.ToInt32(value); } }
        public string Under18Count { set { bunifuCustomTextbox13.Text = value; Under18Value = Convert.ToInt32(value); } }
        public string HoursNeed { set { bunifuCustomTextbox3.Text = value; Hneed = Convert.ToInt32(value); } }
        public string HoursDid { set { bunifuCustomTextbox2.Text = value; HDid = Convert.ToInt32(value); } }
        public string Employee_SickOfChaes { set { if (value == "Yes") bunifuCheckBox1.Checked = true; } }
        public string Employee_LiquidatorOfChaes { set { if (value == "Yes") bunifuCheckBox2.Checked = true; } }
        public string Employee_Hero { set { if (value == "Yes") bunifuCheckBox3.Checked = true; } }
        public string Employee_GPW { set { if (value == "Yes") bunifuCheckBox4.Checked = true; } }
        public string Employee_Invalid { set { if (value == "Yes") bunifuCheckBox5.Checked = true; } }
        double oklad = 0;
        double okladzafakt = 0;
        double zastazh = 0;
        double premia = 0;
        double itogo = 0;
        double podohodni = 0;
        double pens = 0;
        double prof = 0;
        double itogoyderzhano = 0;
        double kvidache = 0;
        public Salary()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCheckbox6.Checked && String.IsNullOrWhiteSpace(bunifuCustomTextbox4.Text))
            {
                MessageBox.Show("Введите размер премии", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                oklad = SettingsBL.Settings.Default.Salary * coef;
                bunifuCustomLabel6.Text = "Оклад: " + oklad.ToString("F" + 2) + " руб.";
                okladzafakt = (oklad / Hneed) * HDid;
                bunifuCustomLabel7.Text = "Оклад за фактически отработанное время: " + okladzafakt.ToString("F" + 2) + " руб.";
                zastazh = 0;
                if (Exp >= 1 && Exp <= 5)
                {
                    zastazh = (okladzafakt / 100.0) * SettingsBL.Settings.Default.FromOneToFive;
                    bunifuCustomLabel8.Text = "Надбавка за стаж: " + zastazh.ToString("F" + 2) + " руб.";
                }
                if (Exp > 5 && Exp < 10)
                {
                    zastazh = (okladzafakt / 100.0) * SettingsBL.Settings.Default.FromFiveToTen;
                    bunifuCustomLabel8.Text = "Надбавка за стаж: " + zastazh.ToString("F" + 2) + " руб.";
                }
                if (Exp > 10 && Exp < 15)
                {
                    zastazh = (okladzafakt / 100.0) * SettingsBL.Settings.Default.FromTenToFifteen;
                    bunifuCustomLabel8.Text = "Надбавка за стаж: " + zastazh.ToString("F" + 2) + " руб.";
                }
                if (Exp > 15)
                {
                    zastazh = (okladzafakt / 100.0) * SettingsBL.Settings.Default.MoreThanFifteen;
                    bunifuCustomLabel8.Text = "Надбавка за стаж: " + zastazh.ToString("F" + 2) + " руб.";
                }

                if (bunifuCheckbox6.Checked)
                {
                    if (String.IsNullOrWhiteSpace(bunifuCustomTextbox4.Text))
                        MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    {
                        premia = (okladzafakt / 100.0) * Convert.ToDouble(bunifuCustomTextbox4.Text);
                        bunifuCustomLabel9.Text = "Премия: " + premia.ToString("F" + 2) + " руб.";
                    }
                }
                else
                {
                    premia = 0;
                }
                itogo = okladzafakt + zastazh + premia;
                bunifuCustomLabel10.Text = "Итого начислено: " + itogo.ToString("F" + 2) + " руб.";


                double vichet = 0;
                if (itogo < SettingsBL.Settings.Default.SmallSalaryValue)
                {
                    vichet += SettingsBL.Settings.Default.SmallSalary;
                }
                if (bunifuCheckBox1.Checked || bunifuCheckBox2.Checked || bunifuCheckBox3.Checked || bunifuCheckBox4.Checked || bunifuCheckBox5.Checked)
                {
                    vichet += SettingsBL.Settings.Default.OtherCatagory;
                }
                if (Under18Value > 0)
                {
                    if (Under18Value == 1)
                    {
                        vichet += SettingsBL.Settings.Default.OneUnder18;
                    }
                    else
                    {
                        vichet += SettingsBL.Settings.Default.TwoAndMoreUnder18 * Under18Value;
                    }
                }
                podohodni = ((itogo - vichet) / 100.0) * 13;
                bunifuCustomLabel12.Text = "Подоходный налог: " + podohodni.ToString("F" + 2) + " руб.";
                pens = (itogo / 100.0) * 1;
                prof = (itogo / 100.0) * 1;
                bunifuCustomLabel17.Text = "Пенсионный фонд: " + pens.ToString("F" + 2) + " руб.";
                bunifuCustomLabel23.Text = "Профсоюзные взносы: " + prof.ToString("F" + 2) + " руб.";
                itogoyderzhano = podohodni + pens + prof;
                bunifuCustomLabel24.Text = "Итого удержано: " + itogoyderzhano.ToString("F" + 2) + " руб.";

                kvidache = itogo - itogoyderzhano;
                bunifuCustomLabel25.Text = "Итого к выдаче: " + kvidache.ToString("F" + 2) + " руб.";
                bunifuFlatButton3.Enabled = true;
            }
        }

        private void bunifuCustomTextbox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
