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
    public partial class vizovvracha : Form
    {
        Form opener;
        public vizovvracha(Form parentForm)
        {

            InitializeComponent();
            opener = parentForm;
        }

        private void vizovvracha_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string spec = "Терапевт";
            object date = dateTimePicker1.Value;
            string polis = textBox3.Text;
            string name = textBox2.Text;
            string fam = textBox1.Text;
            string anamez = textBox4.Text;
            string vrem = "Вечерний прием";
            string day = dateTimePicker1.Value.ToString("dd");

            dBase.AddSoul2(fam, name, polis, spec, anamez, vrem, date,day);
        }
    }
}
