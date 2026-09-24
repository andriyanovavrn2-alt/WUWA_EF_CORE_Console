using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WUWA_WINFORMS_POSTGRE.Models
{
    public class Rarity
    {
        public int RarityId { get; set; }
        public string RarityName { get; set; }
    }
}
