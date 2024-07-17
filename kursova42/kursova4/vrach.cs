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
    public partial class vrach : Form
    {
        
        Form opener;
        dBase dataBase = new dBase();
        public vrach(Form parentForm)
        {
            
            InitializeComponent();
            opener = parentForm;
            string a = String.Format("Select spec From vrach Where login = '{0}'", Na4.login);
            string b = String.Format("Select fam From vrach Where login = '{0}'", Na4.login);
            string c = String.Format("Select name From vrach Where login = '{0}'", Na4.login);
            label2.Text = dataBase.GetFio(b);
            label3.Text = dataBase.GetFio(c);
            pacientBindingSource2.Filter = "[spec] LIKE'" + dataBase.GetFio(a) + "%'";

        }

        private void vrach_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet21.pacient". При необходимости она может быть перемещена или удалена.
            this.pacientTableAdapter2.Fill(this.bazaDataSet21.pacient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet1.pacient". При необходимости она может быть перемещена или удалена.
            this.pacientTableAdapter1.Fill(this.bazaDataSet1.pacient);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet.pacient". При необходимости она может быть перемещена или удалена.
            this.pacientTableAdapter.Fill(this.bazaDataSet.pacient);

        }
        public void DataUpdate() ////////////////////////////////////
        { this.pacientTableAdapter2.Fill(this.bazaDataSet21.pacient); }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(textBox1.Text);
            string anamez = textBox3.Text;
            string diagnoz = textBox4.Text;
            
            dBase.spravka(id, anamez, diagnoz);
            DataUpdate();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string day = dateTimePicker1.Value.ToString("dd");



            pacientBindingSource2.Filter = "[day] LIKE'" + day + "%'";
            

        }
       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            object date = dateTimePicker2.Value;
            string vrem = comboBox1.Text;
            dBase.dopdiagno(id, date, vrem);
            DataUpdate();
            MessageBox.Show("Вы перезаписали пациента");
        }
    }
}
