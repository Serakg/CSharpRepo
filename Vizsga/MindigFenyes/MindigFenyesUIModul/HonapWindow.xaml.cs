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
    /// Interaction logic for HonapWindow.xaml
    /// </summary>
    public partial class HonapWindow : Window
    {
        string honapSzama = "";

        public HonapWindow()
        {
            InitializeComponent();
            ComboBoxFeltolt();
        }

        private void honapWindowBackToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            honapWindow.Close();
            mainWindow.Show();
        }

        private void ComboBoxFeltolt()
        {
            List<string> honapok = new List<string>
            {
                "Január",
                "Február",
                "Március",
                "Április",
                "Május",
                "Június",
                "Augusztus",
                "Szeptember",
                "Október",
                "November",
                "December"
            };

            List<string> evek = new List<string>
            {
                "2020",
                "2021",
                "2022"
            };

            foreach (string honap in honapok)
            {
                honapHonapokComboBox.Items.Add(honap);
            }
            foreach (string ev in evek)
            {
                honapEvekComboBox.Items.Add(ev);
            }
        }

        private void honapLekerdezesBtn_Click(object sender, RoutedEventArgs e)
        {
            honapListbox.Items.Clear();
            Adataim a = new();
            switch (honapHonapokComboBox.SelectedItem)
            {
                case ("Január"):
                    honapSzama = "01";
                    break;
                case ("Február"):
                    honapSzama = "02";
                    break;
                case ("Március"):
                    honapSzama = "03";
                    break;
                case ("Április"):
                    honapSzama = "04";
                    break;
                case ("Május"):
                    honapSzama = "05";
                    break;
                case ("Június"):
                    honapSzama = "06";
                    break;
                case ("Július"):
                    honapSzama = "07";
                    break;
                case ("Augusztus"):
                    honapSzama = "08";
                    break;
                case ("Szeptember"):
                    honapSzama = "09";
                    break;
                case ("Október"):
                    honapSzama = "10";
                    break;
                case ("November"):
                    honapSzama = "11";
                    break;
                case ("December"):
                    honapSzama = "12";
                    break;
            }
            var lekerdezesEredmeny = a.Feladatoks.Where(x => x.BefejezDatum.ToString().Substring(0, 4) == honapEvekComboBox.SelectedItem && x.BefejezDatum.ToString().Substring(5, 2) == honapSzama).ToList();
            foreach (var feladat in lekerdezesEredmeny)
            {
                honapListbox.Items.Add(feladat.Tipus.TrimEnd() + " - " + feladat.Helyszin.TrimEnd());
            }
            if (lekerdezesEredmeny.Count == 0)
            {
                honapListbox.Items.Add("Nincs ilyen eredmény!");
            }
        }

        private void honapExportBtn_Click(object sender, RoutedEventArgs e)
        {
            Adataim a = new();
            var lekerdezesEredmeny = a.Feladatoks.Where(x => x.BefejezDatum.ToString().Substring(0, 4) == honapEvekComboBox.SelectedItem && x.BefejezDatum.ToString().Substring(5, 2) == honapSzama).ToList();
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
            if (CheckListBoxCountGreaterThanZero(honapListbox) == true)
            {
                string jsonFile = JsonConvert.SerializeObject(lbiList, Formatting.Indented);
                string logfile = @"C:\Users\gabser\OneDrive - ASSA ABLOY Group\Documents\Webuni\Vizsga\MindigFenyes\ListaExport\HonapLog" + ".json";
                TextWriter? txt;
                if (File.Exists(logfile))
                {
                    txt = new StreamWriter(logfile, true);
                }
                else
                {
                    txt = new StreamWriter(logfile);
                }

                txt.WriteLine(jsonFile);
                txt.Close();
                MessageBox.Show("Sikeres exportálás!");
            }
            else
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