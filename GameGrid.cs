namespace Tetris {

    public class GameGrid {
        private readonly int[,] grid;

        public int Rows{ get; }
        public int Columns{get; }

        public int this[int row, int col] {
            get => grid[row,col];
            set => grid[row,col] = value;
        }

        public GameGrid(int rows, int columns) {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool isInside(int r, int c) {
            return r < Rows && r >= 0 && c >= 0 && c < Columns;
        }

        public bool isEmpty(int r, int c) {
            if (isInside(r,c))
            {
                if(grid[r, c] == 0) return true;
            }
            return false;
        }
        
        public bool isRowEmpty(int r) {
            for(int i = 0; i < Columns; i++) {
                if(grid[r,i] != 0) return false;
            }
            return true;
        }
        public bool isRowFull(int r) {
            for(int i = 0; i < Columns; i++) {
                if(isEmpty(r,i)) return false;
            }
            return true;
        }

        private void clearRow(int r) {
            for(int i = 0; i < Columns; i++) {
                grid[r,i] = 0;
            }
        }

        private void moveRow(int r, int numRows) {
            for(int i = 0; i < Columns; i++) {
                grid[r+numRows,i] = grid[r,i];
                grid[r,i] = 0;
            }
        }

        public int clearFull() {
            int clr = 0;

            for(int r = Rows-1; r >= 0; r--) {
                if(isRowFull(r)) {
                    clearRow(r);
                    clr++;
                } else if(clr > 0) {
                    moveRow(r,clr);
                }
            }
            return clr;
        }
    }
}