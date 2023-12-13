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

        private void buttonStartBotGame_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new Thread(openBotGame);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void openBotGame(object? obj)
        {
            user.Ave = node.Value;
            user.Name = textBoxUserName.Text;
            Application.Run(new SelectBotLevelPage(user));
        }

        private void buttonStartLocalGame_Click(object sender, EventArgs e)
        {
            Thread f1f2 = new Thread(openLocalGame);
            f1f2.SetApartmentState(ApartmentState.STA);
            f1f2.Start();
            Close();
        }

        public void openLocalGame(object? obj)
        {
            user.Ave = node.Value;
            user.Name = textBoxUserName.Text;
            Application.Run(new LocalGameSelect(user));
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
            //Добавление своего аватара, работает, просто не нужно
            /*
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
            */
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
                Thread f1f2 = new(openBattle);
                f1f2.SetApartmentState(ApartmentState.STA);
                f1f2.Start();
                Close();
            }

        }

        public void openBattle(object? obj)
        {
            Application.Run(new Battle(game));
        }
    }
}