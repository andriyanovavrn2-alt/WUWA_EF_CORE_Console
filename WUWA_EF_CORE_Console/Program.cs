using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using WUWA_CHARACTER_OOP.Models;
using WUWA_EF_CORE_Console;
using WUWA_WINFORMS_POSTGRE;
using WUWA_WINFORMS_POSTGRE.Models;
public static class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter:\nl - list of characters\na - add the character\nr - filter by rarity\ne - filter by element\nc - count of character");
            string chose = Console.ReadLine();
            if (chose == "la") ListAllInfo();
            if (chose == "ls") ListShornInfo();
            // if (chose == 'a') AddCharacter();
            if (chose == "r") FilterRarity();
            if (chose == "e") FilterElement();
            if (chose == "c") CountCharacter();
        }
    }

    public static void ListAllInfo()
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

    public static void ListShornInfo()
    {
        using (var db = new AppDbContext())
        {
            foreach (var character in db.Character.AsNoTracking()
                .Select(character => new CharacterDto(character.Name, character.Rarity.RarityName)).ToList())
            {
                Console.WriteLine($"{character.Name} {character.RarityName}");

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
    public static void FilterElement()  // отложенное выполнение
    {

        using (var db = new AppDbContext())
        {
            var query = db.Character.AsQueryable();
            Console.WriteLine($"Elements:");
            foreach (var element in db.Elements.AsNoTracking())
            {
                Console.WriteLine(element.ElementName);
            }
            Console.WriteLine("Chose the element.");
            var choseElement = Console.ReadLine();
            query = query
                .Where(character => character.Element.ElementName == choseElement); // построение запроса
            var result = query.ToList();  // выполнение
            foreach (var character in result) // вывод списка
            {
                Console.WriteLine(character.Name);
            }
            Console.WriteLine("\n");

        }
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
        using (var db = new AppDbContext())
            Console.WriteLine($"{db.Character.Count()} characters\n\n");
    }
}

