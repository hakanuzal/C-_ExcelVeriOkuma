using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Lütfen Dosya Seçiniz";
            openFileDialog1.Filter = " (*.xlsx)|*.xlsx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya_adres = openFileDialog1.FileName;

                OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + dosya_adres + ";Extended Properties='Excel 12.0 Xml; HDR=YES;'");
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Sayfa1$]", baglanti);

                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;

                List<MusteriBilgi> liste = new List<MusteriBilgi>();

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    MusteriBilgi bilgi = new MusteriBilgi();

                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        if (item.Cells[i].Value == null || item.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(item.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show((i+1) + ".Hücre boş");
                        }
                    }

                    bilgi.sehir = item.Cells[0].Value?.ToString();
                    bilgi.sube = item.Cells[1].Value?.ToString();
                    bilgi.subekodu = item.Cells[2].Value?.ToString();
                    bilgi.seri_no = item.Cells[3].Value?.ToString();
                    bilgi.model = item.Cells[4].Value?.ToString();
                    bilgi.garanti_baslangici = (Convert.ToDateTime(item.Cells[5].Value?.ToString()));
                    bilgi.garanti_suresi = item.Cells[6].Value?.ToString();
                    bilgi.bitis_tarihi = (Convert.ToDateTime(item.Cells[7].Value?.ToString()));
                    bilgi.teknisyen = item.Cells[8].Value?.ToString();
                    bilgi.onceki_bakim = (Convert.ToDateTime(item.Cells[9].Value?.ToString()));
                    bilgi.planlanan_bakim = (Convert.ToDateTime(item.Cells[10].Value?.ToString()));
                    bilgi.fark = Convert.ToInt32(item.Cells[11].Value?.ToString());

                    liste.Add(bilgi);
                    MessageBox.Show(bilgi.ToString());

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }           
  }

