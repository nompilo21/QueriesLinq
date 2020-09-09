using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QueriesLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            //querifying infinity
            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }


            //create new movies list
            var movies = new List<Movie>
            {
                new Movie {Title = "The Dark Knight", Rating = 8.0f, Year = 2020 },
                new Movie {Title = "The King's Speech", Rating = 8.9f, Year = 2019 },
                new Movie {Title = "Casablanka", Rating = 8.5f, Year = 1996 },
                new Movie {Title = "Star Wars V", Rating = 8.7f, Year = 1999 }
            };

            //Query using an extensin method to filter movies(replace where with Filter to use filter method)
            var query = movies.Filter(m => m.Year > 2000).ToList() 
                .OrderByDescending(m=>m.Rating);
            Console.WriteLine(query.Count());
                //.Take(1);(when you want to look at only 1 year

            /**foreach(var movie in query)
            {
                Console.WriteLine(movie.Title);
            }**/

            //Another way to write foreach statement
            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }
        }
    }
}
