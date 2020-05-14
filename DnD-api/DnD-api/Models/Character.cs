﻿namespace DnD_api.Models
{
    public class Character
    {
        public long CharacterId { get; set; }

        public string Name { get; set; }
        
        public virtual CharacterStats CharacterStats { get; set; }
    }
}
