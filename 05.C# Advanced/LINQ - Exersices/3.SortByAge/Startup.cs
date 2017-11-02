﻿namespace _3.SortByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new List<string>();

            while (!input.Equals("END"))
            {
                students.Add(input);

                input = Console.ReadLine();
            }

            students.Select(s =>
            {
                var tokens = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var FirstName = tokens[0];
                var LastName = tokens[1];
                var Age = int.Parse(tokens[2]);
                return new {FirstName, LastName, Age};
            })
            .Where(n => n.Age >= 18 && n.Age <= 24)
            .ToList()
            .ForEach(c => Console.WriteLine($"{c.FirstName} {c.LastName} {c.Age}"));
        }
    }
}
