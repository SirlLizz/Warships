namespace Warships
{
    partial class StartPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStartBotGame = new Button();
            label1 = new Label();
            textBoxUserName = new TextBox();
            buttonStartLocalGame = new Button();
            pictureAvatar = new PictureBox();
            buttonDeveloperInfo = new Button();
            buttonSystemInfo = new Button();
            labelChangeAvatar = new Label();
            buttonPreviousAvatar = new Button();
            buttonNextAvatar = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureAvatar).BeginInit();
            SuspendLayout();
            // 
            // buttonStartBotGame
            // 
            buttonStartBotGame.Location = new Point(25, 184);
            buttonStartBotGame.Margin = new Padding(3, 2, 3, 2);
            buttonStartBotGame.Name = "buttonStartBotGame";
            buttonStartBotGame.Size = new Size(154, 26);
            buttonStartBotGame.TabIndex = 0;
            buttonStartBotGame.Text = "Игра против ИИ";
            buttonStartBotGame.UseVisualStyleBackColor = true;
            buttonStartBotGame.Click += buttonStartBotGame_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 25);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 1;
            label1.Text = "Никнейм";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(26, 43);
            textBoxUserName.Margin = new Padding(3, 2, 3, 2);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(182, 23);
            textBoxUserName.TabIndex = 2;
            textBoxUserName.Text = "Капитан Ямамото";
            // 
            // buttonStartLocalGame
            // 
            buttonStartLocalGame.Location = new Point(185, 186);
            buttonStartLocalGame.Margin = new Padding(3, 2, 3, 2);
            buttonStartLocalGame.Name = "buttonStartLocalGame";
            buttonStartLocalGame.Size = new Size(143, 24);
            buttonStartLocalGame.TabIndex = 3;
            buttonStartLocalGame.Text = "Создать сетевую игру";
            buttonStartLocalGame.UseVisualStyleBackColor = true;
            buttonStartLocalGame.Click += buttonStartLocalGame_Click;
            // 
            // pictureAvatar
            // 
            pictureAvatar.Location = new Point(229, 43);
            pictureAvatar.Margin = new Padding(3, 2, 3, 2);
            pictureAvatar.Name = "pictureAvatar";
            pictureAvatar.Size = new Size(100, 100);
            pictureAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureAvatar.TabIndex = 11;
            pictureAvatar.TabStop = false;
            pictureAvatar.Click += pictureAvatar_Click;
            // 
            // buttonDeveloperInfo
            // 
            buttonDeveloperInfo.Location = new Point(26, 82);
            buttonDeveloperInfo.Name = "buttonDeveloperInfo";
            buttonDeveloperInfo.Size = new Size(182, 23);
            buttonDeveloperInfo.TabIndex = 12;
            buttonDeveloperInfo.Text = "Сведения о разработчиках";
            buttonDeveloperInfo.UseVisualStyleBackColor = true;
            buttonDeveloperInfo.Click += buttonDeveloperInfo_Click;
            // 
            // buttonSystemInfo
            // 
            buttonSystemInfo.Location = new Point(26, 120);
            buttonSystemInfo.Name = "buttonSystemInfo";
            buttonSystemInfo.Size = new Size(182, 23);
            buttonSystemInfo.TabIndex = 13;
            buttonSystemInfo.Text = "Сведения о системе";
            buttonSystemInfo.UseVisualStyleBackColor = true;
            buttonSystemInfo.Click += buttonSystemInfo_Click;
            // 
            // labelChangeAvatar
            // 
            labelChangeAvatar.AutoSize = true;
            labelChangeAvatar.Location = new Point(231, 25);
            labelChangeAvatar.Name = "labelChangeAvatar";
            labelChangeAvatar.Size = new Size(89, 15);
            labelChangeAvatar.TabIndex = 14;
            labelChangeAvatar.Text = "Выбор аватара";
            // 
            // buttonPreviousAvatar
            // 
            buttonPreviousAvatar.Location = new Point(229, 148);
            buttonPreviousAvatar.Name = "buttonPreviousAvatar";
            buttonPreviousAvatar.Size = new Size(47, 23);
            buttonPreviousAvatar.TabIndex = 15;
            buttonPreviousAvatar.Text = "<--";
            buttonPreviousAvatar.UseVisualStyleBackColor = true;
            buttonPreviousAvatar.Click += buttonPreviousAvatar_Click;
            // 
            // buttonNextAvatar
            // 
            buttonNextAvatar.Location = new Point(282, 148);
            buttonNextAvatar.Name = "buttonNextAvatar";
            buttonNextAvatar.Size = new Size(47, 23);
            buttonNextAvatar.TabIndex = 16;
            buttonNextAvatar.Text = "-->";
            buttonNextAvatar.UseVisualStyleBackColor = true;
            buttonNextAvatar.Click += buttonNextAvatar_Click;
            // 
            // StartPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 221);
            Controls.Add(buttonNextAvatar);
            Controls.Add(buttonPreviousAvatar);
            Controls.Add(labelChangeAvatar);
            Controls.Add(buttonSystemInfo);
            Controls.Add(buttonDeveloperInfo);
            Controls.Add(pictureAvatar);
            Controls.Add(buttonStartLocalGame);
            Controls.Add(textBoxUserName);
            Controls.Add(label1);
            Controls.Add(buttonStartBotGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "StartPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Главное меню";
            ((System.ComponentModel.ISupportInitialize)pictureAvatar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStartBotGame;
        private Label label1;
        private TextBox textBoxUserName;
        private Button buttonStartLocalGame;
        private TextBox textBox2;
        private Button button5;
        private PictureBox pictureAvatar;
        private Button buttonDeveloperInfo;
        private Button buttonSystemInfo;
        private Label labelChangeAvatar;
        private Button buttonPreviousAvatar;
        private Button buttonNextAvatar;
    }
}