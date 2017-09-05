using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSetWindowsFormsApp
{
    public partial class Form1 : Form
    {
        String conString = ConfigurationManager.ConnectionStrings["DataSetWindowsFormsApp.Properties.Settings.SQLServerConnection"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            using (var connection = new SqlConnection(conString))
            {
                try
                {
                    // データを保存するテーブルを作成
                    dt = new DataTable();
                    // SQL 文と接続情報を引数に、データアダプターを作成
                    //MySqlCommand cmd = new MySqlCommand("SELECT * FROM EMPLOYEE", connection);
                    //da = new MySqlDataAdapter(cmd);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ADV_DATA", connection);
                    // SQL 文で指定したデータを DataTable に格納
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            dataGridView1.DataSource = dt;
        }
    }
}
