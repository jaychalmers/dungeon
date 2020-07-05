using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dungeon
{
    class Arena
    {
        public int Length { get; private set; }
        public int Height { get; private set; }

        private IToken[,] Tokens;

        public Arena(int length, int height, PlayerCharacter[] party, IEnumerable<Enemy> enemies)
        {
            Length = length;
            Height = height;
            Tokens = new IToken[Height,Length];

            DistributeParty(party);
            DistributeEnemies(enemies);
            PopulateObstacles();
        }

        private void DistributeParty(PlayerCharacter[] party)
        {
            if (party.Length > Height)
            {
                throw new ArgumentException("Party is too big to fit in map!");
            }
            else
            {
                for (int i = 0; i < party.Length; i++)
                {
                    Tokens[i, 0] = party[i];
                }
            }
        }

        private void DistributeEnemies(IEnumerable<Enemy> enemies)
        {
            var partyBuffer = 5;
            var r = new Random();
            foreach (var e in enemies)
            {
                Tokens[r.Next(0, Height), r.Next(partyBuffer, Length)] = e;
            }
        }

        private void PopulateObstacles()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 1; j < Length; j++)
                {
                    var r = new Random();
                    if (r.Next(100) < 10)
                        if (Tokens[i,j] == null)
                            Tokens[i, j] = new Wall();
                }
            }
        }

        private string GetBorder()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Length + 2; i++)
            {
                sb.Append("*");
            }
            return sb.ToString();
        }

        public string Draw()
        {
            var sb = new StringBuilder();
            sb.Append(GetBorder() + "\n");
            for (int i = 0; i < Height; i++)
            {
                sb.Append("*");
                for (int j = 0; j < Length; j++)
                {
                    var TokenAtPoint = Tokens[i, j];
                    sb.Append(TokenAtPoint?.Draw() ?? ' ');
                }
                sb.Append("*" + "\n");
            }
            sb.Append(GetBorder());
            return sb.ToString();
        }
    }
}
