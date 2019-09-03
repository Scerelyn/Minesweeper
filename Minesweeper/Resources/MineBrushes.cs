using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Minesweeper.Resources
{
    /// <summary>
    /// Represents a set of Brushes for a Theme for Minesweeper
    /// </summary>
    public class BrushTheme
    {
        /// <summary>
        /// The Brush for hidden/default cells
        /// </summary>
        public Brush Hidden { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 1
        /// </summary>
        public Brush Zero { get; set; }
        /// <summary>
        /// The Brush for the cell with no adjacent mines
        /// </summary>
        public Brush One { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 2
        /// </summary>
        public Brush Two { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 3
        /// </summary>
        public Brush Three { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 4
        /// </summary>
        public Brush Four { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 5
        /// </summary>
        public Brush Five { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 6
        /// </summary>
        public Brush Six { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 7
        /// </summary>
        public Brush Seven { get; set; }
        /// <summary>
        /// The Brush for the cell containing the Number 8
        /// </summary>
        public Brush Eight { get; set; }
        /// <summary>
        /// The Brush for a cell that has been flagged
        /// </summary>
        public Brush Flagged { get; set; }
        /// <summary>
        /// The Brush for a cell with a mine visible
        /// </summary>
        public Brush Mine { get; set; }
        /// <summary>
        /// The Brush for a mine that has been detonated
        /// </summary>
        public Brush Exploded { get; set; }
        /// <summary>
        /// The Brush for a cell with an invalid state
        /// </summary>
        public Brush Error { get; set; }
    }

    /// <summary>
    /// Container class for various built in themes
    /// </summary>
    public static class BrushThemes
    {
        /// <summary>
        /// Assembles a basic VisualBrush with a label for simple brushes with text in it
        /// </summary>
        /// <param name="foreground">The Foreground brush</param>
        /// <param name="background">The Background brush</param>
        /// <param name="content">The text content</param>
        /// <returns>A VisualBrush with the given foreground, background, and content</returns>
        private static VisualBrush GetLabelBrush(Brush foreground, Brush background, string content)
        {
            return new VisualBrush() { Visual = new Label() { FontSize = 16, Foreground = foreground, Content = content, Background = background } };
        }

        /// <summary>
        /// The default brushes for Minesweeper
        /// </summary>
        public static BrushTheme Default { get; } = new BrushTheme()
        {
            Hidden = Brushes.Blue,
            Zero = Brushes.CadetBlue,
            One = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "1"),
            Two = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "2"),
            Three = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "3"),
            Four = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "4"),
            Five = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "5"),
            Six = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "6"),
            Seven = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "7"),
            Eight = GetLabelBrush(Brushes.Black, Brushes.CadetBlue, "8"),
            Flagged = Brushes.Green,
            Mine = Brushes.Black,
            Exploded = Brushes.Red,
            Error = Brushes.HotPink
        };
    }
}
