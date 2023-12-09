using Warships.Models;

namespace Warships.View
{
    public partial class LocalGameSelect : Form
    {
        private readonly Game game = new();

        public LocalGameSelect(GameUser user)
        {
            InitializeComponent();
            this.game.FirstUser = user;
        }

        private void buttonToStartPage_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new(openStartPage);
            f1f2.Start();
            Close();
        }

        public void openStartPage(object? obj)
        {
            Application.Run(new StartPage(game.FirstUser));
        }

        private void buttonCreateGame_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new(CreateLocalGame);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void CreateLocalGame(object? obj)
        {
            Application.Run(new CreateLocalGamePage(game.FirstUser));
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new(ConnectLocalGame);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void ConnectLocalGame(object? obj)
        {
            Application.Run(new ConnectLocalGamePage(game.FirstUser));
        }
    }
}
