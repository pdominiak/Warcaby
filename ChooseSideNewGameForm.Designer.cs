
namespace Warcaby
{
    partial class ChooseSideNewGameForm
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
            this.btnStartNewGame = new System.Windows.Forms.Button();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.lblPieceColor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartNewGame
            // 
            this.btnStartNewGame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStartNewGame.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartNewGame.Location = new System.Drawing.Point(0, 162);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new System.Drawing.Size(291, 90);
            this.btnStartNewGame.TabIndex = 0;
            this.btnStartNewGame.Text = "Rozpocznij Grę";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Click += new System.EventHandler(this.btnStartNewGame_Click);
            // 
            // rtbMessage
            // 
            this.rtbMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbMessage.Location = new System.Drawing.Point(0, -3);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.ReadOnly = true;
            this.rtbMessage.Size = new System.Drawing.Size(291, 74);
            this.rtbMessage.TabIndex = 1;
            this.rtbMessage.Text = "Wybierz  kolor pionków\n";
            this.rtbMessage.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "",
            "Czarne",
            "Białe"});
            this.cbColor.Location = new System.Drawing.Point(158, 77);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(121, 21);
            this.cbColor.TabIndex = 2;
            // 
            // lblPieceColor
            // 
            this.lblPieceColor.AutoSize = true;
            this.lblPieceColor.Location = new System.Drawing.Point(12, 77);
            this.lblPieceColor.Name = "lblPieceColor";
            this.lblPieceColor.Size = new System.Drawing.Size(75, 13);
            this.lblPieceColor.TabIndex = 4;
            this.lblPieceColor.Text = "Kolor Pionków";
            // 
            // ChooseSideNewGameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(291, 252);
            this.Controls.Add(this.lblPieceColor);
            this.Controls.Add(this.cbColor);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.btnStartNewGame);
            this.Name = "ChooseSideNewGameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseSideNewGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartNewGame;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label lblPieceColor;
    }
}