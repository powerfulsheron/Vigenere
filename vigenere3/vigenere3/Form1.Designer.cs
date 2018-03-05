namespace vigenere3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCle = new System.Windows.Forms.TextBox();
            this.btnCrypter = new System.Windows.Forms.Button();
            this.btnImporter = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelNomFichier = new System.Windows.Forms.Label();
            this.btnDecrypter = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clé :";
            // 
            // textBoxCle
            // 
            this.textBoxCle.Location = new System.Drawing.Point(43, 151);
            this.textBoxCle.Name = "textBoxCle";
            this.textBoxCle.Size = new System.Drawing.Size(207, 20);
            this.textBoxCle.TabIndex = 1;
            this.textBoxCle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCle.UseSystemPasswordChar = true;
            // 
            // btnCrypter
            // 
            this.btnCrypter.Location = new System.Drawing.Point(43, 203);
            this.btnCrypter.Name = "btnCrypter";
            this.btnCrypter.Size = new System.Drawing.Size(62, 23);
            this.btnCrypter.TabIndex = 2;
            this.btnCrypter.Text = "Crypter";
            this.btnCrypter.UseVisualStyleBackColor = true;
            this.btnCrypter.Click += new System.EventHandler(this.btnCrypter_Click);
            // 
            // btnImporter
            // 
            this.btnImporter.Location = new System.Drawing.Point(12, 64);
            this.btnImporter.Name = "btnImporter";
            this.btnImporter.Size = new System.Drawing.Size(53, 23);
            this.btnImporter.TabIndex = 3;
            this.btnImporter.Text = "Importer";
            this.btnImporter.UseVisualStyleBackColor = true;
            this.btnImporter.Click += new System.EventHandler(this.btnImporter_Click);
            // 
            // labelNomFichier
            // 
            this.labelNomFichier.AutoSize = true;
            this.labelNomFichier.Location = new System.Drawing.Point(80, 69);
            this.labelNomFichier.Name = "labelNomFichier";
            this.labelNomFichier.Size = new System.Drawing.Size(0, 13);
            this.labelNomFichier.TabIndex = 4;
            // 
            // btnDecrypter
            // 
            this.btnDecrypter.Location = new System.Drawing.Point(188, 203);
            this.btnDecrypter.Name = "btnDecrypter";
            this.btnDecrypter.Size = new System.Drawing.Size(62, 23);
            this.btnDecrypter.TabIndex = 5;
            this.btnDecrypter.Text = "Décrypter";
            this.btnDecrypter.UseVisualStyleBackColor = true;
            this.btnDecrypter.Click += new System.EventHandler(this.btnDecrypter_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(254, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(26, 24);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.Text = "?";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnDecrypter);
            this.Controls.Add(this.labelNomFichier);
            this.Controls.Add(this.btnImporter);
            this.Controls.Add(this.btnCrypter);
            this.Controls.Add(this.textBoxCle);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vigenere";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCle;
        private System.Windows.Forms.Button btnCrypter;
        private System.Windows.Forms.Button btnImporter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelNomFichier;
        private System.Windows.Forms.Button btnDecrypter;
        private System.Windows.Forms.Button btnInfo;
    }
}

