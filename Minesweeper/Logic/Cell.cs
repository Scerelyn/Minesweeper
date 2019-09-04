using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    /// <summary>
    /// The class representing a cell in Minesweeper
    /// </summary>
    public class Cell : INotifyPropertyChanged
    {
        private CellState cell = CellState.Hidden;
        public CellState State { get => cell; set { cell = value; FieldChanged(); } }
        private bool isMine = false;
        public bool IsMine { get => isMine; set { isMine = value; FieldChanged(); } }
        public int Surrounding { get; set; } = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FieldChanged(string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}
