using System.Net;
using System.Net.Sockets;
using Warships.Models;

namespace Warships.View
{
    public partial class ConnectLocalGamePage : Form
    {
        private readonly Game game = new();
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public ConnectLocalGamePage(GameUser user)
        {
            InitializeComponent();
            game.FirstUser = user;
        }

        private void buttonToStartPage_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new Thread(openStartPage);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void openStartPage(object? obj)
        {
            Application.Run(new StartPage(game.FirstUser));
        }

        private void buttonConnect_ClickAsync(object sender, EventArgs e)
        {
            string ipAddress = textBoxIpAddress.Text;
            string[] parts = ipAddress.Split(':');

            if (parts.Length == 2)
            {
                string address = parts[0];
                int port;

                if (int.TryParse(parts[1], out port))
                {
                    try
                    {
                        serverSocket.Connect(address, port);
                        Thread f1f2 = new Thread(openShipPlacigPage);
                        f1f2.SetApartmentState(ApartmentState.STA);
                        f1f2.Start();
                        Close();
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show($"Не удалось установить подключение с {serverSocket.RemoteEndPoint}");
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка при разборе порта.");
                }
            }
            else
            {
                MessageBox.Show("Строка должна быть ввиде '*:*'");
            }
        }

        public void openShipPlacigPage(object? obj)
        {
            game.BattleType = Enum.BattleType.client;
            Application.Run(new ShipPlacing(game, serverSocket));
        }
    }
}
