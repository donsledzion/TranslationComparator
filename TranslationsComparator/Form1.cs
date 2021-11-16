using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TranslationsComparator;
using Microsoft.VisualBasic;

namespace TranslationsComparator
{
    public partial class MainForm : Form
    {
        private TranslationComparator _translationComparator;
        private Dictionary<Translation, string> _translationMismatches;
        private List<Translation> _translationsDoubled;
        private List<string> _translationFiles;

        public MainForm()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files|*.txt";
            openFileDialog.Multiselect = true;

            this._translationFiles = new List<string> { };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string filePath in openFileDialog.FileNames)
                {
                    _translationFiles.Add(filePath);
                }
                this._translationComparator = new TranslationComparator(_translationFiles);
                this._translationComparator.CompareTranslationFiles();
                
                this._translationMismatches = this._translationComparator.GetMismatches();
                this._translationsDoubled = this._translationComparator.GetDoubles();

                string resultMessage = "";
                bool resultsFound = false;

                if (this._translationMismatches.Count > 0) {
                    resultsFound = true;
                    btnMissingEntries.Visible = true;
                    btnMissingEntries.Text = "Brakujące klucze (" + this._translationMismatches.Count + ")";
                    resultMessage = "\nZnalezione brakujące klucze: " + this._translationMismatches.Count;
                }
                if (this._translationsDoubled.Count > 0)
                {
                    resultsFound = true;
                    btnDoubledEntryies.Visible = true;
                    btnDoubledEntryies.Text = "Identyczne wpisy (" + this._translationsDoubled.Count + ")";
                    resultMessage += "\nZnalezione identyczne wpisy: " + this._translationsDoubled.Count;
                }

                if (!resultsFound) {
                    resultMessage = "Brak uwag do plików - tak trzymaj!";
                }
                //MessageBox.Show("Zakończono pracę" + resultMessage, "Wyniki!",MessageBoxButtons.OK);

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

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            
            foreach (KeyValuePair<Translation, string> mismatch in this._translationMismatches)
            {                

                Button button = new Button();
                counter = missingEntriesPanel.Controls.OfType<Button>().ToList().Count;
                button.Location = new Point(5, 25*counter);
                button.Size = new Size(50, 20);
                button.Name = mismatch.Key.GetKey() + "=" + mismatch.Value;
                button.Text = "dodaj";
                button.Click += new System.EventHandler(this.Button_Click);
                missingEntriesPanel.Controls.Add(button);


                counter = missingEntriesPanel.Controls.OfType<Label>().ToList().Count;

                Label label = new Label();
                label.Location = new Point(65, 25 * counter + 2);
                label.Size = new Size(180, 20);
                label.Name = mismatch.Key.GetKey();
                label.Text = mismatch.Key.GetKey();
                missingEntriesPanel.Controls.Add(label);
            }
        }

        private void btnDoubledEntryies_Click(object sender, EventArgs e)
        {

            foreach (Translation translationDouble in this._translationsDoubled)
            {
                lstDoubled.Items.Add(translationDouble);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void missingEntriesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);

            Translation entry = new Translation(button.Name);

            string fileName = entry.GetValue();

            string fullFilePath = GetFileByName(fileName);

            string newKey = entry.GetKey();

            
            string newValue = Microsoft.VisualBasic.Interaction.InputBox("Podaj wartość dla klucza:"+Environment.NewLine+newKey, "Dodaj tłumaczenie", "Default", 150, 350);
            MessageBox.Show(" dodawanie wpisu: " + newKey + " do pliku " + fileName + "("+fullFilePath+")");
            File.AppendAllText(fullFilePath, newKey+"="+newValue + Environment.NewLine);
        }

        public string GetFileByName(string fileName)
        {
            foreach (string file in this._translationFiles)
            {
                if (fileName == Path.GetFileName(file)) {
                    return file;
                }
            }
            return "Nie znaleziono pliku o nazwie ("+fileName+")!";
        }
                
    }
}
