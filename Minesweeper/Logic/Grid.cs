using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minesweeper.Logic
{
    /// <summary>
    /// The class containing Cell objects and handles logic and behaviors between them
    /// </summary>
    public class CellGrid
    {
        private Random rng = new Random();
        public Cell[,] Cells { get; set; }

        public EventHandler OnMazeGenerated;
        public EventHandler OnMineClicked;

        public CellGrid()
        {
            OnMazeGenerated += (sender,args) => { };
            OnMineClicked += (sender, args) => { };
        }

        public void GenerateCells(int width = 10, int height = 10, int mines = 15)
        {
            Cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    Cells[x, y] = new Cell();
                }
            }
            List<Point> points = GetRandomMinePoints(width, height, mines);
            foreach(Point p in points)
            {
                Cells[(int)p.X, (int)p.Y].IsMine = true;
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Cells[x, y].Surrounding = GetSurrounding(x,y);
                }
            }

            OnMazeGenerated(this, null);
        }

        public void ClickCell(int x, int y)
        {
            if (x >= 0 && x < Cells.GetLength(0) && y >= 0 && y < Cells.GetLength(1))
            {
                if (Cells[x,y].IsMine)
                {
                    RevealCell(x, y);
                    OnMineClicked(this, null);
                }
                else
                {
                    RevealCell(x, y);
                }
            }
            else
            {
                throw new ArgumentException($"X or Y are out of bounds. X:{x} Y:{y}");
            }
        }

        private void RevealCell(int x, int y, List<Point> previous = null)
        {
            if (previous == null)
            {
                previous = new List<Point>();
            }
            if (x >= 0 && x < Cells.GetLength(0) && y >= 0 && y < Cells.GetLength(1) 
                && Cells[x,y].State != CellState.Flagged)
            {
                if (Cells[x,y].IsMine)
                {
                    Cells[x, y].State = CellState.Exploded;
                }
                else
                {
                    Cells[x, y].State = (CellState)Cells[x,y].Surrounding;
                    if (Cells[x,y].Surrounding == 0)
                    {
                        previous.Add(new Point(x, y));
                        if(!previous.Contains(new Point(x, y+1))) RevealCell(x, y + 1, previous);
                        if(!previous.Contains(new Point(x, y-1))) RevealCell(x, y - 1, previous);
                        if(!previous.Contains(new Point(x-1, y))) RevealCell(x - 1, y, previous);
                        if(!previous.Contains(new Point(x+1, y))) RevealCell(x + 1, y, previous);
                        if(!previous.Contains(new Point(x-1, y+1))) RevealCell(x - 1, y + 1, previous);
                        if(!previous.Contains(new Point(x+1, y+1))) RevealCell(x + 1, y + 1, previous);
                        if(!previous.Contains(new Point(x-1, y-1))) RevealCell(x - 1, y - 1, previous);
                        if(!previous.Contains(new Point(x+1, y-1))) RevealCell(x + 1, y - 1, previous);
                    }
                }
            }
        }

        private int GetSurrounding(int x, int y)
        {
            if (x >= 0 && x < Cells.GetLength(0) && y >= 0 && y < Cells.GetLength(1))
            {
                int surrounding = 0;

                if (x - 1 >= 0)
                {
                    surrounding += Cells[x - 1, y].IsMine ? 1 : 0;
                }
                if (x + 1 < Cells.GetLength(1))
                {
                    surrounding += Cells[x + 1, y].IsMine ? 1 : 0;
                }

                if (y - 1 >= 0)
                {
                    surrounding += Cells[x, y - 1].IsMine ? 1 : 0;
                }
                if (y + 1 < Cells.GetLength(1))
                {
                    surrounding += Cells[x, y + 1].IsMine ? 1 : 0;
                }

                if (x - 1 >= 0 && y - 1 >= 0)
                {
                    surrounding += Cells[x - 1, y - 1].IsMine ? 1 : 0;
                }
                if (x - 1 >= 0 && y + 1 < Cells.GetLength(1))
                {
                    surrounding += Cells[x - 1, y + 1].IsMine ? 1 : 0;
                }

                if (x + 1 < Cells.GetLength(0) && y - 1 >= 0)
                {
                    surrounding += Cells[x + 1, y - 1].IsMine ? 1 : 0;
                }
                if (x + 1 < Cells.GetLength(0) && y + 1 < Cells.GetLength(1))
                {
                    surrounding += Cells[x + 1, y + 1].IsMine ? 1 : 0;
                }

                return surrounding;

            }
            else
            {
                throw new ArgumentException($"X or Y are out of bounds. X:{x} Y:{y}");
            }
        }

        private List<Point> GetRandomMinePoints(int width, int height, int amount)
        {
            List<Point> points = new List<Point>();
            List<int> ints = Enumerable.Range(0, width * height).ToList();
            for(int i = 0; i < amount; i++)
            {
                int random = rng.Next(0, ints.Count);
                int value = ints[random];
                ints.Remove(random);
                points.Add(new Point(value % width, value / height));
            }
            return points;
        }
    }
}
