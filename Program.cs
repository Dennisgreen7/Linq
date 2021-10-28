using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHM
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            //Quest1
            //מאגר נתונים
            int[] arrNums = new int[10];
            int rand_num;

            // ממלא מערך במספרים שלמים
            for (int i = 0; i < arrNums.Length; i++)
            {
                arrNums[i] = rand_num = rd.Next(-100, 200);
            }
            ////הגדרת שאילתה 
            var negativeNumberQueryM = arrNums.Where(num => num < 0).ToList();

            var negativeNumberQueryL =
                (from num in arrNums
                 where num < 0
                 select num).ToList();

            ////הרצת השאילתה 
            //foreach (var num in negativeNumberQuery)
            //{
            //    Console.Write(num + " ");
            //}

            //Quest2
            //הגדרת שאילתה 
            //תחביר 1
            var iZugiAsecQueryM = arrNums.Where(num => num % 2 == 1 || num % 2 == -1).OrderByDescending(num => num).Reverse().ToList();
            //תחביר 2
            var iZugiAsecQueryL =
                (from num in arrNums
                 where num % 2 == 1 || num % 2 == -1
                 orderby num
                 ascending
                 select num).ToList();
            ////הרצת השאילתה 
            //foreach (var num in iZugiAsecQuery)
            //{
            //    Console.Write(num + " ");
            //}

            //Quest3
            //הגדרת שאילתה 
            Func<int, bool> BiggerThen5AndDivisionBy3 = num =>
            {
                if (num > 5 && num % 3 != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            var notDivisionqueByQueryL =
                 (from num in arrNums
                  where num > 5 && num % 3 != 0
                  select num * 3).ToList();

            var notDivisionqueByQueryM = arrNums.Where(BiggerThen5AndDivisionBy3).Select(num => num * 3).ToList();
            ////הרצת השאילתה 
            foreach (var num in notDivisionqueByQueryL)
            {
                Console.Write(num + " ");
            }

            //Quest4
            List<string> Citys = new List<string>() { "Kfar-Saba", "Ranna", "Tel-Aviv", "Kiriyat Shmona" };

            Func<string, IList<String>> StrInCityNameQueryListL = str =>
             {
                 var cityQuery =
                  (from City in Citys
                   where City.Contains(str)
                   select City).ToList();
                 return cityQuery;
             };

            Func<string, IList<String>> StrInCityNameQueryListM = str =>
            {
                var StrInCityNameQuery = Citys.Where(city => city.Contains(str)).ToList();
                return StrInCityNameQuery;
            };

            var strincitynamelist = StrInCityNameQueryListL("Tel");
            var strincitynamelist2 = StrInCityNameQueryListM("Tel");

            //Quest5
            Func<string, IList<String>> StrNotInCityNameQueryListL = str =>
            {
                var cityQuery =
                (from City in Citys
                 where !City.Contains(str)
                 select City).ToList();
                return cityQuery;
            };

            Func<string, IList<String>> StrNotInCityNameQueryListM = str =>
            {
                var StrNotInCityNameQuery = Citys.Where(city => !city.Contains(str)).ToList();
                return StrNotInCityNameQuery;
            };

            var strnotincitynamelist = StrNotInCityNameQueryListL("Tel");
            var strnotincitynamelist2 = StrNotInCityNameQueryListM("Tel");

            //Quest6
            Func<string, string> StrInCityNameSinglQueryM = str =>
             {
                 return Citys.FirstOrDefault(city => city.IndexOf(str) != -1);
             };

            Func<string, string> StrInCityNameSinglQueryL = str =>
            {
                var cityQuery =
                (from City in Citys
                 where City.IndexOf(str) != -1
                 select City).First();
                return cityQuery;
            };

            var firstcityM = StrInCityNameSinglQueryM("K");
            var firstcityL = StrInCityNameSinglQueryL("K");

            //Quest7
            var OrderFirstThreeCitysNamesListQueryM = Citys.Select(city => city).OrderBy(city => city).Take(3).ToList();
            Func<List<string>> OrderFirstThreeCitysNamesListQuery = () =>
             {
                 var cityQuery =
                  (from City in Citys
                   orderby City
                   select City).Take(3);
                 return cityQuery.ToList();
             };

            var OrderFirstThreeCitysNamesListQuerylist2 = OrderFirstThreeCitysNamesListQuery();

            //Quest8
            List<City> citysClassList = new List<City>()
            { new City {Id = 1, Name = "Kfar Saba", NumberOfPopulation = 30000 },
              new City {Id = 1, Name = "Ranna", NumberOfPopulation = 20000 },
              new City {Id = 1, Name = "Tel Aviv", NumberOfPopulation = 260000 }
            };
            var NumberOfPopulationQueryL =
                (from city in citysClassList
                 where city.NumberOfPopulation > 25000
                 select city).ToList();

            var NumberOfPopulationQueryM = citysClassList.Where(city => city.NumberOfPopulation > 25000).ToList();

            //Quest9
            var NumberOfPopulationCityNameQueryL =
                (from city in citysClassList
                 where city.NumberOfPopulation > 25000
                 select city.Name).ToList();

            var NumberOfPopulationCityNameQueryM = citysClassList.Where(city => city.NumberOfPopulation > 25000).Select(city => city.Name).ToList();

            //Quest10
            var AnonymousNumberOfPopulationQueryL = (from city in citysClassList
                                                     select new { city.Name, Type =
                                                     (
                                                       city.NumberOfPopulation > 25000 ? "City":
                                                       city.NumberOfPopulation < 25000 ? "Yashov":null
                                                     )
                                                     }).ToList();
;
            var AnonymousNumberOfPopulationQueryM = citysClassList.Select(city => new { city.Name, Type = (city.NumberOfPopulation > 25000 ? "City": city.NumberOfPopulation < 25000 ? "Yashov":null) }).ToList();

            Console.ReadLine();
        }
}
}
