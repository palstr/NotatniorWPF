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
    /// Logika interakcji dla klasy WindowKolor.xaml
    /// </summary>
    public partial class WindowKolor : Window
    {
        public byte R { get; set; } = 0;
        public byte G { get; set; } = 0;
        public byte B { get; set; } = 0;

        public WindowKolor()
        {
            InitializeComponent();
        }

        private void Button_ClickZatwierdz(object sender, RoutedEventArgs e)
        {
            byte r, g, b;

            if(byte.TryParse(rTextBox.Text, out r))
            {
                R = r;
            }
            if(byte.TryParse(gTextBox.Text, out g))
            {
                G = g;
            }
            if(byte.TryParse(bTextBox.Text, out b))
            {
                B = b;
            }


            Close();
        }
    }
}
