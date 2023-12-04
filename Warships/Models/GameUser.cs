using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warships.Models
{
    public class GameUser
    {
        public string Name { get; set; } = string.Empty;
        public Image Ave { get; set; } = Image.FromFile("Resources/1.png");
        public BattleField BattleField { get; set; } = new();
    }
}
