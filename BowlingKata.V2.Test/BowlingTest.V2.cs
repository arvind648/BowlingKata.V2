using System;
using Xunit;

namespace BowlingKata.Test
{
    public class BowlingTest
    {
        BowlingGame game;

        public BowlingTest()
        {
            game = new BowlingGame();
        }

        [Fact]
        public void GutterBalls()
        {
            ManyOpenFrames(10, 0, 0);
            Assert.Equal(0, game.Score());
        }

        [Fact]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);
            Assert.Equal(60, game.Score());
        }

        [Fact]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(21, game.Score());
        }

        [Fact]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(23, game.Score());
        }

        [Fact]
        public void Strike()
        {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);
            Assert.Equal(26, game.Score());
        }

        [Fact]
        public void StrikeFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);
            Assert.Equal(18, game.Score()); // note that this is different from test Strike()
        }

        [Fact]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);
            Assert.Equal(15, game.Score());
        }

        [Fact]
        public void Perfect()
        {
            for (int i = 0; i < 10; i++)
                game.Strike();
            game.BonusRoll(10);
            game.BonusRoll(10);
            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void Alternating()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);
            Assert.Equal(200, game.Score());
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < count; frameNumber++)
                game.OpenFrame(firstThrow, secondThrow);
        }
    }
}
