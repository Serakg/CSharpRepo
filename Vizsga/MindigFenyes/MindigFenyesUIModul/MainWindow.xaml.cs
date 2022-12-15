using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindigFenyesUIModul
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void munkasAltalVegzetMunka_Click(object sender, RoutedEventArgs e)
        {
            MunkatarsWindow mw = new MunkatarsWindow();
            mw.Show();
            mainWindow.Close();
        }

        private void honapbanElvegzettOsszesMunka_Click(object sender, RoutedEventArgs e)
        {
            HonapWindow hw = new HonapWindow();
            hw.Show();
            mainWindow.Close();
        }

        private void munkaCsoportSzerintiLista_Click(object sender, RoutedEventArgs e)
        {
            FeladatCsoportWindow fw = new FeladatCsoportWindow();
            fw.Show();
            mainWindow.Close();
        }
    }
}
