using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursova4
{
    public partial class Na4 : Form
    {
        public Na4()
        {
            InitializeComponent();
        }
        dBase dataBase = new dBase();
        public static string login;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "Для записи на прием";
            i = 1;
            panel2.Visible =true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            label14.Visible = true;
            label13.Visible = true;
            label4.Visible = true;
            dateTimePicker1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vizovvracha frm = new vizovvracha(this);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = "Для входа в личный кабинет";
            i = 3;
            panel2.Visible = true;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i == 1)
            {
                
               

                string polis = textBox3.Text;
                string name = textBox2.Text;
                string fam = textBox1.Text;
                string spec = comboBox1.Text;
                object date = dateTimePicker1.Value;
                string vrem = comboBox2.Text;
                string day = dateTimePicker1.Value.ToString("dd");
                string anamez = "";
                dBase.AddSoul2(fam, name, polis, spec, anamez, vrem, date, day);

                new zapis()
                {

                    namee = textBox2.Text,
                    famm = textBox1.Text,
                    poliss = textBox3.Text,
                    specc = comboBox1.Text,
                    datee = dateTimePicker1.Value.ToString("yyyy-MM-dd"),

                    vremm = comboBox2.Text,

                }.Show();


            }
            
           
            else if(i==4)
            {
                string pass = textBox2.Text;
                login = textBox1.Text;
                string query = String.Format("Select login From vrach Where login = '{0}'", login);
                string query2 = String.Format("Select pass From vrach Where login = '{0}'", login);
                
                query = String.Format("Select login From vrach Where login ='{0}'", login);
                if (dataBase.GetPersonalData(query, login) == 1)
                {
                    
                    query2 = String.Format("Select pass From vrach Where login = '{0}'", login);
                    if (dataBase.GetPersonalData(query2, pass) == 1)
                    {
                        vrach frm = new vrach(this);

                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                

            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            i = 0;
            panel2.Visible = false;
            panel3.Visible = true;
            label6.Visible = true;
            textBox3.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            i = 4;
            panel2.Visible = true;
            label3.Text = "Логин";
            label5.Text = "Пароль";
            panel3.Visible = false;
            label6.Visible = false;
            textBox3.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dateTimePicker1.Visible = false;
            label14.Visible = false;
            label13.Visible = false;
            label4.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }    }
}
