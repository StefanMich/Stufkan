namespace GameBoardTest
{
    partial class Form1
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
            this.gameBoard1 = new GameBoardTest.BOARD();
            this.SuspendLayout();
            // 
            // gameBoard1
            // 
            this.gameBoard1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.gameBoard1.BackgroundColor = System.Drawing.Color.White;
            this.gameBoard1.Border = true;
            this.gameBoard1.Location = new System.Drawing.Point(12, 12);
            this.gameBoard1.Name = "gameBoard1";
            this.gameBoard1.Rows = 5;
            this.gameBoard1.Size = new System.Drawing.Size(617, 617);
            this.gameBoard1.TabIndex = 0;
            this.gameBoard1.TurnControl = null;
            this.gameBoard1.Load += new System.EventHandler(this.gameBoard1_Load);
            this.gameBoard1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameBoard1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 643);
            this.Controls.Add(this.gameBoard1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private GameBoardTest.BOARD gameBoard1;

    }
}