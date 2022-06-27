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
using System.Windows.Shapes;

namespace Zadanie_4
{
    /// <summary>
    /// Logika interakcji dla klasy OknoRodzaj.xaml
    /// </summary>
    public partial class OknoRodzaj : Window
    {
        public OknoRodzaj(System.Xml.XmlElement rodzaj)
        {
            DataContext = rodzaj;
            Console.WriteLine(rodzaj);
            InitializeComponent();
        }

        private void DostępneModele(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((FrameworkElement)sender).Parent;
            ListBox lista = (ListBox)parent.FindName("Marka");
            new OknoMarka((System.Xml.XmlElement)lista.SelectedItem).Show();
        }
    }
}
