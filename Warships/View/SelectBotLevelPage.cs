using Warships.Models;

namespace Warships.View
{
    public partial class SelectBotLevelPage : Form
    {
        private readonly Game game = new();
        public SelectBotLevelPage(GameUser user)
        {
            InitializeComponent();
            game.FirstUser = user;
        }

        private void buttonToStartPage_Click(object sender, EventArgs e)
        {
            StartPage startPage = new(game.FirstUser);
            startPage.Show();
            this.Close();
        }

        private void buttonNext_Click(object sender, EventArgs e)
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
            ShipPlacing layout = new(game);
            layout.Show();
            this.Close();
        }
    }
}
