using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace disKlinigi
{
    public partial class Tedavi : Form
    {
        public Tedavi()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string query = "insert into TedaviTbl values ('" + TedaviAdTb.Text + "','" + TutarTb.Text + "','" + AciklamaTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi Başarıyla Eklendi");
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
                MessageBox.Show("Güncellenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "update TedaviTbl set TAd='" + TedaviAdTb.Text + "',TUcret='" + TutarTb.Text + "',TAciklama='" + AciklamaTb.Text + "' where TId= " + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi İşlemi Başarıyla Güncellendi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }
        void Reset()
        {
            TedaviAdTb.Text = "";
            TutarTb.Text = "";
            AciklamaTb.Text = "";
        }

        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDgv.DataSource = ds.Tables[0];
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from TedaviTbl where TId= " + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        private void TedaviDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdTb.Text = TedaviDgv.SelectedRows[0].Cells[1].Value.ToString();
            TutarTb.Text = TedaviDgv.SelectedRows[0].Cells[2].Value.ToString();
            AciklamaTb.Text = TedaviDgv.SelectedRows[0].Cells[3].Value.ToString();

            if (TedaviAdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDgv.SelectedRows[0].Cells[0].Value.ToString());
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

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            Hasta hst = new Hasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            Randevu rnd = new Randevu();
            rnd.Show();
            this.Hide();
        }
    }
}
