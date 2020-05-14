using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_api.Models
{
    public class CharacterStats
    {
        [ForeignKey("Character")]
        public long CharacterStatsId { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public virtual Character Character { get; set; }

    }
}
