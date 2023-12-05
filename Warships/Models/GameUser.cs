namespace Warships.Models
{
    [Serializable]
    public class GameUser
    {
        public string Name { get; set; } = string.Empty;
        public Image Ave { get; set; } = Image.FromFile("Resources/1.png");
        public BattleField BattleField { get; set; } = new();
    }
}
