using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby
{
    class Algorithm
    {

        List<int> listJump;

        List<int> miniMaxList;
        List<int> miniMaxTempList;
        double currentlyBiggestVal = -10000000;
        int pawnPosI;
        int pawnPosJ;
        bool flagRecurency = false;
        int count = 0;
        int[,] tempTabLongestJump;
        int waga1, waga2;
        public Algorithm(int Waga1, int Waga2)
        {
            this.waga1 = Waga1;
            this.waga2 = Waga2;
            listJump = new List<int>();
            miniMaxTempList = new List<int>();
            miniMaxList = new List<int>();
            tempTabLongestJump = new int[8, 8];
            currentlyBiggestVal = -10000000;
        }

        public void exec(int[,] tab, int maxDepth)
        {
            

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (tab[i, j] == 1)
                    {
                        ++count;
                    }
                }
            }

            executeAlgorithm(tab, 1, 0);
        }

        public void executeAlgorithm(int[,] tab, int maxDepth, int currentDepth)
        {

            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (tab[i, j] == 0 )
                    {
                        rankingFunction(i, j, tab, currentDepth, maxDepth);
                    }
                    else if (tab[i, j] == -2) //damka
                    {
                        rankingFunQueen2(i, j, tab, currentDepth, maxDepth);
                    }
                }
            }
        }
        public List<int> getMoveList()
        {

            if (miniMaxTempList[0] < 4)
            {
                while (miniMaxTempList.Count != 1)
                {
                    miniMaxTempList.RemoveAt(miniMaxTempList.Count - 1);
                }
                return miniMaxTempList;
            }
            else
            {


                while (miniMaxTempList[miniMaxTempList.Count - 1] < 4)
                {
                    miniMaxTempList.RemoveAt(miniMaxTempList.Count - 1);
                }
            }

            return miniMaxTempList;
        }
        public int getI()
        {
            return pawnPosI;
        }
        public int getJ()
        {
            return pawnPosJ;
        }
        public void rankingFunction(int i, int j, int[,] tab, int currentDepth, int maxDepth)
        {
            List<int> listJump2 = new List<int>();
            if (currentDepth == maxDepth)
            {

                double val = count > 3 ? getGameValue(tab) : getGameValueSecondPhase(tab);
                if (val > currentlyBiggestVal)
                {
                    currentlyBiggestVal = val;
                    miniMaxTempList.Clear();
                    for (int c = 0; c < miniMaxList.Count; ++c)
                    {
                        miniMaxTempList.Add(miniMaxList[c]);
                    }
                    flagRecurency = true;
                }
            }
            else
            {
                int[,] nextTab;
                if (i + 1 < 8 && j + 1 < 8 && tab[i + 1, j + 1] == -1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i + 1, j + 1] = 0; //wykonanie ruchu
                    nextTab[i, j] = -1; //zwolnienie miejsca
                    miniMaxList.Add(0);
                    nextTab = findBestMoveForPlayer(nextTab, 1);
                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;
                    }
                    miniMaxList.RemoveAt(miniMaxList.Count - 1);

                }
                //if (i + 1 < 8 && j - 1 >= 0 && tab[i + 1, j - 1] == -1)
                //{
                //    //rekur 
                //    nextTab = (int[,])tab.Clone();
                //    nextTab[i + 1, j - 1] = 0;
                //    nextTab[i, j] = -1;
                //    miniMaxList.Add(1);
                //    nextTab = findBestMoveForPlayer(nextTab, 1);
                //    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                //    if (currentDepth == 0 && flagRecurency == true)
                //    {
                //        flagRecurency = false;
                //        pawnPosI = i;
                //        pawnPosJ = j;
                //    }
                //    miniMaxList.RemoveAt(miniMaxList.Count - 1);
                //}
                //if (i - 1 >= 0 && j - 1 >= 0 && tab[i - 1, j - 1] == -1)
                //{
                //    //rekur 
                //    nextTab = (int[,])tab.Clone();
                //    nextTab[i - 1, j - 1] = 0;
                //    nextTab[i, j] = -1;
                //    miniMaxList.Add(2);
                //    nextTab = findBestMoveForPlayer(nextTab, 1);
                //    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                //    if (currentDepth == 0 && flagRecurency == true)
                //    {
                //        flagRecurency = false;
                //        pawnPosI = i;
                //        pawnPosJ = j;
                //    }
                //    miniMaxList.RemoveAt(miniMaxList.Count - 1);
                //}
                if (i - 1 >= 0 && j + 1 < 8 && tab[i - 1, j + 1] == -1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i - 1, j + 1] = 0;
                    nextTab[i, j] = -1;
                    miniMaxList.Add(3);
                    nextTab = findBestMoveForPlayer(nextTab, 1);
                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;
                    }
                    miniMaxList.RemoveAt(miniMaxList.Count - 1);
                }



                //bicia 
                if (i + 2 < 8 && j + 2 < 8 && tab[i + 2, j + 2] == -1 && tab[i + 1, j + 1] == 1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i, j] = -1;
                    nextTab[i + 2, j + 2] = 0;
                    nextTab[i + 1, j + 1] = -1;
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 0).Clone();
                    listJump2.Clear();
                    listJump2.Add(4);
                    miniMaxList.Add(4);
                    for (int c = 0; c < listJump.Count; ++c)
                    {
                        listJump2.Add(listJump[c]);
                        miniMaxList.Add(listJump[c]);
                    }
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 1).Clone();

                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;
                    }

                    for (int c = 0; c < listJump2.Count; ++c)
                    {
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                    }



                }

                if (i + 2 < 8 && j - 2 >= 0 && tab[i + 2, j - 2] == -1 && tab[i + 1, j - 1] == 1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i, j] = -1;
                    nextTab[i + 2, j - 2] = 0;
                    nextTab[i + 1, j - 1] = -1;
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 0).Clone();
                    listJump2.Clear();
                    listJump2.Add(5);
                    miniMaxList.Add(5);
                    for (int c = 0; c < listJump.Count; ++c)
                    {
                        listJump2.Add(listJump[c]);
                        miniMaxList.Add(listJump[c]);
                    }
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 1).Clone();
                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;

                    }
                    for (int c = 0; c < listJump2.Count; ++c)
                    {
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                    }

                }

                if (i - 2 >= 0 && j - 2 >= 0 && tab[i - 2, j - 2] == -1 && tab[i - 1, j - 1] == 1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i, j] = -1;
                    nextTab[i - 2, j - 2] = 0;
                    nextTab[i - 1, j - 1] = -1;
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 0).Clone();
                    listJump2.Clear();
                    listJump2.Add(6);
                    miniMaxList.Add(6);
                    for (int c = 0; c < listJump.Count; ++c)
                    {
                        listJump2.Add(listJump[c]);
                        miniMaxList.Add(listJump[c]);
                    }
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 1).Clone();
                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;

                    }
                    for (int c = 0; c < listJump2.Count; ++c)
                    {
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                    }

                }
                if (i - 2 >= 0 && j + 2 < 8 && tab[i - 2, j + 2] == -1 && tab[i - 1, j + 1] == 1)
                {
                    //rekur 
                    nextTab = (int[,])tab.Clone();
                    nextTab[i, j] = -1;
                    nextTab[i - 2, j + 2] = 0;
                    nextTab[i - 1, j + 1] = -1;
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 0).Clone();
                    listJump2.Clear();
                    listJump2.Add(7);
                    miniMaxList.Add(7);
                    for (int c = 0; c < listJump.Count; ++c)
                    {
                        listJump2.Add(listJump[c]);
                        miniMaxList.Add(listJump[c]);
                    }
                    nextTab = (int[,])findBestMoveForPlayer(nextTab, 1).Clone();
                    executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                    if (currentDepth == 0 && flagRecurency == true)
                    {
                        flagRecurency = false;
                        pawnPosI = i;
                        pawnPosJ = j;
                    }
                    for (int c = 0; c < listJump2.Count; ++c)
                    {
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                    }
                }

            }
        }

        public void rankingFunQueen2(int x, int y, int[,] tab, int currentDepth, int maxDepth)
        {
            int[,] nextTab;
            if (currentDepth == maxDepth)
            {

                double val = count > 3 ? getGameValue(tab) : getGameValueSecondPhase(tab);
                if (val >= currentlyBiggestVal)
                {
                    currentlyBiggestVal = val;
                    miniMaxTempList.Clear();
                    for (int c = 0; c < miniMaxList.Count; ++c)
                    {
                        miniMaxTempList.Add(miniMaxList[c]);
                    }
                    flagRecurency = true;
                }
            }
            else
            {

                //dla +i + i
                for(int i = 1; i < 8; ++i) 
                {
                    if(x+i <8 && y+i <8)
                    {
                        if (tab[x + i, y + i] == -1)
                        {                       
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x + i, y + i] = 2;
                            miniMaxList.Add(0 + i * 4);
                            executeAlgorithm(nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                        }
                        if(tab[x+i,y+i] == -2 || tab[x + i, y + i] == 0)//pionek AI
                        {
                            break;
                        }
                        if(tab[x+i,y+i] == 1 && x+i+1 <8 && y+i+1 <8 && tab[x + i +1, y + i+1] == -1)//pole z pionkiem gracza, a następne puste
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x + i +1, y + i+1] = 2;
                            nextTab[x + i, y + 1] = -1;
                            miniMaxList.Add(0 + (i+1) * 4);
                            rankingFunQueenBeated(x + i + 1, y + i + 1, nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                            break;
                        }

                    }                   
                }

                //dla +1 -1
                for (int i = 1; i < 8; ++i)
                {
                    if (x + i < 8 && y - i >= 0)
                    {
                        if (tab[x + i, y- i] == -1)
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x + i, y - i] = 2;
                            miniMaxList.Add(1 + i * 4);
                            executeAlgorithm(nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                        }
                        if (tab[x + i, y - i] == -2 || tab[x + i, y - i] == 0)//pionek AI
                        {
                            break;
                        }
                        if (tab[x + i, y - i] == 1 && x + i + 1 < 8 && y - i - 1 >= 0 && tab[x + i + 1, y - i - 1] == -1)//pole z pionkiem gracza, a następne puste
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x + i + 1, y - i - 1] = 2;
                            nextTab[x + i, y - i] = -1;
                            miniMaxList.Add(1 + (i) * 4);
                            rankingFunQueenBeated(x + i + 1, y - i - 1, nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }                         
                            miniMaxList.Clear();
                            
                            break;
                        }

                    }
                }
                //dla -i + i
                for (int i = 1; i < 8; ++i)
                {
                    if (x - i >= 0 && y + i < 8)
                    {
                        if (tab[x - i, y + i] == -1)
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x - i, y + i] = 2;
                            miniMaxList.Add(3 + i * 4);
                            executeAlgorithm(nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                        }
                        if (tab[x - i, y + i] == -2 || tab[x - i, y + i] == 0)//pionek AI
                        {
                            break;
                        }
                        if (tab[x - i, y + i] == 1 && x - i - 1 >= 0 && y + i + 1 < 8 && tab[x - i - 1, y + i + 1] == -1)//pole z pionkiem gracza, a następne puste
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x - i - 1, y + i + 1] = 2;
                            nextTab[x - i, y + i] = -1;
                            miniMaxList.Add(3 + (i) * 4);
                            rankingFunQueenBeated(x - i - 1, y + i + 1, nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                            break;
                        }

                    }
                }
                //dla -i -i
                for (int i = 1; i < 8; ++i)
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if (tab[x - i, y - i] == -1)
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x - i, y - i] = 2;
                            miniMaxList.Add(2 + i * 4);
                            executeAlgorithm(nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                        }
                        if (tab[x - i, y - i] == -2 || tab[x - i, y - i] == 0)//pionek AI
                        {
                            break;
                        }
                        if (tab[x - i, y - i] == 1 && x - i - 1 >= 0 && y - i - 1 >= 0 && tab[x - i - 1, y - i - 1] == -1)//pole z pionkiem gracza, a następne puste
                        {
                            nextTab = (int[,])tab.Clone();
                            nextTab[x, y] = -1;
                            nextTab[x - i - 1, y - i - 1] = 2;
                            nextTab[x - i, y - i] = -1;
                            miniMaxList.Add(2 + (i) * 4);
                            rankingFunQueenBeated(x - i - 1, y - i - 1, nextTab, 1, 1);
                            if (currentDepth == 0 && flagRecurency == true)
                            {
                                flagRecurency = false;
                                pawnPosI = x;
                                pawnPosJ = y;
                            }
                            miniMaxList.Clear();
                            break;
                        }

                    }
                }

            }
        }
        public void rankingFunQueenBeated(int x, int y, int[,] tab, int currentDepth, int maxDepth) //przypadek ze nie ma bić
        {
            int counter = 0;
            int[,] nextTab;
            for (int i = 1; i < 8; ++i)
            {
                if (x + i < 8 && y + i < 8)
                {
                    
                    if (tab[x + i, y + i] == -2 || tab[x + i, y + i] == 0)//pionek AI
                    {
                        break;
                    }
                    if (tab[x + i, y + i] == 1 && x + i + 1 < 8 && y + i + 1 < 8 && tab[x + i + 1, y + i + 1] == -1)//pole z pionkiem gracza, a następne puste
                    {
                        ++counter;
                        nextTab = (int[,])tab.Clone();
                        nextTab[x, y] = -1;
                        nextTab[x + i + 1, y + i + 1] = 2;
                        nextTab[x + i, y + i] = -1;
                        miniMaxList.Add(0 + (i) * 4);
                        rankingFunQueenBeated(x + i + 1, y + i + 1, nextTab, 1, 1);
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                        break;
                    }

                }
            }

            //dla +1 -1
            for (int i = 1; i < 8; ++i)
            {
                if (x + i < 8 && y - i >= 0)
                {
                   
                    if (tab[x + i, y - i] == -2 || tab[x + i, y - i] == 0)//pionek AI
                    {
                        break;
                    }
                    if (tab[x + i, y - i] == 1 && x + i + 1 < 8 && y - i - 1 >= 0 && tab[x + i + 1, y - i - 1] == -1)//pole z pionkiem gracza, a następne puste
                    {
                        ++counter;
                        nextTab = (int[,])tab.Clone();
                        nextTab[x, y] = -1;
                        nextTab[x + i + 1, y - i - 1] = 2;
                        nextTab[x + i, y - i] = -1;
                        miniMaxList.Add(1 + (i ) * 4);
                        rankingFunQueenBeated(x + i + 1, y - i - 1, nextTab, 1, 1);
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                        break;
                    }

                }
            }
            //dla -i + i
            for (int i = 1; i < 8; ++i)
            {
                if (x - i >= 0 && y + i < 8)
                {
                    
                    if (tab[x - i, y + i] == -2 || tab[x - i, y + i] == 0)//pionek AI
                    {
                        break;
                    }
                    if (tab[x - i, y + i] == 1 && x - i - 1 >= 0 && y + i + 1 < 8 && tab[x - i - 1, y + i + 1] == -1)//pole z pionkiem gracza, a następne puste
                    {
                        ++counter;
                        nextTab = (int[,])tab.Clone();
                        nextTab[x, y] = -1;
                        nextTab[x - i - 1, y + i + 1] = 2;
                        nextTab[x - i, y + i] = -1;
                        miniMaxList.Add(3 + (i) * 4);
                        rankingFunQueenBeated(x - i - 1, y + i + 1, nextTab, 1, 1);
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                        break;
                    }

                }
            }
            //dla -i -i
            for (int i = 1; i < 8; ++i)
            {
                if (x - i >= 0 && y - i >= 0)
                {
                    
                    if (tab[x - i, y - i] == -2 || tab[x - i, y - i] == 0)//pionek AI
                    {
                        break;
                    }
                    if (tab[x - i, y - i] == 1 && x - i - 1 >= 0 && y - i - 1 >= 0 && tab[x - i - 1, y - i - 1] == -1)//pole z pionkiem gracza, a następne puste
                    {
                        ++counter;
                        
                        nextTab = (int[,])tab.Clone();
                        nextTab[x, y] = -1;
                        nextTab[x - i - 1, y - i - 1] = 2;
                        nextTab[x - i, y - i] = -1;
                        miniMaxList.Add(2 + (i) * 4);
                        rankingFunQueenBeated(x - i - 1, y - i - 1, nextTab, 1, 1);
                        miniMaxList.RemoveAt(miniMaxList.Count - 1);
                        break;
                    }

                }
            }
            if (counter == 0)
            {
                executeAlgorithm(tab, 1, 1);
            }
        }
        public void rankingFunQueen(int x, int y, int[,] tab, int currentDepth, int maxDepth, bool wasBeaten)
        {
            int counter = 0;
            int[,] nextTab;
            if (currentDepth == maxDepth)
            {

                double val = count > 3 ? getGameValue(tab) : getGameValueSecondPhase(tab);
                if (val > currentlyBiggestVal)
                {
                    currentlyBiggestVal = val;
                    miniMaxTempList.Clear();
                    for (int c = 0; c < miniMaxList.Count; ++c)
                    {
                        miniMaxTempList.Add(miniMaxList[c]);
                    }
                    flagRecurency = true;
                }
            }
            else
            {
                for (int i = 1; i < 8; ++i)
                {
                    if (x + i < 8 && y + i < 8)
                    {
                        if (tab[x + i, y + i] == 1 && counter < 1)
                        {
                            ++counter;

                        }
                        else if (tab[x + i, y + i] == -1)
                        {
                            if ((wasBeaten && counter == 1) || (!wasBeaten))
                            {


                                nextTab = (int[,])tab.Clone();
                                nextTab[x, y] = -1;
                                nextTab[x + i, y + i] = -2;
                                if (counter != 0) //pawn was beaten
                                {
                                    --counter;
                                    nextTab[x + i - 1, y + i - 1] = -1;
                                    rankingFunQueen(x + i, y + i, nextTab, currentDepth, maxDepth, true);
                                }
                                miniMaxList.Add(0 + 4 * (i - 1));
                                executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                                miniMaxList.RemoveAt(miniMaxList.Count - 1);
                            }

                        }
                        else if (counter == 1 && tab[x + i, y + i] == 1) { break; }
                    }
                    else
                    {
                        break;
                    }
                }
                counter = 0;
                for (int i = 1; i < 8; ++i)
                {
                    if (x + i < 8 && y - i >= 0)
                    {
                        if (tab[x + i, y - i] == 1 && counter < 1)
                        {
                            ++counter;

                        }
                        else if (tab[x + i, y - i] == -1)
                        {
                            if ((wasBeaten && counter == 1) || (!wasBeaten))
                            {


                                nextTab = (int[,])tab.Clone();
                                nextTab[x, y] = -1;
                                nextTab[x + i, y - i] = -2;
                                if (counter != 0) //pawn was beaten
                                {
                                    --counter;
                                    nextTab[x + i - 1, y - i + 1] = -1;
                                    rankingFunQueen(x + i, y - i, nextTab, currentDepth, maxDepth, true);
                                }
                                miniMaxList.Add(1 + 4 * (i - 1));
                                executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                                miniMaxList.RemoveAt(miniMaxList.Count - 1);
                            }

                        }
                        else if (counter == 1 && tab[x + i, y - i] == 1) { break; }
                    }
                    else
                    {
                        break;
                    }
                }
                counter = 0;
                for (int i = 1; i < 8; ++i)
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if (tab[x - i, y - i] == 1 && counter < 1)
                        {
                            ++counter;

                        }
                        else if (tab[x - i, y - i] == -1)
                        {
                            if ((wasBeaten && counter == 1) || (!wasBeaten))
                            {


                                nextTab = (int[,])tab.Clone();
                                nextTab[x, y] = -1;
                                nextTab[x - i, y - i] = -2;
                                if (counter != 0) //pawn was beaten
                                {
                                    --counter;
                                    nextTab[x - i + 1, y - i + 1] = -1;
                                    rankingFunQueen(x - i, y - i, nextTab, currentDepth, maxDepth, true);
                                }
                                miniMaxList.Add(2 + 4 * (i - 1));
                                executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                                miniMaxList.RemoveAt(miniMaxList.Count - 1);
                            }

                        }
                        else if (counter == 1 && tab[x - i, y - i] == 1) { break; }
                    }
                    else
                    {
                        break;
                    }
                }
                counter = 0;
                for (int i = 1; i < 8; ++i)
                {
                    if (x - i >= 0 && y + i < 8)
                    {
                        if (tab[x - i, y + i] == 1 && counter < 1)
                        {
                            ++counter;

                        }
                        else if (tab[x - i, y + i] == -1)
                        {
                            if ((wasBeaten && counter == 1) || (!wasBeaten))
                            {


                                nextTab = (int[,])tab.Clone();
                                nextTab[x, y] = -1;
                                nextTab[x - i, y + i] = -2;
                                if (counter != 0) //pawn was beaten
                                {
                                    --counter;
                                    nextTab[x - i + 1, y + i - 1] = -1;
                                    rankingFunQueen(x - i, y + i, nextTab, currentDepth, maxDepth, true);
                                }
                                miniMaxList.Add(0 + 4 * (i - 1));
                                executeAlgorithm(nextTab, maxDepth, currentDepth + 1);
                                miniMaxList.RemoveAt(miniMaxList.Count - 1);
                            }

                        }
                        else if (counter == 1 && tab[x - i, y + i] == 1) { break; }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public int[,] findBestMoveForPlayer(int[,] tab, int color) //returns how many pawns can player beat with a single move with any pawn 
        {

            listJump.Clear();
            int[,] nextTab = (int[,])tab.Clone();
            int temp;
            int jumpCounterTemp = 0;
            int tempI = -1, tempJ = -1;
            List<int> listaSkokow = new List<int>();
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {

                    if (tab[i, j] == color)
                    {
                        listaSkokow.Clear();
                        temp = findLongestJump(tab, i, j, color);
                        if (temp > jumpCounterTemp)
                        {
                            jumpCounterTemp = temp;
                            tempI = i;
                            tempJ = j;
                        }
                    }

                }
            }
            if (color == 1 && jumpCounterTemp == 0)
            {
                return nextTab;
            }
            int k;
            List<int> list = new List<int>();
            if (color == 1 && jumpCounterTemp == 0)
            {
                escapeFromJump(ref nextTab);
            }
            else
            {
                k = executeLongestJump((int[,])tab.Clone(), tempI, tempJ, 0, jumpCounterTemp, list);
            }
            if (color == 1 && listJump.Count != 0)
            {

            }
            if (listJump.Count == 0)
            {
                return nextTab;
            }
            else

                return tempTabLongestJump;
        }
        public int findLongestJump(int[,] tab, int i, int j, int jumpCounter)//return the amount of pawns that pawn at i/j position can beat in 1 move
        {
            int temp = tab[i, j];
            int[,] nextTab;
            int[] len = new int[4];
            len[0] = -1; len[1] = -1; len[2] = -1; len[3] = -1;
            if (i + 2 < 8 && j + 2 < 8)
            {
                if (temp != -1 && temp != tab[i + 1, j + 1] && tab[i + 1, j + 1] != -1 && tab[i + 2, j + 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the +2 +2 field is empty
                {
                    nextTab = (int[,])tab.Clone();
                    nextTab[i + 2, j + 2] = temp;
                    nextTab[i + 1, j + 1] = -1;
                    nextTab[i, j] = -1;
                    len[0] = findLongestJump(nextTab, i + 2, j + 2, jumpCounter + 1);
                }
            }
            if (i + 2 < 8 && j - 2 >= 0)
            {
                if (temp != -1 && temp != tab[i + 1, j - 1] && tab[i + 1, j - 1] != -1 && tab[i + 2, j - 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the +2 -2 field is empty
                {
                    nextTab = (int[,])tab.Clone();
                    nextTab[i + 2, j - 2] = temp;
                    nextTab[i + 1, j - 1] = -1;
                    nextTab[i, j] = -1;
                    len[1] = findLongestJump(nextTab, i + 2, j - 2, jumpCounter + 1);
                }
            }
            if (i - 2 >= 0 && j - 2 >= 0)
            {
                if (temp != -1 && temp != tab[i - 1, j - 1] && tab[i - 1, j - 1] != -1 && tab[i - 2, j - 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the -2 -2 field is empty
                {
                    nextTab = (int[,])tab.Clone();
                    nextTab[i - 2, j - 2] = temp;
                    nextTab[i - 1, j - 1] = -1;
                    nextTab[i, j] = -1;
                    len[2] = findLongestJump(nextTab, i - 2, j - 2, jumpCounter + 1);
                }
            }
            if (i - 2 >= 0 && j + 2 < 8)
            {
                if (temp != -1 && temp != tab[i - 1, j + 1] && tab[i - 1, j + 1] != -1 && tab[i - 2, j + 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the -2 +2 field is empty
                {

                    nextTab = (int[,])tab.Clone();
                    nextTab[i - 2, j + 2] = temp;
                    nextTab[i - 1, j + 1] = -1;
                    nextTab[i, j] = -1;
                    len[3] = findLongestJump(nextTab, i - 2, j + 2, jumpCounter + 1);

                }
            }


            return Math.Max(jumpCounter, Math.Max(Math.Max(len[0], len[1]), Math.Max(len[2], len[3]))); //returns biggest val out of 4

        }
        public int executeLongestJump(int[,] tab, int i, int j, int jumpCounter, int jumpCounterTemp, List<int> list)
        {

            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (list.Count == jumpCounterTemp || (tab[i, j] == 1 && list.Count == jumpCounterTemp - 1 && list.Count != 0))
            {
                for (int c = 0; c < list.Count; ++c)
                {
                    listJump.Add(list[c]);
                }

                tempTabLongestJump = (int[,])tab.Clone();
                return 0;
            }
            else
            {
                int temp = tab[i, j];
                if (temp == 1)
                {

                }
                int[,] nextTab;
                int[] len = new int[4];
                len[0] = -1; len[1] = -1; len[2] = -1; len[3] = -1;
                if (i + 2 < 8 && j + 2 < 8)
                {
                    if (temp != -1 && temp != tab[i + 1, j + 1] && tab[i + 1, j + 1] != -1 && tab[i + 2, j + 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the +2 +2 field is empty
                    {
                        nextTab = (int[,])tab.Clone();
                        nextTab[i + 2, j + 2] = temp;
                        nextTab[i + 1, j + 1] = -1;
                        nextTab[i, j] = -1;
                        list.Add(4);
                        len[0] = executeLongestJump(nextTab, i + 2, j + 2, jumpCounter + 1, jumpCounterTemp, list);
                        list.RemoveAt(list.Count - 1);
                    }
                }
                if (i + 2 < 8 && j - 2 >= 0)
                {
                    if (temp != -1 && temp != tab[i + 1, j - 1] && tab[i + 1, j - 1] != -1 && tab[i + 2, j - 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the +2 -2 field is empty
                    {
                        nextTab = (int[,])tab.Clone();
                        nextTab[i + 2, j - 2] = temp;
                        nextTab[i + 1, j - 1] = -1;
                        nextTab[i, j] = -1;
                        list.Add(5);
                        len[1] = executeLongestJump(nextTab, i + 2, j - 2, jumpCounter + 1, jumpCounterTemp, list);
                        list.RemoveAt(list.Count - 1);
                    }
                }
                if (i - 2 >= 0 && j - 2 >= 0)
                {
                    if (temp != -1 && temp != tab[i - 1, j - 1] && tab[i - 1, j - 1] != -1 && tab[i - 2, j - 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the -2 -2 field is empty
                    {
                        nextTab = (int[,])tab.Clone();
                        nextTab[i - 2, j - 2] = temp;
                        nextTab[i - 1, j - 1] = -1;
                        nextTab[i, j] = -1;
                        list.Add(6);
                        len[2] = executeLongestJump(nextTab, i - 2, j - 2, jumpCounter + 1, jumpCounterTemp, list);
                        list.RemoveAt(list.Count - 1);
                    }
                }
                if (i - 2 >= 0 && j + 2 < 8)
                {
                    if (temp != -1 && temp != tab[i - 1, j + 1] && tab[i - 1, j + 1] != -1 && tab[i - 2, j + 2] == -1) //if the pawn is owned by the other side, and field between them is not empty, and the -2 +2 field is empty
                    {

                        nextTab = (int[,])tab.Clone();
                        nextTab[i - 2, j + 2] = temp;
                        nextTab[i - 1, j + 1] = -1;
                        nextTab[i, j] = -1;
                        list.Add(7);
                        len[3] = executeLongestJump(nextTab, i - 2, j + 2, jumpCounter + 1, jumpCounterTemp, list);
                        list.RemoveAt(list.Count - 1);

                    }
                }


                return Math.Max(jumpCounter, Math.Max(Math.Max(len[0], len[1]), Math.Max(len[2], len[3]))); //returns biggest val out of 4
            }
        }
        public void escapeFromJump(ref int[,] tab)
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (tab[i, j] == 1)
                    {
                        if (i + 2 <= 8 && j + 2 <= 8)
                        {
                            if (tab[i + 1, j + 1] == -1 && tab[i + 2, j + 2] != 0)
                            {
                                if (isPawnSafeOnTheField(i + 1, j + 1, ref tab))
                                {
                                    tab[i, j] = -1;
                                    tab[i + 1, j + 1] = 1;
                                    return;
                                }

                            }
                        }
                        if (i - 2 >= 0 && j + 2 <= 8)
                        {
                            if (tab[i - 1, j + 1] == -1 && tab[i - 2, j + 2] != 0)
                            {
                                if (isPawnSafeOnTheField(i - 1, j + 1, ref tab))
                                {
                                    tab[i, j] = -1;
                                    tab[i - 1, j + 1] = 1;
                                    return;
                                }

                            }
                        }
                        if (i + 2 <= 8 && j - 2 >= 0)
                        {
                            if (tab[i + 1, j - 1] == -1 && tab[i + 2, j - 2] != 0)
                            {
                                if (isPawnSafeOnTheField(i + 1, j - 1, ref tab))
                                {
                                    tab[i, j] = -1;
                                    tab[i + 1, j - 1] = 1;
                                    return;
                                }

                            }
                        }
                        if (i - 2 >= 0 && j - 2 >= 0)
                        {
                            if (tab[i - 1, j - 1] == -1 && tab[i - 2, j - 2] != 0)
                            {
                                if (isPawnSafeOnTheField(i - 1, j - 1, ref tab))
                                {
                                    tab[i, j] = -1;
                                    tab[i - 1, j - 1] = 1;
                                    return;
                                }

                            }
                        }
                    }

                }
            }

        }
        public bool isPawnSafeOnTheField(int i, int j, ref int[,] tab)
        {
            if (i + 1 <= 8 && j + 1 <= 8 && i - 1 >= 0 && j - 1 >= 0)
            {
                if (tab[i + 1, j + 1] == 0 && tab[i - 1, j - 1] == -1)
                {
                    return false;
                }
            }
            if (i + 1 <= 8 && j - 1 >= 0 && i - 1 >= 0 && j + 1 <= 8)
            {
                if (tab[i - 1, j + 1] == 0 && tab[i - 1, j + 1] == -1)
                {
                    return false;
                }
            }
            if (i - 1 >= 0 && j + 1 <= 8 && i + 1 <= 8 && j - 1 >= 0)
            {
                if (tab[i - 1, j + 1] == 0 && tab[i + 1, j - 1] == -1)
                {
                    return false;
                }
            }
            if (i - 1 >= 0 && j - 1 >= 0 && i + 1 <= 8 && j + 1 <= 8)
            {
                if (tab[i - 1, j - 1] == 0 && tab[i + 1, j + 1] == -1)
                {
                    return false;
                }
            }
            return true;
        }
        public double getGameValue(int[,] tab)//tab ->tablica aktualnego stanu gry
        { 
            double val = 0; //ustawia początkową wartość jako 0
            for (int i = 0; i < 8; ++i)//przechodzi po całej tablicy wartości pól
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (tab[i, j] == 1) // znajduje pionek gracza i obniża wartość val o 1
                    {
                        val -= 2; 
                    }
                    else if (tab[i, j] == 0) // znajduje pionek komputera i obniża wartość val o 1
                    {
                        val += 1;
                    }
                }
            }
            for(int i = 0; i<8; ++i)  //sprawdza, czy w tej turze komputer dotarł właśnie do ostatniego rzędu(promocja do damki)
            {
                if(tab[i,7] == 0)
                {
                    val += 5;
                }
                
            }           
            return val;
        }
        public double getGameValueSecondPhase(int[,] tab)//returns the difference between the amount of black and white pawns
        {
            double val = 0;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    if (tab[i, j] == 0 && tab[i,j] == -2) {
                        val += 500;
                        
                    }                  
                    if (tab[i, j] == 1)
                    {
                        val -= 10000;                 
                    }


                }
            }
          

            return val;
        }



    }
}
