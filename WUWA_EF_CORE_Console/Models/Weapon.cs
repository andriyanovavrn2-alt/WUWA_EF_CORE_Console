using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WUWA_WINFORMS_POSTGRE
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
    }
}
