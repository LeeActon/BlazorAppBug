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
using Test;

namespace WpfApp
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        public MainWindow()
            {
            InitializeComponent();
            }

        private void TestIt_Click(object sender, RoutedEventArgs e)
            {
            Crypto crypto = new Crypto();
            byte[] salt = crypto.Random(512 / 8);
            Timer timer = new Timer();

            double seconds = timer.Run(() =>
            {
                byte[] bytes = crypto.GetHashBytes("Test password", salt, 2000, 256 / 8);
            });

            this.Time.Text = $"Time = {seconds} seconds";
            }
        }
    }
