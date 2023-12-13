namespace Warships.View
{
    partial class LocalGameSelect
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
            buttonCreateGame = new Button();
            buttonConnect = new Button();
            buttonToStartPage = new Button();
            SuspendLayout();
            // 
            // buttonCreateGame
            // 
            buttonCreateGame.Location = new Point(12, 12);
            buttonCreateGame.Name = "buttonCreateGame";
            buttonCreateGame.Size = new Size(111, 23);
            buttonCreateGame.TabIndex = 0;
            buttonCreateGame.Text = "Создать игру";
            buttonCreateGame.UseVisualStyleBackColor = true;
            buttonCreateGame.Click += buttonCreateGame_Click;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(129, 12);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(101, 23);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Подключиться";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonToStartPage
            // 
            buttonToStartPage.Location = new Point(66, 41);
            buttonToStartPage.Name = "buttonToStartPage";
            buttonToStartPage.Size = new Size(117, 23);
            buttonToStartPage.TabIndex = 2;
            buttonToStartPage.Text = "В главное меню";
            buttonToStartPage.UseVisualStyleBackColor = true;
            buttonToStartPage.Click += buttonToStartPage_Click;
            // 
            // LocalGameSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 68);
            Controls.Add(buttonToStartPage);
            Controls.Add(buttonConnect);
            Controls.Add(buttonCreateGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LocalGameSelect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Игра по сети";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateGame;
        private Button buttonConnect;
        private Button buttonToStartPage;
    }
}