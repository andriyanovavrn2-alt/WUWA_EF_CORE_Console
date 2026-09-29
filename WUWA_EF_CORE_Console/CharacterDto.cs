using System;
using System.Collections.Generic;
using System.Text;

namespace WUWA_EF_CORE_Console
{
    public record CharacterDto
    {
        public string Name { get; set; }
        public string RarityName { get; set; }
        public CharacterDto(string name, string rarity)
        {
            Name = name; RarityName = rarity;
        }
    }
}
