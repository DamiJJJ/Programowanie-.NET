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
    public partial class OknoMarka : Window
    {
        public OknoMarka(System.Xml.XmlElement marka)
        {
            DataContext = marka;
            Console.WriteLine(marka);
            InitializeComponent();
        }
        private void WyświetlModele(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((FrameworkElement)sender).Parent;
            ListBox lista = (ListBox)parent.FindName("Marka");
            new OknoModel((System.Xml.XmlElement)lista.SelectedItem).Show();
        }
    }
}
