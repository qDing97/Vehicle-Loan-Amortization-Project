using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Assignment_6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cost, downPayment, balance, month, monthlyPayment,
                principal, rate, interest, loan, result;

            cost = double.Parse(textBox1.Text);
            downPayment = double.Parse(textBox2.Text);
            month = double.Parse(textBox3.Text);
            loan = cost - downPayment;
            balance = loan;
            result = 0;

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "Payment #";
            dataGridView1.Columns[1].HeaderText = "Monthly Payment";
            dataGridView1.Columns[2].HeaderText = "Amount to Interest";
            dataGridView1.Columns[3].HeaderText = "Amount to principal";
            dataGridView1.Columns[4].HeaderText = "Remaining balance";

            if (radioButton1.Checked)
            {
                rate = .059;
            }
            else
            {
                rate = .075;
            }
            textBox4.Text = rate.ToString("p");

            monthlyPayment = Financial.Pmt(rate / 12, month, -balance);

            dataGridView1.Rows.Clear();
            for (int i = 1; i <= month; i++)
            {

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i - 1].Cells[0].Value = i;
                dataGridView1.Rows[i - 1].Cells[1].Value = monthlyPayment.ToString("c");
                interest = Financial.IPmt(rate / 12, i, month, -loan);
                dataGridView1.Rows[i - 1].Cells[2].Value = interest.ToString("c");
                principal = Financial.PPmt(rate / 12, i, month, -loan);
                dataGridView1.Rows[i - 1].Cells[3].Value = principal.ToString("c");
                balance -= principal;
                dataGridView1.Rows[i - 1].Cells[4].Value = balance.ToString("c");
                result += interest;

                if (i % 2 == 0)
                {
                    dataGridView1.Rows[i - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    dataGridView1.Rows[i - 1].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
    }


            
        
}
