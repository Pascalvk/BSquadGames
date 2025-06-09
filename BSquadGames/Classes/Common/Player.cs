using System.Reflection.Metadata;

namespace BSquadGames.Classes.Common
{
    public class Player
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }


        public Player(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
            Score = 0;
            
        }

    }
}
