using Minesweeper.Converters;
using Minesweeper.Logic;
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
        CellGrid MineSweeperGrid { get; } = new Logic.CellGrid();
        CellStateToBrushConverter BrushConverter { get; } = new CellStateToBrushConverter();
        public MainWindow()
        {
            InitializeComponent();
            CreateGrid(10,10,15);
            this.KeyUp += KeyPressHandler;
        }

        public void CreateGrid(int width, int height, int mines)
        {
            MineSweeperGrid.GenerateCells(width, height, mines);
            CellContainerGrid.RowDefinitions.Clear();
            for (int y = 0; y < MineSweeperGrid.Cells.GetLength(0); y++)
            {
                CellContainerGrid.RowDefinitions.Add(new RowDefinition());
            }

            CellContainerGrid.ColumnDefinitions.Clear();
            for (int x = 0; x < MineSweeperGrid.Cells.GetLength(1); x++)
            {
                CellContainerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int y = 0; y < MineSweeperGrid.Cells.GetLength(0); y++)
            {
                int tY = y;
                for (int x = 0; x < MineSweeperGrid.Cells.GetLength(1); x++)
                {
                    int tX = x;
                    Label label = new Label()
                    {
                        Width = 50,
                        Height = 50,
                        DataContext = MineSweeperGrid.Cells[x, y],
                    };
                    label.MouseEnter += (sender, args) => {

                    };
                    label.MouseLeave += (sender, args) => {

                    };
                    label.MouseLeftButtonUp += (sender, args) => {
                        MineSweeperGrid.ClickCell(tX, tY);
                    };
                    Binding b = new Binding("State")
                    {
                        Converter = BrushConverter
                    };
                    label.SetBinding(Button.BackgroundProperty, b);
                    Grid.SetRow(label, y);
                    Grid.SetColumn(label, x);
                    CellContainerGrid.Children.Add(label);
                }
            }
        }

        public void KeyPressHandler(object sender, KeyEventArgs args)
        {
            switch (args.Key)
            {
                //TODO: keyboard controls
            }
        }
    }
}
