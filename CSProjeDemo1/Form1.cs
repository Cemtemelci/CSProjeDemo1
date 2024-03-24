using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSProjeDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Options();
            GetAllBook();

        }

        private void Options()
        {
            if (!Directory.Exists("C:\\BookStore"))
            {
                Directory.CreateDirectory("C:\\BookStore");
            }

        }

        private void GetAllBook()
        {
            dataGridView1.DataSource = db.GetBooks().Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["RESIM"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Kapa = true;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=!db.Kapa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Book Kitap= new Book();
            Kitap.ShowDialog();
            GetAllBook();
        }
    }
}
