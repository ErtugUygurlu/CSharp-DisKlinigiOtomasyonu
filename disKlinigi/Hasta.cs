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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string query = "insert into HastaTbl values ('" + HAdSoyadTb.Text + "','" + HTelefonTb.Text + "','" + HAdresTb.Text + "','" + HDogTarih.Text + "','" + HCinsiyetCb.SelectedItem.ToString() + "','" + HAlerjiTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        void uyeler()
        {
            Hastalar Hs = new Hastalar();
            string query = "select * from HastaTbl";
            DataSet ds = Hs.ShowHasta(query);
            HastaDgv.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HAdSoyadTb.Text = "";
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HDogTarih.Text = "";
            HCinsiyetCb.SelectedItem = "";
            HAlerjiTb.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        int key = 0;
        private void HastaDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDgv.SelectedRows[0].Cells[1].Value.ToString();
            HTelefonTb.Text = HastaDgv.SelectedRows[0].Cells[2].Value.ToString();
            HAdresTb.Text = HastaDgv.SelectedRows[0].Cells[3].Value.ToString();
            HDogTarih.Text = HastaDgv.SelectedRows[0].Cells[4].Value.ToString();
            HCinsiyetCb.SelectedItem = HastaDgv.SelectedRows[0].Cells[5].Value.ToString();
            HAlerjiTb.Text = HastaDgv.SelectedRows[0].Cells[6].Value.ToString();
            if (HAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDgv.SelectedRows[0].Cells[0].Value.ToString());
            }

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
                    string query = "delete from HastaTbl where HId= " + key + "";
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
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
                    string query = "update HastaTbl set HAd='" + HAdSoyadTb.Text + "',HTelefon='" + HTelefonTb.Text + "',HAdres='" + HAdresTb.Text + "',HDTarih='" + HDogTarih.Text + "', HCinsiyet='" + HCinsiyetCb.SelectedItem.ToString() + "',HAlerji='" + HAlerjiTb.Text + "' where HId= " + key + ";";
                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                    uyeler();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Tedavi tv = new Tedavi();
            tv.Show();
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
