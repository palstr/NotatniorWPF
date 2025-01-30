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

namespace NotatniorWPF
{
    /// <summary>
    /// Logika interakcji dla klasy WindowRozmiar.xaml
    /// </summary>
    public partial class WindowRozmiar : Window
    {
        public List<int> rozmiaryCzcionek { get; set; } = new List<int>();
        public WindowRozmiar()
        {
            InitializeComponent();
            
            for(int i=6; i>40; i += 2)
            {
                rozmiaryCzcionek.Add(i);
            }
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
