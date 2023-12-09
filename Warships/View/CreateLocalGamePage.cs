using Warships.Models;

namespace Warships.View
{
    public partial class CreateLocalGamePage : Form
    {
        private readonly Game game = new();

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
    }
}
