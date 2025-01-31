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
        public int Rozmiar { get; set; } = 12;
        public FontStyle Styl1 { get; set; } = FontStyles.Normal;
        public FontWeight Styl2 { get; set; } = FontWeights.Normal;
        public WindowRozmiar()
        {
            InitializeComponent();

            for (int i = 6; i < 40; i += 2)
            {
                rozmiaryCzcionek.Add(i);
            }
            DataContext = this;

            string podglad = podgladTextBlock.Text;

            Rozmiar = 20;
        }

        

        private void Button_Click_Zatwierdz(object sender, RoutedEventArgs e)
        {
            Rozmiar = (int)(listVju.SelectedItem);
            podgladTextBlock.FontSize = Rozmiar;
            if(stylCombobox.SelectedIndex == 0)
            {
                Styl1 = FontStyles.Italic;
                Styl2 = FontWeights.Normal;
            }
            else if(stylCombobox.SelectedIndex == 1)
            {
                Styl1 = FontStyles.Normal;
                Styl2 = FontWeights.Bold;
            }
            else if(stylCombobox.SelectedIndex == 2)
            {
                Styl1 = FontStyles.Normal;
                Styl2 = FontWeights.Normal;
            }
            else
            {
                Styl1 = FontStyles.Italic;
                Styl2 = FontWeights.Bold;
            }
            podgladTextBlock.FontStyle = Styl1;
            podgladTextBlock.FontWeight = Styl2;

        }

    }
}
