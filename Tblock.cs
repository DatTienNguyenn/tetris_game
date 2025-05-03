namespace Tetris {

    public class Tblock : Block {
        private readonly Position[][] title = new Position[][] {
            new Position[] {new Position(0,1), new Position(1,0), new Position(1,1), new Position(1,2)},
            new Position[] {new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,1)},
            new Position[] {new Position(1,0), new Position(1,1), new Position(1,2), new Position(2,1)},
            new Position[] {new Position(0,1), new Position(1,0), new Position(1,1), new Position(2,1)}
        };

        public override int BlockID => 6;

        public override Position startPoint => new Position(0,3);
        public override Position[][] Title => title;
    } 
}