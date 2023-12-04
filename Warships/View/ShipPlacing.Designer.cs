namespace Warships
{
    partial class ShipPlacing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipPlacing));
            buttonLoadPattern = new Button();
            pictureBoxShipPlace = new PictureBox();
            buttonSavePattern = new Button();
            RotateButton = new Button();
            buttonStart = new Button();
            select_1_ship = new RadioButton();
            select_2_ship = new RadioButton();
            select_3_ship = new RadioButton();
            select_4_ship = new RadioButton();
            buttonClearField = new Button();
            groupBoxManualPlasing = new GroupBox();
            labelRotateShip = new Label();
            groupBoxRandomPlacing = new GroupBox();
            buttonRandomRandomly = new Button();
            buttonRandomBeach = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShipPlace).BeginInit();
            groupBoxManualPlasing.SuspendLayout();
            groupBoxRandomPlacing.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLoadPattern
            // 
            buttonLoadPattern.Location = new Point(522, 309);
            buttonLoadPattern.Margin = new Padding(3, 2, 3, 2);
            buttonLoadPattern.Name = "buttonLoadPattern";
            buttonLoadPattern.Size = new Size(183, 37);
            buttonLoadPattern.TabIndex = 0;
            buttonLoadPattern.Text = "Загрузить расстановку";
            buttonLoadPattern.UseVisualStyleBackColor = true;
            buttonLoadPattern.Click += buttonLoadPattern_Click;
            // 
            // pictureBoxShipPlace
            // 
            pictureBoxShipPlace.Location = new Point(12, 11);
            pictureBoxShipPlace.Margin = new Padding(3, 2, 3, 2);
            pictureBoxShipPlace.Name = "pictureBoxShipPlace";
            pictureBoxShipPlace.Size = new Size(500, 500);
            pictureBoxShipPlace.TabIndex = 1;
            pictureBoxShipPlace.TabStop = false;
            pictureBoxShipPlace.Click += pictureBox1_Click;
            pictureBoxShipPlace.MouseMove += pictureBoxShipPlace_MouseMove;
            // 
            // buttonSavePattern
            // 
            buttonSavePattern.Location = new Point(522, 350);
            buttonSavePattern.Margin = new Padding(3, 2, 3, 2);
            buttonSavePattern.Name = "buttonSavePattern";
            buttonSavePattern.Size = new Size(183, 37);
            buttonSavePattern.TabIndex = 2;
            buttonSavePattern.Text = "Сохранить расстановку";
            buttonSavePattern.UseVisualStyleBackColor = true;
            buttonSavePattern.Click += buttonSavePattern_Click;
            // 
            // RotateButton
            // 
            RotateButton.BackgroundImage = (Image)resources.GetObject("RotateButton.BackgroundImage");
            RotateButton.BackgroundImageLayout = ImageLayout.Zoom;
            RotateButton.Location = new Point(13, 23);
            RotateButton.Margin = new Padding(3, 2, 3, 2);
            RotateButton.Name = "RotateButton";
            RotateButton.Size = new Size(30, 30);
            RotateButton.TabIndex = 3;
            RotateButton.UseVisualStyleBackColor = true;
            RotateButton.Click += RotateButton_Click;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(522, 474);
            buttonStart.Margin = new Padding(3, 2, 3, 2);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(183, 37);
            buttonStart.TabIndex = 11;
            buttonStart.Text = "Готов";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // select_1_ship
            // 
            select_1_ship.AutoSize = true;
            select_1_ship.Checked = true;
            select_1_ship.Location = new Point(16, 57);
            select_1_ship.Margin = new Padding(3, 2, 3, 2);
            select_1_ship.Name = "select_1_ship";
            select_1_ship.Size = new Size(119, 19);
            select_1_ship.TabIndex = 12;
            select_1_ship.TabStop = true;
            select_1_ship.Text = "однопалубных: 4";
            select_1_ship.UseVisualStyleBackColor = true;
            // 
            // select_2_ship
            // 
            select_2_ship.AutoSize = true;
            select_2_ship.Location = new Point(16, 80);
            select_2_ship.Margin = new Padding(3, 2, 3, 2);
            select_2_ship.Name = "select_2_ship";
            select_2_ship.Size = new Size(116, 19);
            select_2_ship.TabIndex = 13;
            select_2_ship.Text = "двухпалубных: 3";
            select_2_ship.UseVisualStyleBackColor = true;
            // 
            // select_3_ship
            // 
            select_3_ship.AutoSize = true;
            select_3_ship.Location = new Point(16, 102);
            select_3_ship.Margin = new Padding(3, 2, 3, 2);
            select_3_ship.Name = "select_3_ship";
            select_3_ship.Size = new Size(122, 19);
            select_3_ship.TabIndex = 14;
            select_3_ship.Text = "треххпалубных: 2";
            select_3_ship.UseVisualStyleBackColor = true;
            // 
            // select_4_ship
            // 
            select_4_ship.AutoSize = true;
            select_4_ship.Location = new Point(16, 125);
            select_4_ship.Margin = new Padding(3, 2, 3, 2);
            select_4_ship.Name = "select_4_ship";
            select_4_ship.Size = new Size(138, 19);
            select_4_ship.TabIndex = 15;
            select_4_ship.Text = "четырехпалубных: 1";
            select_4_ship.UseVisualStyleBackColor = true;
            // 
            // buttonClearField
            // 
            buttonClearField.Location = new Point(522, 268);
            buttonClearField.Margin = new Padding(3, 2, 3, 2);
            buttonClearField.Name = "buttonClearField";
            buttonClearField.Size = new Size(183, 37);
            buttonClearField.TabIndex = 16;
            buttonClearField.Text = "Отчистить поле";
            buttonClearField.UseVisualStyleBackColor = true;
            buttonClearField.Click += buttonClearField_Click;
            // 
            // groupBoxManualPlasing
            // 
            groupBoxManualPlasing.Controls.Add(labelRotateShip);
            groupBoxManualPlasing.Controls.Add(RotateButton);
            groupBoxManualPlasing.Controls.Add(select_4_ship);
            groupBoxManualPlasing.Controls.Add(select_2_ship);
            groupBoxManualPlasing.Controls.Add(select_3_ship);
            groupBoxManualPlasing.Controls.Add(select_1_ship);
            groupBoxManualPlasing.Location = new Point(522, 12);
            groupBoxManualPlasing.Name = "groupBoxManualPlasing";
            groupBoxManualPlasing.Size = new Size(183, 153);
            groupBoxManualPlasing.TabIndex = 17;
            groupBoxManualPlasing.TabStop = false;
            groupBoxManualPlasing.Text = "Ручная расстановка";
            // 
            // labelRotateShip
            // 
            labelRotateShip.AutoSize = true;
            labelRotateShip.Location = new Point(49, 31);
            labelRotateShip.Name = "labelRotateShip";
            labelRotateShip.Size = new Size(115, 15);
            labelRotateShip.TabIndex = 4;
            labelRotateShip.Text = "Повернуть корабль";
            // 
            // groupBoxRandomPlacing
            // 
            groupBoxRandomPlacing.Controls.Add(buttonRandomRandomly);
            groupBoxRandomPlacing.Controls.Add(buttonRandomBeach);
            groupBoxRandomPlacing.Location = new Point(522, 179);
            groupBoxRandomPlacing.Name = "groupBoxRandomPlacing";
            groupBoxRandomPlacing.Size = new Size(183, 84);
            groupBoxRandomPlacing.TabIndex = 18;
            groupBoxRandomPlacing.TabStop = false;
            groupBoxRandomPlacing.Text = "Случайная расстановка";
            // 
            // buttonRandomRandomly
            // 
            buttonRandomRandomly.Location = new Point(9, 51);
            buttonRandomRandomly.Name = "buttonRandomRandomly";
            buttonRandomRandomly.Size = new Size(164, 23);
            buttonRandomRandomly.TabIndex = 1;
            buttonRandomRandomly.Text = "Случайная";
            buttonRandomRandomly.UseVisualStyleBackColor = true;
            buttonRandomRandomly.Click += buttonRandomRandomly_Click;
            // 
            // buttonRandomBeach
            // 
            buttonRandomBeach.Location = new Point(9, 22);
            buttonRandomBeach.Name = "buttonRandomBeach";
            buttonRandomBeach.Size = new Size(164, 23);
            buttonRandomBeach.TabIndex = 0;
            buttonRandomBeach.Text = "Берега";
            buttonRandomBeach.UseVisualStyleBackColor = true;
            // 
            // ShipPlacing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 518);
            Controls.Add(groupBoxRandomPlacing);
            Controls.Add(groupBoxManualPlasing);
            Controls.Add(buttonClearField);
            Controls.Add(buttonStart);
            Controls.Add(buttonSavePattern);
            Controls.Add(pictureBoxShipPlace);
            Controls.Add(buttonLoadPattern);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "ShipPlacing";
            Text = "Расстановка кораблей";
            ((System.ComponentModel.ISupportInitialize)pictureBoxShipPlace).EndInit();
            groupBoxManualPlasing.ResumeLayout(false);
            groupBoxManualPlasing.PerformLayout();
            groupBoxRandomPlacing.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadPattern;
        private PictureBox pictureBoxShipPlace;
        private Button buttonSavePattern;
        private Button RotateButton;
        private Button buttonStart;
        private RadioButton select_1_ship;
        private RadioButton select_2_ship;
        private RadioButton select_3_ship;
        private RadioButton select_4_ship;
        private Button buttonClearField;
        private GroupBox groupBoxManualPlasing;
        private Label labelRotateShip;
        private GroupBox groupBoxRandomPlacing;
        private Button buttonRandomRandomly;
        private Button buttonRandomBeach;
    }
}