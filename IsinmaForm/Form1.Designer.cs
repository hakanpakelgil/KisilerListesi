namespace IsinmaForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            label2 = new Label();
            lstKisiler = new ListBox();
            btnEkle = new Button();
            btnDuzenle = new Button();
            btnSil = new Button();
            btnYukari = new Button();
            btnAsagi = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 18);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 0;
            label1.Text = "Ad";
            // 
            // txtAd
            // 
            txtAd.Location = new Point(21, 36);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(165, 23);
            txtAd.TabIndex = 1;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(205, 36);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(165, 23);
            txtSoyad.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 18);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 2;
            label2.Text = "Soyad";
            // 
            // lstKisiler
            // 
            lstKisiler.FormattingEnabled = true;
            lstKisiler.ItemHeight = 15;
            lstKisiler.Location = new Point(21, 65);
            lstKisiler.Name = "lstKisiler";
            lstKisiler.Size = new Size(470, 289);
            lstKisiler.TabIndex = 4;
            lstKisiler.KeyDown += lstKisiler_KeyDown;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(386, 35);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(105, 23);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "EKLE";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Location = new Point(21, 360);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(146, 31);
            btnDuzenle.TabIndex = 6;
            btnDuzenle.Text = "DÜZENLE";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(184, 360);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(132, 30);
            btnSil.TabIndex = 7;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYukari
            // 
            btnYukari.Image = (Image)resources.GetObject("btnYukari.Image");
            btnYukari.Location = new Point(507, 144);
            btnYukari.Name = "btnYukari";
            btnYukari.Size = new Size(52, 45);
            btnYukari.TabIndex = 8;
            btnYukari.UseVisualStyleBackColor = true;
            btnYukari.Click += btnYukari_Click;
            // 
            // btnAsagi
            // 
            btnAsagi.Image = (Image)resources.GetObject("btnAsagi.Image");
            btnAsagi.Location = new Point(507, 205);
            btnAsagi.Name = "btnAsagi";
            btnAsagi.Size = new Size(52, 45);
            btnAsagi.TabIndex = 9;
            btnAsagi.UseVisualStyleBackColor = true;
            btnAsagi.Click += btnAsagi_Click;
            // 
            // Form1
            // 
            AcceptButton = btnEkle;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 450);
            Controls.Add(btnAsagi);
            Controls.Add(btnYukari);
            Controls.Add(btnSil);
            Controls.Add(btnDuzenle);
            Controls.Add(btnEkle);
            Controls.Add(lstKisiler);
            Controls.Add(txtSoyad);
            Controls.Add(label2);
            Controls.Add(txtAd);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kişi Defteri";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAd;
        private TextBox txtSoyad;
        private Label label2;
        private ListBox lstKisiler;
        private Button btnEkle;
        private Button btnDuzenle;
        private Button btnSil;
        private Button btnYukari;
        private Button btnAsagi;
    }
}