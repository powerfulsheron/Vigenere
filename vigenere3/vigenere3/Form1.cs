using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace vigenere3
{
    public partial class Form1 : Form
    {
        int[,] matrice = new int[26, 26];     // la matrice 26*26
        string phraseCryptee = "";            // La ligne du fichier texte qui sera cryptée
        string phraseDecryptee = "";          // La ligne du fichier texte qui sera decryptée
        string cle = "";                      // La clé de cryptage
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // pour avoir accès au desktop de l'user


        public Form1()
        {
            InitializeComponent();
            remplirGrille(matrice);                // au démarage de l'application on rempli la matrice pour les traitements de cryptage/décryptage.
            openFileDialog1.Filter = "Text|*.txt"; // On spécifie au openFileDialog que l'on veut que des fichier.txt
        }

        //FONCTION CRYPTER
        //fonction qui permet de crypter une phrase et de la retourner crypté grace au tableau.
        // Paramètres : phrase à crypter, cle de cryptage, matrice de cryptage 26*26
        public string crypter(string phrase, string cle, int[,] matrice)     
        {
            try     // on fait un try/catch ici car on veut gérer l'erreur d'une mauvaise phrase à crytper.
            {
                phraseCryptee = "";                                    // on réinitialise la phrase cryptée qu'on va retourner pour eviter les doublons.
                int indiceCle = 0;                                     // on réinitialise l'indice de la clé car on a changé de ligne.
                foreach (char c in phrase)                             // parcours de la phrase à crypter.
                {
                    if (c.Equals(' '))                                 // si le caractère est un éspace on ajoute un espace à la phrase cryptée.
                    {
                        phraseCryptee = phraseCryptee + " ";
                    }
                    else                                               // Sinon on ajoute à phrase cryptée le charactère issu de la matrice.
                    {
                        phraseCryptee = phraseCryptee + ((char)(matrice[((int)c) - 97, (int)cle[indiceCle] - 97]));

                        indiceCle++;                                   // on incrémente l'indice de la clé pour passer au caractère de cryptage suivant.
                        if (indiceCle == cle.Length)                   // si on arrive à la fin de la clé, on réinitialise.
                        {
                            indiceCle = 0;
                        }

                    }
                }

                return phraseCryptee;                                  // on retourne la phrase, on a fait une ligne.
            }
            catch (System.IndexOutOfRangeException e)                  // Si la phrase à crypter n'est pas bonne, on affiche l'erreur dans le fichier texte.
            {
                return("La phrase située a cet endroit n'a pas pu être cryptée : "+e.Message);
            }
        }


        //FONCTION DECRYPTER

        public string decrypter(int[,] matrice, string phraseCryptee, string cle)
        {
            // a peu près même fonctionnement que pour crypter mis à part qu'on parcours d'abord les premiere lettres 
            // des lignes avec le caractère de la phrase cryptée. Puis ensuite on compare les chars de la ligne avec l'indice clé et on remonte
            // on ajoute le char décrypté à la phrase puis on la retourne à la fin de la ligne.
            phraseDecryptee = "";
            int indiceCle = 0;
            foreach (char c in phraseCryptee)
            {
                if (c == ' ')
                {
                    phraseDecryptee = phraseDecryptee + ' ';
                }
                else
                {
                    for (int i = 0; i < 26; i++)
                    {
                        if (indiceCle == cle.Length)
                        {
                            indiceCle = 0;
                        }
                        if (matrice[0, i] == cle[indiceCle])
                        {
                            for (int j = 0; j < 26; j++)
                            {
                                if (matrice[j, i] == c)
                                {
                                    phraseDecryptee = phraseDecryptee + (char)matrice[j, 0];

                                }
                            }

                        }
                    }
                    indiceCle++;
                }
            }
            return phraseDecryptee;
        }
        public void remplirGrille(int[,] matrice)
        {
            int ascii = 97;
            int depart = 97;
            for (int i = 0; i < 26; i++) // boucle ligne
            {
                for (int j = 0; j < 26; j++) // boucle colonne
                {
                    if (j == 0)
                    {
                        matrice[i, j] = depart;
                        ascii = depart + 1;
                        depart++;
                    }
                    else
                    {
                        if (ascii > 122)
                        {
                            ascii = 97;
                        }
                        matrice[i, j] = ascii;
                        ascii++;
                    }
                }
            }
        }

        //ACTION BOUTON IMPORTER FICHIER
        private void btnImporter_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); // ouvre l'explorateur de fichier.
            labelNomFichier.Text = openFileDialog1.FileName; // on affiche le chemin du fichier 
        }


        //ACTION BOUTON CRYPTER
        private void btnCrypter_Click(object sender, EventArgs e)
        {
            cle = textBoxCle.Text;
            bool flag=false; //booleen pour valider le double caractère.
          
            foreach (char c in cle )
            {
                if (cle.IndexOf(c) != cle.LastIndexOf(c)) 
                {
                    flag = true;
                }
            }
            if (labelNomFichier.Text == "")
            {
                MessageBox.Show("Vous devez importer un fichier texte d'extension .txt", "Erreur");
            }
            else if (flag == true) 
            {
                MessageBox.Show("La clé de cryptage contient plus de deux fois le même caractère", "Erreur");
                textBoxCle.Text = ""; // si la clé est mauvaise, on réinitialise.
            }
           
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxCle.Text, @"^[a-zA-Z]+$")) // regex pour la clé de cryptage : que des lettres de l'alphabet.
            {
                MessageBox.Show("La clé de cryptage doit être composée uniquement de caractères de l'alphabet", "Erreur");
                textBoxCle.Text = ""; // si la clé est mauvaise, on réinitialise.

            }
            else // La clé est bonne
            {

                cle = textBoxCle.Text; // on récupère la clé pour la passer en paramètres.

                using (StreamReader sr = File.OpenText(openFileDialog1.FileName)) // on ouvre le fichier renseigné par l'utilisateur
                {
                    using (FileStream fs = File.Create(path+@"\crypté.txt")) // on crée un nouveau fichier texte dans lequel on va crypter
                    {
                        string s = ""; // Obligé de réinitilaiser s car sinon on ajoute les phrase entre elles.
                        while ((s = sr.ReadLine()) != null) // pour chaque ligne
                        {
                            Byte[] info =
                                new UTF8Encoding(true).GetBytes(crypter(s, cle, matrice)); //on crypte la ligne puis on la transforme en bytes pour pouvoir écrire.
                            fs.Write(info, 0, info.Length); // on ecrit
                            Byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine); // on saute une ligne 
                            fs.Write(newline, 0, newline.Length); // on saute une ligne
                        }
                    }
                }
                System.Diagnostics.Process.Start(path+@"\crypté.txt"); // on lance le fichier crée une fois toutes les lignes cryptées.
            }
        }

        //ACTION BOUTON DECRYPTER
        private void btnDecrypter_Click(object sender, EventArgs e)
        {
            cle = textBoxCle.Text;
            bool flag = false; //booleen pour valider le double caractère.

            foreach (char c in cle)
            {
                if (cle.IndexOf(c) != cle.LastIndexOf(c))
                {
                    flag = true;
                }
            }
            if (labelNomFichier.Text == "")
            {
                MessageBox.Show("Vous devez importer un fichier texte d'extension .txt", "Erreur");
            }
            else if (flag == true)
            {
                MessageBox.Show("La clé de cryptage contient plus de deux fois le même caractère", "Erreur");
                textBoxCle.Text = ""; // si la clé est mauvaise, on réinitialise.
            }
           
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxCle.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("La clé de cryptage doit être composée uniquement de caractères de l'alphabet", "Erreur");
                textBoxCle.Text = "";
            }
            else
            {
                cle = textBoxCle.Text;
                using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                {
                    using (FileStream fs = File.Create(path+@"\decrypté.txt"))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Byte[] info =
                                new UTF8Encoding(true).GetBytes(decrypter(matrice, s, cle));
                            fs.Write(info, 0, info.Length);
                            Byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                            fs.Write(newline, 0, newline.Length);
                        }
                    }
                }
                System.Diagnostics.Process.Start(path+@"\decrypté.txt");
            }

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
