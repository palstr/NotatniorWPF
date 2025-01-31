using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace NotatniorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string NazwaPliku { get; set; } = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_Zapisz(object sender, RoutedEventArgs e)
        {
            if (NazwaPliku == "")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "pliki tekstowe | *.txt";
                if (saveFileDialog.ShowDialog() == true)
                {
                    //ZAPIS DO PLIKU
                    NazwaPliku = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, wpisaneTextBox.Text);
                }

            }
            else
            {
                File.WriteAllText(NazwaPliku, wpisaneTextBox.Text);
            }
            Title = NazwaPliku;
        }

        private void MenuItem_Click_Otworz(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            MessageBoxResult result = MessageBox.Show("Czy chcesz wcześniej to zapisać?",
                                                      "Pytanie",
                                                      MessageBoxButton.YesNoCancel,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuItem_Click_Zapisz(sender, e);
            }
            else if (result == MessageBoxResult.Cancel)
            {
                return;
            }

            if (openFileDialog.ShowDialog() == true)
            {
                NazwaPliku = openFileDialog.FileName;
                wpisaneTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                Title = NazwaPliku;
            }
        }

        private void MenuItem_Click_Nowy(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz wcześniej to zapisać?",
                                                      "Pytanie",
                                                      MessageBoxButton.YesNoCancel,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MenuItem_Click_Zapisz(sender, e);
            }
            else if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            NazwaPliku = "";
            wpisaneTextBox.Text = "";
            Title = "Notatnik";
        }

        private void TextChange_AktualizacjaTytulu(object sender, TextChangedEventArgs e)
        {
            if (Title.Contains("*") == false)
            {
                Title = "* " + Title;
            }

        }

        private void MenuItem_Click_Zamknij(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result1 = MessageBox.Show("Czy chcesz wcześniej to zapisać?",
                                                      "Pytanie",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            if (result1 == MessageBoxResult.Yes)
            {
                MenuItem_Click_Zapisz(sender, e);
            }
            else if (result1 == MessageBoxResult.No)
            {
                Close();
            }


        }

        private void MenuItem_Click_Czerwona(object sender, RoutedEventArgs e)
        {
            if (wpisaneTextBox != null)
            {
                wpisaneTextBox.Foreground = Brushes.Red;
            }
        }

        private void DzienNoc_Zaznacz(object sender, RoutedEventArgs e)
        {
            if(wpisaneTextBox != null)
            {
                wpisaneTextBox.Background = Brushes.White;
                wpisaneTextBox.Foreground = Brushes.Black;

            }
        }

        private void DzienNoc_Odznacz(object sender, RoutedEventArgs e)
        {
            if (wpisaneTextBox != null)
            {
                wpisaneTextBox.Background = Brushes.Black;
                wpisaneTextBox.Foreground = Brushes.White;

            }
        }

        private void MenuItem_ClickAutor(object sender, RoutedEventArgs e)
        {
            //MODALNE - BLOKUJE
            WindowAutor windowAutor = new WindowAutor();
            windowAutor.ShowDialog();
        }

        private void MenuItem_ClickAppka(object sender, RoutedEventArgs e)
        {
            //NIEMODALNE - NIE BLOKUJE
            WindowAppka windowApka = new WindowAppka();
            windowApka.Show();
        }

        private void MenuItem_ClickDowolnyKolor(object sender, RoutedEventArgs e)
        {
            WindowKolor windowKolor = new WindowKolor();
            windowKolor.ShowDialog();
            byte r = windowKolor.R;
            byte g = windowKolor.G;
            byte b = windowKolor.B;

            Color color = Color.FromRgb(r, g, b);

            wpisaneTextBox.Background = new SolidColorBrush(color);
        }

        private void MenuItem_ClickRozmiar(object sender, RoutedEventArgs e)
        {
            WindowRozmiar windowRozmiar = new WindowRozmiar();
            windowRozmiar.ShowDialog();
            wpisaneTextBox.FontSize = windowRozmiar.Rozmiar;
            wpisaneTextBox.FontStyle = windowRozmiar.Styl1;
            wpisaneTextBox.FontWeight = windowRozmiar.Styl2;
        }

        private void MenuItem_Zawijaj(object sender, RoutedEventArgs e)
        {
            if(wpisaneTextBox != null)
            {
                wpisaneTextBox.TextWrapping = TextWrapping.Wrap;
            }

        }

        private void MenuItem_NieZawijaj(object sender, RoutedEventArgs e)
        {
            if (wpisaneTextBox != null)
            {
                wpisaneTextBox.TextWrapping = TextWrapping.NoWrap;
            }
        }
    }
}
