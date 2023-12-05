using Warships.Models;

namespace Warships.View
{
    public partial class SelectBotLevelPage : Form
    {
        private readonly Game game = new();
        Thread? f1f2;
        public SelectBotLevelPage(GameUser user)
        {
            InitializeComponent();
            game.FirstUser = user;
        }

        private void buttonToStartPage_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openStartPage);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        public void openStartPage(object? obj)
        {
            Application.Run(new StartPage(game.FirstUser));
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.Close();
            f1f2 = new Thread(openShipPlacingPage);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
        }

        public void openShipPlacingPage(object? obj)
        {
            if (LightLevelDifficulty.Checked)
            {
                game.BattleType = Enum.BattleType.vsEasyBot;
            }
            if (MediumLevelDifficulty.Checked)
            {
                game.BattleType = Enum.BattleType.vsMediumBot;
            }
            if (HardLevelDifficulty.Checked)
            {
                game.BattleType = Enum.BattleType.vsHardBot;
            }
            Application.Run(new ShipPlacing(game));
        }
    }
}
