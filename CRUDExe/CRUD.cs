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

namespace CRUDExe
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LENOVO\\MSSQLSERVER1;Initial Catalog=SPLAZZ_DB;Integrated Security=True");

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.Splazz_insert '"+int.Parse(txtid.Text) + "','" +txtnama.Text+ "','" +cbjenis.Text+"','" +txtjumlah.Text+ "','" +txtalamat.Text+ "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil Ditambahkan");
            LoadAllRecords();
        }

        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.Splazz_view", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sPLAZZ_DBDataSet.Splazz_table' table. You can move, or remove it, as needed.
            this.splazz_tableTableAdapter.Fill(this.sPLAZZ_DBDataSet.Splazz_table);
            LoadAllRecords();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.Splazz_update '" + int.Parse(txtid.Text) + "','" + txtnama.Text + "','" + cbjenis.Text + "','" + txtjumlah.Text + "','" + txtalamat.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil Diupdate");
            LoadAllRecords();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Anda Yakin Untuk Menghapus?","Delete", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                con.Open();
                SqlCommand com = new SqlCommand("exec dbo.Splazz_delete '" +int.Parse(txtid.Text) + "'", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Berhasil Dihapus");
                LoadAllRecords();
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("exec dbo.Splazz_search '"+int.Parse(textBox1.Text)+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
