using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Warships.Models;
using static Warships.Models.Miscleanous;
using System.Net.Sockets;

namespace Warships
{
    public partial class Battle : Form
    {
        bool youCanShoot = false;
        bool botCanShoot = false;
        readonly Bot bot = new(Enum.BattleType.vsEasyBot);
        Game game = new();
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        int lastX = 1;
        int lastY = 1;
        public Battle(Game newGame)
        {
            this.game = newGame;
            InitializeComponent();

            label1.Text = game.FirstUser.Name;
            pictureBox3.Image = game.FirstUser.Ave;

            bot = new Bot(game.BattleType);
            label2.Text = bot.Name;
            pictureBox4.Image = bot.Ave;
            BattleLoad();
        }

        public Battle(Game newGame, Socket newSocket)
        {
            game = newGame;
            socket = newSocket;
            InitializeComponent();

            label1.Text = game.FirstUser.Name;
            pictureBox3.Image = game.FirstUser.Ave;

            SendSocetData(game.FirstUser);
            game.SecondUser = GetSocetData<GameUser>();

            label2.Text = game.SecondUser.Name;
            pictureBox4.Image = game.SecondUser.Ave;
            BattleLoad();
        }

        Bitmap myField = new Bitmap("Resources/water-4.jpg");
        Bitmap enemyField = new Bitmap("Resources/water-4.jpg");
        Image redKrest = Image.FromFile("Resources/red_krest.png");
        Image aim = Image.FromFile("Resources/aim.png");
        Image exp = Image.FromFile("Resources/exp.png");
        Image mis = Image.FromFile("Resources/black_krest.png");
        bool oppHit = false;

        private void BattleLoad()
        {
            pictureBox2.Image = enemyField;
            updateBoat(game.FirstUser.BattleField, myField);
            pictureBox1.Image = myField;
            switch (game.BattleType)
            {
                case Enum.BattleType.client:
                    label3.Text = "Выстрел противника!";
                    buttonSaveGame.Visible = false;

                    CheckHitLocalGame();

                    break;
                case Enum.BattleType.server:
                    label3.Text = "Ваш выстрел!";
                    buttonSaveGame.Visible = false;
                    break;
                default:
                    pictureBox2.Image = enemyField;
                    label3.Text = "Ваш выстрел!";
                    youCanShoot = true;
                    ReloadGameboard();
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (game.BattleType != Enum.BattleType.client && game.BattleType != Enum.BattleType.server)
            {
                BotGame();
            }
            else
            {
                LocalGame();
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int X = e.Location.X / 50;
            int Y = e.Location.Y / 50;
            if (X % 50 >= 25) X++;
            if (Y % 50 >= 25) Y++;

            if (X != lastX || Y != lastY)
            {
                Bitmap enemyFieldEnimated = new Bitmap(enemyField);
                using (var graphics = Graphics.FromImage(enemyFieldEnimated))
                {
                    if (game.FirstUser.BattleField.shooted[X, Y] || game.FirstUser.BattleField.forbiddenToShot[X, Y])
                    {
                        graphics.DrawImage(redKrest, X * 50 + 5, Y * 50 + 5, 40, 40);
                    }
                    else
                    {
                        graphics.DrawImage(aim, X * 50 + 5, Y * 50 + 5, 40, 40);
                    }
                }
                pictureBox2.Image = enemyFieldEnimated;
                lastX = X;
                lastY = Y;
            }
        }

        private void ReloadGameboard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    using (var graphics = Graphics.FromImage(enemyField))
                    {
                        if (game.FirstUser.BattleField.hitted[i, j])
                        {
                            graphics.DrawImage(exp, i * 50 + 5, j * 50 + 5, 40, 40);
                        }
                        else
                        {
                            if (game.FirstUser.BattleField.shooted[i, j])
                            {
                                graphics.DrawImage(mis, i * 50 + 5, j * 50 + 5, 40, 40);
                            }
                            if (IsDestroyedWhole(bot.BattleField, i, j))  //если полностью уничтожили корабль противника
                            {
                                Miscleanous.ForbidShotBoat(game.FirstUser.BattleField, i, j);

                                for (int k = 0; k < 10; k++)
                                {
                                    for (int l = 0; l < 10; l++)
                                    {
                                        if (game.FirstUser.BattleField.hitted[k, l] == false
                                            && game.FirstUser.BattleField.forbiddenToShot[k, l] == true)
                                        {
                                            Miscleanous.FillLines(enemyField, k, l);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    using (var graphics = Graphics.FromImage(myField))
                    {
                        if (game.SecondUser.BattleField.hitted[i, j])
                        {
                            graphics.DrawImage(exp, i * 50 + 5, j * 50 + 5, 40, 40);
                        }
                        else
                        {
                            if (game.SecondUser.BattleField.shooted[i, j])
                            {
                                graphics.DrawImage(mis, i * 50 + 5, j * 50 + 5, 40, 40);
                            }
                        }
                    }
                }
            }
        }

        private void BotGame()
        {
            if (youCanShoot && game.FirstUser.BattleField.shooted[lastX, lastY] == false
                && game.FirstUser.BattleField.forbiddenToShot[lastX, lastY] == false)
            {
                Point point = new Point(lastX, lastY);
                bool res = bot.ShotToBot(point);
                game.FirstUser.BattleField.shooted[lastX, lastY] = true;


                using (var graphics = Graphics.FromImage(enemyField))
                {
                    if (res == true) //если попали
                    {
                        graphics.DrawImage(exp, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        game.FirstUser.BattleField.hitted[lastX, lastY] = true;
                        if (IsDestroyedWhole(bot.BattleField, lastX, lastY))  //если полностью уничтожили корабль противника
                        {
                            Miscleanous.ForbidShotBoat(game.FirstUser.BattleField, lastX, lastY);

                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    if (game.FirstUser.BattleField.hitted[i, j] == false
                                        && game.FirstUser.BattleField.forbiddenToShot[i, j] == true)
                                    {
                                        Miscleanous.FillLines(enemyField, i, j);
                                    }
                                }

                            }

                        }
                        if (AllIsDestroyed(bot.BattleField)) { MessageBox.Show("Победа!!!"); this.Close(); }
                    }
                    else
                    {
                        graphics.DrawImage(mis, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        youCanShoot = false;
                        botCanShoot = true;
                        label3.Text = "Выстрел противника!";
                    }
                }



                if (botCanShoot)
                {
                    bool enemyMissed = false;
                    do
                    {
                        Point p = bot.ShotByBot();
                        bot.BattleField.shooted[p.X, p.Y] = true;
                        game.SecondUser.BattleField.shooted[p.X, p.Y] = true;
                        using (var graphics = Graphics.FromImage(myField))
                        {
                            if (game.FirstUser.BattleField.shipPlacement[p.X, p.Y])//если бот попал
                            {
                                game.FirstUser.BattleField.shipDestroyed[p.X, p.Y] = true;
                                bot.BattleField.hitted[p.X, p.Y] = true;
                                if (IsDestroyedWhole(game.FirstUser.BattleField, p.X, p.Y))  //если полностью уничтожили корабль противника
                                {
                                    Miscleanous.ForbidShotBoat(bot.BattleField, p.X, p.Y);
                                }
                                if (AllIsDestroyed(game.FirstUser.BattleField)) { MessageBox.Show("поражение!!!"); this.Close(); }
                                graphics.DrawImage(exp, p.X * 50 + 5, p.Y * 50 + 5, 40, 40);
                            }
                            else
                            {
                                graphics.DrawImage(mis, p.X * 50 + 5, p.Y * 50 + 5, 40, 40);
                                enemyMissed = true;
                            }

                        }
                        pictureBox1.Image = myField;
                        pictureBox1.Update();

                    } while (!enemyMissed);
                    botCanShoot = false;
                    youCanShoot = true;
                    label3.Text = "Ваш выстрел!";
                }
            }
        }

        private void LocalGame()
        {
            if (game.FirstUser.BattleField.shooted[lastX, lastY] == false
                && game.FirstUser.BattleField.forbiddenToShot[lastX, lastY] == false)
            {
                Point point = new Point(lastX, lastY);
                game.FirstUser.BattleField.shooted[lastX, lastY] = true;
                SendSocetData<Point>(point);
                game.SecondUser.BattleField = GetSocetData<BattleField>();

                using (var graphics = Graphics.FromImage(enemyField))
                {
                    if (game.SecondUser.BattleField.shipDestroyed[point.X, point.Y]) //если попали
                    {
                        graphics.DrawImage(exp, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        game.FirstUser.BattleField.hitted[lastX, lastY] = true;
                        if (IsDestroyedWhole(game.SecondUser.BattleField, lastX, lastY))  //если полностью уничтожили корабль противника
                        {
                            Miscleanous.ForbidShotBoat(game.FirstUser.BattleField, lastX, lastY);

                            for (int i = 0; i < 10; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    if (game.FirstUser.BattleField.hitted[i, j] == false
                                        && game.FirstUser.BattleField.forbiddenToShot[i, j] == true)
                                    {
                                        Miscleanous.FillLines(enemyField, i, j);
                                    }
                                }

                            }

                        }
                        if (AllIsDestroyed(game.SecondUser.BattleField))
                        {
                            MessageBox.Show("Победа!!!");
                            SendSocetData<Point>(new Point(-1, -1));
                            socket.Close();
                            this.Close();
                        }
                    }
                    else
                    {
                        graphics.DrawImage(mis, lastX * 50 + 5, lastY * 50 + 5, 40, 40);
                        label3.Text = "Выстрел противника!";
                        CheckHitLocalGame();
                        label3.Text = "Ваш выстрел!";
                    }
                }
            }
        }

        private void CheckHitLocalGame()
        {
            do
            {
                Point point = GetSocetData<Point>();
                if(point.X == -1 && point.Y == -1)
                {
                    MessageBox.Show("Поражение");
                    socket.Close();
                    this.Close();
                }
                using (var graphics = Graphics.FromImage(myField))
                {
                    if (game.FirstUser.BattleField.shipPlacement[point.X, point.Y])
                    {
                        game.FirstUser.BattleField.shipDestroyed[point.X, point.Y] = true;
                        oppHit = true;
                        graphics.DrawImage(exp, point.X * 50 + 5, point.Y * 50 + 5, 40, 40);
                    }
                    else
                    {
                        oppHit = false;
                        graphics.DrawImage(mis, point.X * 50 + 5, point.Y * 50 + 5, 40, 40);
                    }
                    pictureBox1.Image = myField;
                    pictureBox1.Update();
                }

                SendSocetData(game.FirstUser.BattleField);
            }
            while (oppHit);
        }

        private void SendSocetData<T>(T data)
        {
            byte[] dataBuffer;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, data);
                dataBuffer = memoryStream.ToArray();
            }
            socket.Send(dataBuffer);
        }

        private T GetSocetData<T>()
        {
            byte[] receivedData = new byte[10000000];

            // Получаем количество байтов, которые были фактически прочитаны
            int bytesRead = socket.Receive(receivedData);

            // Десериализуем полученные байты в объект
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(receivedData, 0, bytesRead))
            {
                T receivedObject = (T)binaryFormatter.Deserialize(memoryStream);
                return receivedObject;
            }
        }

        private void buttonSaveGame_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "game files (*.game)|*.game";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                game.SecondUser.BattleField = bot.BattleField;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, game);
                stream.Close();
            }
        }

        private void ClearSocket()
        {
            while (socket.Available > 0)
            {
                int bytesRead = socket.Receive(new byte[10000000]);
            }
        }
    }
}
