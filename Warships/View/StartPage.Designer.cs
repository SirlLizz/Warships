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
            buttonLoadBotGame = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureAvatar).BeginInit();
            SuspendLayout();
            // 
            // buttonStartBotGame
            // 
            buttonStartBotGame.Location = new Point(116, 170);
            buttonStartBotGame.Margin = new Padding(3, 2, 3, 2);
            buttonStartBotGame.Name = "buttonStartBotGame";
            buttonStartBotGame.Size = new Size(85, 46);
            buttonStartBotGame.TabIndex = 0;
            buttonStartBotGame.Text = "Создать игру с ИИ";
            buttonStartBotGame.UseVisualStyleBackColor = true;
            buttonStartBotGame.Click += buttonStartBotGame_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 1;
            label1.Text = "Никнейм";
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(12, 27);
            textBoxUserName.Margin = new Padding(3, 2, 3, 2);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(182, 23);
            textBoxUserName.TabIndex = 2;
            textBoxUserName.Text = "Капитан Ямамото";
            // 
            // buttonStartLocalGame
            // 
            buttonStartLocalGame.Location = new Point(215, 170);
            buttonStartLocalGame.Margin = new Padding(3, 2, 3, 2);
            buttonStartLocalGame.Name = "buttonStartLocalGame";
            buttonStartLocalGame.Size = new Size(99, 46);
            buttonStartLocalGame.TabIndex = 3;
            buttonStartLocalGame.Text = "Создать сетевую игру";
            buttonStartLocalGame.UseVisualStyleBackColor = true;
            buttonStartLocalGame.Click += buttonStartLocalGame_Click;
            // 
            // pictureAvatar
            // 
            pictureAvatar.Location = new Point(215, 27);
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
            buttonDeveloperInfo.Location = new Point(12, 66);
            buttonDeveloperInfo.Name = "buttonDeveloperInfo";
            buttonDeveloperInfo.Size = new Size(182, 23);
            buttonDeveloperInfo.TabIndex = 12;
            buttonDeveloperInfo.Text = "Сведения о разработчиках";
            buttonDeveloperInfo.UseVisualStyleBackColor = true;
            buttonDeveloperInfo.Click += buttonDeveloperInfo_Click;
            // 
            // buttonSystemInfo
            // 
            buttonSystemInfo.Location = new Point(12, 104);
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
            labelChangeAvatar.Location = new Point(217, 9);
            labelChangeAvatar.Name = "labelChangeAvatar";
            labelChangeAvatar.Size = new Size(89, 15);
            labelChangeAvatar.TabIndex = 14;
            labelChangeAvatar.Text = "Выбор аватара";
            // 
            // buttonPreviousAvatar
            // 
            buttonPreviousAvatar.Location = new Point(215, 132);
            buttonPreviousAvatar.Name = "buttonPreviousAvatar";
            buttonPreviousAvatar.Size = new Size(47, 23);
            buttonPreviousAvatar.TabIndex = 15;
            buttonPreviousAvatar.Text = "<--";
            buttonPreviousAvatar.UseVisualStyleBackColor = true;
            buttonPreviousAvatar.Click += buttonPreviousAvatar_Click;
            // 
            // buttonNextAvatar
            // 
            buttonNextAvatar.Location = new Point(268, 132);
            buttonNextAvatar.Name = "buttonNextAvatar";
            buttonNextAvatar.Size = new Size(47, 23);
            buttonNextAvatar.TabIndex = 16;
            buttonNextAvatar.Text = "-->";
            buttonNextAvatar.UseVisualStyleBackColor = true;
            buttonNextAvatar.Click += buttonNextAvatar_Click;
            // 
            // buttonLoadBotGame
            // 
            buttonLoadBotGame.Location = new Point(11, 170);
            buttonLoadBotGame.Name = "buttonLoadBotGame";
            buttonLoadBotGame.Size = new Size(93, 46);
            buttonLoadBotGame.TabIndex = 17;
            buttonLoadBotGame.Text = "Загрузить игру с ИИ";
            buttonLoadBotGame.UseVisualStyleBackColor = true;
            buttonLoadBotGame.Click += buttonLoadBotGame_Click;
            // 
            // StartPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 223);
            Controls.Add(buttonLoadBotGame);
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
            MaximizeBox = false;
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
        private Button buttonLoadBotGame;
    }
}