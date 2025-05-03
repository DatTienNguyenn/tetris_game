using System;
using Tetris;

namespace Tetris {

    public class BlockQueue {
        private readonly Block[] blocks = new Block[]
        {
            new Jblock(),
            new Iblock(),
            new Lblock(),
            new Oblock(),
            new Sblock(),
            new Tblock(),
            new Zblock()
        };

        private readonly Random random = new Random();

        public Block nextBlock { get; private set;}

        public BlockQueue() {
            nextBlock = randomBlock();
        }
        public Block randomBlock() {
            return blocks[random.Next(blocks.Length)];
        }

        public Block update() {
            Block block = nextBlock;
            Block newBlock;
            do {
                newBlock = randomBlock(); 
            } while(newBlock.BlockID == block.BlockID);
            nextBlock = newBlock;
            return block;
        }
    }
}