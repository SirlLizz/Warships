using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Warships.Models;
using static Warships.Models.Miscleanous;

namespace Warships
{
    public partial class Battle : Form
    {
        bool youCanShoot = false;
        bool botCanShoot = false;
        Bot bot;
        Game game;

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
        }

        Bitmap myField = new Bitmap("Resources/water-4.jpg");
        Bitmap enemyField = new Bitmap("Resources/water-4.jpg");
        Image redKrest = Image.FromFile("Resources/red_krest.png");
        Image aim = Image.FromFile("Resources/aim.png");
        Image exp = Image.FromFile("Resources/exp.png");
        Image mis = Image.FromFile("Resources/black_krest.png");

        private void Battle_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = enemyField;
            updateBoat(game.FirstUser.BattleField, myField);
            pictureBox1.Image = myField;
            if (game.BattleType != Enum.BattleType.Local)
            {
                pictureBox2.Image = enemyField;
                label3.Text = "Ваш выстрел!";
                youCanShoot = true;

                ReloadGameboard();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(game.BattleType != Enum.BattleType.Local)
            {
                LocalGame();
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int X = e.Location.X;
            int Y = e.Location.Y;
            X = X / 50;
            Y = Y / 50;
            if (X % 50 >= 25) X++;
            if (Y % 50 >= 25) Y++;

            if (X != lastX || Y != lastY)
            {
                Bitmap enemyFieldEnimated = new Bitmap(enemyField);
                using (var graphics = Graphics.FromImage(enemyFieldEnimated))
                {
                    if (game.FirstUser.BattleField.shooted[X, Y])
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

        private void LocalGame()
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
    }
}
