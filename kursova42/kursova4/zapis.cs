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
    public partial class zapis : Form
    {
        
        dBase dataBase = new dBase();

       
        public zapis()
        {
          
            InitializeComponent();

            

        }

 

        public string namee { get; set; }
        public string poliss { get; set; }
        public string famm { get; set; }
        public string specc { get; set; }
        public string datee { get; set; }
        public string vremm { get; set; }


        private void zapis_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bazaDataSet3.pacient". При необходимости она может быть перемещена или удалена.
            this.pacientTableAdapter.Fill(this.bazaDataSet3.pacient);
            fam1.Text = famm;
            nam1.Text = namee;
            label5.Text = poliss;
            if (specc == "Терапевт")
            {
                fam2.Text = "Шемчук Евгений";
                cab.Text = "101";
            }
            else if(specc == "Уролог")
            {
                fam2.Text = "Токарев Никита";
                cab.Text = "103";
            }
            else if(specc == "Хирург")
            {
                fam2.Text = "Ткачев Никита";
                cab.Text = "102";
            }
            label7.Text = datee;
            label9.Text = vremm;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void fam1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}
