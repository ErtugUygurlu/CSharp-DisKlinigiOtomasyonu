using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace disKlinigi
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();

        private void FillHasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl ", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            RandevuCb.ValueMember = "HAd";
            RandevuCb.DataSource = dt;
            baglanti.Close();
        }
        private void FillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TedaviTbl ", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            RTedaviCb.ValueMember = "TAd";
            RTedaviCb.DataSource = dt;
            baglanti.Close();
        }
        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from RandevuTbl";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }

        void Reset()
        {
            RandevuCb.SelectedValue = "";
            RTedaviCb.SelectedValue = "";
            RTarihCb.Text = "";
            RSaatCb.SelectedValue = "";
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            FillHasta();
            FillTedavi();
            uyeler();
            Reset();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string query = "insert into RandevuTbl values ('" + RandevuCb.SelectedValue.ToString() + "','" + RTedaviCb.SelectedValue.ToString() + "','" + RTarihCb.Text + "','" + RSaatCb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Randevu Başarıyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Update RandevuTbl set Hasta='" + RandevuCb.SelectedValue.ToString() + "',Tedavi='" + RTedaviCb.SelectedValue.ToString() + "',RTarih='" + RTarihCb.Text + "',RSaat='" + RSaatCb.Text + "' where RId= " + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu İşlemi Başarıyla Güncellendi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RandevuDgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            RandevuCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[1].Value.ToString();
            RTedaviCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[2].Value.ToString();
            RTarihCb.Text = RandevuDgv.SelectedRows[0].Cells[3].Value.ToString();
            RSaatCb.Text = RandevuDgv.SelectedRows[0].Cells[4].Value.ToString();


            if (RandevuCb.SelectedIndex == -1)
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RandevuDgv.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Randevuyu Seçiniz Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from RandevuTbl where RId= " + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu Başarıyla Silindi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            Hasta hst = new Hasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Tedavi tv = new Tedavi();
            tv.Show();
            this.Hide();
        }
    }
}
