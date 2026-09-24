using System;
using System.Collections.Generic;
using System.Text;
using WUWA_WINFORMS_POSTGRE;
using WUWA_WINFORMS_POSTGRE.Models;
using Microsoft.EntityFrameworkCore;

namespace WUWA_CHARACTER_OOP.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; }
        public int RarityId { get; set; }
        public Rarity Rarity { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Photo { get; set; }

    }
}
