using System.Net;
using System.Net.Sockets;
using Warships.Models;

namespace Warships.View
{
    public partial class CreateLocalGamePage : Form
    {
        private readonly Game game = new();
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public CreateLocalGamePage(GameUser user)
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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = false;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(localEndPoint);
            socket.Listen();
            clientSocket = socket.Accept();
            Thread f1f2 = new Thread(openShipPlacigPage);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void openShipPlacigPage(object? obj)
        {
            game.BattleType = Enum.BattleType.server;
            Application.Run(new ShipPlacing(game, clientSocket));
        }

        private void CreateLocalGamePage_Load(object sender, EventArgs e)
        {
            labelIpAddressView.Text = localEndPoint.Address + ":" + localEndPoint.Port;
        }

        private void labelIpAddressView_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label != null)
            {
                Clipboard.SetText(label.Text, TextDataFormat.UnicodeText);
            }
        }

        private void labelIpAddressView_MouseEnter(object sender, EventArgs e)
        {
            toolTipLabel.SetToolTip(labelIpAddressView, "Кликните для копирования");
        }
    }
}
