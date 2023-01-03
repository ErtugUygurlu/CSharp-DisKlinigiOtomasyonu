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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(LAdTb.Text==""||LSifreTb.Text=="")
            {
                MessageBox.Show("Lütfen Şifre Giriniz");
            }
            else if(LAdTb.Text == "ertu" && LSifreTb.Text == "123")
            {                          
                    Anasayfa ana = new Anasayfa();
                    ana.Show();
                    this.Show();               
            }
            else
            {
                MessageBox.Show("Yanlış Şifre Girdiniz");
            }
        }
    }
}
