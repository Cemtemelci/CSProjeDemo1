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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bu ekran kapatılırsa girmiş olduğunuz veriler silinecektir.\nDevam Edilsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Dolu = true;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.TabStop == true)
                {
                    if (c.Text == string.Empty)
                    {
                        Dolu = false;
                        c.BackColor = Color.White;
                    }
                }
            }
            foreach (Control c in this.Controls)
            {
                if(c is TextBox && c.TabStop==true && c.Tag.ToString()=="B")
                {
                    if (c.Text == string.Empty)
                    {
                        Dolu = false;
                        c.BackColor=Color.Red;
                    }
                }
            }
            if (!Dolu)
            {
                MessageBox.Show("Barkod Numarası ve Kitap Adı sekmeleri boş bırakılamaz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            //Veri Tabanımıza Veri girişi gerçekleştiriyoruz.
            db.SaveBook(db.KitapID, txtBarkodNo.Text, txtKitapAdi.Text, txtYazar.Text, Convert.ToInt32(txtSayfaNo.Text), txtTur.Text, txtDil.Text, txtYayinci.Text, txtYayinYili.Text, PicData);
        }

        byte[] PicData = null;
        private void pboxKitap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog selectPic = new OpenFileDialog();
            selectPic.Filter = "(*.jpg)|*.jpg";
            if(selectPic.ShowDialog()==DialogResult.No)return;
            PicData=File.ReadAllBytes(selectPic.FileName);
            pboxKitap.Image=Image.FromFile(selectPic.FileName);
        }
        private void pboxKitap_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
