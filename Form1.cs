using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
         MySqlConnection mcon = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1410");
         MySqlCommand mcd; 
       
        public Form1()
        { 
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
               
                MySqlDataAdapter mda = new MySqlDataAdapter("select *from cse.student",mcon);
                mcon.Open();
                DataSet ds = new DataSet();
                mda.Fill(ds, "student");
                dataGridView1.DataSource = ds.Tables["student"];
                mcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string q = "insert into cse.student values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + ", " + textBox6.Text + "," + textBox7.Text + ")";
           
            ExecuteQuery(q);

        }
        public void openCon()
        {
            
            if (mcon.State == ConnectionState.Closed)
            {
                mcon.Open();

            }
        }
            public void closeCon()
            {
                if(mcon.State==ConnectionState.Open)

                {
                    mcon.Close();
                }

        }
            public void ExecuteQuery(string q)
            {
                openCon();
                try
                {
                    mcd = new MySqlCommand(q, mcon);
                    if (mcd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Query Executed");
                    }
                    else
                    {
                        MessageBox.Show("Query not executed");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    closeCon();
                }
            }


            private void button4_Click(object sender, EventArgs e)
            {
                string q = "delete from cse.student where id=" + textBox1.Text;
                ExecuteQuery(q);
                textBox1.Text = "";
                textBox2.Text = "";


                
            }

            private void button3_Click(object sender, EventArgs e)
            {
                string q = " select "+textBox1.Text+" from cse.student";
                ExecuteQuery(q);
            }

            private void label8_Click(object sender, EventArgs e)
            {
               this.Font = new Font("Arial", this.Font.Size);
            }
           


    }
}
