using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Warcaby
{
    public partial class Form1 : Form
    {

        PictureBox currentlyChosenPawn;
        GameField gameField = null;
        Image BlackPawn = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPiece.bmp");
        Image WhitePawn = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePiece.bmp");
        Image WhiteHPawn = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePieceGreen.bmp");
        Image BlackHPawn = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPieceGreen.bmp");
        Image BlackQueen = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPieceQueen.bmp");
        Image WhiteQueen = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePieceQueen.bmp");
        string currentlyChosenColor =  "black";
        string AIChosenColor = "";
        bool lastMoveWasRepeat;
        List<PictureBox> pboxList;
        public Form1()
        {
           InitializeComponent();
           this.BackgroundImage = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\siatka.bmp");
            pboxList = new List<PictureBox>();
          
            string imglocation1 = "", imglocation2 = "";
            if(currentlyChosenColor == "white")
            {
                imglocation1 = "\\WhitePiece.bmp";
                imglocation2 = "\\BlackPiece.bmp";
                AIChosenColor = "black";
            }
            else
            {
                AIChosenColor = "white";
                imglocation2 = "\\WhitePiece.bmp";
                imglocation1 = "\\BlackPiece.bmp";
            }
            currentlyChosenColor = "white";
            AIChosenColor = "black";
            gameField = new GameField(currentlyChosenColor, AIChosenColor);
            gameField.diffLevel = "Easy";
            PictureBox pawnPicture;
            bool flag = false;
            int counter = 0;
            for(int i = 0; i < 3; ++i)
            {
                for(int j =0; j < 8; ++j)
                {
                    if (flag)
                    {
                       
                        pawnPicture = new PictureBox();
                        pawnPicture.Name = "AIPAWN";
                        pawnPicture.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + imglocation1);
                        pawnPicture.Location = new Point(j*90,i*90);
                        pawnPicture.Size = new Size(90, 90);
                        pawnPicture.Visible = true;
                        pawnPicture.Click += new EventHandler(ClickPawn);
                        this.Controls.Add(pawnPicture);
                        pboxList.Add(pawnPicture);
                    }
                    flag = !flag;
                    
                }
                flag = !flag;
            }
            for (int i = 5; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (flag)
                    {
                        pawnPicture = new PictureBox();
                        pawnPicture.Name = System.Convert.ToString(++counter);
                        pawnPicture.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + imglocation2);
                        pawnPicture.Location = new Point(j * 90, i * 90);
                        pawnPicture.Size = new Size(90, 90);
                        pawnPicture.Visible = true;
                        pawnPicture.Click += new EventHandler(ClickPawn);
                        this.Controls.Add(pawnPicture);
                        pboxList.Add(pawnPicture);
                    }
                    flag = !flag;

                }
                flag = !flag;
            }

            lastMoveWasRepeat = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void ClickPawn(object sender, EventArgs e)
        {
            PictureBox x = sender as PictureBox;
            if ((currentlyChosenPawn != null && currentlyChosenPawn != sender as PictureBox) || x.Name=="AIPAWN" )
            {
                
               
                if (currentlyChosenColor == "black")
                {
                    for(int i = 12; i < 24; ++i)
                    {
                        pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPiece.bmp");
                    }
                    
                }
                else
                {
                    for (int i = 12; i < 24; ++i)
                    {
                        pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePiece.bmp");
                    }
                    }
                currentlyChosenPawn = null;
            }
            else
            {
                
                currentlyChosenPawn = x;
                 
   
                if(currentlyChosenColor == "black")
                {
                    currentlyChosenPawn.Image = BlackHPawn;
                }
                else
                {
                    currentlyChosenPawn.Image = WhiteHPawn;
                }

            }
            
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e) //clicking on empty field event
        {

            if (currentlyChosenPawn != null)
            {
                int wspX = e.X / 90;
                int wspY = e.Y / 90;
                string movementState = gameField.TryMove(currentlyChosenPawn.Location.X / 90, currentlyChosenPawn.Location.Y / 90, wspX, wspY);
                switch (movementState)
                {
                    case "yes":
                        if (!lastMoveWasRepeat) { 
                        currentlyChosenPawn.Location = new Point(wspX * 90, wspY * 90);
                        if (currentlyChosenColor == "black")
                        {
                            currentlyChosenPawn.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPiece.bmp");
                        }
                        else
                        {
                            currentlyChosenPawn.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePiece.bmp");
                        }
                        currentlyChosenPawn = null;
                
                //ruch AI 
                int currentAIPawn = gameField.AI_move(currentlyChosenColor);
                MovePawn(currentAIPawn, gameField.list, gameField.listOfDeletedPawns);
                isGameFinished();
                             }
                        var queen = gameField.nominateQueen();
                        if (queen != -1)
                        {
                            if (currentlyChosenColor != "black")
                            {
                                if (queen > 12) //gracz
                                {
                                    pboxList[queen - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePieceQueen.bmp");
                                }
                                else //AI
                                {
                                    pboxList[queen - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPieceQueen.bmp");
                                }

                            }
                            else
                            {
                                if (queen > 12) //gracz
                                {
                                    pboxList[queen - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPieceQueen.bmp");
                                }
                                else //AI
                                {
                                    pboxList[queen - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePieceQueen.bmp");
                                }
                            }
                        }
                        break;
                    case "no":
                        if (!lastMoveWasRepeat)
                        {
                            if (currentlyChosenColor == "black")
                            {
                                for (int i = 12; i < 24; ++i)
                                {
                                    pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPiece.bmp");
                                }

                            }
                            else
                            {
                                for (int i = 12; i < 24; ++i)
                                {
                                    pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePiece.bmp");
                                }
                            }
                            currentlyChosenPawn = null;
                        }
                        MessageBox.Show("Nieprawidłowy ruch");
                        break;
                    case "repeat":
                        currentlyChosenPawn.Location = new Point(wspX * 90, wspY * 90);
                        lastMoveWasRepeat = true;
                        pboxList[gameField.LastDeletedPawn-1].Visible = false;
                        isGameFinished();
                        if (!gameField.canBeat(currentlyChosenPawn.Location.X/90, currentlyChosenPawn.Location.Y/90))
                        {
                            EndTurn();
                        }
                        //if(mozliwe kolejne bicie)
                        //trymovebicie
                        //else
                        //ruch pc, pionek null
                        break;
                    case "beat":
                        MessageBox.Show("Masz dostępne bicie");
                        break;

                }
                
                
            }
            else
            {
                MessageBox.Show("Najpierw wybierz pionek");
            }
            gameField.nominateQueen();
            refreshQueenImages();
        }
        private void refreshQueenImages()
        {
           var list = gameField.ListOfQueens();
            for(int i = 0;i< list.Count; ++i)
            {
                if (currentlyChosenColor != "black")
                {                 
                   pboxList[list[i] - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPieceQueen.bmp");
                }
                else
                {
                    pboxList[list[i] - 1].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePieceQueen.bmp");
                }
                pboxList[list[i] - 1].Refresh();
            }
        }
        private void MovePawn(int pawnID, List<int> list, List<int> listOfBeatenPawns)
        {
            refreshQueenImages();
            if (list.Count == 0)
            {

            }
            pawnID--;
            
            if (currentlyChosenColor != "black")
            {
                for (int i = 0; i < 12; ++i)
                {
                    pboxList[i].Image = BlackPawn;
                    pboxList[i].Refresh();
                }

            }
            else
            {
                for (int i = 0; i < 12; ++i)
                {
                    pboxList[i].Image = WhitePawn;
                    pboxList[i].Refresh();
                }
            }
            
            if (currentlyChosenColor != "black")
            {
                pboxList[pawnID].Image = BlackHPawn;
            }
            else
            {
                pboxList[pawnID].Image = WhiteHPawn;
            }

            pboxList[pawnID].Refresh();        
            System.Threading.Thread.Sleep(300);
            for (int i = 0; i < list.Count; ++i)
            {
                System.Threading.Thread.Sleep(100);
                rtbHistory.Text += "Ruch komputera z pola: ";
                rtbHistory.Text += ConvertToField(pboxList[pawnID].Location.X/90, pboxList[pawnID].Location.Y / 90) +"\n";
                switch (list[i])
                {
                    case 0:                       
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X+90, pboxList[pawnID].Location.Y+90);
                        break;
                    case 1:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 90, pboxList[pawnID].Location.Y - 90);
                        break;
                    case 2:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 90, pboxList[pawnID].Location.Y - 90);
                        break;
                    case 3:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 90, pboxList[pawnID].Location.Y + 90);
                        break;
                    case 4:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 180, pboxList[pawnID].Location.Y + 180);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 5:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 180, pboxList[pawnID].Location.Y - 180);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 6:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 180, pboxList[pawnID].Location.Y - 180);
                        if (listOfBeatenPawns.Count != 0)
                        {
                             pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                   case 7:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 180, pboxList[pawnID].Location.Y + 180);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;

                    case 8:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 270, pboxList[pawnID].Location.Y + 270);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 9:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 270, pboxList[pawnID].Location.Y - 270);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 10:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 270, pboxList[pawnID].Location.Y - 270);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 11:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 270, pboxList[pawnID].Location.Y + 270);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;

                    case 12:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 360, pboxList[pawnID].Location.Y + 360);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 13:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 360, pboxList[pawnID].Location.Y - 360);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 14:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 360, pboxList[pawnID].Location.Y - 360);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 15:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 360, pboxList[pawnID].Location.Y + 360);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 16:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 450, pboxList[pawnID].Location.Y + 450);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 17:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 450, pboxList[pawnID].Location.Y - 1450);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 18:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 450, pboxList[pawnID].Location.Y - 450);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 19:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 450, pboxList[pawnID].Location.Y + 450);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 20:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 540, pboxList[pawnID].Location.Y + 540);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 21:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 540, pboxList[pawnID].Location.Y - 540);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 22:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 540, pboxList[pawnID].Location.Y - 540);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 23:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 540, pboxList[pawnID].Location.Y + 540);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 24:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 630, pboxList[pawnID].Location.Y + 630);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 25:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 630, pboxList[pawnID].Location.Y - 630);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 26:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 630, pboxList[pawnID].Location.Y - 630);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 27:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 630, pboxList[pawnID].Location.Y + 630);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 28:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 720, pboxList[pawnID].Location.Y + 720);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 29:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X + 720, pboxList[pawnID].Location.Y - 720);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 30:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 720, pboxList[pawnID].Location.Y - 720);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                    case 31:
                        pboxList[pawnID].Location = new Point(pboxList[pawnID].Location.X - 720, pboxList[pawnID].Location.Y + 720);
                        if (listOfBeatenPawns.Count != 0)
                        {
                            pboxList[listOfBeatenPawns[0] - 1].Visible = false;
                            listOfBeatenPawns.RemoveAt(0);
                        }
                        break;
                }
                rtbHistory.Text += "Na Pole:";
                rtbHistory.Text += ConvertToField(pboxList[pawnID].Location.X / 90, pboxList[pawnID].Location.Y / 90) + "\n\n";
                
            }

            refreshQueenImages();
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            ChooseSideNewGameForm frm = new ChooseSideNewGameForm();
            frm.ShowDialog();
            string Color = frm.Color;
            string DifficultyLevel = "Easy";
           
            if (frm.wasButtonClicked)
            {
                if(Color != null && DifficultyLevel != null)
                {
                    if(Color == "Białe")
                    {
                        Color = "white";
                    }
                    else
                    {
                        Color = "black";
                    }
                    StartTheGame(Color, DifficultyLevel);
                   
                }
                else
                {
                    MessageBox.Show("Musisz najpierw wybrać parametry gry");
                }

            }
        }
        private void StartTheGame(string Color, string DifficultyLevel)
        {
            gameField = null;
            for(int i = 0; i < 24; ++i)
            {
                pboxList[i].Visible = false;
            }
            pboxList.RemoveRange(0, 24);
            currentlyChosenColor = Color;

            string imglocation1 = "", imglocation2 = "";
            if (Color == "white")
            {
                imglocation1 = "\\WhitePiece.bmp";
                imglocation2 = "\\BlackPiece.bmp";
                AIChosenColor = "black";
            }
            else
            {
                AIChosenColor = "white";
                imglocation2 = "\\WhitePiece.bmp";
                imglocation1 = "\\BlackPiece.bmp";
            }
            gameField = new GameField(currentlyChosenColor, AIChosenColor);
            gameField.diffLevel = DifficultyLevel;
            PictureBox pawnPicture;
            bool flag = false;
            int counter = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (flag)
                    {

                        pawnPicture = new PictureBox();
                        pawnPicture.Name = System.Convert.ToString(++counter);
                        pawnPicture.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + imglocation2);
                        pawnPicture.Location = new Point(j * 90, i * 90);
                        pawnPicture.Size = new Size(90, 90);
                        pawnPicture.Visible = true;
                        pawnPicture.Click += new EventHandler(ClickPawn);
                        this.Controls.Add(pawnPicture);
                        pboxList.Add(pawnPicture);
                    }
                    flag = !flag;

                }
                flag = !flag;
            }

            for (int i = 5; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (flag)
                    {
                        pawnPicture = new PictureBox();
                        pawnPicture.Name = System.Convert.ToString(++counter);
                        pawnPicture.Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + imglocation1);
                        pawnPicture.Location = new Point(j * 90, i * 90);
                        pawnPicture.Size = new Size(90, 90);
                        pawnPicture.Visible = true;
                        pawnPicture.Click += new EventHandler(ClickPawn);
                        this.Controls.Add(pawnPicture);
                        pboxList.Add(pawnPicture);
                    }
                    flag = !flag;

                }
                flag = !flag;
            }

            lastMoveWasRepeat = false;
            if (AIChosenColor == "white")
            {
                int currentAIPawn = gameField.AI_move(currentlyChosenColor);
                MovePawn(currentAIPawn, gameField.list, gameField.listOfDeletedPawns);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            EndTurn();
        }

        public void EndTurn()
        {
            if (currentlyChosenColor == "black")
            {
                for (int i = 12; i < 24; ++i)
                {
                    pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\BlackPiece.bmp");
                }

            }
            else
            {
                for (int i = 12; i < 24; ++i)
                {
                    pboxList[i].Image = Image.FromFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\WhitePiece.bmp");
                }
            }
            isGameFinished();
            currentlyChosenPawn = null;
            lastMoveWasRepeat = false;
            int currentAIPawn = gameField.AI_move(currentlyChosenColor);
            MovePawn(currentAIPawn, gameField.list, gameField.listOfDeletedPawns);
            isGameFinished();
            refreshQueenImages();
        }
        public void isGameFinished()
        {
           string msg =  gameField.isVictorious();

            switch (msg)
            {
                case "white":
                    MessageBox.Show("Wygrały pionki białe!");
                    Close();
                    break;
                case "black":
                    MessageBox.Show("Wygrały pionki czarne!");
                    Close();
                    break;
                default:
                    break;

            }
        }
        public string ConvertToField(int x, int y)
        {
            StringBuilder strB = new StringBuilder();
            switch (x)
            {
                case 0: strB.Append("A");
                    break;
                case 1:
                    strB.Append("B");
                    break;
                case 2:
                    strB.Append("C");
                    break;
                case 3:
                    strB.Append("D");
                    break;
                case 4:
                    strB.Append("E");
                    break;
                case 5:
                    strB.Append("F");
                    break;
                case 6:
                    strB.Append("G");
                    break;
                case 7:
                    strB.Append("H");
                    break;

            }
            strB.Append(System.Convert.ToString(8-(y)));
            return strB.ToString();
        }
    }
}
   
