using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1
{
     class db
    {
        public static int KitapID = 0;
        public static bool Kapa=false;
        public static string Constr = "Server=JEMOTYPC\\SQLEXPRESS01;Database=BookStore;Trusted_Connection=true";

        public static DataSet GetBooks()
        {
            DataSet ds = new DataSet();

            SqlConnection con=new SqlConnection(Constr);
            SqlDataAdapter da = new SqlDataAdapter("select KitapID as[ID],KitapAdi as [KITAP ADI],BarkodNo as [BARKOD NO],Yazar as [YAZARI],SayfaNo as [SAYFA SAYISI],Tur as[KİTAP TÜRÜ],Dil as[DİLİ],Yayınci as [YAYINCISI],Yil as[YILI],KayitTarihi as[ARŞİV GİRİŞ TARİHİ],Resim as [RESIM] from Kitap", con);
            da.Fill(ds);
            
            return ds;
             
            
        }
        public static void SaveBook(int KitapID,string BarkodNo,string KitapAdi,string Yazar,int SayfaNo,string Tur,string Dili,string Yayınci,string YayinYili,byte[] Fotograf)
        {
            SqlConnection con=new SqlConnection(Constr);
            SqlCommand com = new SqlCommand("if not exists(select * from Kitap Where KitapID=@ID) insert into Kitap(KitapID,KitapAdi,BarkodNo,Yazar,SayfaNo,Tur,Dil,Yayınci,Yil,KayitTarihi,Resim) values(@KitapID,@KitapAdi,@BarkodNo,@Yazar,@SayfaNo,@Tur,@Dil,@Yayınci,@Yil,@KayitTarihi,@Resim) else update Kitap set KitapID=@KitapID,KitapAdi=@KitapAdi,BarkodNo=@BarkodNo,Yazar=@Yazar,SayfaNo=@SayfaNo,Tur=@Tur,Dil=@Dil,Yayınci=@Yayınci,Yil=@Yil,Resim= Where KitapID=@ID", con);
            com.Parameters.AddWithValue("@KitapID",KitapID);
            com.Parameters.AddWithValue("@BarkodNo", BarkodNo);
            com.Parameters.AddWithValue("@Yazar", Yazar);
            com.Parameters.AddWithValue("@SayfaNo", SayfaNo);
            com.Parameters.AddWithValue("@Tur", Tur);
            com.Parameters.AddWithValue("@Dil", Dili);
            com.Parameters.AddWithValue("@Yayınci", Yayınci);
            com.Parameters.AddWithValue("@Yil", YayinYili);
            com.Parameters.AddWithValue("@KayitTarihi", DateTime.Now.ToString("dd-MM-yyyy"));
            if (Fotograf == null)
            {
                com.Parameters.AddWithValue("@Resim", 0);
            }
            else
            {
                com.Parameters.AddWithValue("@Resim", Fotograf);
            }

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public static void BackDatabase()
        {
            SqlConnection con=new SqlConnection(Constr);
            SqlCommand com = new SqlCommand("Backup database BookStore to disk='C:\\BookStore\\BookStore.bak' with format", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}
