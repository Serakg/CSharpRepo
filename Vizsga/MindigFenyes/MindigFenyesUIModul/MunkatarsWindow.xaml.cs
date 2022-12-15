using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MunkatarsWindow : Window
    {
        public MunkatarsWindow()
        {
            InitializeComponent();
            ComboBoxFeltolt();
        }

        private void munkasWindowBackToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            munkatarsWindow.Close();
            mainWindow.Show();
        }

        private void ComboBoxFeltolt()
        {
            Adataim a = new Adataim();
            foreach (var munkas in a.Munkas)
            {
                munkasComboBox.Items.Add(munkas.Nev);
            }
        }

        private void munkasLekerdezesBtn_Click(object sender, RoutedEventArgs e)
        {
            munkakListbox.Items.Clear();
            Adataim a = new();
            var lekerdezesEredmeny = a.Feladatoks.Where(x => x.Szerelo.TrimEnd() == munkasComboBox.SelectedItem.ToString()).ToList();
            foreach (var feladat in lekerdezesEredmeny)
            {
                munkakListbox.Items.Add(feladat.Tipus.TrimEnd() + " - " + feladat.Helyszin.TrimEnd());
            }
            if (lekerdezesEredmeny.Count == 0)
            {
                munkakListbox.Items.Add("Nincs ilyen eredmény!");
            }
        }

        private void munkasExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Adataim a = new();
                var lekerdezesEredmeny = a.Feladatoks.Where(x => x.Szerelo.TrimEnd() == munkasComboBox.SelectedItem.ToString()).ToList();
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
                if (CheckListBoxCountGreaterThanZero(munkakListbox) == true)
                {
                    string jsonFile = JsonConvert.SerializeObject(lbiList, Formatting.Indented);
                    string logfile = @"C:\Users\gabser\OneDrive - ASSA ABLOY Group\Documents\Webuni\Vizsga\MindigFenyes\ListaExport\MunkasLog" + ".json";
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
            }
            catch (InvalidOperationException) 
            {
                MessageBox.Show("Nincs mit kiexportálni!");
            }

        }
        public static bool CheckListBoxCountGreaterThanZero(ListBox lb)
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
