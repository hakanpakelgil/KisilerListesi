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
                new Kisi() { Ad = "Ali", Soyad = "Yýlmaz" },
                new Kisi() { Ad = "Can", Soyad = "Öztürk" },
                new Kisi() { Ad = "Cem", Soyad = "Þahin" },
                new Kisi() { Ad = "Ece", Soyad = "Doðan" }
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
            lstKisiler.SelectedItem = k;//son ekleneni seçili tutar
            txtAd.Clear();
            txtSoyad.Clear();
            txtAd.Focus();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Silmek Ýstediðinize Emin Misiniz?", "Uyarý", MessageBoxButtons.YesNo);
            if (sil == DialogResult.Yes)
            {
                if (lstKisiler.SelectedItem == null)
                {
                    MessageBox.Show("Silinmesini istediðiniz kiþiyi seçiniz.");
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

            Kisi k = (Kisi)lstKisiler.SelectedItem!;//"!" nullable çizgisini yok eder
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
                MessageBox.Show("Düzenlenmesini istediðiniz kiþiyi seçiniz.");
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
            sil = MessageBox.Show("Silmek Ýstediðinize Emin Misiniz?", "Uyarý", MessageBoxButtons.YesNo);
            if (sil == DialogResult.Yes)
            {
                if (lstKisiler.SelectedItem == null)
                {
                    MessageBox.Show("Silinmesini istediðiniz kiþiyi seçiniz.");
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
            //    btnSil.PerformClick();   yukarýdakinin yerine buda kullanýlabilir
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