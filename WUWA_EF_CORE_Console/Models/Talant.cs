using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WUWA_CHARACTER_OOP.Models
{
    public class Talant
    {
        public int TalantId { get; set; }
        public string TalantName { get; set; }
        public ICollection<Skill> Skills{ get; set; }
    }
}
