using System;

namespace dungeon
{
    abstract class Actor
    {
        public string Name { get; }
        public StatBlock Stats { get; }

        private Random Rng;

        public Actor(string name, StatBlock stats)
        {
            Name = name;
            Stats = stats;
            Rng = new Random();
        }

        public int RollInitiative()
        {
            return Rng.Next(6) + 1 + Stats.Dexterity;
        }
    }
}
