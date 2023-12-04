using Warships.Enum;

namespace Warships.Models
{
    [Serializable]
    public class Game
    {
        public GameUser FirstUser { get; set; } = new();
        public GameUser SecondUser { get; set; } = new();
        public BattleType BattleType { get; set; } = BattleType.vsEasyBot;
    }
}
