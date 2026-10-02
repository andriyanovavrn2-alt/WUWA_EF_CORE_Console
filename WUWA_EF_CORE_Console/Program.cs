using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using WUWA_CHARACTER_OOP.Models;
using WUWA_EF_CORE_Console;
using WUWA_WINFORMS_POSTGRE;
using WUWA_WINFORMS_POSTGRE.Models;
using System.Linq;

public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter:\nla - list of all characters\nls - list of character (short version)\na - add the character\nr - filter by rarity\ne - filter by element\nc - count of character");
            string chose = Console.ReadLine();
            if (chose == "la") ListAllInfoInclude();
            if (chose == "ls") ListShortInfo();
            // if (chose == 'a') AddCharacter();
            if (chose == "r") FilterRarity();
            if (chose == "e") FilterElement();
            if (chose == "c") CountCharacter();
            if (chose == "Join") ListAllInfoJoin();
            if (chose == "Selectmany") ListAllSkill();

        }
    }

    public static void ListAllInfoInclude()  // использование .Include
    {
        Console.Clear();
        using (var db = new AppDbContext())
        {
            foreach (var character in
                db.Character.AsNoTracking()
                .Include(character => character.Weapon)
                .Include(character => character.Element)
                .Include(character => character.Rarity)
                .Include(character => character.Role))
            {
                ElementColorConsole(character.Element.ElementName);
                Console.WriteLine($"Name: {character.Name}\nWeapon: {character.Weapon.WeaponName}\nElement: {character.Element.ElementName}\nRarity: {character.Rarity.RarityName}\nRole: {character.Role.RoleName}\n------------\n");
                Console.ResetColor();

            }
        }
        Console.ReadLine();
        Console.Clear();
    }

    public static void ListAllSkill() //  использование Selectmany
    {
        Console.Clear();
        using (var db = new AppDbContext())
        {
            var linq = db.Character.AsNoTracking()
                .SelectMany(
                    ch => ch.Skill, (ch, s) => new { ch.Name, s.SkillName, s.Talant.TalantName}).ToList();
            linq.ForEach(item => Console.WriteLine($"{item.Name}: {item.TalantName} - {item.SkillName}"));
        }

    }

    public static void ListAllInfoJoin()  // использование Join
    {
        Console.Clear();
        using (var db = new AppDbContext())
        {
            var result = db.Character.Join(
                    db.Weapon,
                    character => character.WeaponId,
                    weapon => weapon.WeaponId,
                    (character, weapon) => new { character.Name, weapon.WeaponName }).ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.WeaponName}");
            }
        }
        Console.ReadLine();
        Console.Clear();
    }

    public static void ListShortInfo() // использование record
    {
        Console.Clear();
        using (var db = new AppDbContext())
        {
            foreach (var character in db.Character.AsNoTracking()
                .Select(character_dto => new CharacterDto(character_dto.Name, character_dto.Rarity.RarityName, character_dto.Element.ElementName)))
            {
                ElementColorConsole(character.ElementName);
                Console.WriteLine($"{character.Name} {character.RarityName}");
                Console.ResetColor();
            }
        }
        Console.ReadLine();
        Console.Clear();
    }
    public static void FilterRarity()
    {
        Console.Clear();
        Console.WriteLine("Chose the rarity: 4* or 5*?");
        var choice_rarity = Console.ReadLine();
        Console.Clear();
        using (var db = new AppDbContext())
        {
            var filtered_characters = db.Character.Where(character => character.Rarity.RarityName == choice_rarity).ToList();
            filtered_characters.ForEach(character => Console.WriteLine(character.Name));
        }
        Console.ReadLine();
        Console.Clear();
    }
    public static void FilterElement()  // отложенное выполнение
    {
        Console.Clear();
        using (var db = new AppDbContext())
        {
            var query = db.Character.AsQueryable();
            Console.WriteLine($"Elements:");
            foreach (var element in db.Elements.AsNoTracking())
            {
                Console.WriteLine(element.ElementName);
            }
            Console.WriteLine("Chose the element.\n");
            string choseElement = Console.ReadLine();
            Console.Clear();
            ElementColorConsole(choseElement);
            query = query
                .Where(character => character.Element.ElementName == choseElement); // построение запроса
            var result = query.ToList();  // выполнение
            foreach (var character in result) // вывод списка
            {
                Console.WriteLine(character.Name);
            }
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        Console.ReadLine();
        Console.Clear();
    }
    //public static void AddCharacter()
    //{
    //    using (var db = new AppDbContext())
    //    {
    //        Console.WriteLine("Enter Name: ");
    //        string name = Console.ReadLine();
    //        Console.WriteLine("Enter Weapon: ");
    //        string weapon = Console.ReadLine();

    //        Console.WriteLine("Enter nElement: ");
    //        Element element = Console.ReadLine();
    //        Console.WriteLine("Enter Rarity: ");
    //        Rarity rarity = Console.ReadLine();
    //        Console.WriteLine("Enter Role: ");
    //        Role role = Console.ReadLine();

    //        var character = new Character
    //        {
    //            Name = name,
    //            Weapon = weapon,
    //            Element = element,
    //            Rarity = rarity,
    //            Role = role
    //        };
    //        db.Add(character);
    //        db.SaveChanges();
    //    }
    //}
    public static void CountCharacter()
    {
        Console.Clear();
        using (var db = new AppDbContext())
            Console.WriteLine($"{db.Character.Count()} characters");
        Console.ReadLine();
        Console.Clear();
    }
    public static ConsoleColor ElementColorConsole(string element_name)
    {
        ConsoleColor color = element_name switch
        {
            "Aero" => ConsoleColor.Cyan,
            "Fusion" => ConsoleColor.Red,
            "Electro" => ConsoleColor.DarkMagenta,
            "Glacio" => ConsoleColor.Blue,
            "Havoc" => ConsoleColor.Magenta,
            "Spectro" => ConsoleColor.Yellow,
            _ => ConsoleColor.Gray
        };
        Console.ForegroundColor = color;
        return color;
    }
}

