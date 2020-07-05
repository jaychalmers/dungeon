namespace dungeon
{
    interface IProp : IToken
    {
        public bool IsDestructible { get; }
    }
}
