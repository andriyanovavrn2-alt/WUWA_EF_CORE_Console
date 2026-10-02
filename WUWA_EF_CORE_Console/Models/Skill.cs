using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WUWA_CHARACTER_OOP.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int CharacterId { get; set; }
        public int TalantId { get; set; }
        public Talant Talant { get; set; }
    }
}
