using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Rows = File.ReadAllLines("fuel.csv");
            string[] Rowdata = Rows.Skip(1).ToArray();
            List<Car> CarList = new List<Car>();
            foreach (var row in Rowdata)
            {
                string[] isolRow = row.Split(',');
                CarList.Add(new Car
                {
                    ModelYear = int.Parse(isolRow[0]),
                    Division = isolRow[1],
                    Carline = isolRow[2],
                    EngDispl = isolRow[3],
                    Cyl = double.Parse(isolRow[4]),
                    CityFE = int.Parse(isolRow[5]),
                    HwyFE = int.Parse(isolRow[6]),
                    CombFE = int.Parse(isolRow[7])
                });
               
            }
           // foreach(var item in CarList)
            //    {
            //        Console.Write(item.Carline);
            //   }


            //---------------------ex.1-------------------
            var fueleff = CarList
                         .OrderByDescending(x => x.CityFE)
                         .Take(10);
            foreach (var item in fueleff)
            {
                Console.WriteLine(item.Division + " " + item.Carline + " " + item.CityFE);
            }
            Console.WriteLine("-----------------------");

            //-----------------ex.2--------------------
            var europcar = CarList.Select(c =>

            {
                var europMult = 284;
                return new EuropenCar()
                {
                    Division = c.Division,
                    Carline = c.Carline,
                    CityFE = europMult / c.CityFE
                };
            })
            .OrderBy(x => x.CityFE)
            .Take(10);
            foreach (var item in europcar)
            {
                Console.WriteLine(item.Division + " " + item.Carline + " " + item.CityFE);
            }

            Console.WriteLine("-----------------------");

            //-----------------ex.3--------------------

            var sortedNames = europcar.OrderBy(x => x.Division)
                .OrderBy(x => x.Carline)
                .OrderBy(x => x.Division);
            foreach (var item in sortedNames)
            {
                Console.WriteLine(item.Division + " " + item.Carline + " " + item.CityFE);
            }


            //-----------------ex.4--------------------

            

            Console.WriteLine("press [enter] to exit");
            Console.ReadLine();
        }
    }
}
