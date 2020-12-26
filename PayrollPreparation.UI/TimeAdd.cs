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
    public partial class TimeAdd : Form
    {
        public PayrollContext PayrollContext { get; set; }

        private int Time_Year;
        private int Month_ID;
        private int Time_Day;
        private int Employee_ID;
        private object current;

        public object CURR
        {
            set
            {
                current = value;
            }
        }
        public int TY
        {
            set
            {
                Time_Year = value;
            }
        }

        public int MI
        {
            set
            {
                Month_ID = value;
            }
        }

        public int TD
        {
            set
            {
                Time_Day = value;
            }
        }

        public int EI
        {
            set
            {
                Employee_ID = value;
            }
        }

        public TimeAdd()
        {
            InitializeComponent();
            PayrollContext = new PayrollContext();
        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void bunifuDropdown4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(bunifuDropdown4.SelectedIndex))
            {
                case 0: bunifuCustomTextbox1.Enabled = true; bunifuCustomTextbox1.Text = "8"; break;
                case 1: bunifuCustomTextbox1.Enabled = false; bunifuCustomTextbox1.Text = "В"; break;
                case 2: bunifuCustomTextbox1.Enabled = false; bunifuCustomTextbox1.Text = "Б"; break;
                case 3: bunifuCustomTextbox1.Enabled = false; bunifuCustomTextbox1.Text = "О"; break;
            }
        }

        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(bunifuCustomTextbox1.Text) ||
            String.IsNullOrWhiteSpace(bunifuDropdown4.Text))
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                if (current != null)
                {
                    var Time = PayrollContext.WorkingTimes.SingleOrDefault(i => i.Year == Time_Year && i.MonthId == Month_ID && i.Day == Time_Day && i.EmployeeId == Employee_ID);
                    Time.Year = Time_Year;
                    Time.MonthId = Month_ID;
                    Time.Day = Time_Day;
                    Time.Count = bunifuCustomTextbox1.Text;
                    Time.EmployeeId = Employee_ID;

                    PayrollContext.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    WorkingTime Time = new WorkingTime();
                    Time.Year = Time_Year;
                    Time.MonthId = Month_ID;
                    Time.Day = Time_Day;
                    Time.Count = bunifuCustomTextbox1.Text;
                    Time.EmployeeId = Employee_ID;
                    PayrollContext.WorkingTimes.Add(Time);

                    PayrollContext.SaveChanges();

                    this.DialogResult = DialogResult.OK;
                }

            }
        }
    }
}
