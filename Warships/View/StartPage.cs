namespace Warships
{
    using System.Drawing;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    using System.Windows.Forms;
    using Warships.Models;
    using Warships.View;

    public partial class StartPage : Form
    {
        private readonly GameUser user = new();
        private readonly LinkedList<Image> collectionImage = new();
        private LinkedListNode<Image> node;

        public StartPage()
        {
            InitializeComponent();
            string[] filePaths = Directory.GetFiles("Resources/avatars", "*.png");
            foreach (var file in filePaths)
            {
                collectionImage.AddFirst(Image.FromFile(file));
            }

            var findObject = collectionImage.Find(collectionImage.First());

            if (findObject != null)
            {
                node = findObject;
            }
            else
            {
                throw new Exception();
            }

            pictureAvatar.Image = collectionImage.First();
        }

        public StartPage(GameUser user)
        {
            InitializeComponent();
            textBoxUserName.Text = user.Name;

            string[] filePaths = Directory.GetFiles("Resources/avatars", "*.png");
            foreach (var file in filePaths)
            {
                collectionImage.AddFirst(Image.FromFile(file));
            }
            var findObject = collectionImage.Find(user.Ave);

            if (findObject != null)
            {
                node = findObject;
                pictureAvatar.Image = user.Ave;
            }
            else
            {
                findObject = collectionImage.Find(collectionImage.First());

                if (findObject != null)
                {
                    node = findObject;
                }
                else
                {
                    throw new Exception();
                }
                if (user.Ave != null)
                {
                    pictureAvatar.Image = user.Ave;
                }
                else
                {
                    pictureAvatar.Image = collectionImage.First();
                }

            }

        }

        Thread? f1f2;
        private void buttonStartBotGame_Click(object sender, EventArgs e)
        {
            f1f2 = new Thread(openBotGame);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            this.Close();
        }

        public void openBotGame(object? obj)
        {
            user.Ave = node.Value;
            user.Name = textBoxUserName.Text;
            Application.Run(new SelectBotLevelPage(user));
        }

        private void buttonStartLocalGame_Click(object sender, EventArgs e)
        {
            /*            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                        IPAddress ipAddr = ipHost.AddressList[0];
                        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

                        Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        label1.Text = "Ваш IP: " + ipHost.AddressList[1] + "/" + ipEndPoint.Port;
                        buttonStartBotGame.Hide();
                        buttonStartLocalGame.Hide();
                        button3.Hide();
                        textBoxUserName.Hide();
                        textBox2.Hide();
                        playerName = textBoxUserName.Text;

                        button4.Show();
                        try
                        {
                            sListener.Bind(ipEndPoint);
                            sListener.Listen(1);
                            label1.Text = "fnjafbalkfa";
                            //Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                            // Программа приостанавливается, ожидая входящее соединение
                            //Socket handler = sListener.Accept();
                            string data = null;
                        }
                        catch (Exception ex) { }*/
        }

        private void buttonDeveloperInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение разработал я", "Сведения о разработчиках");
        }

        private void buttonSystemInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия приложения: 0.0.0.1", "Сведения о системе");
        }

        private void buttonPreviousAvatar_Click(object sender, EventArgs e)
        {
            if (node.Previous != null)
            {
                node = node.Previous;
                pictureAvatar.Image = node.Value;
            }
        }

        private void buttonNextAvatar_Click(object sender, EventArgs e)
        {
            if (node.Next != null)
            {
                node = node.Next;
                pictureAvatar.Image = node.Value;
            }
        }

        private void pictureAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    collectionImage.AddFirst(Image.FromFile(openFileDialog.FileName));
                    var findObject = collectionImage.Find(collectionImage.First());

                    if (findObject != null)
                    {
                        node = findObject;
                    }
                    else
                    {
                        throw new Exception();
                    }

                    pictureAvatar.Image = collectionImage.First();
                }
            }
        }

        Game? game;
        private void buttonLoadBotGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "game files (*.game)|*.game";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                game = (Game)formatter.Deserialize(stream);
                stream.Close();
            }
            if (game != null)
            {
                f1f2 = new Thread(openBattle);
                f1f2.SetApartmentState(ApartmentState.STA);
                f1f2.Start();
                this.Close();
            }

        }

        public void openBattle(object? obj)
        {
            Application.Run(new Battle(game));
        }
    }
}