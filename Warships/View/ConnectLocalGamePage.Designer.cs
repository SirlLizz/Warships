namespace Warships.View
{
    partial class ConnectLocalGamePage
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
            buttonToStartPage = new Button();
            buttonConnect = new Button();
            labelIPaddress = new Label();
            textBoxIPaddress = new TextBox();
            SuspendLayout();
            // 
            // buttonToStartPage
            // 
            buttonToStartPage.Location = new Point(11, 56);
            buttonToStartPage.Name = "buttonToStartPage";
            buttonToStartPage.Size = new Size(118, 23);
            buttonToStartPage.TabIndex = 0;
            buttonToStartPage.Text = "В главное меню";
            buttonToStartPage.UseVisualStyleBackColor = true;
            buttonToStartPage.Click += buttonToStartPage_Click;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(135, 56);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(109, 23);
            buttonConnect.TabIndex = 1;
            buttonConnect.Text = "Подключение";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // labelIPaddress
            // 
            labelIPaddress.AutoSize = true;
            labelIPaddress.Location = new Point(12, 9);
            labelIPaddress.Name = "labelIPaddress";
            labelIPaddress.Size = new Size(53, 15);
            labelIPaddress.TabIndex = 2;
            labelIPaddress.Text = "IP-адрес";
            // 
            // textBoxIPaddress
            // 
            textBoxIPaddress.Location = new Point(12, 27);
            textBoxIPaddress.Name = "textBoxIPaddress";
            textBoxIPaddress.Size = new Size(232, 23);
            textBoxIPaddress.TabIndex = 3;
            // 
            // ConnectLocalGamePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 86);
            Controls.Add(textBoxIPaddress);
            Controls.Add(labelIPaddress);
            Controls.Add(buttonConnect);
            Controls.Add(buttonToStartPage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ConnectLocalGamePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Подключение к игре";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonToStartPage;
        private Button buttonConnect;
        private Label labelIPaddress;
        private TextBox textBoxIPaddress;
    }
}