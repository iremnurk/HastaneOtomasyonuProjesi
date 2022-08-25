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

namespace Hastane_Proje
{
    public partial class FrmRandevuListesi1 : Form
    {
        public FrmRandevuListesi1()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmRandevuListesi1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

      
        private void FrmRandevuListesi1_DoubleClick(object sender, EventArgs e)
        {
         
        }
    }
}
