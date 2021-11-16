using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationsComparator;

namespace TranslationsComparator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            lblTranslationsComparator.Text = "Znalezione niedopasowania: \n";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files|*.txt";
            openFileDialog.Multiselect = true;

            List<string> paths = new List<string> { };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    paths.Add(filePath);
                }
                TranslationComparator translationComparator = new TranslationComparator(paths);
                translationComparator.CompareTranslationFiles();
                
                Dictionary<Translation, string> translationMismatches = translationComparator.GetMismatches();
                List<Translation> translationsDoubled = translationComparator.GetDoubles();
                foreach (KeyValuePair<Translation,string>mismatch in translationMismatches) {
                    
                    lstMismatches.Items.Add(mismatch.Key.GetKey() + " \t( w pliku " + mismatch.Value + ")");
                }

                foreach (Translation translationDouble in translationsDoubled) {
                    lstDoubled.Items.Add(translationDouble);
                }



            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lstMismatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvMismatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
