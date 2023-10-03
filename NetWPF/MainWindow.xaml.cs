using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace NetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client.Client _client;
        
        public MainWindow()
        {
            InitializeComponent();
            _client = new Client.Client(new TcpClient());
        }
        
        private void Connect_OnClick(object sender, RoutedEventArgs e)
        {
            _client.connect(new IPEndPoint(IPAddress.Loopback, 8080));
            _client.writeToServer($"{Username.Text}:{Password.Text}");
        }

        private async void GetQuote_OnClick(object sender, RoutedEventArgs e)
        {
            Quote.Text = await _client.getQuote();
        }
    }
}