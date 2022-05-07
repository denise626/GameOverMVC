using System.Collections.Generic;

namespace GameOverMVC.Models
{
    public class GameOver
    {
        public int GameValue { get; set; }

        public int OverValue { get; set; }

        public List<string> Result { get; set; } = new();
    }
}
