using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block {
        public abstract Position[][] Title { get; }

        public abstract Position startPoint { get; }
        public abstract int BlockID {get;}
        private int state;
        private Position offset;
        public Block() {
            offset = new Position(startPoint.Row, startPoint.Column);

        }
        public IEnumerable<Position> TilePosition() {
            foreach(var p in Title[state]) {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }
        public void rotateCW() {
            state = (state + 1) % Title.Length;
        }
        public void rotateCCW() {
            if(state == 0) {
                state = Title.Length - 1; 
            } else state--; 
        }
        public void Move(int r, int c) {
            offset.Row += r;
            offset.Column += c;
        }
        public void init() {
            state = 0;
            offset.Row = startPoint.Row;
            offset.Column = startPoint.Column;
        }
    }   
}
