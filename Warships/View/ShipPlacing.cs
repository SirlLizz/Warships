﻿using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using static Warships.Models.Miscleanous;
using Warships.Models;

namespace Warships
{
    public partial class ShipPlacing : Form
    {
        Game g;
        BattleField bf = new BattleField();

        Bitmap RawOcean = new Bitmap("Resources/water-4.jpg");
        Pen blackPen = new Pen(Color.Black, 3);
        Image ship_1 = Image.FromFile("Resources/1.png");

        public ShipPlacing(Game g)
        {
            this.g = g;

            InitializeComponent();
            updateLayout();
        }


        int[] shipCount = new int[4] { 4, 3, 2, 1 };

        bool dragActive = true;
        bool rotated = false;
        int shipSize = 1;
        int lastX = 1;
        int lastY = 1;
        public void updateLayout()
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (bf.forbiddenToPlace[i, j] == true && bf.shipPlacement[i, j] == false)
                        Miscleanous.FillLines(RawOcean, i, j);


            select_1_ship.Text = "однопалубных: " + shipCount[0];
            select_2_ship.Text = "двухпалубных: " + shipCount[1];
            select_3_ship.Text = "трехпалубных: " + shipCount[2];
            select_4_ship.Text = "четырехпалубных: " + shipCount[3];

            pictureBoxShipPlace.Image = RawOcean;
            if (shipCount[0] == 0) { select_1_ship.Checked = false; select_1_ship.Enabled = false; selectNextShip(); }
            if (shipCount[1] == 0) { select_2_ship.Checked = false; select_2_ship.Enabled = false; selectNextShip(); }
            if (shipCount[2] == 0) { select_3_ship.Checked = false; select_3_ship.Enabled = false; selectNextShip(); }
            if (shipCount[3] == 0) { select_4_ship.Checked = false; select_4_ship.Enabled = false; selectNextShip(); }

        }
        public void resetLayout()
        {
            bf.forbiddenToPlace = new bool[10, 10];
            bf.shipPlacement = new bool[10, 10];
            RawOcean = new Bitmap("Resources/water-4.jpg");

            shipCount = new int[4] { 4, 3, 2, 1 };
            select_1_ship.Enabled = true;
            select_2_ship.Enabled = true;
            select_3_ship.Enabled = true;
            select_4_ship.Enabled = true;
            selectNextShip();
            shipSize = GetSizeOfShip();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (true && dragActive) //left click 
            {
                shipSize = GetSizeOfShip();
                if (shipSize != -1)
                    if (Miscleanous.IsPossibleToPlaceHere(bf, shipSize, rotated, lastX, lastY))
                    {
                        Miscleanous.PlaceShip(bf, shipSize, rotated, lastX, lastY);
                        drawBoat(bf, shipSize, RawOcean, lastX, lastY, rotated);

                        shipCount[shipSize - 1]--;
                        updateLayout();

                        shipSize = GetSizeOfShip();
                    }
            }
        }

        private void selectNextShip()
        {
            if (shipCount[0] != 0) select_1_ship.Checked = true;
            else if (shipCount[1] != 0) select_2_ship.Checked = true;
            else if (shipCount[2] != 0) select_3_ship.Checked = true;
            else if (shipCount[3] != 0) select_4_ship.Checked = true;
        }

        private void pictureBoxShipPlace_MouseMove(object sender, MouseEventArgs e)  //анимация
        {
            Bitmap ocean = new Bitmap(RawOcean);
            int X = e.Location.X;
            int Y = e.Location.Y;
            int dz = 10;
            shipSize = GetSizeOfShip();
            if (X >= dz && X <= 500 - dz && Y >= dz && Y <= 500 - dz && shipSize != -1)
            {
                X = X / 50;
                Y = Y / 50;
                if (X % 50 >= 25) X++;
                if (Y % 50 >= 25) Y++;
                drawBoat(bf, shipSize, ocean, X, Y, rotated);

                lastX = X;
                lastY = Y;
            }

            pictureBoxShipPlace.Image = ocean;

        }
        private int GetSizeOfShip()
        {
            if (select_1_ship.Checked) return 1;
            else if (select_2_ship.Checked) return 2;
            else if (select_3_ship.Checked) return 3;
            else if (select_4_ship.Checked) return 4;
            else return -1;
        }
        private void RotateButton_Click(object sender, EventArgs e)
        {
            rotated = !rotated;
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (shipCount[0] == 0 && shipCount[1] == 0 && shipCount[2] == 0 && shipCount[3] == 0)
            {
                int bt = 0;
                g.FirstUser.BattleField = bf;
                Battle btlWindow = new Battle(g);
                btlWindow.Show();
                this.Close();
            }
        }
        private void buttonLoadPattern_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                resetLayout();
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                bf = (BattleField)formatter.Deserialize(stream);
                stream.Close();
            }
            shipCount = new int[4] { 0, 0, 0, 0 };

            updateLayout();
            updateBoat(bf, RawOcean);
        }

        private void buttonSavePattern_Click(object sender, EventArgs e)
        {
            if (shipCount[0] == 0 && shipCount[1] == 0 && shipCount[2] == 0 && shipCount[3] == 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                    formatter.Serialize(stream, bf);
                    stream.Close();
                }

            }
        }

        private void buttonClearField_Click(object sender, EventArgs e)
        {
            resetLayout();
            updateLayout();
        }

        private void buttonRandomRandomly_Click(object sender, EventArgs e)
        {
            resetLayout();
            FillRandomly(bf);
            shipCount = new int[4] { 0, 0, 0, 0 };

            updateLayout();
            updateBoat(bf, RawOcean);
        }

        private void ShipPlacing_KeyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString() == "R" || e.KeyCode.ToString() == "r" || e.KeyCode.ToString() == "К" || e.KeyCode.ToString() == "к")
            {
                rotated = !rotated;
            }
            if(e.KeyCode.ToString() == "F1")
            {
                MessageBox.Show("Расстановка кораблей осуществляется мышкой или случайно, повернуть можно при нажатии кнопки R", "Справка");
            }
            updateLayout();
        }
    }
}
