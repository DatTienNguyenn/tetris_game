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
using Tetris;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative))

        };

        private readonly Image[,] imageControls;

        private GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.gameGrid);
        }

        private Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.Rows, grid.Columns];
            int cellSize = 25;

            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                    Height = cellSize
                };
                Canvas.SetTop(imageControl, (r - 2) * cellSize);
                Canvas.SetLeft(imageControl, c * cellSize);
                GameCanvas.Children.Add(imageControl);
                imageControls[r, c] = imageControl;
                }
        }
        return imageControls;    
    }
        
        
        private void DrawGrid(GameGrid grid)
        {
            for(int r = 0; r < grid.Rows; r++)
            {
                for(int c = 0; c < grid.Columns; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }
        private void DrawBlock(Block block)
        {
            foreach (Position p in block.TilePosition())
            {
            imageControls[p.Row, p.Column].Source = tileImages[block.BlockID];
            }
        }
        
        private void Draw(GameState gameState)
        {
            DrawGrid(gameState.gameGrid);
            DrawBlock(gameState.currentBlock);
        }

        private async Task GameLoop()
        {
            Draw(gameState);

            while (!gameState.gameOver)
            {
                await Task.Delay(500);
                gameState.moveDown();
                Draw(gameState);
                GameScore.Text = $"Score: {gameState.score}";
            }
            GameOverMenu.Visibility = Visibility.Visible;
            Final.Text = $"Score: {gameState.score}";
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            GameLoop();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gameState = new GameState();
            GameOverMenu.Visibility = Visibility.Hidden;
            Draw(gameState);
            GameLoop();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e )
        {
            if(gameState.gameOver)
            {
                return;
            }
            switch(e.Key)
            {
                case Key.Left:
                    gameState.moveLeft();
                    break;
                case Key.Right:
                    gameState.moveRight();
                    break;
                case Key.Down:
                    gameState.moveDown();
                    break;
                case Key.Up:
                    gameState.rotateCW();
                    break;
                default: return;


            }
            Draw(gameState);
             
        }
    }
}
