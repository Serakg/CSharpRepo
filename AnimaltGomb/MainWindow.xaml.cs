using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimaltGomb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int angel = 15;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainBtn_Click(object sender, RoutedEventArgs e)
        {
           
            mainBtn.LayoutTransform= new RotateTransform(angel);
            angel += 15;
        }
    }
}
