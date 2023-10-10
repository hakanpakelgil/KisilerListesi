using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace IsinmaForm
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiler;

        public Form1()
        {
            InitializeComponent();
            VerileriYukle();
            KisileriListele();
        }

        private void VerileriYukle()
        {
            try
            {
                string json = File.ReadAllText("veri.json");
                kisiler = JsonSerializer.Deserialize<List<Kisi>>(json)!;
            }
            catch (Exception)
            {
                kisiler = OrnekVeriler();
            }
        }

        private void KisileriListele()
        {
            lstKisiler.Items.Clear();

            foreach (Kisi kisi in kisiler)
                lstKisiler.Items.Add(kisi);//$ ile eklersen koddaki listeye eklenmez
        }

        private List<Kisi> OrnekVeriler()
        {
            return new List<Kisi>()
            {
                new Kisi() { Ad = "Ali", Soyad = "Y�lmaz" },
                new Kisi() { Ad = "Can", Soyad = "�zt�rk" },
                new Kisi() { Ad = "Cem", Soyad = "�ahin" },
                new Kisi() { Ad = "Ece", Soyad = "Do�an" }
            };
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();

            if (ad == "" || soyad == "")
            {
                MessageBox.Show("Ad ve soyad zorunlu!");
                return;
            }
            Kisi k = new Kisi() { Ad = ad, Soyad = soyad };
            kisiler.Add(k);
            KisileriListele();
            lstKisiler.SelectedItem = k;//son ekleneni se�ili tutar
            txtAd.Clear();
            txtSoyad.Clear();
            txtAd.Focus();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Silmek �stedi�inize Emin Misiniz?", "Uyar�", MessageBoxButtons.YesNo);
            if (sil == DialogResult.Yes)
            {
                if (lstKisiler.SelectedItem == null)
                {
                    MessageBox.Show("Silinmesini istedi�iniz ki�iyi se�iniz.");
                    return;
                }
                Kisi k = (Kisi)lstKisiler.SelectedItem;
                int sid = lstKisiler.SelectedIndex;
                kisiler.Remove(k);
                KisileriListele();
                if (sid == lstKisiler.Items.Count)
                    lstKisiler.SelectedIndex = lstKisiler.Items.Count - 1;
                else lstKisiler.SelectedIndex = sid;
            }
            else
                return;



        }

        private void btnYukari_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;

            if (sid < 1) return;

            Kisi k = (Kisi)lstKisiler.SelectedItem!;//"!" nullable �izgisini yok eder
            kisiler.Remove(k);
            kisiler.Insert(sid - 1, k);
            KisileriListele();
            lstKisiler.SelectedIndex = sid - 1;
        }



        private void btnAsagi_Click(object sender, EventArgs e)
        {
            int sid = lstKisiler.SelectedIndex;

            if (sid == -1 || sid == lstKisiler.Items.Count - 1) return;

            Kisi k = (Kisi)lstKisiler.SelectedItem!;
            kisiler.Remove(k);
            kisiler.Insert(sid + 1, k);
            KisileriListele();
            lstKisiler.SelectedItem = k;
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (lstKisiler.SelectedItem == null)
            {
                MessageBox.Show("D�zenlenmesini istedi�iniz ki�iyi se�iniz.");
                return;
            }
            Kisi k = (Kisi)lstKisiler.SelectedItem;
            Form2 frmDuzenle = new Form2(k);
            frmDuzenle.ShowDialog();
            KisileriListele();
            lstKisiler.SelectedItem = k;

        }

        private void lstKisiler_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Silmek �stedi�inize Emin Misiniz?", "Uyar�", MessageBoxButtons.YesNo);
            if (sil == DialogResult.Yes)
            {
                if (lstKisiler.SelectedItem == null)
                {
                    MessageBox.Show("Silinmesini istedi�iniz ki�iyi se�iniz.");
                    return;
                }
                Kisi k = (Kisi)lstKisiler.SelectedItem;
                int sid = lstKisiler.SelectedIndex;
                kisiler.Remove(k);
                KisileriListele();
                if (sid == lstKisiler.Items.Count)
                    lstKisiler.SelectedIndex = lstKisiler.Items.Count - 1;
                else lstKisiler.SelectedIndex = sid;
            }
            else
                return;
            //if(e.KeyCode == Keys.Delete)
            //    btnSil.PerformClick();   yukar�dakinin yerine buda kullan�labilir
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(kisiler, options);//json(javascript object notation)
            File.WriteAllText("veri.json", json);
        }
    }
}