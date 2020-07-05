using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace dungeon
{
    class Enemy : Actor, IToken
    {
        public EnemyType Type { get; }

        public Enemy(EnemyType enemyType) : base(enemyType.ToString(), GetStatBlock(enemyType))
        {
            Type = enemyType;
        }

        public char Draw()
        {
            return GetEnemyInfo(Type).Token;
        }

        public static StatBlock GetStatBlock(EnemyType enemyType)
        {
            return GetEnemyInfo(enemyType).Stats;
        }

        private static EnemyInfoJson GetEnemyInfo(EnemyType enemyType)
        {
            using (StreamReader r = new StreamReader("enemyInfo.json"))
            {
                var json = r.ReadToEnd();
                var info = JsonConvert.DeserializeObject<Dictionary<string, EnemyInfoJson>>(json);
                return info[enemyType.ToString()];
            }
        }
    }

    class EnemyInfoJson
    {
        public StatBlock Stats { get; set; }
        public char Token { get; set; }
    }
}
