using Microsoft.CodeAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_api.Models
{
    public class Character
    {
        public enum Classes
        {
            Barbarian, Bard, Cleric, Druid, Rogue
        }

        public enum Races
        {
            Dwarf, Elf, Tiefling, Human
        }

        public long CharacterId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public Races Race { get; set; }

        public Classes Class { get; set; }

        [Range(1,20)]
        public int Level { get; set; }

        public string Background { get; set; }

        public virtual CharacterStats CharacterStats { get; set; }
    }
}
