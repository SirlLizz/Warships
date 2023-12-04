namespace Warships.Models
{
    [Serializable]
    public class Game
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public Image FirstAve { get; set; } = Image.FromFile("Resources/1.png");
        public Image SecondAve { get; set; } = Image.FromFile("Resources/1.png");
        public BattleField FirstBF { get; set; } = new();
        public BattleField SecondBF { get; set; } = new();
    }
}
