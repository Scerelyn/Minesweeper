using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    /// <summary>
    /// The class representing a cell in Minesweeper
    /// </summary>
    public class Cell
    {
        public CellState State { get; set; } = CellState.Hidden;
        public bool IsMine { get; set; } = false;
    }
}
