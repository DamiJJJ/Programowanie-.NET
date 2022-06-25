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

namespace Zadanie_3
{
    public partial class MainWindow : Window
    {
        Model model = new Model();
        public MainWindow()
        {
            DataContext = model;
            InitializeComponent();
        }

        private void Edytuj(object sender, RoutedEventArgs e)
        {
            ListBox lista = (ListBox)this.FindName("ListaAlbumów");
            Album wybrany = (Album)lista.SelectedItem;
            if (wybrany != null)
                new WidokAlbumu(wybrany).Show();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            new WidokAlbumu(
                model.NowyAlbum()
                ).Show();
        }
    }
}
