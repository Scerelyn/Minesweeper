using Minesweeper.Logic;
using Minesweeper.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Minesweeper.Converters
{
    public class CellStateToBrushConverter : IValueConverter
    {
        public BrushTheme ActiveTheme { get; set; } = BrushThemes.Default;
        public object Convert(object value, Type targetTypem, object parameter, CultureInfo culture)
        {
            if (value is CellState state)
            {
                switch (state)
                {
                    case CellState.Hidden:
                        return ActiveTheme.Hidden;
                    case CellState.One:
                        return ActiveTheme.One;
                    case CellState.Two:
                        return ActiveTheme.Two;
                    case CellState.Three:
                        return ActiveTheme.Three;
                    case CellState.Four:
                        return ActiveTheme.Four;
                    case CellState.Five:
                        return ActiveTheme.Five;
                    case CellState.Six:
                        return ActiveTheme.Six;
                    case CellState.Seven:
                        return ActiveTheme.Seven;
                    case CellState.Eight:
                        return ActiveTheme.Eight;
                    case CellState.Flagged:
                        return ActiveTheme.Flagged;
                    case CellState.Mine:
                        return ActiveTheme.Mine;
                    case CellState.Exploded:
                        return ActiveTheme.Exploded;
                    case CellState.Error:
                    default:
                        return ActiveTheme.Error;
                }
            }
            else
            {
                return ActiveTheme.Error;
            }
        }

        public object ConvertBack(object value, Type targetTypem, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
