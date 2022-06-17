using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDExe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Blogin_Click(object sender, EventArgs e)
        {
            if (txusername.Text == "david" && txpass.Text == "123")
            {
                new Menu().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username dan Password salah, coba lagi");
                txusername.Clear();
                txpass.Clear();
                txusername.Focus();
            }
        }

        private void Bexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
