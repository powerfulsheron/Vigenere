using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vigenere3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Ce logiciel vous permet de crypter et de décrypter \nun fichier texte selon la méthode de Vigenere.";
            label2.Text = "Importez un fichier texte, le logiciel va créer et ouvrir un\nfichier 'crypté.txt' ou 'decrypté.txt' sur votre bureau";
            label3.Text = "La clé de cryptage et le contenu du .txt doivent contenir\ndes caractères de l'alphabet en minuscule.";
            label5.Text = "La clé de cryptage ne peut contenir deux fois le même\ncaractère";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:lorenzo.canavaggio@laposte.net");
        }
    }
}
