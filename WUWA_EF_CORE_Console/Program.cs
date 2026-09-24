using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WUWA_CHARACTER_OOP.Models;
using WUWA_WINFORMS_POSTGRE;
using WUWA_WINFORMS_POSTGRE.Models;
public static class Program
{
    public static void Main() 
    {
        ListAll();
    }

    public static void ListAll()
    {
        using (var db = new AppDbContext())
        {
            foreach (var character in
                db.Character.AsNoTracking()
                .Include(character => character.Weapon)
                .Include(character => character.Element)
                .Include(character => character.Rarity)
                .Include(character => character.Role))
            {
                Console.WriteLine($"Name: {character.Name}\nWeapon: {character.Weapon.WeaponName}\nElement: {character.Element.ElementName}\nRarity: {character.Rarity.RarityName}\nRole: {character.Role.RoleName}");
            }
        }
    } 
}

