using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dungeon
{
    class Game
    {
        private const int ArenaLength = 32;
        private const int ArenaHeight = 12;

        private Arena Arena;

        private PlayerCharacter[] Party;
        private List<Enemy> Enemies;

        private List<Actor> TurnOrder;

        public Game()
        {
            //Initialize party
            Party = new PlayerCharacter[]
            {
                new PlayerCharacter("Fred", ClassType.Fighter),
                new PlayerCharacter("Roger", ClassType.Rogue)
            };
            //Initialize enemies
            Enemies = new List<Enemy>();
            for (int i = 0; i < 5; i++)
            {
                Enemies.Add(new Random().Next(2) == 0 ? new Enemy(EnemyType.Orc) : new Enemy(EnemyType.Goblin));
            }
            //Create arena
            Arena = new Arena(ArenaLength, ArenaHeight, Party, Enemies);
            //Create turn order
            var allActors = new List<Actor>().Concat(Party).Concat(Enemies);
            TurnOrder = new List<Actor>(allActors.OrderBy(character => character.RollInitiative()));
        }

        private int Update()
        {
            var input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Escape)
            {
                return 0;
            }
            return 1;
        }

        private string DrawStatus()
        {
            var sb = new StringBuilder();
            sb.Append("WELCOME TO MY DUNGEON GAME - VERSION 0.0.1\n");
            return sb.ToString();
        }

        private string DrawTurns()
        {
            var sb = new StringBuilder();
            sb.Append("Turn order:\n");
            for (int i = 0; i < TurnOrder.Count; i++)
            {
                sb.Append($"{i + 1}: {TurnOrder[i].Name}\n");
            }
            return sb.ToString();
        }

        private string DrawParty()
        {
            var sb = new StringBuilder();
            sb.Append("Party:\n");
            sb.Append("Name\tClass\n");
            foreach(var character in Party)
            {
                sb.Append($"{character.Name}\t{character.Class}\n");
            }
            return sb.ToString();
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine(DrawStatus());
            Console.WriteLine(Arena.Draw());
            Console.WriteLine(DrawParty());
            Console.WriteLine(DrawTurns());
        }

        public void Run()
        {
            while (Update() == 1) { Render(); }
        }
    }
}
