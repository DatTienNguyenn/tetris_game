namespace Tetris {

    public class GameState {
        private Block current_Block;
        public Block currentBlock {
            get => current_Block;
            private set {
                current_Block = value;
                current_Block.init();
            }
        } 

        public GameGrid gameGrid { get;}
        public BlockQueue blockQueue {get; }
        public bool gameOver {get; private set;}

        public int score { get; private set;}
        public GameState() {
            gameGrid = new GameGrid(22,10);
            blockQueue = new BlockQueue();
            currentBlock = blockQueue.randomBlock();
        }

        private bool isFit() {
            foreach(var p in current_Block.TilePosition()) {
                if(!gameGrid.isEmpty(p.Row, p.Column) || !gameGrid.isInside(p.Row, p.Column)) {
                    return false;
                }
            }
            return true;
        }

        public void rotateCW() {
            current_Block.rotateCW();

            if(!isFit()) {
                current_Block.rotateCCW(); 
            }
        }

        public void rotateCCw() {
            current_Block.rotateCCW();

            if(!isFit()) {
                current_Block.rotateCW();
            }
        }

        public void moveLeft() {
            current_Block.Move(0,-1);

            if(!isFit()) {
                current_Block.Move(0,1);
            }
        }

        public void moveRight() {
            current_Block.Move(0,1);

            if(!isFit()) {
                current_Block.Move(0,-1);
            }
        }

        private bool isGameOver() {
            if (!(gameGrid.isRowEmpty(0) && gameGrid.isRowEmpty(1))) {
                return true;
            }
            return false;
        }
        public void placeBlock() {
            foreach(Position p in current_Block.TilePosition()) {
                gameGrid[p.Row, p.Column] = current_Block.BlockID;
            }

            score += gameGrid.clearFull()*10;

            if(isGameOver()) {
                gameOver = true;
            } else {
                currentBlock = blockQueue.update();
            }

        }

        public void moveDown() {
            current_Block.Move(1,0);

            if(!isFit()) {
                current_Block.Move(-1,0);
                placeBlock();
            }
        }

    }

}