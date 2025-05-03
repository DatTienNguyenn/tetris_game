namespace Tetris {

    public class Oblock : Block {
        private readonly Position[][] title = new Position[][] {
            new Position[] { new Position(0,0), new Position(0,1), new Position(1,0), new Position(1,1)}
        };

        public override int BlockID => 4;

        public override Position startPoint => new Position(0,4);
        public override Position[][] Title => title;
    } 
}