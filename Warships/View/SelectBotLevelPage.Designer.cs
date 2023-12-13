namespace Warships.View
{
    partial class SelectBotLevelPage
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
            HardLevelDifficulty = new RadioButton();
            MediumLevelDifficulty = new RadioButton();
            LightLevelDifficulty = new RadioButton();
            buttonToStartPage = new Button();
            buttonNext = new Button();
            groupGameDiffculty = new GroupBox();
            groupGameDiffculty.SuspendLayout();
            SuspendLayout();
            // 
            // HardLevelDifficulty
            // 
            HardLevelDifficulty.AutoSize = true;
            HardLevelDifficulty.Location = new Point(6, 67);
            HardLevelDifficulty.Margin = new Padding(3, 2, 3, 2);
            HardLevelDifficulty.Name = "HardLevelDifficulty";
            HardLevelDifficulty.Size = new Size(79, 19);
            HardLevelDifficulty.TabIndex = 13;
            HardLevelDifficulty.Text = "Сложный";
            HardLevelDifficulty.TextAlign = ContentAlignment.MiddleCenter;
            HardLevelDifficulty.UseVisualStyleBackColor = true;
            // 
            // MediumLevelDifficulty
            // 
            MediumLevelDifficulty.AutoSize = true;
            MediumLevelDifficulty.Location = new Point(8, 44);
            MediumLevelDifficulty.Margin = new Padding(3, 2, 3, 2);
            MediumLevelDifficulty.Name = "MediumLevelDifficulty";
            MediumLevelDifficulty.Size = new Size(73, 19);
            MediumLevelDifficulty.TabIndex = 12;
            MediumLevelDifficulty.Text = "Средний";
            MediumLevelDifficulty.UseVisualStyleBackColor = true;
            // 
            // LightLevelDifficulty
            // 
            LightLevelDifficulty.AutoSize = true;
            LightLevelDifficulty.Checked = true;
            LightLevelDifficulty.Location = new Point(8, 21);
            LightLevelDifficulty.Margin = new Padding(3, 2, 3, 2);
            LightLevelDifficulty.Name = "LightLevelDifficulty";
            LightLevelDifficulty.Size = new Size(64, 19);
            LightLevelDifficulty.TabIndex = 11;
            LightLevelDifficulty.TabStop = true;
            LightLevelDifficulty.Text = "Легкий";
            LightLevelDifficulty.UseVisualStyleBackColor = true;
            // 
            // buttonToStartPage
            // 
            buttonToStartPage.Location = new Point(12, 115);
            buttonToStartPage.Name = "buttonToStartPage";
            buttonToStartPage.Size = new Size(111, 23);
            buttonToStartPage.TabIndex = 15;
            buttonToStartPage.Text = "В главное меню";
            buttonToStartPage.UseVisualStyleBackColor = true;
            buttonToStartPage.Click += buttonToStartPage_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(129, 115);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(111, 23);
            buttonNext.TabIndex = 16;
            buttonNext.Text = "Далее";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // groupGameDiffculty
            // 
            groupGameDiffculty.Controls.Add(LightLevelDifficulty);
            groupGameDiffculty.Controls.Add(MediumLevelDifficulty);
            groupGameDiffculty.Controls.Add(HardLevelDifficulty);
            groupGameDiffculty.Location = new Point(12, 12);
            groupGameDiffculty.Name = "groupGameDiffculty";
            groupGameDiffculty.Size = new Size(228, 100);
            groupGameDiffculty.TabIndex = 17;
            groupGameDiffculty.TabStop = false;
            groupGameDiffculty.Text = "Выбор уровня сложности:";
            // 
            // SelectBotLevelPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 152);
            Controls.Add(groupGameDiffculty);
            Controls.Add(buttonNext);
            Controls.Add(buttonToStartPage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "SelectBotLevelPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Игра против ИИ";
            groupGameDiffculty.ResumeLayout(false);
            groupGameDiffculty.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton HardLevelDifficulty;
        private RadioButton MediumLevelDifficulty;
        private RadioButton LightLevelDifficulty;
        private Button buttonToStartPage;
        private Button buttonNext;
        private GroupBox groupGameDiffculty;
    }
}