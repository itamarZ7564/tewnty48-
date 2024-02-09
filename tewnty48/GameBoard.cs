using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tewnty48
{
    internal class GameBoard
    {
        public Tile[,] Board { get; set; }
        public GameBoard()
        {
            Board = new Tile[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Board[i, j] = new Tile();
                }
            }
            AddRandom();
            AddRandom();

        }
        public void AddRandom()
        {
            int x, y;
            Random rnd = new Random();
            while (true)
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 4);
                if (!Board[x, y].IsTaken)
                    break;
            }
            Board[x, y] = new Tile(x, y);

        }
        public void MoveLeft()
        {
            bool change = false;
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (!Board[j, i].IsTaken)
                    {
                        if (j + 1 < Board.GetLength(0))
                        {
                            if (Board[j + 1, i].IsTaken)
                            {
                                Board[j + 1, i].MoveX(j);
                                Board[j, i] = Board[j + 1, i];
                                Board[j + 1, i] = new Tile();
                                change = true;
                            }
                        }
                        if (j + 2 < Board.GetLength(0) && !Board[j, i].IsTaken)
                        {
                            if (Board[j + 2, i].IsTaken)
                            {
                                Board[j + 2, i].MoveX(j);
                                Board[j, i] = Board[j + 2, i];
                                Board[j + 2, i] = new Tile();
                                change = true;
                            }
                        }
                        if (j + 3 < Board.GetLength(0) && !Board[j, i].IsTaken)
                        {
                            if (Board[j + 3, i].IsTaken)
                            {
                                Board[j + 3, i].MoveX(j);
                                Board[j, i] = Board[j + 3, i];
                                Board[j + 3, i] = new Tile();
                                change = true;
                            }
                        }

                    }


                }
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    if (x + 1 < Board.GetLength(0))
                    {
                        if (Board[x + 1, i].IsTaken)
                        {
                            if (Board[x, i].IsTaken)
                            {
                                if (Board[x, i].Value == Board[x + 1, i].Value)
                                {
                                    Board[x, i].Value *= 2;
                                    Board[x + 1, i] = new Tile();
                                    change = true;
                                }
                            }
                            else
                            {
                                Board[x, i] = Board[x + 1, i];
                                Board[x + 1, i] = new Tile();
                                Board[x, i].MoveX(x);
                                change = true;
                                if (x + 2 < Board.GetLength(0))
                                {
                                    if (Board[x + 2, i].IsTaken)
                                    {
                                        if (Board[x + 2, i].Value == Board[x, i].Value)
                                        {
                                            Board[x, i].Value *= 2;
                                            Board[x + 2, i] = new Tile();
                                            change = true;
                                        }
                                        else
                                        {
                                            Board[x + 1, i] = Board[x + 2, i];
                                            Board[x + 2, i] = new Tile();
                                            Board[x + 1, i].MoveX(x + 1);
                                            change = true;
                                        }
                                    }
                                }
                            }


                        }

                    }
                }
                
            }
            if (change)
                AddRandom();
            else if (IsFull())
            {
                Console.WriteLine("Game over or try other move");
            }
        }
        public void MoveRight()
        {
            bool change = false;
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                for (int j = Board.GetLength(0)-1; j >=0; j--)
                {
                    if (!Board[j, i].IsTaken)
                    {
                        if (j - 1 >= 0)
                        {
                            if (Board[j - 1, i].IsTaken)
                            {
                                Board[j - 1, i].MoveX(j);
                                Board[j, i] = Board[j - 1, i];
                                Board[j - 1, i] = new Tile();
                                change = true;
                            }
                        }
                        if (j - 2 >= 0 && !Board[j, i].IsTaken)
                        {
                            if (Board[j - 2, i].IsTaken)
                            {
                                Board[j - 2, i].MoveX(j);
                                Board[j, i] = Board[j - 2, i];
                                Board[j - 2, i] = new Tile();
                                change = true;
                            }
                        }
                        if (j - 3 >= 0 && !Board[j, i].IsTaken)
                        {
                            if (Board[j - 3, i].IsTaken)
                            {
                                Board[j - 3, i].MoveX(j);
                                Board[j, i] = Board[j - 3, i];
                                Board[j - 3, i] = new Tile();
                                change = true;
                            }
                        }

                    }


                }
                for (int x = Board.GetLength(0)-1; x >=0; x--)
                {
                    if (x - 1 >= 0)
                    {
                        if (Board[x - 1, i].IsTaken)
                        {
                            if (Board[x, i].IsTaken)
                            {
                                if (Board[x, i].Value == Board[x - 1, i].Value)
                                {
                                    Board[x, i].Value *= 2;
                                    Board[x - 1, i] = new Tile();
                                    change = true;
                                }
                            }
                            else
                            {
                                Board[x, i] = Board[x - 1, i];
                                Board[x - 1, i] = new Tile();
                                Board[x, i].MoveX(x);
                                change = true;
                                if (x - 2 >= 0)
                                {
                                    if (Board[x - 2, i].IsTaken)
                                    {
                                        if (Board[x - 2, i].Value == Board[x, i].Value)
                                        {
                                            Board[x, i].Value *= 2;
                                            Board[x - 2, i] = new Tile();
                                            change = true;
                                        }
                                        else
                                        {
                                            Board[x - 1, i] = Board[x - 2, i];
                                            Board[x - 2, i] = new Tile();
                                            Board[x - 1, i].MoveX(x - 1);
                                            change = true;
                                        }
                                    }
                                }
                            }


                        }
                    }
                }
                

            }
            if (change)
                AddRandom();
            else if (IsFull())
            {
                Console.WriteLine("Game over or try other move");
            }

        }
        public void MoveUp()
        {
            bool change = false;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (!Board[i, j].IsTaken)
                    {
                        if (j + 1 < Board.GetLength(1))
                        {
                            if (Board[i, j+1].IsTaken)
                            {
                                Board[i, j + 1].MoveY(j);
                                Board[i, j] = Board[i, j + 1];
                                Board[i, j + 1] = new Tile();
                                change = true;
                            }
                        }
                        if (j + 2 < Board.GetLength(1) && !Board[i, j].IsTaken)
                        {
                            if (Board[i, j + 2].IsTaken)
                            {
                                Board[i, j + 2].MoveY(j);
                                Board[i, j] = Board[i, j + 2];
                                Board[i, j + 2] = new Tile();
                                change = true;
                            }
                        }
                        if (j + 3 < Board.GetLength(1) && !Board[i, j].IsTaken)
                        {
                            if (Board[i, j + 3].IsTaken)
                            {
                                Board[i, j + 3].MoveY(j);
                                Board[i, j] = Board[i, j + 3];
                                Board[i, j + 3] = new Tile();
                                change = true;
                            }
                        }

                    }


                }
                for (int y = 0; y < Board.GetLength(1); y++)
                {
                    if (y + 1 < Board.GetLength(1))
                    {
                        if (Board[i,y + 1].IsTaken)
                        {
                            if (Board[i, y].IsTaken)
                            {
                                if (Board[i, y].Value == Board[i, y + 1].Value)
                                {
                                    Board[i, y].Value *= 2;
                                    Board[i, y + 1] = new Tile();
                                    change = true;
                                }
                            }
                            else
                            {
                                Board[i, y] = Board[i, y + 1];
                                Board[i, y + 1] = new Tile();
                                Board[i, y].MoveY(y);
                                change = true;
                                if (y + 2 < Board.GetLength(1))
                                {
                                    if (Board[i, y + 2].IsTaken)
                                    {
                                        if (Board[i, y + 2].Value == Board[i, y].Value)
                                        {
                                            Board[i, y].Value *= 2;
                                            Board[i, y + 2] = new Tile();
                                            change = true;
                                        }
                                        else
                                        {
                                            Board[i, y + 1] = Board[i, y + 2];
                                            Board[i, y + 2] = new Tile();
                                            Board[i, y + 1].MoveY(y + 1);
                                            change = true;
                                        }
                                    }
                                }
                            }


                        }
                    }
                }
                

            }
            if (change)
                AddRandom();
            else if(IsFull())
            {
                Console.WriteLine("Game over or try other move");
            }

        }
        public void MoveDown()
        {
            bool change = false;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = Board.GetLength(1)-1; j >= 0; j--)
                {
                    if (!Board[i, j].IsTaken)
                    {
                        if (j - 1 >= 0)
                        {
                            if (Board[i, j - 1].IsTaken)
                            {
                                Board[i, j - 1].MoveY(j);
                                Board[i, j] = Board[i, j - 1];
                                Board[i, j - 1] = new Tile();
                                change = true;
                            }
                        }
                        if (j - 2 >= 0 && !Board[i, j].IsTaken)
                        {
                            if (Board[i, j - 2].IsTaken)
                            {
                                Board[i, j - 2].MoveY(j);
                                Board[i, j] = Board[i, j - 2];
                                Board[i, j - 2] = new Tile();
                                change = true;
                            }
                        }
                        if (j - 3 >= 0 && !Board[i, j].IsTaken)
                        {
                            if (Board[i, j - 3].IsTaken)
                            {
                                Board[i, j - 3].MoveY(j);
                                Board[i, j] = Board[i, j - 3];
                                Board[i, j - 3] = new Tile();
                                change = true;
                            }
                        }

                    }


                }
                
                for (int y = Board.GetLength(1)-1; y >= 0; y--)
                {
                    if (y - 1 >= 0)
                    {
                        if (Board[i, y - 1].IsTaken)
                        {
                            if (Board[i, y].IsTaken)
                            {
                                if (Board[i, y].Value == Board[i, y - 1].Value)
                                {
                                    Board[i, y].Value *= 2;
                                    Board[i, y - 1] = new Tile();
                                    change = true;
                                }
                            }
                            else
                            {
                                Board[i, y] = Board[i, y - 1];
                                Board[i, y - 1] = new Tile();
                                Board[i, y].MoveY(y);
                                change = true;
                                if (y - 2 >= 0)
                                {
                                    if (Board[i, y - 2].IsTaken)
                                    {
                                        if (Board[i, y - 2].Value == Board[i, y].Value)
                                        {
                                            Board[i, y].Value *= 2;
                                            Board[i, y - 2] = new Tile();
                                            change = true;
                                        }
                                        else
                                        {
                                            Board[i, y - 1] = Board[i, y - 2];
                                            Board[i, y - 2] = new Tile();
                                            Board[i, y - 1].MoveY(y - 1);
                                            change = true;
                                        }
                                    }
                                }
                            }


                        }
                    }
                }


            }
            if(change)
                AddRandom();
            else if (IsFull())
            {
                Console.WriteLine("Game over or try other move");
            }

        }

        public void DisplayBoard()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                Console.Write("\t\t\t");
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (!Board[j, i].IsTaken)
                        Console.Write("_\t");
                    else
                        Console.Write(Board[j,i].Value + "\t");
                }
                
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
        public bool IsFull()
        {
            {
                for (int i = 0; i < Board.GetLength(1); i++)
                {
                    for (int j = 0; j < Board.GetLength(0); j++)
                    {
                        if (!Board[j,i].IsTaken)
                        {
                            return false;
                        }
                    }
                    
                }
                return true;
            }
        }
        public bool avalibaleMove()
        {
            if(!IsFull()) {
                return true;
            }
            else
            {
                for (int i = 0; i < Board.GetLength(1); i++)
                {
                    for (int j = 0; j < Board.GetLength(0); j++)
                    {
                        if (j + 1 < Board.GetLength(0))
                        {
                            if (Board[j, i].Value == Board[j + 1, i].Value)
                                return true;
                        }
                        if (j - 1 >= 0)
                        {
                            if (Board[j, i].Value == Board[j - 1, i].Value)
                                return true;
                        }
                        if (i + 1 < Board.GetLength(1))
                        {
                            if (Board[j, i].Value == Board[j, i + 1].Value)
                                return true;
                        }
                        if (i - 1 >= 0)
                        {
                            if (Board[j, i].Value == Board[j, i - 1].Value)
                                return true;
                        }
                    }

                    
                }
                return false;
            }
        }
        public bool HasWon()
        {
            for (int i = 0; i < Board.GetLength(1); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[j, i].Value == 2048)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        //public void Play()
        //{
        //    while (avalibaleMove())
        //    {
        //        DisplayBoard();
        //    start:
                
        //        var move = Console.ReadKey().KeyChar;
        //        if (move == 'w' || move == 'W')
        //        {
        //            MoveUp();
        //        }
        //        else if (move == 's' || move == 'S')
        //        {
        //            MoveDown();
        //        }
        //        else if (move == 'a' || move == 'A')
        //        {
        //            MoveLeft();
        //        }
        //        else if (move == 'd'|| move == 'D')
        //        {
        //            MoveRight();
        //        }
        //        else
        //        {
        //            goto start;
        //        }


        //        if (HasWon())
        //        {
        //            Console.WriteLine("Congrats you won");
        //            return;
        //        }
        //        Console.Clear();


        //    }
        //    Console.WriteLine("Game over ):");

        //}
        public void Play()
        {
            while (avalibaleMove())
            {
                DisplayBoard();
            start:
                var move = Console.ReadKey(true).Key;
                if (move == ConsoleKey.W || move == ConsoleKey.UpArrow)
                {
                    MoveUp();
                }
                else if (move == ConsoleKey.S || move == ConsoleKey.DownArrow)
                {
                    MoveDown();
                }
                else if (move == ConsoleKey.A || move == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }
                else if (move == ConsoleKey.D || move == ConsoleKey.RightArrow)
                {
                    MoveRight();
                }
                else
                {
                    goto start;
                }

                if (HasWon())
                {
                    Console.WriteLine("Congrats you won");
                    return;
                }
                Console.Clear();
            }
            Console.WriteLine("Game over ):");
        }


    }
}