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

        private int lastX = 0, lastY = 0;
        private bool matrixSearch = true;
        public Point ShotByBot()
        {

            Random r = new Random();
            switch (Difficulty)
            {
                case BattleType.vsMediumBot:
                    if (BattleField.hitted[lastX, lastY])
                    {
                        Point? nearbyPoint = CheckNearbyPoint();
                        if(nearbyPoint != null)
                        {
                            BattleField.shooted[nearbyPoint.Value.X, nearbyPoint.Value.X] = true;
                            return (Point)nearbyPoint;
                        }
                    }
                    Point pointMedium = GetRandomAvailablePoint();
                    lastX = pointMedium.X;
                    lastY = pointMedium.Y;
                    BattleField.shooted[lastX, lastY] = true;
                    return pointMedium;
                case BattleType.vsHardBot:
                    if(!BattleField.shooted[0, 0])
                    {
                        BattleField.shooted[0, 0] = true;
                        return new Point(0, 0);
                    }
                    if (BattleField.hitted[lastX, lastY])
                    {
                        Point? nearbyPoint = CheckNearbyPoint();
                        if (nearbyPoint != null)
                        {
                            BattleField.shooted[nearbyPoint.Value.X, nearbyPoint.Value.X] = true;
                            return (Point)nearbyPoint;
                        }
                    }

                    do
                    {
                        if(lastY <= 9 && matrixSearch)
                        {
                            lastX += 2;
                            if (lastX > 9)
                            {
                                lastX = (lastX + 1) % 2;
                                lastY += 1;
                            }
                        }

                        if (lastY > 9 || !matrixSearch)
                        {
                            matrixSearch = false;
                            Point pointHard = GetRandomAvailablePoint();
                            lastX = pointHard.X;
                            lastY = pointHard.Y;
                            BattleField.shooted[lastX, lastY] = true;
                            return pointHard;
                        }
                    }
                    while (BattleField.shooted[lastX, lastY] || BattleField.forbiddenToShot[lastX, lastY]);
                    BattleField.shooted[lastX, lastY] = true;
                    return new Point(lastX, lastY);
                case BattleType.vsEasyBot:
                default:
                    Point pointEasy = GetRandomAvailablePoint();
                    BattleField.shooted[pointEasy.X, pointEasy.Y] = true;
                    return pointEasy;
            }

        }

        private Point? CheckNearbyPoint()
        {
            if (lastX + 1 < 10)
            {
                if (!BattleField.shooted[lastX + 1, lastY] && !BattleField.forbiddenToShot[lastX + 1, lastY])
                {
                    BattleField.shooted[lastX + 1, lastY] = true;
                    return new Point(lastX + 1, lastY);
                }
            }
            if (lastX - 1 >= 0)
            {
                if (!BattleField.shooted[lastX - 1, lastY] && !BattleField.forbiddenToShot[lastX - 1, lastY])
                {
                    BattleField.shooted[lastX - 1, lastY] = true;
                    return new Point(lastX - 1, lastY);
                }
            }
            if (lastY + 1 < 10)
            {
                if (!BattleField.shooted[lastX, lastY + 1] && !BattleField.forbiddenToShot[lastX, lastY + 1])
                {
                    BattleField.shooted[lastX, lastY + 1] = true;
                    return new Point(lastX, lastY + 1);
                }
            }
            if (lastY - 1 >= 0)
            {
                if (!BattleField.shooted[lastX, lastY - 1] && !BattleField.forbiddenToShot[lastX, lastY - 1])
                {
                    BattleField.shooted[lastX, lastY - 1] = true;
                    return new Point(lastX, lastY - 1);
                }
            }
            return null;
        }

        private Point GetRandomAvailablePoint()
        {
            List<Point> availablePoints = GetAvailablePoints();
            Random r = new();
            if (availablePoints.Count != 0)
            {
                return availablePoints[r.Next(availablePoints.Count)];
            }
            return new Point(0, 0);
        }

        private List<Point> GetAvailablePoints()
        {
            List<Point> result = new();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(!(BattleField.shooted[i, j] || BattleField.forbiddenToShot[i, j]))
                    {
                        result.Add(new Point(i,j));
                    }
                }
            }
            return result;
        }

    }
}
