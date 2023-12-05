using System.Security.Policy;

namespace Warships.Models
{
    internal static class Miscleanous
    {
        public static bool AllIsDestroyed(BattleField bf)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (bf.shipPlacement[i, j] == true && bf.shipDestroyed[i, j] == false) return false;
                }
            return true;
        }
        public static bool IsPossibleToPlaceHere(BattleField bf, int shipSize, bool rotated, int x, int y)
        {
            while (shipSize != 0)
            {
                if (x >= 0 && x < 10 && y >= 0 && y < 10 && bf.forbiddenToPlace[x, y] == false)
                {
                    shipSize--;
                    if (rotated)
                        y++;
                    else
                        x++;
                }
                else
                    return false;
            }
            return true;
        }
        public static void PlaceShip(BattleField bf, int shipSize, bool rotated, int x, int y)
        {
            for (int i = 0; i < shipSize; i++)
            {
                bf.shipPlacement[x, y] = true;
                ForbidAround(bf.forbiddenToPlace, x, y);
                if (rotated) y++;
                else x++;
            }
        }
        public static void ForbidAround(bool[,] forbidden, int x, int y)
        {
            forbidden[x, y] = true;

            if (x > 0) forbidden[x - 1, y] = true;
            if (y > 0) forbidden[x, y - 1] = true;
            if (x < 9) forbidden[x + 1, y] = true;
            if (y < 9) forbidden[x, y + 1] = true;

            if (x > 0 && y > 0) forbidden[x - 1, y - 1] = true;
            if (x > 0 && y < 9) forbidden[x - 1, y + 1] = true;
            if (x < 9 && y > 0) forbidden[x + 1, y - 1] = true;
            if (x < 9 && y < 9) forbidden[x + 1, y + 1] = true;
        }
        public static void FillLines(Bitmap bmp, int x, int y)
        {
            x *= 50;
            y *= 50;
            using (var graphics = Graphics.FromImage(bmp))
            {
                Pen redPen = new Pen(Color.Red, 1);
                graphics.DrawLine(redPen, x + 8, y, x + 49, y + 12);
                graphics.DrawLine(redPen, x + 1, y + 5, x + 50, y + 20);
                graphics.DrawLine(redPen, x + 30, y, x + 49, y + 5);
                graphics.DrawLine(redPen, x + 1, y + 5, x + 49, y + 20);
                graphics.DrawLine(redPen, x + 1, y + 23, x + 50, y + 38);
                graphics.DrawLine(redPen, x + 1, y + 13, x + 49, y + 28);
                graphics.DrawLine(redPen, x + 1, y + 32, x + 49, y + 47);
                graphics.DrawLine(redPen, x + 1, y + 40, x + 30, y + 49);
            }
        }


        public static Image selectShipIcon(int size, bool rotated, bool phantom)
        {
            string path = "Resources//icons//" + size.ToString();
            if (phantom) path += "b";
            else path += "g";
            if (rotated) path += "p";
            else path += "n";
            path += ".png";
            return Image.FromFile(path);
        }

        public static void FillRandomly(BattleField bf)
        {
            Random r = new Random();
            int x, y;
            bool rotated;
            for(var shipSize = 4; shipSize !=0; shipSize--)
            {
                for (int i = 0; i < 5 - shipSize; i++)
                {
                    do
                    {
                        x = r.Next(10);
                        y = r.Next(10);
                        rotated = r.Next() % 2 == 0;
                    } while (!IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                    PlaceShip(bf, shipSize, rotated, x, y);
                }
            }
        }

        public static void FillRandomBeach(BattleField bf)
        {
            Random r = new Random();
            int xPosition = 0, yPosition = 0;
            bool rotated = true;
            for (var shipSize = 4; shipSize != 1; shipSize--)
            {
                for (int i = 0; i < 5 - shipSize; i++)
                {
                    do
                    {
                        switch (r.Next(4))
                        {
                            case 0:
                                yPosition = r.Next(10);
                                xPosition = 0;
                                rotated = true;
                                break;
                            case 1:
                                xPosition = 9;
                                yPosition = r.Next(10);
                                rotated = true;
                                break;
                            case 2:
                                yPosition = 0;
                                xPosition = r.Next(10);
                                rotated = false;
                                break;
                            case 3:
                                yPosition = 9;
                                xPosition = r.Next(10);
                                rotated = false;
                                break;
                        }
                    } while (!IsPossibleToPlaceHere(bf, shipSize, rotated, xPosition, yPosition));
                    PlaceShip(bf, shipSize, rotated, xPosition, yPosition);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    xPosition = r.Next(10);
                    yPosition = r.Next(10);
                    rotated = r.Next() % 2 == 0;
                } while (!IsPossibleToPlaceHere(bf, 1, rotated, xPosition, yPosition));
                PlaceShip(bf, 1, rotated, xPosition, yPosition);
            }
        }

        public static void drawBoat(BattleField bf, int shipSize, Bitmap image, int x, int y, bool rotated)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                Image icon = selectShipIcon(shipSize, rotated, IsPossibleToPlaceHere(bf, shipSize, rotated, x, y));
                int xSize = 50;
                int ySize = 50;
                if (rotated)
                    ySize *= shipSize;
                else
                    xSize *= shipSize;
                graphics.DrawImage(icon, x * 50 + 5, y * 50 + 5, xSize - 10, ySize - 10);
            }
        }

        public static void updateBoat(BattleField bf, Bitmap image)
        {
            bool[,] boatInfo = (bool[,])bf.shipPlacement.Clone();
            using (var graphics = Graphics.FromImage(image))
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int boatLen = 4; boatLen > 1; boatLen--)
                        {
                            bool isRealy = true;
                            for (int iterBoatLen = 0; iterBoatLen < boatLen; iterBoatLen++)
                            {
                                if (i + iterBoatLen < 10)
                                {
                                    if (!boatInfo[i + iterBoatLen, j])
                                    {
                                        isRealy = false;
                                    }
                                }
                                else
                                {
                                    isRealy = false;
                                }
                            }
                            if (isRealy)
                            {
                                drawBoat(bf, boatLen, image, i, j, false);
                                for (int iterBoatLen = 0; iterBoatLen < boatLen; iterBoatLen++)
                                {
                                    boatInfo[i + iterBoatLen, j] = false;
                                };
                            }
                            else
                            {
                                isRealy = true;
                                for (int iterBoatLen = 0; iterBoatLen < boatLen; iterBoatLen++)
                                {
                                    if (j + iterBoatLen < 10)
                                    {
                                        if (!boatInfo[i, j + iterBoatLen])
                                        {
                                            isRealy = false;
                                        }
                                    }
                                    else
                                    {
                                        isRealy = false;
                                    }
                                }
                                if (isRealy)
                                {
                                    drawBoat(bf, boatLen, image, i, j, true);
                                    for (int iterBoatLen = 0; iterBoatLen < boatLen; iterBoatLen++)
                                    {
                                        boatInfo[i, j + iterBoatLen] = false;
                                    };
                                }
                            }
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (boatInfo[i, j])
                        {
                            drawBoat(bf, 1, image, i, j, false);
                        }
                    }
                }
            }
        }
    }
}
