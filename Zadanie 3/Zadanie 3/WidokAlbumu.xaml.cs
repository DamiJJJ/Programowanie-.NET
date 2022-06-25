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

namespace Zadanie_3
{
    public partial class WidokAlbumu : Window
    {
        public WidokAlbumu(Album album)
        {
            DataContext = album;
            InitializeComponent();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
