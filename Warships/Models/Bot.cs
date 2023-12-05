using Warships.Enum;

namespace Warships.Models
{
    public class Bot
    {
        public string Name { get; set; } = string.Empty;
        public Image Ave { get; set; } = Image.FromFile("Resources/1.png");
        public BattleField BattleField { get; set; } = new();
        public BattleType Difficulty { get; set; } = BattleType.vsEasyBot;

        public Bot(BattleType difficulty)
        {
            Difficulty = difficulty;
            Miscleanous.FillRandomly(BattleField);
        }

        public bool ShotToBot(Point p)
        {
            if (BattleField.shipPlacement[p.X, p.Y])
            {
                BattleField.shipDestroyed[p.X, p.Y] = true;
                return true;
            }
            else
                return false;
        }

        private int lastX, lastY;
        public Point ShotByBot()
        {

            Random r = new Random();
            int x = 0, y = 0;
            switch (Difficulty)
            {
                case BattleType.vsMediumBot:
                    if (BattleField.hitted[lastX, lastY])
                    {
                        if(lastX + 1 < 10)
                        {
                            if(!BattleField.shooted[lastX + 1, lastY] && !BattleField.forbiddenToShot[lastX + 1, lastY])
                            {
                                BattleField.shooted[x, y] = true;
                                return new Point(lastX + 1, lastY);
                            }
                        }
                        if (lastX - 1 >= 0)
                        {
                            if (!BattleField.shooted[lastX - 1, lastY] && !BattleField.forbiddenToShot[lastX - 1, lastY])
                            {
                                BattleField.shooted[x, y] = true;
                                return new Point(lastX - 1, lastY);
                            }
                        }
                        if (lastY + 1 < 10)
                        {
                            if (!BattleField.shooted[lastX, lastY + 1] && !BattleField.forbiddenToShot[lastX, lastY + 1])
                            {
                                BattleField.shooted[x, y] = true;
                                return new Point(lastX, lastY + 1);
                            }
                        }
                        if (lastY - 1 >= 0)
                        {
                            if (!BattleField.shooted[lastX, lastY - 1] && !BattleField.forbiddenToShot[lastX, lastY - 1])
                            {
                                BattleField.shooted[x, y] = true;
                                return new Point(lastX, lastY - 1);
                            }
                        }
                    }
                    do
                    {
                        x = r.Next(10);
                        y = r.Next(10);
                        lastX = x;
                        lastY = y;
                    }
                    while (BattleField.shooted[x, y] || BattleField.forbiddenToShot[x, y]);
                    BattleField.shooted[x, y] = true;
                    return new Point(x, y);
                case BattleType.vsHardBot:
                case BattleType.vsEasyBot:
                default:
                    do
                    {
                        x = r.Next(10);
                        y = r.Next(10);
                    }
                    while (BattleField.shooted[x, y] || BattleField.forbiddenToShot[x, y]);
                    BattleField.shooted[x, y] = true;
                    return new Point(x, y);
            }

        }

    }
}
