namespace dungeon
{
    class Wall : IProp
    {
        bool IProp.IsDestructible => false;

        char IToken.Draw()
        {
            return '█';
        }
    }
}
