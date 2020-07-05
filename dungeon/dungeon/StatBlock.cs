namespace dungeon
{
    class StatBlock
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }

        public StatBlock(int str, int dex)
        {
            Strength = str;
            Dexterity = dex;
        }
    }
}
