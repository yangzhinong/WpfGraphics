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

namespace WpfApp7.Chapter14
{
    /// <summary>
    /// Interaction logic for Viewport2DVisual3DTest.xaml
    /// </summary>
    public partial class Viewport2DVisual3DTest : Window
    {
        public Viewport2DVisual3DTest()
        {
            InitializeComponent();
        }

        private void ForntButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am a 2D button on the front surface.");
        }
    }
}
