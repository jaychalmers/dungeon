using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace dungeon
{
    class PlayerCharacter : Actor, IToken
    {
        public ClassType Class { get; }

        public PlayerCharacter(string name, ClassType classType) : base(name, DefaultStatBlock(classType))
        {
            Class = classType;
        }

        public static StatBlock DefaultStatBlock(ClassType classType)
        {
            using (StreamReader r = new StreamReader("classInfo.json"))
            {
                var json = r.ReadToEnd();
                var defaults = JsonConvert.DeserializeObject<Dictionary<string, StatBlock>>(json);
                return defaults[classType.ToString()];
            }
        }

        public char Draw()
        {
            return Name[0];
        }

        public override string ToString()
        {
            return $"Name: {Name}, Class: {Class}";
        }
    }
}
