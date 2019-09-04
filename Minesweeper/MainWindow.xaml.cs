using Minesweeper.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic.Grid MineSweeperGrid { get; } = new Logic.Grid();
        CellStateToBrushConverter BrushConverter { get; } = new CellStateToBrushConverter();
        public MainWindow()
        {
            InitializeComponent();
            CreateGrid(10,10,15);
            
        }

        public void CreateGrid(int width, int height, int mines)
        {
            MineSweeperGrid.GenerateCells(width, height, mines);
            CellGrid.RowDefinitions.Clear();
            for (int y = 0; y < MineSweeperGrid.Cells.GetLength(0); y++)
            {
                CellGrid.RowDefinitions.Add(new RowDefinition());
            }

            CellGrid.ColumnDefinitions.Clear();
            for (int x = 0; x < MineSweeperGrid.Cells.GetLength(1); x++)
            {
                CellGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < MineSweeperGrid.Cells.GetLength(0); y++)
            {
                for (int x = 0; x < MineSweeperGrid.Cells.GetLength(1); x++)
                {
                    Label label = new Label();
                    label.Content = $"{x},{y}";
                    label.Width = 50;
                    label.Height = 50;
                    label.DataContext = MineSweeperGrid.Cells[x, y];
                    Binding b = new Binding("State");
                    b.Converter = BrushConverter;
                    label.SetBinding(Label.BackgroundProperty, b);
                    Grid.SetRow(label, y);
                    Grid.SetColumn(label, x);
                    CellGrid.Children.Add(label);
                }
            }
        }
    }
}
