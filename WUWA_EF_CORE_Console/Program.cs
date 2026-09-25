using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using WUWA_CHARACTER_OOP.Models;
using WUWA_WINFORMS_POSTGRE;
using WUWA_WINFORMS_POSTGRE.Models;
public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter:\nl - list of characters\na - add the character\nf - filter by rarity\nc - count of character");
            char chose = Convert.ToChar(Console.ReadLine());
            if (chose == 'l') ListAll();
            if (chose == 'a') AddCharacter();
            if (chose == 'f') FilterRarity();
            if (chose == 'c') CountCharacter();
        }
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
                Console.WriteLine($"Name: {character.Name}\nWeapon: {character.Weapon.WeaponName}\nElement: {character.Element.ElementName}\nRarity: {character.Rarity.RarityName}\nRole: {character.Role.RoleName}\n\n");
            }
        }
    }
    public static void FilterRarity()
    {
        Console.WriteLine("Chose the rarity: 4* or 5*?");
        var choice_rarity = Console.ReadLine();
        using (var db = new AppDbContext())
        {
            var filtered_characters = db.Character.Where(character => character.Rarity.RarityName == choice_rarity).ToList();
            filtered_characters.ForEach(character => Console.WriteLine($"{character.Name}\n\n"));
        }
    }
    public static void AddCharacter()
    {
        using (var db = new AppDbContext())
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Weapon: ");
            string weapon = Console.ReadLine();

            Console.WriteLine("Enter nElement: ");
            Element element = Console.ReadLine();
            Console.WriteLine("Enter Rarity: ");
            Rarity rarity = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            Role role = Console.ReadLine();
            
            var character = new Character
            {
                Name = name,
                Weapon = weapon,
                Element = element,
                Rarity = rarity,
                Role = role
            };
            db.Add(character);
            db.SaveChanges();
        }
    }
    public static void CountCharacter()
    {
        using (var db = new AppDbContext())
            Console.WriteLine($"{db.Character.Count()} characters\n\n");
    }
}

