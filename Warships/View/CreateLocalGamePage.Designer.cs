namespace Warships.View
{
    partial class CreateLocalGamePage
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
            components = new System.ComponentModel.Container();
            labelIPaddress = new Label();
            buttonToStartPage = new Button();
            buttonNext = new Button();
            labelIpAddressView = new Label();
            toolTipLabel = new ToolTip(components);
            SuspendLayout();
            // 
            // labelIPaddress
            // 
            labelIPaddress.AutoSize = true;
            labelIPaddress.Location = new Point(7, 7);
            labelIPaddress.Name = "labelIPaddress";
            labelIPaddress.Size = new Size(53, 15);
            labelIPaddress.TabIndex = 0;
            labelIPaddress.Text = "IP-адрес";
            // 
            // buttonToStartPage
            // 
            buttonToStartPage.Location = new Point(7, 59);
            buttonToStartPage.Name = "buttonToStartPage";
            buttonToStartPage.Size = new Size(109, 23);
            buttonToStartPage.TabIndex = 1;
            buttonToStartPage.Text = "В главное меню";
            buttonToStartPage.UseVisualStyleBackColor = true;
            buttonToStartPage.Click += buttonToStartPage_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(122, 59);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(107, 23);
            buttonNext.TabIndex = 2;
            buttonNext.Text = "Далее";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // labelIpAddressView
            // 
            labelIpAddressView.AutoSize = true;
            labelIpAddressView.Location = new Point(12, 31);
            labelIpAddressView.Name = "labelIpAddressView";
            labelIpAddressView.Size = new Size(0, 15);
            labelIpAddressView.TabIndex = 3;
            labelIpAddressView.Click += labelIpAddressView_Click;
            labelIpAddressView.MouseEnter += labelIpAddressView_MouseEnter;
            // 
            // CreateLocalGamePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(237, 88);
            Controls.Add(labelIpAddressView);
            Controls.Add(buttonNext);
            Controls.Add(buttonToStartPage);
            Controls.Add(labelIPaddress);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreateLocalGamePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание игры";
            Load += CreateLocalGamePage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIPaddress;
        private Button buttonToStartPage;
        private Button buttonNext;
        private Label labelIpAddressView;
        private ToolTip toolTipLabel;
    }
}