using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class GameField
    {       
        private int lastDeletedPawn;
        public int LastDeletedPawn
        {
            get
            {
                return this.lastDeletedPawn;
            }
            set
            {
                this.lastDeletedPawn = value;

            }


        }
        public SingleField[,] GameFields;
        public List<int> list;
        public List<int> listOfDeletedPawns = new List<int>();
        public GameField(string AIcolor, string playerColor)
        {
            
            GameFields = new SingleField[8, 8];
            for(int i = 0; i < 8; ++i)
            {

                for(int j = 0; j < 8; ++j)
                {
                    GameFields[i, j] = new SingleField();
                   
                }


            }
            InitializeGameField( AIcolor, playerColor);
        }
        public void InitializeGameField(string AIcolor, string playerColor) //places pieces in first and last 3 rows for each player
        {
            
            //1st row of white pieces
            Pawn pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 1;
            GameFields[1, 0].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 2;
            GameFields[3, 0].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 3;
            GameFields[5, 0].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 4;
            GameFields[7, 0].placePawn(pawn);
            //pawnsList.Add(pawn);
            //2nd row of white pieces
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 5;
            GameFields[0, 1].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 6;
            GameFields[2, 1].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 7;
            GameFields[4, 1].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 8;
            GameFields[6, 1].placePawn(pawn);
            //pawnsList.Add(pawn);
            //3rd row of white pieces
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 9;
            GameFields[1, 2].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 10;
            GameFields[3, 2].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 11;
            GameFields[5, 2].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = AIcolor;
            pawn.pawnID = 12;
            GameFields[7, 2].placePawn(pawn);
            //pawnsList.Add(pawn);



            //1st row of black pieces
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 13;
            GameFields[0, 5].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 14;
            GameFields[2, 5].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 15;
            GameFields[4, 5].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 16;
            GameFields[6, 5].placePawn(pawn);
            //pawnsList.Add(pawn);

            //2nd row of black pieces
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 17;
            GameFields[1, 6].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 18;
            GameFields[3, 6].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 19;
            GameFields[5, 6].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 20;
            GameFields[7, 6].placePawn(pawn);
            //pawnsList.Add(pawn);
            //3rd row of black pieces
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 21;
            GameFields[0, 7].placePawn(pawn);
            //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 22;
            GameFields[2, 7].placePawn(pawn);
           // //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 23;
            GameFields[4, 7].placePawn(pawn);
           // //pawnsList.Add(pawn);
            pawn = new Pawn();
            pawn.PawnColor = playerColor;
            pawn.pawnID = 24;
            GameFields[6, 7].placePawn(pawn);
            ////pawnsList.Add(pawn);


        }
        public string IsPawnOnTheField(int wspX, int wspY)
        {
            if (GameFields[wspX, wspY] == null)
            {
                return "empty";
            } else
            {
                return GameFields[wspX, wspY].GetPawnColor();
            }


        }
        public void MovePawn(int prev_X, int prev_Y, int next_X, int next_Y)
        {

            GameFields[next_X, next_Y].pawn = GameFields[prev_X, prev_Y].pawn;
            GameFields[prev_X, prev_Y].pawn = null;

        }
        public bool CanPawnBeat(int wspX, int wspY)
        {
            if (GameFields[wspX, wspY].pawn.pawnID <= 12)//-2 -2
            {
                if (wspX - 2 >= 0 && wspY - 2 >= 0 && GameFields[wspX - 2, wspY - 2].pawn == null && GameFields[wspX - 1, wspY - 1].pawn != null && GameFields[wspX - 1, wspY - 1].pawn.pawnID > 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID <= 12)
            {
                if (wspX + 2 < 8 && wspY - 2 > 0 && GameFields[wspX + 2, wspY - 2].pawn == null && GameFields[wspX + 1, wspY - 1].pawn != null && GameFields[wspX + 1, wspY - 1].pawn.pawnID > 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID <= 12)
            {
                if (wspX - 2 >= 0 && wspY + 2 < 8 && GameFields[wspX - 2, wspY + 2].pawn == null && GameFields[wspX - 1, wspY + 1].pawn != null && GameFields[wspX - 1, wspY + 1].pawn.pawnID > 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID <= 12)
            {
                if (wspX + 2 < 8 && wspY + 2 < 8 && GameFields[wspX + 2, wspY + 2].pawn == null && GameFields[wspX + 1, wspY + 1].pawn != null && GameFields[wspX + 1, wspY + 1].pawn.pawnID > 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID > 12)//-2 -2
            {
                if (wspX - 2 >= 0 && wspY - 2 >= 0 && GameFields[wspX - 2, wspY - 2].pawn == null && GameFields[wspX - 1, wspY - 1].pawn != null && GameFields[wspX - 1, wspY - 1].pawn.pawnID < 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID > 12)
            {
                if (wspX + 2 < 8 && wspY - 2 >= 0 && GameFields[wspX + 2, wspY - 2].pawn == null && GameFields[wspX + 1, wspY - 1].pawn != null && GameFields[wspX + 1, wspY - 1].pawn.pawnID < 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID > 12)
            {
                if (wspX - 2 >= 0 && wspY + 2 < 8 && GameFields[wspX - 2, wspY + 2].pawn == null && GameFields[wspX - 1, wspY + 1].pawn != null && GameFields[wspX - 1, wspY + 1].pawn.pawnID < 12)
                {
                    return true;
                }

            }
            if (GameFields[wspX, wspY].pawn.pawnID > 12)
            {
                if (wspX + 2 < 8 && wspY + 2 < 8 && GameFields[wspX + 2, wspY + 2].pawn == null && GameFields[wspX + 1, wspY + 1].pawn != null && GameFields[wspX + 1, wspY + 1].pawn.pawnID < 12)
                {
                    return true;
                }

            }




            return false;
        }
        public bool CanPlayerBeat()
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (GameFields[i, j].pawn != null && GameFields[i, j].pawn.pawnID > 12)
                    {
                        if (CanPawnBeat(i, j) == true)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //prev_X/prev_Y -> stare współrzędne pionka next_X/next_Y-> nowe współrzędne pionka
        public string TryMove(int prev_X, int prev_Y, int next_X, int next_Y)//returns an information if pawn placed at prev_X/prev_Y can move to next_X/next_Y
        {
            if (CanPlayerBeat() == true && Math.Abs(prev_Y - next_Y) != 2) // zwraca "beat", jeśli gracz ma możliwość zbicia i z niego nie skorzystał
            {
                return "beat";
            }
           
            if (next_Y - prev_Y == 1)//zwaraca "no", jeśli gracz chce się ruszyć w tył
            {
                return "no";
            }
            string chosenPawnColor = GameFields[prev_X, prev_Y].GetPawnColor(); // zapisuje kolor pionka którym chcemy się ruszyć
            if(chosenPawnColor!="empty") { //checks if destination field is empty
               
                if (Math.Abs(next_X - prev_X) == 1 && Math.Abs(next_Y - prev_Y) == 1)  //sprawdza, czy ruch nie jest o jedno pole po skosie          
                {
                    if(next_Y-prev_Y > 0) //
                    {
                        return "no";
                    }
                    MovePawn( prev_X,  prev_Y, next_X,  next_Y);
                    
                    return "yes";

                }  //warunek linijkę niżej sprawdza, czy ruch wykonany przez gracza jest ruchem zbijającym
                else if (Math.Abs(next_X - prev_X) == 2 && Math.Abs(next_Y - prev_Y) == 2 
                    && GameFields[(next_X+prev_X)/2,(next_Y+prev_Y)/2].GetPawnColor()!="empty" 
                    && GameFields[(next_X + prev_X) / 2,(next_Y + prev_Y) / 2].GetPawnColor()!=chosenPawnColor ) 
                {

                    lastDeletedPawn = GameFields[(next_X + prev_X) / 2, (next_Y + prev_Y) / 2].pawn.pawnID;
                    GameFields[(next_X + prev_X) / 2, (next_Y + prev_Y) / 2].pawn = null; //zbija pionek
                    MovePawn(prev_X, prev_Y, next_X, next_Y); // przesuwa pionek
                    return "repeat"; //zwraca informację o wykonanej akcji

                }
            }
            return "no"; //zwraca "no", czyli gracz wykonał nie przewidziany niedozwolony ruch
        }       
        public int[,] GetGameStateArray(string AIcolor) //returns an array, where 0 -> AI pawn, 1->players pawn -1 -> empty field
        {
            int[,] array = new int[8, 8]; //tworzy tablicę
            for(int i = 0; i < 8; ++i)//przechodzi po calej szachownicy
            {
                for (int j = 0; j < 8; ++j)
                {
                    if(GameFields[i,j].pawn ==null)//jeśli na polu nie ma pionka to wstawia -1 do nowej tablicy
                    {
                        array[i, j] = -1; // empty field
                    } else if (GameFields[i,j].pawn.PawnColor == AIcolor) //jeśli pionek ma ten kolor którym gra komputer ustawia wartość 0, -2 dla damki
                    {
                        if (GameFields[i, j].pawn.isQueen) //sprawdza czy pionek jest damką
                            array[i, j] = -2;
                        else
                        array[i, j] = 0;
                    }
                    else  //jeśli pionek ma ten kolor którym gra gracz ustawia wartość 1, -3 dla damki
                    {                 
                        if (GameFields[i, j].pawn.isQueen) //sprawdza czy pionek jest damką
                            array[i, j] = -3; 
                        else
                            array[i, j] = 1;
                    }
                   
                }
            }
            return array;
         }
        public string diffLevel
        {
            get; set;
        }
        public int AI_move(String color)
        {
            Algorithm algorithm;
            if(diffLevel == "Easy")
            {
                algorithm = new Algorithm(5 ,4);
            } else
            {
                algorithm = new Algorithm(6, 5);
            }
            
            
            algorithm.exec(GetGameStateArray(color), 1);
            list = algorithm.getMoveList();
            int i = algorithm.getI();
            int j = algorithm.getJ();
            int I = i, J = j;
           
            if (list.Count != 1)
            {
                List<int> lista = new List<int>();
                for (int c = 0; c < list.Count; ++c)
                {
                    switch (list[c])
                    {
                        case 4:
                            if (i + 2 < 8 && j + 2 < 8)
                            {
                                if (GameFields[i + 1, j + 1].pawn != null && GameFields[i + 1, j + 1].pawn.pawnID >= 12)
                                {
                                    if (GameFields[i + 2, j + 2].pawn == null)
                                    {
                                        i += 2; j += 2;
                                        lista.Add(4);
                                    }
                                    else
                                    {
                                        c = 20;
                                    }
                                }
                                else
                                {
                                    c = 20;
                                }
                            }
                            else
                            {
                                c = 20;
                            }

                            break;
                        case 5:
                            if (i + 2 < 8 && j - 2 >= 0)
                            {
                                if (GameFields[i + 1, j - 1].pawn != null && GameFields[i + 1, j - 1].pawn.pawnID >= 12)
                                {
                                    if (GameFields[i + 2, j - 2].pawn == null)
                                    {
                                        i += 2; j -= 2;
                                        lista.Add(5);
                                    }
                                    else
                                    {
                                        c = 20;
                                    }
                                }
                                else
                                {
                                    c = 20;
                                }
                            }
                            else
                            {
                                c = 20;
                            }
                            break;
                        case 6:
                            if (i - 2 >= 0 && j - 2 >= 0)
                            {
                                if (GameFields[i - 1, j - 1].pawn != null && GameFields[i - 1, j - 1].pawn.pawnID >= 12)
                                {
                                    if (GameFields[i - 2, j - 2].pawn == null)
                                    {
                                        i -= 2; j -= 2;
                                        lista.Add(6);
                                    }
                                    else
                                    {
                                        c = 20;
                                    }
                                }
                                else
                                {
                                    c = 20;
                                }
                            }
                            else
                            {
                                c = 20;
                            }
                            break;
                        case 7:

                            if (i - 2 >= 0 && j + 2 < 8)
                            {
                                if (GameFields[i - 1, j + 1].pawn != null && GameFields[i - 1, j + 1].pawn.pawnID >= 12)
                                {
                                    if (GameFields[i - 2, j + 2].pawn == null)
                                    {
                                        i -= 2; j += 2;
                                        lista.Add(7);
                                    }
                                    else
                                    {
                                        c = 20;
                                    }
                                }
                                else
                                {
                                    c = 20;
                                }
                            }
                            else
                            {
                                c = 20;
                            }
                            break;


                        default:
                            c = 20;
                            break;
                    }

                }
                list = lista.ToList();
            }

            int returnVal = GameFields[I, J].pawn.pawnID;
            
            
                moveSwitch(list, I, J);


           
            return returnVal;
        }       
        public List<int> moveSwitch(List<int> list, int i, int j)
        {
            listOfDeletedPawns.Clear();
            for (int k = 0; k < list.Count; ++k)
            {
                switch (list[k])
                {
                    case 0:
                       
                        GameFields[i + 1, j + 1].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        break;
                    case 1:
                       
                        GameFields[i + 1, j - 1].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        break;

                    case 2:
                       
                        GameFields[i - 1, j - 1].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        break;

                    case 3:
                        
                        GameFields[i - 1, j + 1].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        break;
                    case 4:
                        if (GameFields[i + 1, j + 1].pawn == null)
                        {
                            k = list.Count;
                            while (list.Count > listOfDeletedPawns.Count)
                            {
                                list.RemoveAt(list.Count - 1);
                            }
                            break;
                        }
                        listOfDeletedPawns.Add(GameFields[i + 1, j + 1].pawn.pawnID);
                        GameFields[i + 2, j + 2].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        GameFields[i + 1, j + 1].pawn = null;
                        i += 2; j += 2;
                        break;
                    case 5:
                        if (GameFields[i + 1, j - 1] == null)
                        {
                            k = list.Count;
                            while(list.Count > listOfDeletedPawns.Count)
                            {
                                list.RemoveAt(list.Count - 1);
                            }
                            break;
                        }
                        listOfDeletedPawns.Add(GameFields[i + 1, j - 1].pawn.pawnID);
                        GameFields[i + 2, j - 2].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        GameFields[i + 1, j - 1].pawn = null;
                        i += 2; j -= 2;
                        break;

                    case 6:
                        if (GameFields[i - 1, j - 1].pawn == null)
                        {
                            k = list.Count;
                            while (list.Count > listOfDeletedPawns.Count)
                            {
                                list.RemoveAt(list.Count - 1);
                            }
                            break;
                        }
                        listOfDeletedPawns.Add(GameFields[i - 1, j - 1].pawn.pawnID);
                        GameFields[i - 2, j - 2].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        GameFields[i - 1, j - 1].pawn = null;
                        i -= 2; j -= 2;
                        break;

                    case 7:
                        if (GameFields[i - 1, j + 1].pawn == null)
                        {
                            k = list.Count;
                            while (list.Count > listOfDeletedPawns.Count)
                            {
                                list.RemoveAt(list.Count - 1);
                            }
                            break;
                        }
                        listOfDeletedPawns.Add(GameFields[i - 1, j + 1].pawn.pawnID);
                        GameFields[i - 2, j + 2].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        GameFields[i - 1, j + 1].pawn = null;
                        i -= 2; j += 2;
                        break;
                    case 8:
                        
                        GameFields[i + 3, j + 3].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 3, j + 3, listOfDeletedPawns);
                        i += 3; j += 3;
                        break;
                    case 9:
                        
                        GameFields[i + 3, j - 3].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 3, j - 3, listOfDeletedPawns);
                        i += 3; j -= 3;
                        break;

                    case 10:
                        
                        GameFields[i - 3, j - 3].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 3, j - 3, listOfDeletedPawns);
                        i -= 3; j -= 3;
                        break;

                    case 11:
                        
                        GameFields[i - 3, j + 3].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 3, j + 3, listOfDeletedPawns);
                        i -= 3; j += 3;
                        break;
                    case 12:
                        
                        GameFields[i + 4, j + 4].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 4, j + 4, listOfDeletedPawns);
                        i += 4; j += 4;
                        break;
                    case 13:
                        
                        GameFields[i + 4, j - 4].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 4, j - 4, listOfDeletedPawns);
                        i += 4; j -= 4;
                        break;

                    case 14:
                        
                        GameFields[i - 4, j - 4].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 4, j - 4, listOfDeletedPawns);
                        i -= 4; j -= 4;
                        break;

                    case 15:
                        
                        GameFields[i - 4, j + 4].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 4, j + 4, listOfDeletedPawns);
                        i -= 4; j += 4;
                        break;
                    case 16:
                        
                        GameFields[i + 5, j + 5].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 5, j + 5, listOfDeletedPawns);
                        i += 5; j += 5;
                        break;
                    case 17:
                        
                        GameFields[i + 5, j - 5].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 5, j - 5, listOfDeletedPawns);
                        i += 5; j -= 5;
                        break;

                    case 18:
                        
                        GameFields[i - 5, j - 5].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 5, j - 5, listOfDeletedPawns);
                        i -= 5; j -= 5;
                        break;

                    case 19:
                        
                        GameFields[i - 5, j + 5].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 5, j + 5, listOfDeletedPawns);
                        i -= 5; j += 5;
                        break;
                    case 20:
                        GameFields[i + 6, j + 6].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 6, j + 6, listOfDeletedPawns);
                        i += 6; j += 6;
                        break;
                    case 21:
                        
                        GameFields[i + 6, j - 6].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 6, j - 6, listOfDeletedPawns);
                        i += 6; j -= 6;
                        break;

                    case 22:
                       
                        GameFields[i - 6, j - 6].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 6, j - 6, listOfDeletedPawns);
                        i -= 6; j -= 6;
                        break;

                    case 23:
                       
                        GameFields[i - 6, j + 6].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 6, j + 6, listOfDeletedPawns);
                        i -= 6; j += 6;
                        break;
                    case 24:
                        
                        GameFields[i + 7, j + 7].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 7, j + 7, listOfDeletedPawns);
                        i += 7; j += 7;
                        break;
                    case 25:
                        
                        GameFields[i + 7, j - 7].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i + 7, j - 7, listOfDeletedPawns);
                        i += 7; j -= 7;
                        break;

                    case 26:
                        
                        GameFields[i - 7, j - 7].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 7, j - 7, listOfDeletedPawns);
                        i -= 7; j -= 7;
                        break;

                    case 27:
                        
                        GameFields[i - 7, j + 7].pawn = GameFields[i, j].pawn;
                        GameFields[i, j].pawn = null;
                        beatPawnsBetweenFields(i, j, i - 7, j + 7, listOfDeletedPawns);
                        i -= 7; j += 7;
                        break;
                }
            }

            return listOfDeletedPawns;

        }
        public string isVictorious() //funkcja sprawdzająca, czy ktoś już wygrał
        {
            int blackPawns = 0, whitePawns = 0; //liczniki czarnych i białych pionków
            for(int i =0;i <8; ++i) // podwójna pętla przechodząca przez całą szachownicę
            {
                for(int j = 0; j < 8; ++j)
                {
                    if(GameFields[i,j].pawn != null) //sprawdza, czy na danym polu istnieje pionek
                    {
                        if(GameFields[i, j].pawn.PawnColor == "black") //pionek jest czarny
                        {
                            blackPawns++; //inkrementuje licznik czarnych pionków
                        }
                        else //pionek jest biały
                        {
                            whitePawns++;//inkrementuje licznik białych pionków
                        }

                    }
                }
                
            }
            if (whitePawns == 0 || blackPawns == 0) //sprawdza, czy któreś z pionków zostały "wyzerowane"
            {
                return whitePawns != 0 ?   "black" : "white"; //zwraca odpowiedni ciąg znaków
            }
            return ""; //zwraca pustą wartość
        }
        public int nominateQueen()
        {

            for (int i = 0; i < 8; ++i)
            {
                //dla gracza
                if (GameFields[i, 0].pawn != null && GameFields[i, 0].pawn.pawnID > 12)
                {
                    if (GameFields[i, 0].pawn.isQueen == false)
                    {
                        GameFields[i, 0].pawn.isQueen = true;
                        return GameFields[i, 0].pawn.pawnID;
                    }
                }
                //dla AI
                if (GameFields[i, 7].pawn != null && GameFields[i, 7].pawn.pawnID <= 12)
                {
                    if (GameFields[i, 7].pawn.isQueen == false)
                    {
                        GameFields[i, 7].pawn.isQueen = true;
                        return GameFields[i, 7].pawn.pawnID;
                    }
                }
            }
            return -1;


        }

        public bool canBeat(int i, int j)
        {
            string playerColor = GameFields[i, j].pawn.PawnColor;
                    if(GameFields[i,j].pawn!=null && GameFields[i,j].pawn.PawnColor == playerColor)
                    {
                        if(i+2<8 && j + 2<8 && 
                            GameFields[i+2, j+2].pawn == null && 
                            GameFields[i+1, j+1].pawn != null && 
                            GameFields[i + 1, j + 1].pawn.PawnColor != playerColor)
                        {
                            return true;
                        }
                        if (i - 2 >= 0 && j + 2 < 8 &&
                            GameFields[i - 2, j + 2].pawn == null &&
                            GameFields[i - 1, j + 1].pawn != null &&
                            GameFields[i - 1, j + 1].pawn.PawnColor != playerColor)
                        {
                            return true;
                        }
                        if (i - 2 >= 0 && j - 2 >=0 &&
                            GameFields[i - 2, j - 2].pawn == null &&
                            GameFields[i - 1, j - 1].pawn != null &&
                            GameFields[i - 1, j - 1].pawn.PawnColor != playerColor)
                        {
                            return true;
                        }
                        if (i + 2 <8 && j - 2 >= 0 &&
                            GameFields[i + 2, j - 2].pawn == null &&
                            GameFields[i + 1, j - 1].pawn != null &&
                            GameFields[i + 1, j - 1].pawn.PawnColor != playerColor)
                        {
                            return true;
                        }
                    
                
            }
            return false;
        }
        public void beatPawnsBetweenFields(int x1, int y1, int x2, int y2, List<int> listOfBeatenPawns)
        {
            if(x2>x1 && y2 > y1)
            {
                for(int i = 1; i< Math.Abs(x2 - x1); ++i)
                {
                    if (GameFields[x1 + i, y1 + i].pawn != null)
                    {
                        listOfBeatenPawns.Add(GameFields[x1 + i, y1 + i].pawn.pawnID);
                        GameFields[x1 + i, y1 + i].pawn = null;
                        break;
                    }
                }
            } else if(x2>x1 && y1 > y2)
            {
                for (int i = 1; i < Math.Abs(x2 - x1); ++i)
                {
                    if (GameFields[x1 + i, y2 + i].pawn != null)
                    {
                        listOfBeatenPawns.Add(GameFields[x1 + i, y2 + i].pawn.pawnID);
                        GameFields[x1 + i, y2 + i].pawn = null;
                        break;
                    }
                }
            } else if(x1>x2 && y2 > y1)
            {
                for (int i = 1; i < Math.Abs(x2 - x1); ++i)
                {
                    if (GameFields[x2+ i, y1 + i].pawn != null)
                    {
                        listOfBeatenPawns.Add(GameFields[x2 + i, y1 + i].pawn.pawnID);
                        GameFields[x2 + i, y1 + i].pawn = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 1; i < Math.Abs(x2 - x1); ++i)
                {
                    if (GameFields[x2 + i, y2 + i].pawn != null)
                    {
                        listOfBeatenPawns.Add(GameFields[x2 + i, y2 + i].pawn.pawnID);
                        GameFields[x2 + i, y2 + i].pawn = null;
                        break;
                    }
                }
            }

        }

        public List<int> ListOfQueens()
        {
            List<int> listOfQueens = new List<int>();
            for(int i = 0; i < 8; ++i)
            {
                for(int j = 0; j < 8; ++j)
                {
                    if(GameFields[i,j].pawn!= null  && GameFields[i, j].pawn.isQueen)
                    {
                        listOfQueens.Add(GameFields[i, j].pawn.pawnID);
                    }
                }
            }
           
            return listOfQueens;
        }
    }
}
