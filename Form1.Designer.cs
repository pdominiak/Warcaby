
namespace Warcaby
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbFile = new System.Windows.Forms.TabPage();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.tbPomoc = new System.Windows.Forms.TabPage();
            this.rtbHelp = new System.Windows.Forms.RichTextBox();
            this.tbHistoria = new System.Windows.Forms.TabPage();
            this.rtbHistory = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbFile.SuspendLayout();
            this.tbPomoc.SuspendLayout();
            this.tbHistoria.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(720, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 720);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbFile);
            this.tabControl1.Controls.Add(this.tbPomoc);
            this.tabControl1.Controls.Add(this.tbHistoria);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 720);
            this.tabControl1.TabIndex = 0;
            // 
            // tbFile
            // 
            this.tbFile.Controls.Add(this.btnEndTurn);
            this.tbFile.Controls.Add(this.btnExit);
            this.tbFile.Controls.Add(this.btnNewGame);
            this.tbFile.Location = new System.Drawing.Point(4, 22);
            this.tbFile.Name = "tbFile";
            this.tbFile.Padding = new System.Windows.Forms.Padding(3);
            this.tbFile.Size = new System.Drawing.Size(192, 694);
            this.tbFile.TabIndex = 0;
            this.tbFile.Text = "Plik";
            this.tbFile.UseVisualStyleBackColor = true;
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEndTurn.Location = new System.Drawing.Point(3, 151);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(186, 74);
            this.btnEndTurn.TabIndex = 2;
            this.btnEndTurn.Text = "Zakończ Turę";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExit.Location = new System.Drawing.Point(3, 77);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(186, 74);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Wyjdź";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNewGame.Location = new System.Drawing.Point(3, 3);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(186, 74);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "Nowa Gra";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // tbPomoc
            // 
            this.tbPomoc.Controls.Add(this.rtbHelp);
            this.tbPomoc.Location = new System.Drawing.Point(4, 22);
            this.tbPomoc.Name = "tbPomoc";
            this.tbPomoc.Size = new System.Drawing.Size(192, 694);
            this.tbPomoc.TabIndex = 2;
            this.tbPomoc.Text = "Pomoc";
            this.tbPomoc.UseVisualStyleBackColor = true;
            // 
            // rtbHelp
            // 
            this.rtbHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbHelp.Location = new System.Drawing.Point(0, 0);
            this.rtbHelp.Name = "rtbHelp";
            this.rtbHelp.ReadOnly = true;
            this.rtbHelp.Size = new System.Drawing.Size(192, 96);
            this.rtbHelp.TabIndex = 0;
            this.rtbHelp.Text = "";
            // 
            // tbHistoria
            // 
            this.tbHistoria.Controls.Add(this.rtbHistory);
            this.tbHistoria.Location = new System.Drawing.Point(4, 22);
            this.tbHistoria.Name = "tbHistoria";
            this.tbHistoria.Size = new System.Drawing.Size(192, 694);
            this.tbHistoria.TabIndex = 3;
            this.tbHistoria.Text = "Historia Ruchów";
            this.tbHistoria.UseVisualStyleBackColor = true;
            // 
            // rtbHistory
            // 
            this.rtbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbHistory.Location = new System.Drawing.Point(0, 0);
            this.rtbHistory.Name = "rtbHistory";
            this.rtbHistory.ReadOnly = true;
            this.rtbHistory.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbHistory.Size = new System.Drawing.Size(192, 694);
            this.rtbHistory.TabIndex = 0;
            this.rtbHistory.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 720);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Load);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbFile.ResumeLayout(false);
            this.tbPomoc.ResumeLayout(false);
            this.tbHistoria.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbFile;
        private System.Windows.Forms.TabPage tbPomoc;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.RichTextBox rtbHelp;
        private System.Windows.Forms.TabPage tbHistoria;
        private System.Windows.Forms.RichTextBox rtbHistory;
    }
}

