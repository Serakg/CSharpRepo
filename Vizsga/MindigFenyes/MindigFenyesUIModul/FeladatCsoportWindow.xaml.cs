using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MindigFenyesUIModul
{
    /// <summary>
    /// Interaction logic for FeladatCsoportWindow.xaml
    /// </summary>
    public partial class FeladatCsoportWindow : Window
    {
        public FeladatCsoportWindow()
        {
            InitializeComponent();
            ComboBoxFeltolt();
        }

        private void feladatWindowBackToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            feladatCsoportWindow.Close();
            mainWindow.Show();
        }


        private void ComboBoxFeltolt()
        {
            Adataim a = new Adataim();
            foreach (var feladatTipus in a.FeladatTipusoks)
            {
                feladatCsoportComboBox.Items.Add(feladatTipus.FeladatTipus);
            }
        }

        private void feladatLekerdezesBtn_Click(object sender, RoutedEventArgs e)
        {
            feladatCsoportListbox.Items.Clear();
            Adataim a = new();
            var lekerdezesEredmeny = a.Feladatoks.Where(x => x.Tipus.TrimEnd() == feladatCsoportComboBox.SelectedItem.ToString()).ToList();
            foreach (var feladat in lekerdezesEredmeny)
            {
                feladatCsoportListbox.Items.Add(feladat.Helyszin.TrimEnd() + " - " + feladat.Leiras.TrimEnd());
            }
            if (lekerdezesEredmeny.Count == 0)
            {
                feladatCsoportListbox.Items.Add("Nincs ilyen eredmény!");
            }
        }

        private void feladatCsoportExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Adataim a = new();
                var lekerdezesEredmeny = a.Feladatoks.Where(x => x.Tipus.TrimEnd() == feladatCsoportComboBox.SelectedItem.ToString()).ToList();
                List<ListBoxItem> lbiList = new List<ListBoxItem>();

                foreach (var item in lekerdezesEredmeny)
                {
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Szerelo = item.Szerelo.TrimEnd();
                    lbi.BejDatum = item.BejDatum.Date;
                    lbi.BefDatum = item.BefejezDatum;
                    lbi.Cim = item.Helyszin.TrimEnd();
                    lbi.Tipus = item.Tipus.TrimEnd();
                    lbi.Leiras = item.Leiras.TrimEnd();
                    lbiList.Add(lbi);
                }

                if (CheckListBoxCountGreaterThanZero(feladatCsoportListbox) == true)
                {
                    string jsonFile = JsonConvert.SerializeObject(lbiList, Formatting.Indented);
                    string logfile = @"C:\Users\gabser\OneDrive - ASSA ABLOY Group\Documents\Webuni\Vizsga\MindigFenyes\ListaExport\FeladatLog" + ".json";
                    TextWriter? txt;
                    if (File.Exists(logfile))
                    {
                        txt = new StreamWriter(logfile, true);
                    }
                    else
                    {
                        txt = new StreamWriter(logfile);
                    }

                    txt.WriteLine(jsonFile.TrimEnd());
                    txt.Close();
                    MessageBox.Show("Sikeres exportálás!");
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Nincs mit kiexportálni!");
            }
            
        }
        public bool CheckListBoxCountGreaterThanZero(ListBox lb)
        {
            if (lb.Items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
