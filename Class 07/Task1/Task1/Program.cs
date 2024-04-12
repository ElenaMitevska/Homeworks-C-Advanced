﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Filter all cars that have origin from Europe and print them in console.
            var result = CarsData.Cars.Where(x => x.Origin == "Europe").Select(x => x.Model).ToList();
            result.ForEach(Console.WriteLine);
            Console.WriteLine("*********************************************");
            //Filter all cars that have more than 6 Cylinders not including 6,
            //    after that Filter all cars that have
            //    exactly 4 Cylinders and have HorsePower more than 110.0.Join them in one result and print them in console.

            var carsWithMoreThan6Cylinders = CarsData.Cars.Where(x => x.Cylinders > 6).Select(x => x.Model).ToList();
            var carsWith4Cylinders = CarsData.Cars.Where(x => x.Cylinders == 4).Select(x => x.Model).ToList();
            var carsWith4andMoreThan6Cylinders = carsWithMoreThan6Cylinders.Concat(carsWith4Cylinders).ToList();
            carsWith4andMoreThan6Cylinders.ForEach(Console.WriteLine);
            Console.WriteLine("*************************");
            //Count all cars based on their Origin and print the result in console.Example outpur "US 10 models\n Eu 15 Models";
            var originUs = CarsData.Cars.Count(x => x.Origin == "US").ToString();
            var originEurope = CarsData.Cars.Count(x => x.Origin ==  "Europe").ToString();
            var originJapan = CarsData.Cars.Count(x => x.Origin == "Japan").ToString();

            Console.WriteLine($"US -{originUs}");
            Console.WriteLine($"Europe -{originEurope}");
            Console.WriteLine($"Japan- {originJapan}");
            Console.WriteLine("*************************");
            //Filter all cars that have more then 200 HorsePower and Find out how much is the lowest, highes
            //    and average Miles per galon and print them in console;

            var carsWithMoreThan200HP = CarsData.Cars.Where(x => x.HorsePower > 200).Select(x => x.MilesPerGalon).OrderBy(x => x).ToList();
            var lowestMilesPerGalon = carsWithMoreThan200HP[0];
            Console.WriteLine(lowestMilesPerGalon);
            var highestMilesPerGalon = carsWithMoreThan200HP.Last();
            Console.WriteLine(highestMilesPerGalon);
            var carsWithMoreThan200HPSum = carsWithMoreThan200HP.Sum();
            var carsWithMoreThan200HPCount = carsWithMoreThan200HP.Count();
            var averageMilesPerGalonOfCarsWithMoreThan200HP = carsWithMoreThan200HPSum / carsWithMoreThan200HPCount;
            Console.WriteLine(averageMilesPerGalonOfCarsWithMoreThan200HP);






            Console.WriteLine("*************************");
            //Find the top 3 fastest accelerating cars:
            /*Ne znam kako se presmetuba*/

            Console.WriteLine("*************************");
            //Order cars by their AccelerationTime in ascending order. Take the top 3 cars from the ordered list.Print the model of each of these top 3 cars.

            var carByAccelerationTime = CarsData.Cars.OrderBy(x => x.AccelerationTime).ToList();
            var carByAccelerationTime1 = carByAccelerationTime[0].Model;
            Console.WriteLine(carByAccelerationTime1);
            var carByAccelerationTime2 = carByAccelerationTime[1].Model;
            Console.WriteLine(carByAccelerationTime2);
            var carByAccelerationTime3 = carByAccelerationTime[2].Model;
            Console.WriteLine(carByAccelerationTime3);
            Console.WriteLine("*************************");
            //Calculate the total weight of cars with more than 6 cylinders:
            var totalWeight = CarsData.Cars.Where(x => x.Cylinders > 6).Select(x => x.Weight).Sum().ToString();
            Console.WriteLine(totalWeight);
            Console.WriteLine("*************************");
            //Filter cars that have more than 6 cylinders.Calculate the total weight of these cars.Print the total weight.
            //Mislam deka e istio rezultat kako na prethodnoto baranje, barem spored moeto reshenie

            Console.WriteLine("*************************");
            //Find the average MilesPerGalon for cars with even number of cylinders:
            var carsWithEvenNumberOfCylinders = CarsData.Cars.Where(x => x.Cylinders % 2 == 0).Select(x => x.MilesPerGalon);
            var averageMilesPerGalonSum = carsWithEvenNumberOfCylinders.Sum();
            Console.WriteLine(averageMilesPerGalonSum);

            var averageMilesPerGalonCount = carsWithEvenNumberOfCylinders.Count();
            Console.WriteLine(averageMilesPerGalonCount);
            var averageMilesPerGalon = averageMilesPerGalonSum / averageMilesPerGalonCount;
            Console.WriteLine(averageMilesPerGalon);






        }
    }
    public static class CarsData
    {
            public static List<Car> Cars = new List<Car>();
            static CarsData()
            {
                LoadCars();
            } 
            public static void LoadCars()
            {
                Cars = new List<Car>()
       {
           new Car() { Model = "Chevrolet Chevelle Malibu", MilesPerGalon = 18, AccelerationTime = 12, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 3504 },
           new Car() { Model = "Buick Skylark 320", MilesPerGalon = 15, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 165, Origin = "US", Weight = 3693 },
           new Car() { Model = "Plymouth Satellite", MilesPerGalon = 18, AccelerationTime = 11, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3436 },
           new Car() { Model = "AMC Rebel SST", MilesPerGalon = 16, AccelerationTime = 12, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3433 },
           new Car() { Model = "Ford Torino", MilesPerGalon = 17, AccelerationTime = 10.5, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 3449 },
           new Car() { Model = "Ford Galaxie 500", MilesPerGalon = 15, AccelerationTime = 10, Cylinders = 8, HorsePower = 198, Origin = "US", Weight = 4341 },
           new Car() { Model = "Chevrolet Impala", MilesPerGalon = 14, AccelerationTime = 9, Cylinders = 8, HorsePower = 220, Origin = "US", Weight = 4354 },
           new Car() { Model = "Plymouth Fury iii", MilesPerGalon = 14, AccelerationTime = 8.5, Cylinders = 8, HorsePower = 215, Origin = "US", Weight = 4312 },
           new Car() { Model = "Pontiac Catalina", MilesPerGalon = 14, AccelerationTime = 10, Cylinders = 8, HorsePower = 225, Origin = "US", Weight = 4425 },
           new Car() { Model = "AMC Ambassador DPL", MilesPerGalon = 15, AccelerationTime = 8.5, Cylinders = 8, HorsePower = 190, Origin = "US", Weight = 3850 },
           new Car() { Model = "Citroen DS-21 Pallas", MilesPerGalon = 0, AccelerationTime = 17.5, Cylinders = 4, HorsePower = 115, Origin = "Europe", Weight = 3090 },
           new Car() { Model = "Chevrolet Chevelle Concours (sw)", MilesPerGalon = 0, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 165, Origin = "US", Weight = 4142 },
           new Car() { Model = "Ford Torino (sw)", MilesPerGalon = 0, AccelerationTime = 11, Cylinders = 8, HorsePower = 153, Origin = "US", Weight = 4034 },
           new Car() { Model = "Plymouth Satellite (sw)", MilesPerGalon = 0, AccelerationTime = 10.5, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 4166 },
           new Car() { Model = "AMC Rebel SST (sw)", MilesPerGalon = 0, AccelerationTime = 11, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 3850 },
           new Car() { Model = "Dodge Challenger SE", MilesPerGalon = 15, AccelerationTime = 10, Cylinders = 8, HorsePower = 170, Origin = "US", Weight = 3563 },
           new Car() { Model = "Plymouth 'Cuda 340", MilesPerGalon = 14, AccelerationTime = 8, Cylinders = 8, HorsePower = 160, Origin = "US", Weight = 3609 },
           new Car() { Model = "Ford Mustang Boss 302", MilesPerGalon = 0, AccelerationTime = 8, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 3353 },
           new Car() { Model = "Chevrolet Monte Carlo", MilesPerGalon = 15, AccelerationTime = 9.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3761 },
           new Car() { Model = "Buick Estate Wagon (sw)", MilesPerGalon = 14, AccelerationTime = 10, Cylinders = 8, HorsePower = 225, Origin = "US", Weight = 3086 },
           new Car() { Model = "Toyota Corolla Mark ii", MilesPerGalon = 24, AccelerationTime = 15, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2372 },
           new Car() { Model = "Plymouth Duster", MilesPerGalon = 22, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 2833 },
           new Car() { Model = "AMC Hornet", MilesPerGalon = 18, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 97, Origin = "US", Weight = 2774 },
           new Car() { Model = "Ford Maverick", MilesPerGalon = 21, AccelerationTime = 16, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 2587 },
           new Car() { Model = "Datsun PL510", MilesPerGalon = 27, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 88, Origin = "Japan", Weight = 2130 },
           new Car() { Model = "Volkswagen 1131 Deluxe Sedan", MilesPerGalon = 26, AccelerationTime = 20.5, Cylinders = 4, HorsePower = 46, Origin = "Europe", Weight = 1835 },
           new Car() { Model = "Peugeot 504", MilesPerGalon = 25, AccelerationTime = 17.5, Cylinders = 4, HorsePower = 87, Origin = "Europe", Weight = 2672 },
           new Car() { Model = "Audi 100 LS", MilesPerGalon = 24, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 90, Origin = "Europe", Weight = 2430 },
           new Car() { Model = "Saab 99e", MilesPerGalon = 25, AccelerationTime = 17.5, Cylinders = 4, HorsePower = 95, Origin = "Europe", Weight = 2375 },
           new Car() { Model = "BMW 2002", MilesPerGalon = 26, AccelerationTime = 12.5, Cylinders = 4, HorsePower = 113, Origin = "Europe", Weight = 2234 },
           new Car() { Model = "AMC Gremlin", MilesPerGalon = 21, AccelerationTime = 15, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 2648 },
           new Car() { Model = "Ford F250", MilesPerGalon = 10, AccelerationTime = 14, Cylinders = 8, HorsePower = 215, Origin = "US", Weight = 4615 },
           new Car() { Model = "Chevy C20", MilesPerGalon = 10, AccelerationTime = 15, Cylinders = 8, HorsePower = 200, Origin = "US", Weight = 4376 },
           new Car() { Model = "Dodge D200", MilesPerGalon = 11, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 210, Origin = "US", Weight = 4382 },
           new Car() { Model = "Hi 1200D", MilesPerGalon = 9, AccelerationTime = 18.5, Cylinders = 8, HorsePower = 193, Origin = "US", Weight = 4732 },
           new Car() { Model = "Datsun PL510", MilesPerGalon = 27, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 88, Origin = "Japan", Weight = 2130 },
           new Car() { Model = "Chevrolet Vega 2300", MilesPerGalon = 28, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2264 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 25, AccelerationTime = 14, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2228 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 25, AccelerationTime = 19, Cylinders = 4, HorsePower = 0, Origin = "US", Weight = 2046 },
           new Car() { Model = "Volkswagen Super Beetle 117", MilesPerGalon = 0, AccelerationTime = 20, Cylinders = 4, HorsePower = 48, Origin = "Europe", Weight = 1978 },
           new Car() { Model = "AMC Gremlin", MilesPerGalon = 19, AccelerationTime = 13, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 2634 },
           new Car() { Model = "Plymouth Satellite Custom", MilesPerGalon = 16, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3439 },
           new Car() { Model = "Chevrolet Chevelle Malibu", MilesPerGalon = 17, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3329 },
           new Car() { Model = "Ford Torino 500", MilesPerGalon = 19, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 88, Origin = "US", Weight = 3302 },
           new Car() { Model = "AMC Matador", MilesPerGalon = 18, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3288 },
           new Car() { Model = "Chevrolet Impala", MilesPerGalon = 14, AccelerationTime = 12, Cylinders = 8, HorsePower = 165, Origin = "US", Weight = 4209 },
           new Car() { Model = "Pontiac Catalina Brougham", MilesPerGalon = 14, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 4464 },
           new Car() { Model = "Ford Galaxie 500", MilesPerGalon = 14, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 153, Origin = "US", Weight = 4154 },
           new Car() { Model = "Plymouth Fury iii", MilesPerGalon = 14, AccelerationTime = 13, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4096 },
           new Car() { Model = "Dodge Monaco (sw)", MilesPerGalon = 12, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 180, Origin = "US", Weight = 4955 },
           new Car() { Model = "Ford Country Squire (sw)", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 170, Origin = "US", Weight = 4746 },
           new Car() { Model = "Pontiac Safari (sw)", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 5140 },
           new Car() { Model = "AMC Hornet Sportabout (sw)", MilesPerGalon = 18, AccelerationTime = 13.5, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 2962 },
           new Car() { Model = "Chevrolet Vega (sw)", MilesPerGalon = 22, AccelerationTime = 19, Cylinders = 4, HorsePower = 72, Origin = "US", Weight = 2408 },
           new Car() { Model = "Pontiac Firebird", MilesPerGalon = 19, AccelerationTime = 15, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3282 },
           new Car() { Model = "Ford Mustang", MilesPerGalon = 18, AccelerationTime = 14.5, Cylinders = 6, HorsePower = 88, Origin = "US", Weight = 3139 },
           new Car() { Model = "Mercury Capri 2000", MilesPerGalon = 23, AccelerationTime = 14, Cylinders = 4, HorsePower = 86, Origin = "US", Weight = 2220 },
           new Car() { Model = "Opel 1900", MilesPerGalon = 28, AccelerationTime = 14, Cylinders = 4, HorsePower = 90, Origin = "Europe", Weight = 2123 },
           new Car() { Model = "Peugeot 304", MilesPerGalon = 30, AccelerationTime = 19.5, Cylinders = 4, HorsePower = 70, Origin = "Europe", Weight = 2074 },
           new Car() { Model = "Fiat 124B", MilesPerGalon = 30, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 76, Origin = "Europe", Weight = 2065 },
           new Car() { Model = "Toyota Corolla 1200", MilesPerGalon = 31, AccelerationTime = 19, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 1773 },
           new Car() { Model = "Datsun 1200", MilesPerGalon = 35, AccelerationTime = 18, Cylinders = 4, HorsePower = 69, Origin = "Japan", Weight = 1613 },
           new Car() { Model = "Volkswagen Model 111", MilesPerGalon = 27, AccelerationTime = 19, Cylinders = 4, HorsePower = 60, Origin = "Europe", Weight = 1834 },
           new Car() { Model = "Plymouth Cricket", MilesPerGalon = 26, AccelerationTime = 20.5, Cylinders = 4, HorsePower = 70, Origin = "US", Weight = 1955 },
           new Car() { Model = "Toyota Corolla Hardtop", MilesPerGalon = 24, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2278 },
           new Car() { Model = "Dodge Colt Hardtop", MilesPerGalon = 25, AccelerationTime = 17, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 2126 },
           new Car() { Model = "Volkswagen Type 3", MilesPerGalon = 23, AccelerationTime = 23.5, Cylinders = 4, HorsePower = 54, Origin = "Europe", Weight = 2254 },
           new Car() { Model = "Chevrolet Vega", MilesPerGalon = 20, AccelerationTime = 19.5, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2408 },
           new Car() { Model = "Ford Pinto Runabout", MilesPerGalon = 21, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 86, Origin = "US", Weight = 2226 },
           new Car() { Model = "Chevrolet Impala", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 165, Origin = "US", Weight = 4274 },
           new Car() { Model = "Pontiac Catalina", MilesPerGalon = 14, AccelerationTime = 12, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 4385 },
           new Car() { Model = "Plymouth Fury III", MilesPerGalon = 15, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4135 },
           new Car() { Model = "Ford Galaxie 500", MilesPerGalon = 14, AccelerationTime = 13, Cylinders = 8, HorsePower = 153, Origin = "US", Weight = 4129 },
           new Car() { Model = "AMC Ambassador SST", MilesPerGalon = 17, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3672 },
           new Car() { Model = "Mercury Marquis", MilesPerGalon = 11, AccelerationTime = 11, Cylinders = 8, HorsePower = 208, Origin = "US", Weight = 4633 },
           new Car() { Model = "Buick LeSabre Custom", MilesPerGalon = 13, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 155, Origin = "US", Weight = 4502 },
           new Car() { Model = "Oldsmobile Delta 88 Royale", MilesPerGalon = 12, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 160, Origin = "US", Weight = 4456 },
           new Car() { Model = "Chrysler Newport Royal", MilesPerGalon = 13, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 190, Origin = "US", Weight = 4422 },
           new Car() { Model = "Mazda RX2 Coupe", MilesPerGalon = 19, AccelerationTime = 13.5, Cylinders = 3, HorsePower = 97, Origin = "Japan", Weight = 2330 },
           new Car() { Model = "AMC Matador (sw)", MilesPerGalon = 15, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3892 },
           new Car() { Model = "Chevrolet Chevelle Concours (sw)", MilesPerGalon = 13, AccelerationTime = 14, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 4098 },
           new Car() { Model = "Ford Gran Torino (sw)", MilesPerGalon = 13, AccelerationTime = 16, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 4294 },
           new Car() { Model = "Plymouth Satellite Custom (sw)", MilesPerGalon = 14, AccelerationTime = 14, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4077 },
           new Car() { Model = "Volvo 145e (sw)", MilesPerGalon = 18, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 112, Origin = "Europe", Weight = 2933 },
           new Car() { Model = "Volkswagen 411 (sw)", MilesPerGalon = 22, AccelerationTime = 18, Cylinders = 4, HorsePower = 76, Origin = "Europe", Weight = 2511 },
           new Car() { Model = "Peugeot 504 (sw)", MilesPerGalon = 21, AccelerationTime = 19.5, Cylinders = 4, HorsePower = 87, Origin = "Europe", Weight = 2979 },
           new Car() { Model = "Renault 12 (sw)", MilesPerGalon = 26, AccelerationTime = 18, Cylinders = 4, HorsePower = 69, Origin = "Europe", Weight = 2189 },
           new Car() { Model = "Ford Pinto (sw)", MilesPerGalon = 22, AccelerationTime = 16, Cylinders = 4, HorsePower = 86, Origin = "US", Weight = 2395 },
           new Car() { Model = "Datsun 510 (sw)", MilesPerGalon = 28, AccelerationTime = 17, Cylinders = 4, HorsePower = 92, Origin = "Japan", Weight = 2288 },
           new Car() { Model = "Toyota Corolla Mark II (sw)", MilesPerGalon = 23, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 97, Origin = "Japan", Weight = 2506 },
           new Car() { Model = "Dodge Colt (sw)", MilesPerGalon = 28, AccelerationTime = 15, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 2164 },
           new Car() { Model = "Toyota Corolla 1600 (sw)", MilesPerGalon = 27, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 88, Origin = "Japan", Weight = 2100 },
           new Car() { Model = "Buick Century 350", MilesPerGalon = 13, AccelerationTime = 13, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 4100 },
           new Car() { Model = "AMC Matador", MilesPerGalon = 14, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3672 },
           new Car() { Model = "Chevrolet Malibu", MilesPerGalon = 13, AccelerationTime = 13, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 3988 },
           new Car() { Model = "Ford Gran Torino", MilesPerGalon = 14, AccelerationTime = 14.5, Cylinders = 8, HorsePower = 137, Origin = "US", Weight = 4042 },
           new Car() { Model = "Dodge Coronet Custom", MilesPerGalon = 15, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3777 },
           new Car() { Model = "Mercury Marquis Brougham", MilesPerGalon = 12, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 198, Origin = "US", Weight = 4952 },
           new Car() { Model = "Chevrolet Caprice Classic", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4464 },
           new Car() { Model = "Ford LTD", MilesPerGalon = 13, AccelerationTime = 13, Cylinders = 8, HorsePower = 158, Origin = "US", Weight = 4363 },
           new Car() { Model = "Plymouth Fury Gran Sedan", MilesPerGalon = 14, AccelerationTime = 14.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4237 },
           new Car() { Model = "Chrysler New Yorker Brougham", MilesPerGalon = 13, AccelerationTime = 11, Cylinders = 8, HorsePower = 215, Origin = "US", Weight = 4735 },
           new Car() { Model = "Buick Electra 225 Custom", MilesPerGalon = 12, AccelerationTime = 11, Cylinders = 8, HorsePower = 225, Origin = "US", Weight = 4951 },
           new Car() { Model = "AMC Ambassador Brougham", MilesPerGalon = 13, AccelerationTime = 11, Cylinders = 8, HorsePower = 175, Origin = "US", Weight = 3821 },
           new Car() { Model = "Plymouth Valiant", MilesPerGalon = 18, AccelerationTime = 16.5, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3121 },
           new Car() { Model = "Chevrolet Nova Custom", MilesPerGalon = 16, AccelerationTime = 18, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3278 },
           new Car() { Model = "AMC Hornet", MilesPerGalon = 18, AccelerationTime = 16, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 2945 },
           new Car() { Model = "Ford Maverick", MilesPerGalon = 18, AccelerationTime = 16.5, Cylinders = 6, HorsePower = 88, Origin = "US", Weight = 3021 },
           new Car() { Model = "Plymouth Duster", MilesPerGalon = 23, AccelerationTime = 16, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 2904 },
           new Car() { Model = "Volkswagen Super Beetle", MilesPerGalon = 26, AccelerationTime = 21, Cylinders = 4, HorsePower = 46, Origin = "Europe", Weight = 1950 },
           new Car() { Model = "Chevrolet Impala", MilesPerGalon = 11, AccelerationTime = 14, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4997 },
           new Car() { Model = "Ford Country", MilesPerGalon = 12, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 167, Origin = "US", Weight = 4906 },
           new Car() { Model = "Plymouth Custom Suburb", MilesPerGalon = 13, AccelerationTime = 13, Cylinders = 8, HorsePower = 170, Origin = "US", Weight = 4654 },
           new Car() { Model = "Oldsmobile Vista Cruiser", MilesPerGalon = 12, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 180, Origin = "US", Weight = 4499 },
           new Car() { Model = "AMC Gremlin", MilesPerGalon = 18, AccelerationTime = 15, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 2789 },
           new Car() { Model = "Toyota Camry", MilesPerGalon = 20, AccelerationTime = 19, Cylinders = 4, HorsePower = 88, Origin = "Japan", Weight = 2279 },
           new Car() { Model = "Chevrolet Vega", MilesPerGalon = 21, AccelerationTime = 19.5, Cylinders = 4, HorsePower = 72, Origin = "US", Weight = 2401 },
           new Car() { Model = "Datsun 610", MilesPerGalon = 22, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 94, Origin = "Japan", Weight = 2379 },
           new Car() { Model = "Mazda RX3", MilesPerGalon = 18, AccelerationTime = 13.5, Cylinders = 3, HorsePower = 90, Origin = "Japan", Weight = 2124 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 19, AccelerationTime = 18.5, Cylinders = 4, HorsePower = 85, Origin = "US", Weight = 2310 },
           new Car() { Model = "Mercury Capri v6", MilesPerGalon = 21, AccelerationTime = 14, Cylinders = 6, HorsePower = 107, Origin = "US", Weight = 2472 },
           new Car() { Model = "Fiat 124 Sport Coupe", MilesPerGalon = 26, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 90, Origin = "Europe", Weight = 2265 },
           new Car() { Model = "Chevrolet Monte Carlo S", MilesPerGalon = 15, AccelerationTime = 13, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 4082 },
           new Car() { Model = "Pontiac Grand Prix", MilesPerGalon = 16, AccelerationTime = 9.5, Cylinders = 8, HorsePower = 230, Origin = "US", Weight = 4278 },
           new Car() { Model = "Fiat 128", MilesPerGalon = 29, AccelerationTime = 19.5, Cylinders = 4, HorsePower = 49, Origin = "Europe", Weight = 1867 },
           new Car() { Model = "Opel Manta", MilesPerGalon = 24, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 75, Origin = "Europe", Weight = 2158 },
           new Car() { Model = "Audi 100LS", MilesPerGalon = 20, AccelerationTime = 14, Cylinders = 4, HorsePower = 91, Origin = "Europe", Weight = 2582 },
           new Car() { Model = "Volvo 144ea", MilesPerGalon = 19, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 112, Origin = "Europe", Weight = 2868 },
           new Car() { Model = "Dodge Dart Custom", MilesPerGalon = 15, AccelerationTime = 11, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3399 },
           new Car() { Model = "Saab 99le", MilesPerGalon = 24, AccelerationTime = 14, Cylinders = 4, HorsePower = 110, Origin = "Europe", Weight = 2660 },
           new Car() { Model = "Toyota Mark II", MilesPerGalon = 20, AccelerationTime = 13.5, Cylinders = 6, HorsePower = 122, Origin = "Japan", Weight = 2807 },
           new Car() { Model = "Oldsmobile Omega", MilesPerGalon = 11, AccelerationTime = 11, Cylinders = 8, HorsePower = 180, Origin = "US", Weight = 3664 },
           new Car() { Model = "Plymouth Duster", MilesPerGalon = 20, AccelerationTime = 16.5, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 3102 },
           new Car() { Model = "Ford Maverick", MilesPerGalon = 21, AccelerationTime = 17, Cylinders = 6, HorsePower = 0, Origin = "US", Weight = 2875 },
           new Car() { Model = "AMC Hornet", MilesPerGalon = 19, AccelerationTime = 16, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 2901 },
           new Car() { Model = "Chevrolet Nova", MilesPerGalon = 15, AccelerationTime = 17, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3336 },
           new Car() { Model = "Datsun B210", MilesPerGalon = 31, AccelerationTime = 19, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1950 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 26, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 2451 },
           new Car() { Model = "Toyota Corolla 1200", MilesPerGalon = 32, AccelerationTime = 21, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 1836 },
           new Car() { Model = "Chevrolet Vega", MilesPerGalon = 25, AccelerationTime = 17, Cylinders = 4, HorsePower = 75, Origin = "US", Weight = 2542 },
           new Car() { Model = "Chevrolet Chevelle Malibu Classic", MilesPerGalon = 16, AccelerationTime = 17, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3781 },
           new Car() { Model = "AMC Matador", MilesPerGalon = 16, AccelerationTime = 18, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3632 },
           new Car() { Model = "Plymouth Satellite Sebring", MilesPerGalon = 18, AccelerationTime = 16.5, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3613 },
           new Car() { Model = "Ford Gran Torino", MilesPerGalon = 16, AccelerationTime = 14, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 4141 },
           new Car() { Model = "Buick Century Luxus (sw)", MilesPerGalon = 13, AccelerationTime = 14.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4699 },
           new Car() { Model = "Dodge Coronet Custom (sw)", MilesPerGalon = 14, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4457 },
           new Car() { Model = "Ford Gran Torino (sw)", MilesPerGalon = 14, AccelerationTime = 16, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 4638 },
           new Car() { Model = "AMC Matador (sw)", MilesPerGalon = 14, AccelerationTime = 15.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4257 },
           new Car() { Model = "Audi Fox", MilesPerGalon = 29, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 83, Origin = "Europe", Weight = 2219 },
           new Car() { Model = "Volkswagen Dasher", MilesPerGalon = 26, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 67, Origin = "Europe", Weight = 1963 },
           new Car() { Model = "Opel Manta", MilesPerGalon = 26, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 78, Origin = "Europe", Weight = 2300 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 31, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 52, Origin = "Japan", Weight = 1649 },
           new Car() { Model = "Datsun 710", MilesPerGalon = 32, AccelerationTime = 19, Cylinders = 4, HorsePower = 61, Origin = "Japan", Weight = 2003 },
           new Car() { Model = "Dodge Colt", MilesPerGalon = 28, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 75, Origin = "US", Weight = 2125 },
           new Car() { Model = "Fiat 128", MilesPerGalon = 24, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 75, Origin = "Europe", Weight = 2108 },
           new Car() { Model = "Fiat 124 TC", MilesPerGalon = 26, AccelerationTime = 14, Cylinders = 4, HorsePower = 75, Origin = "Europe", Weight = 2246 },
           new Car() { Model = "Honda Civic", MilesPerGalon = 24, AccelerationTime = 15, Cylinders = 4, HorsePower = 97, Origin = "Japan", Weight = 2489 },
           new Car() { Model = "Subaru", MilesPerGalon = 26, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 93, Origin = "Japan", Weight = 2391 },
           new Car() { Model = "Fiat x1,9", MilesPerGalon = 31, AccelerationTime = 16, Cylinders = 4, HorsePower = 67, Origin = "Europe", Weight = 2000 },
           new Car() { Model = "Plymouth Valiant Custom", MilesPerGalon = 19, AccelerationTime = 16, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 3264 },
           new Car() { Model = "Chevrolet Nova", MilesPerGalon = 18, AccelerationTime = 16, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3459 },
           new Car() { Model = "Mercury Monarch", MilesPerGalon = 15, AccelerationTime = 21, Cylinders = 6, HorsePower = 72, Origin = "US", Weight = 3432 },
           new Car() { Model = "Ford Maverick", MilesPerGalon = 15, AccelerationTime = 19.5, Cylinders = 6, HorsePower = 72, Origin = "US", Weight = 3158 },
           new Car() { Model = "Pontiac Catalina", MilesPerGalon = 16, AccelerationTime = 11.5, Cylinders = 8, HorsePower = 170, Origin = "US", Weight = 4668 },
           new Car() { Model = "Chevrolet Bel Air", MilesPerGalon = 15, AccelerationTime = 14, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 4440 },
           new Car() { Model = "Plymouth Grand Fury", MilesPerGalon = 16, AccelerationTime = 14.5, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4498 },
           new Car() { Model = "Ford LTD", MilesPerGalon = 14, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 148, Origin = "US", Weight = 4657 },
           new Car() { Model = "Buick Century", MilesPerGalon = 17, AccelerationTime = 21, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3907 },
           new Car() { Model = "Chevrolete Chevelle Malibu", MilesPerGalon = 16, AccelerationTime = 18.5, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3897 },
           new Car() { Model = "AMC Matador", MilesPerGalon = 15, AccelerationTime = 19, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3730 },
           new Car() { Model = "Plymouth Fury", MilesPerGalon = 18, AccelerationTime = 19, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 3785 },
           new Car() { Model = "Buick Skyhawk", MilesPerGalon = 21, AccelerationTime = 15, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3039 },
           new Car() { Model = "Chevrolet Monza 2+2", MilesPerGalon = 20, AccelerationTime = 13.5, Cylinders = 8, HorsePower = 110, Origin = "US", Weight = 3221 },
           new Car() { Model = "Ford Mustang II", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 129, Origin = "US", Weight = 3169 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 29, AccelerationTime = 16, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2171 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 23, AccelerationTime = 17, Cylinders = 4, HorsePower = 83, Origin = "US", Weight = 2639 },
           new Car() { Model = "AMC Gremlin", MilesPerGalon = 20, AccelerationTime = 16, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 2914 },
           new Car() { Model = "Pontiac Astro", MilesPerGalon = 23, AccelerationTime = 18.5, Cylinders = 4, HorsePower = 78, Origin = "US", Weight = 2592 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 24, AccelerationTime = 13.5, Cylinders = 4, HorsePower = 96, Origin = "Japan", Weight = 2702 },
           new Car() { Model = "Volkswagen Dasher", MilesPerGalon = 25, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 71, Origin = "Europe", Weight = 2223 },
           new Car() { Model = "Datsun 710", MilesPerGalon = 24, AccelerationTime = 17, Cylinders = 4, HorsePower = 97, Origin = "Japan", Weight = 2545 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 18, AccelerationTime = 14.5, Cylinders = 6, HorsePower = 97, Origin = "US", Weight = 2984 },
           new Car() { Model = "Volkswagen Rabbit", MilesPerGalon = 29, AccelerationTime = 14, Cylinders = 4, HorsePower = 70, Origin = "Europe", Weight = 1937 },
           new Car() { Model = "AMC Pacer", MilesPerGalon = 19, AccelerationTime = 17, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 3211 },
           new Car() { Model = "Audi 100LS", MilesPerGalon = 23, AccelerationTime = 15, Cylinders = 4, HorsePower = 95, Origin = "Europe", Weight = 2694 },
           new Car() { Model = "Peugeot 504", MilesPerGalon = 23, AccelerationTime = 17, Cylinders = 4, HorsePower = 88, Origin = "Europe", Weight = 2957 },
           new Car() { Model = "Volvo 244DL", MilesPerGalon = 22, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 98, Origin = "Europe", Weight = 2945 },
           new Car() { Model = "Saab 99LE", MilesPerGalon = 25, AccelerationTime = 13.5, Cylinders = 4, HorsePower = 115, Origin = "Europe", Weight = 2671 },
           new Car() { Model = "Honda Civic CVCC", MilesPerGalon = 33, AccelerationTime = 17.5, Cylinders = 4, HorsePower = 53, Origin = "Japan", Weight = 1795 },
           new Car() { Model = "Fiat 131", MilesPerGalon = 28, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 86, Origin = "Europe", Weight = 2464 },
           new Car() { Model = "Opel 1900", MilesPerGalon = 25, AccelerationTime = 16.9, Cylinders = 4, HorsePower = 81, Origin = "Europe", Weight = 2220 },
           new Car() { Model = "Capri ii", MilesPerGalon = 25, AccelerationTime = 14.9, Cylinders = 4, HorsePower = 92, Origin = "US", Weight = 2572 },
           new Car() { Model = "Dodge Colt", MilesPerGalon = 26, AccelerationTime = 17.7, Cylinders = 4, HorsePower = 79, Origin = "US", Weight = 2255 },
           new Car() { Model = "Renault 12tl", MilesPerGalon = 27, AccelerationTime = 15.3, Cylinders = 4, HorsePower = 83, Origin = "Europe", Weight = 2202 },
           new Car() { Model = "Chevrolet Chevelle Malibu Classic", MilesPerGalon = 17.5, AccelerationTime = 13, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 4215 },
           new Car() { Model = "Dodge Coronet Brougham", MilesPerGalon = 16, AccelerationTime = 13, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 4190 },
           new Car() { Model = "AMC Matador", MilesPerGalon = 15.5, AccelerationTime = 13.9, Cylinders = 8, HorsePower = 120, Origin = "US", Weight = 3962 },
           new Car() { Model = "Ford Gran Torino", MilesPerGalon = 14.5, AccelerationTime = 12.8, Cylinders = 8, HorsePower = 152, Origin = "US", Weight = 4215 },
           new Car() { Model = "Plymouth Valiant", MilesPerGalon = 22, AccelerationTime = 15.4, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3233 },
           new Car() { Model = "Chevrolet Nova", MilesPerGalon = 22, AccelerationTime = 14.5, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3353 },
           new Car() { Model = "Ford Maverick", MilesPerGalon = 24, AccelerationTime = 17.6, Cylinders = 6, HorsePower = 81, Origin = "US", Weight = 3012 },
           new Car() { Model = "AMC Hornet", MilesPerGalon = 22.5, AccelerationTime = 17.6, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 3085 },
           new Car() { Model = "Chevrolet Chevette", MilesPerGalon = 29, AccelerationTime = 22.2, Cylinders = 4, HorsePower = 52, Origin = "US", Weight = 2035 },
           new Car() { Model = "Chevrolet Woody", MilesPerGalon = 24.5, AccelerationTime = 22.1, Cylinders = 4, HorsePower = 60, Origin = "US", Weight = 2164 },
           new Car() { Model = "Volkswagen Rabbit", MilesPerGalon = 29, AccelerationTime = 14.2, Cylinders = 4, HorsePower = 70, Origin = "Europe", Weight = 1937 },
           new Car() { Model = "Honda Civic", MilesPerGalon = 33, AccelerationTime = 17.4, Cylinders = 4, HorsePower = 53, Origin = "Japan", Weight = 1795 },
           new Car() { Model = "Dodge Aspen SE", MilesPerGalon = 20, AccelerationTime = 17.7, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3651 },
           new Car() { Model = "Ford Grenada ghia", MilesPerGalon = 18, AccelerationTime = 21, Cylinders = 6, HorsePower = 78, Origin = "US", Weight = 3574 },
           new Car() { Model = "Pontiac Ventura SJ", MilesPerGalon = 18.5, AccelerationTime = 16.2, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3645 },
           new Car() { Model = "AMC Pacer d/l", MilesPerGalon = 17.5, AccelerationTime = 17.8, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 3193 },
           new Car() { Model = "Volkswagen Rabbit", MilesPerGalon = 29.5, AccelerationTime = 12.2, Cylinders = 4, HorsePower = 71, Origin = "Europe", Weight = 1825 },
           new Car() { Model = "Datsun B-210", MilesPerGalon = 32, AccelerationTime = 17, Cylinders = 4, HorsePower = 70, Origin = "Japan", Weight = 1990 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 28, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2155 },
           new Car() { Model = "Ford Pinto", MilesPerGalon = 26.5, AccelerationTime = 13.6, Cylinders = 4, HorsePower = 72, Origin = "US", Weight = 2565 },
           new Car() { Model = "Volvo 245", MilesPerGalon = 20, AccelerationTime = 15.7, Cylinders = 4, HorsePower = 102, Origin = "Europe", Weight = 3150 },
           new Car() { Model = "Plymouth Volare Premier v8", MilesPerGalon = 13, AccelerationTime = 13.2, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3940 },
           new Car() { Model = "Peugeot 504", MilesPerGalon = 19, AccelerationTime = 21.9, Cylinders = 4, HorsePower = 88, Origin = "Europe", Weight = 3270 },
           new Car() { Model = "Toyota Mark II", MilesPerGalon = 19, AccelerationTime = 15.5, Cylinders = 6, HorsePower = 108, Origin = "Japan", Weight = 2930 },
           new Car() { Model = "Mercedes-Benz 280s", MilesPerGalon = 16.5, AccelerationTime = 16.7, Cylinders = 6, HorsePower = 120, Origin = "Europe", Weight = 3820 },
           new Car() { Model = "Cadillac Seville", MilesPerGalon = 16.5, AccelerationTime = 12.1, Cylinders = 8, HorsePower = 180, Origin = "US", Weight = 4380 },
           new Car() { Model = "Chevrolet C10", MilesPerGalon = 13, AccelerationTime = 12, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 4055 },
           new Car() { Model = "Ford F108", MilesPerGalon = 13, AccelerationTime = 15, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 3870 },
           new Car() { Model = "Dodge D100", MilesPerGalon = 13, AccelerationTime = 14, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3755 },
           new Car() { Model = "Honda Accord CVCC", MilesPerGalon = 31.5, AccelerationTime = 18.5, Cylinders = 4, HorsePower = 68, Origin = "Japan", Weight = 2045 },
           new Car() { Model = "Buick Opel Isuzu Deluxe", MilesPerGalon = 30, AccelerationTime = 14.8, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 2155 },
           new Car() { Model = "Renault 5 GTL", MilesPerGalon = 36, AccelerationTime = 18.6, Cylinders = 4, HorsePower = 58, Origin = "Europe", Weight = 1825 },
           new Car() { Model = "Plymouth Arrow GS", MilesPerGalon = 25.5, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 96, Origin = "US", Weight = 2300 },
           new Car() { Model = "Datsun F-10 Hatchback", MilesPerGalon = 33.5, AccelerationTime = 16.8, Cylinders = 4, HorsePower = 70, Origin = "Japan", Weight = 1945 },
           new Car() { Model = "Chevrolet Caprice Classic", MilesPerGalon = 17.5, AccelerationTime = 12.5, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 3880 },
           new Car() { Model = "Oldsmobile Cutlass Supreme", MilesPerGalon = 17, AccelerationTime = 19, Cylinders = 8, HorsePower = 110, Origin = "US", Weight = 4060 },
           new Car() { Model = "Dodge Monaco Brougham", MilesPerGalon = 15.5, AccelerationTime = 13.7, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 4140 },
           new Car() { Model = "Mercury Cougar Brougham", MilesPerGalon = 15, AccelerationTime = 14.9, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 4295 },
           new Car() { Model = "Chevrolet Concours", MilesPerGalon = 17.5, AccelerationTime = 16.4, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3520 },
           new Car() { Model = "Buick Skylark", MilesPerGalon = 20.5, AccelerationTime = 16.9, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3425 },
           new Car() { Model = "Plymouth Volare Custom", MilesPerGalon = 19, AccelerationTime = 17.7, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3630 },
           new Car() { Model = "Ford Grenada", MilesPerGalon = 18.5, AccelerationTime = 19, Cylinders = 6, HorsePower = 98, Origin = "US", Weight = 3525 },
           new Car() { Model = "Pontiac Grand Prix LJ", MilesPerGalon = 16, AccelerationTime = 11.1, Cylinders = 8, HorsePower = 180, Origin = "US", Weight = 4220 },
           new Car() { Model = "Chevrolet Monte Carlo Landau", MilesPerGalon = 15.5, AccelerationTime = 11.4, Cylinders = 8, HorsePower = 170, Origin = "US", Weight = 4165 },
           new Car() { Model = "Chrysler Cordoba", MilesPerGalon = 15.5, AccelerationTime = 12.2, Cylinders = 8, HorsePower = 190, Origin = "US", Weight = 4325 },
           new Car() { Model = "Ford Thunderbird", MilesPerGalon = 16, AccelerationTime = 14.5, Cylinders = 8, HorsePower = 149, Origin = "US", Weight = 4335 },
           new Car() { Model = "Volkswagen Rabbit Custom", MilesPerGalon = 29, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 78, Origin = "Europe", Weight = 1940 },
           new Car() { Model = "Pontiac Sunbird Coupe", MilesPerGalon = 24.5, AccelerationTime = 16, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2740 },
           new Car() { Model = "Toyota Corolla Liftback", MilesPerGalon = 26, AccelerationTime = 18.2, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2265 },
           new Car() { Model = "Ford Mustang II 2+2", MilesPerGalon = 25.5, AccelerationTime = 15.8, Cylinders = 4, HorsePower = 89, Origin = "US", Weight = 2755 },
           new Car() { Model = "Chevrolet Chevette", MilesPerGalon = 35.5, AccelerationTime = 17, Cylinders = 4, HorsePower = 63, Origin = "US", Weight = 2051 },
           new Car() { Model = "Dodge Colt m/m", MilesPerGalon = 33.5, AccelerationTime = 15.9, Cylinders = 4, HorsePower = 83, Origin = "US", Weight = 2075 },
           new Car() { Model = "Subaru DL", MilesPerGalon = 30, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1985 },
           new Car() { Model = "Volkswagen Dasher", MilesPerGalon = 30.5, AccelerationTime = 14.1, Cylinders = 4, HorsePower = 78, Origin = "Europe", Weight = 2190 },
           new Car() { Model = "Datsun 810", MilesPerGalon = 22, AccelerationTime = 14.5, Cylinders = 6, HorsePower = 97, Origin = "Japan", Weight = 2815 },
           new Car() { Model = "BMW 320i", MilesPerGalon = 21.5, AccelerationTime = 12.8, Cylinders = 4, HorsePower = 110, Origin = "Europe", Weight = 2600 },
           new Car() { Model = "Mazda RX-4", MilesPerGalon = 21.5, AccelerationTime = 13.5, Cylinders = 3, HorsePower = 110, Origin = "Japan", Weight = 2720 },
           new Car() { Model = "Volkswagen Rabbit Custom Diesel", MilesPerGalon = 43.1, AccelerationTime = 21.5, Cylinders = 4, HorsePower = 48, Origin = "Europe", Weight = 1985 },
           new Car() { Model = "Ford Fiesta", MilesPerGalon = 36.1, AccelerationTime = 14.4, Cylinders = 4, HorsePower = 66, Origin = "US", Weight = 1800 },
           new Car() { Model = "Mazda GLC Deluxe", MilesPerGalon = 32.8, AccelerationTime = 19.4, Cylinders = 4, HorsePower = 52, Origin = "Japan", Weight = 1985 },
           new Car() { Model = "Datsun B210 GX", MilesPerGalon = 39.4, AccelerationTime = 18.6, Cylinders = 4, HorsePower = 70, Origin = "Japan", Weight = 2070 },
           new Car() { Model = "Honda Civic CVCC", MilesPerGalon = 36.1, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 60, Origin = "Japan", Weight = 1800 },
           new Car() { Model = "Oldsmobile Cutlass Salon Brougham", MilesPerGalon = 19.9, AccelerationTime = 15.5, Cylinders = 8, HorsePower = 110, Origin = "US", Weight = 3365 },
           new Car() { Model = "Dodge Diplomat", MilesPerGalon = 19.4, AccelerationTime = 13.2, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 3735 },
           new Car() { Model = "Mercury Monarch ghia", MilesPerGalon = 20.2, AccelerationTime = 12.8, Cylinders = 8, HorsePower = 139, Origin = "US", Weight = 3570 },
           new Car() { Model = "Pontiac Phoenix LJ", MilesPerGalon = 19.2, AccelerationTime = 19.2, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3535 },
           new Car() { Model = "Chevrolet Malibu", MilesPerGalon = 20.5, AccelerationTime = 18.2, Cylinders = 6, HorsePower = 95, Origin = "US", Weight = 3155 },
           new Car() { Model = "Ford Fairmont (auto)", MilesPerGalon = 20.2, AccelerationTime = 15.8, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 2965 },
           new Car() { Model = "Ford Fairmont (man)", MilesPerGalon = 25.1, AccelerationTime = 15.4, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2720 },
           new Car() { Model = "Plymouth Volare", MilesPerGalon = 20.5, AccelerationTime = 17.2, Cylinders = 6, HorsePower = 100, Origin = "US", Weight = 3430 },
           new Car() { Model = "AMC Concord", MilesPerGalon = 19.4, AccelerationTime = 17.2, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 3210 },
           new Car() { Model = "Buick Century Special", MilesPerGalon = 20.6, AccelerationTime = 15.8, Cylinders = 6, HorsePower = 105, Origin = "US", Weight = 3380 },
           new Car() { Model = "Mercury Zephyr", MilesPerGalon = 20.8, AccelerationTime = 16.7, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 3070 },
           new Car() { Model = "Dodge Aspen", MilesPerGalon = 18.6, AccelerationTime = 18.7, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3620 },
           new Car() { Model = "AMC Concord d/l", MilesPerGalon = 18.1, AccelerationTime = 15.1, Cylinders = 6, HorsePower = 120, Origin = "US", Weight = 3410 },
           new Car() { Model = "Chevrolet Monte Carlo Landau", MilesPerGalon = 19.2, AccelerationTime = 13.2, Cylinders = 8, HorsePower = 145, Origin = "US", Weight = 3425 },
           new Car() { Model = "Buick Regal Sport Coupe (turbo)", MilesPerGalon = 17.7, AccelerationTime = 13.4, Cylinders = 6, HorsePower = 165, Origin = "US", Weight = 3445 },
           new Car() { Model = "Ford Futura", MilesPerGalon = 18.1, AccelerationTime = 11.2, Cylinders = 8, HorsePower = 139, Origin = "US", Weight = 3205 },
           new Car() { Model = "Dodge Magnum XE", MilesPerGalon = 17.5, AccelerationTime = 13.7, Cylinders = 8, HorsePower = 140, Origin = "US", Weight = 4080 },
           new Car() { Model = "Chevrolet Chevette", MilesPerGalon = 30, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 68, Origin = "US", Weight = 2155 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 27.5, AccelerationTime = 14.2, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2560 },
           new Car() { Model = "Datsun 510", MilesPerGalon = 27.2, AccelerationTime = 14.7, Cylinders = 4, HorsePower = 97, Origin = "Japan", Weight = 2300 },
           new Car() { Model = "Dodge Omni", MilesPerGalon = 30.9, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 75, Origin = "US", Weight = 2230 },
           new Car() { Model = "Toyota Celica GT Liftback", MilesPerGalon = 21.1, AccelerationTime = 14.8, Cylinders = 4, HorsePower = 95, Origin = "Japan", Weight = 2515 },
           new Car() { Model = "Plymouth Sapporo", MilesPerGalon = 23.2, AccelerationTime = 16.7, Cylinders = 4, HorsePower = 105, Origin = "US", Weight = 2745 },
           new Car() { Model = "Oldsmobile Starfire SX", MilesPerGalon = 23.8, AccelerationTime = 17.6, Cylinders = 4, HorsePower = 85, Origin = "US", Weight = 2855 },
           new Car() { Model = "Datsun 200-SX", MilesPerGalon = 23.9, AccelerationTime = 14.9, Cylinders = 4, HorsePower = 97, Origin = "Japan", Weight = 2405 },
           new Car() { Model = "Audi 5000", MilesPerGalon = 20.3, AccelerationTime = 15.9, Cylinders = 5, HorsePower = 103, Origin = "Europe", Weight = 2830 },
           new Car() { Model = "Volvo 264gl", MilesPerGalon = 17, AccelerationTime = 13.6, Cylinders = 6, HorsePower = 125, Origin = "Europe", Weight = 3140 },
           new Car() { Model = "Saab 99gle", MilesPerGalon = 21.6, AccelerationTime = 15.7, Cylinders = 4, HorsePower = 115, Origin = "Europe", Weight = 2795 },
           new Car() { Model = "Peugeot 604sl", MilesPerGalon = 16.2, AccelerationTime = 15.8, Cylinders = 6, HorsePower = 133, Origin = "Europe", Weight = 3410 },
           new Car() { Model = "Volkswagen Scirocco", MilesPerGalon = 31.5, AccelerationTime = 14.9, Cylinders = 4, HorsePower = 71, Origin = "Europe", Weight = 1990 },
           new Car() { Model = "Honda Accord LX", MilesPerGalon = 29.5, AccelerationTime = 16.6, Cylinders = 4, HorsePower = 68, Origin = "Japan", Weight = 2135 },
           new Car() { Model = "Pontiac Lemans V6", MilesPerGalon = 21.5, AccelerationTime = 15.4, Cylinders = 6, HorsePower = 115, Origin = "US", Weight = 3245 },
           new Car() { Model = "Mercury Zephyr 6", MilesPerGalon = 19.8, AccelerationTime = 18.2, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 2990 },
           new Car() { Model = "Ford Fairmont 4", MilesPerGalon = 22.3, AccelerationTime = 17.3, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2890 },
           new Car() { Model = "AMC Concord DL 6", MilesPerGalon = 20.2, AccelerationTime = 18.2, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 3265 },
           new Car() { Model = "Dodge Aspen 6", MilesPerGalon = 20.6, AccelerationTime = 16.6, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3360 },
           new Car() { Model = "Chevrolet Caprice Classic", MilesPerGalon = 17, AccelerationTime = 15.4, Cylinders = 8, HorsePower = 130, Origin = "US", Weight = 3840 },
           new Car() { Model = "Ford LTD Landau", MilesPerGalon = 17.6, AccelerationTime = 13.4, Cylinders = 8, HorsePower = 129, Origin = "US", Weight = 3725 },
           new Car() { Model = "Mercury Grand Marquis", MilesPerGalon = 16.5, AccelerationTime = 13.2, Cylinders = 8, HorsePower = 138, Origin = "US", Weight = 3955 },
           new Car() { Model = "Dodge St, Regis", MilesPerGalon = 18.2, AccelerationTime = 15.2, Cylinders = 8, HorsePower = 135, Origin = "US", Weight = 3830 },
           new Car() { Model = "Buick Estate Wagon (sw)", MilesPerGalon = 16.9, AccelerationTime = 14.9, Cylinders = 8, HorsePower = 155, Origin = "US", Weight = 4360 },
           new Car() { Model = "Ford Country Squire (sw)", MilesPerGalon = 15.5, AccelerationTime = 14.3, Cylinders = 8, HorsePower = 142, Origin = "US", Weight = 4054 },
           new Car() { Model = "Chevrolet Malibu Classic (sw)", MilesPerGalon = 19.2, AccelerationTime = 15, Cylinders = 8, HorsePower = 125, Origin = "US", Weight = 3605 },
           new Car() { Model = "Chrysler Lebaron Town @ Country (sw)", MilesPerGalon = 18.5, AccelerationTime = 13, Cylinders = 8, HorsePower = 150, Origin = "US", Weight = 3940 },
           new Car() { Model = "Volkswagen Rabbit Custom", MilesPerGalon = 31.9, AccelerationTime = 14, Cylinders = 4, HorsePower = 71, Origin = "Europe", Weight = 1925 },
           new Car() { Model = "Mazda GLC Deluxe", MilesPerGalon = 34.1, AccelerationTime = 15.2, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 1975 },
           new Car() { Model = "Dodge Colt Hatchback Custom", MilesPerGalon = 35.7, AccelerationTime = 14.4, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 1915 },
           new Car() { Model = "AMC Spirit DL", MilesPerGalon = 27.4, AccelerationTime = 15, Cylinders = 4, HorsePower = 80, Origin = "US", Weight = 2670 },
           new Car() { Model = "Mercedes Benz 300d", MilesPerGalon = 25.4, AccelerationTime = 20.1, Cylinders = 5, HorsePower = 77, Origin = "Europe", Weight = 3530 },
           new Car() { Model = "Cadillac Eldorado", MilesPerGalon = 23, AccelerationTime = 17.4, Cylinders = 8, HorsePower = 125, Origin = "US", Weight = 3900 },
           new Car() { Model = "Peugeot 504", MilesPerGalon = 27.2, AccelerationTime = 24.8, Cylinders = 4, HorsePower = 71, Origin = "Europe", Weight = 3190 },
           new Car() { Model = "Oldsmobile Cutlass Salon Brougham", MilesPerGalon = 23.9, AccelerationTime = 22.2, Cylinders = 8, HorsePower = 90, Origin = "US", Weight = 3420 },
           new Car() { Model = "Plymouth Horizon", MilesPerGalon = 34.2, AccelerationTime = 13.2, Cylinders = 4, HorsePower = 70, Origin = "US", Weight = 2200 },
           new Car() { Model = "Plymouth Horizon TC3", MilesPerGalon = 34.5, AccelerationTime = 14.9, Cylinders = 4, HorsePower = 70, Origin = "US", Weight = 2150 },
           new Car() { Model = "Datsun 210", MilesPerGalon = 31.8, AccelerationTime = 19.2, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 2020 },
           new Car() { Model = "Fiat Strada Custom", MilesPerGalon = 37.3, AccelerationTime = 14.7, Cylinders = 4, HorsePower = 69, Origin = "Europe", Weight = 2130 },
           new Car() { Model = "Buick Skylark Limited", MilesPerGalon = 28.4, AccelerationTime = 16, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2670 },
           new Car() { Model = "Chevrolet Citation", MilesPerGalon = 28.8, AccelerationTime = 11.3, Cylinders = 6, HorsePower = 115, Origin = "US", Weight = 2595 },
           new Car() { Model = "Oldsmobile Omega Brougham", MilesPerGalon = 26.8, AccelerationTime = 12.9, Cylinders = 6, HorsePower = 115, Origin = "US", Weight = 2700 },
           new Car() { Model = "Pontiac Phoenix", MilesPerGalon = 33.5, AccelerationTime = 13.2, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2556 },
           new Car() { Model = "Volkswagen Rabbit", MilesPerGalon = 41.5, AccelerationTime = 14.7, Cylinders = 4, HorsePower = 76, Origin = "Europe", Weight = 2144 },
           new Car() { Model = "Toyota Corolla Tercel", MilesPerGalon = 38.1, AccelerationTime = 18.8, Cylinders = 4, HorsePower = 60, Origin = "Japan", Weight = 1968 },
           new Car() { Model = "Chevrolet Chevette", MilesPerGalon = 32.1, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 70, Origin = "US", Weight = 2120 },
           new Car() { Model = "Datsun 310", MilesPerGalon = 37.2, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 2019 },
           new Car() { Model = "Chevrolet Citation", MilesPerGalon = 28, AccelerationTime = 16.5, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2678 },
           new Car() { Model = "Ford Fairmont", MilesPerGalon = 26.4, AccelerationTime = 18.1, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2870 },
           new Car() { Model = "AMC Concord", MilesPerGalon = 24.3, AccelerationTime = 20.1, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 3003 },
           new Car() { Model = "Dodge Aspen", MilesPerGalon = 19.1, AccelerationTime = 18.7, Cylinders = 6, HorsePower = 90, Origin = "US", Weight = 3381 },
           new Car() { Model = "Audi 4000", MilesPerGalon = 34.3, AccelerationTime = 15.8, Cylinders = 4, HorsePower = 78, Origin = "Europe", Weight = 2188 },
           new Car() { Model = "Toyota Corolla Liftback", MilesPerGalon = 29.8, AccelerationTime = 15.5, Cylinders = 4, HorsePower = 90, Origin = "Japan", Weight = 2711 },
           new Car() { Model = "Mazda 626", MilesPerGalon = 31.3, AccelerationTime = 17.5, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2542 },
           new Car() { Model = "Datsun 510 Hatchback", MilesPerGalon = 37, AccelerationTime = 15, Cylinders = 4, HorsePower = 92, Origin = "Japan", Weight = 2434 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 32.2, AccelerationTime = 15.2, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2265 },
           new Car() { Model = "Mazda GLC", MilesPerGalon = 46.6, AccelerationTime = 17.9, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 2110 },
           new Car() { Model = "Dodge Colt", MilesPerGalon = 27.9, AccelerationTime = 14.4, Cylinders = 4, HorsePower = 105, Origin = "US", Weight = 2800 },
           new Car() { Model = "Datsun 210", MilesPerGalon = 40.8, AccelerationTime = 19.2, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 2110 },
           new Car() { Model = "Volkswagen Rabbit C (Diesel)", MilesPerGalon = 44.3, AccelerationTime = 21.7, Cylinders = 4, HorsePower = 48, Origin = "Europe", Weight = 2085 },
           new Car() { Model = "Volkswagen Dasher (diesel)", MilesPerGalon = 43.4, AccelerationTime = 23.7, Cylinders = 4, HorsePower = 48, Origin = "Europe", Weight = 2335 },
           new Car() { Model = "Audi 5000s (diesel)", MilesPerGalon = 36.4, AccelerationTime = 19.9, Cylinders = 5, HorsePower = 67, Origin = "Europe", Weight = 2950 },
           new Car() { Model = "Mercedes-Benz 240d", MilesPerGalon = 30, AccelerationTime = 21.8, Cylinders = 4, HorsePower = 67, Origin = "Europe", Weight = 3250 },
           new Car() { Model = "Honda Civic 1500 gl", MilesPerGalon = 44.6, AccelerationTime = 13.8, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1850 },
           new Car() { Model = "Renault Lecar Deluxe", MilesPerGalon = 40.9, AccelerationTime = 17.3, Cylinders = 4, HorsePower = 0, Origin = "Europe", Weight = 1835 },
           new Car() { Model = "Subaru DL", MilesPerGalon = 33.8, AccelerationTime = 18, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 2145 },
           new Car() { Model = "Volkswagen Rabbit", MilesPerGalon = 29.8, AccelerationTime = 15.3, Cylinders = 4, HorsePower = 62, Origin = "Europe", Weight = 1845 },
           new Car() { Model = "Datsun 280-ZX", MilesPerGalon = 32.7, AccelerationTime = 11.4, Cylinders = 6, HorsePower = 132, Origin = "Japan", Weight = 2910 },
           new Car() { Model = "Mazda RX-7 GS", MilesPerGalon = 23.7, AccelerationTime = 12.5, Cylinders = 3, HorsePower = 100, Origin = "Japan", Weight = 2420 },
           new Car() { Model = "Triumph TR7 Coupe", MilesPerGalon = 35, AccelerationTime = 15.1, Cylinders = 4, HorsePower = 88, Origin = "Europe", Weight = 2500 },
           new Car() { Model = "Ford Mustang Cobra", MilesPerGalon = 23.6, AccelerationTime = 14.3, Cylinders = 4, HorsePower = 0, Origin = "US", Weight = 2905 },
           new Car() { Model = "Ford Mustang Cobra", MilesPerGalon = 23.6, AccelerationTime = 14.3, Cylinders = 4, HorsePower = 0, Origin = "US", Weight = 2905 },
           new Car() { Model = "Honda Accord", MilesPerGalon = 32.4, AccelerationTime = 17, Cylinders = 4, HorsePower = 72, Origin = "Japan", Weight = 2290 },
           new Car() { Model = "Plymouth Reliant", MilesPerGalon = 27.2, AccelerationTime = 15.7, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2490 },
           new Car() { Model = "Buick Skylark", MilesPerGalon = 26.6, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2635 },
           new Car() { Model = "Dodge Aries Wagon (sw)", MilesPerGalon = 25.8, AccelerationTime = 14.4, Cylinders = 4, HorsePower = 92, Origin = "US", Weight = 2620 },
           new Car() { Model = "Chevrolet Citation", MilesPerGalon = 23.5, AccelerationTime = 12.6, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 2725 },
           new Car() { Model = "Plymouth Reliant", MilesPerGalon = 30, AccelerationTime = 12.9, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2385 },
           new Car() { Model = "Toyota Starlet", MilesPerGalon = 39.1, AccelerationTime = 16.9, Cylinders = 4, HorsePower = 58, Origin = "Japan", Weight = 1755 },
           new Car() { Model = "Plymouth Champ", MilesPerGalon = 39, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 64, Origin = "US", Weight = 1875 },
           new Car() { Model = "Honda Civic 1300", MilesPerGalon = 35.1, AccelerationTime = 16.1, Cylinders = 4, HorsePower = 60, Origin = "Japan", Weight = 1760 },
           new Car() { Model = "Subaru", MilesPerGalon = 32.3, AccelerationTime = 17.8, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 2065 },
           new Car() { Model = "Datsun 210 MPG", MilesPerGalon = 37, AccelerationTime = 19.4, Cylinders = 4, HorsePower = 65, Origin = "Japan", Weight = 1975 },
           new Car() { Model = "Toyota Tercel", MilesPerGalon = 37.7, AccelerationTime = 17.3, Cylinders = 4, HorsePower = 62, Origin = "Japan", Weight = 2050 },
           new Car() { Model = "Mazda GLC 4", MilesPerGalon = 34.1, AccelerationTime = 16, Cylinders = 4, HorsePower = 68, Origin = "Japan", Weight = 1985 },
           new Car() { Model = "Plymouth Horizon 4", MilesPerGalon = 34.7, AccelerationTime = 14.9, Cylinders = 4, HorsePower = 63, Origin = "US", Weight = 2215 },
           new Car() { Model = "Ford Escort 4W", MilesPerGalon = 34.4, AccelerationTime = 16.2, Cylinders = 4, HorsePower = 65, Origin = "US", Weight = 2045 },
           new Car() { Model = "Ford Escort 2H", MilesPerGalon = 29.9, AccelerationTime = 20.7, Cylinders = 4, HorsePower = 65, Origin = "US", Weight = 2380 },
           new Car() { Model = "Volkswagen Jetta", MilesPerGalon = 33, AccelerationTime = 14.2, Cylinders = 4, HorsePower = 74, Origin = "Europe", Weight = 2190 },
           new Car() { Model = "Renault 18i", MilesPerGalon = 34.5, AccelerationTime = 15.8, Cylinders = 4, HorsePower = 0, Origin = "Europe", Weight = 2320 },
           new Car() { Model = "Honda Prelude", MilesPerGalon = 33.7, AccelerationTime = 14.4, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2210 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 32.4, AccelerationTime = 16.8, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2350 },
           new Car() { Model = "Datsun 200SX", MilesPerGalon = 32.9, AccelerationTime = 14.8, Cylinders = 4, HorsePower = 100, Origin = "Japan", Weight = 2615 },
           new Car() { Model = "Mazda 626", MilesPerGalon = 31.6, AccelerationTime = 18.3, Cylinders = 4, HorsePower = 74, Origin = "Japan", Weight = 2635 },
           new Car() { Model = "Peugeot 505s Turbo Diesel", MilesPerGalon = 28.1, AccelerationTime = 20.4, Cylinders = 4, HorsePower = 80, Origin = "Europe", Weight = 3230 },
           new Car() { Model = "Saab 900s", MilesPerGalon = 0, AccelerationTime = 15.4, Cylinders = 4, HorsePower = 110, Origin = "Europe", Weight = 2800 },
           new Car() { Model = "Volvo Diesel", MilesPerGalon = 30.7, AccelerationTime = 19.6, Cylinders = 6, HorsePower = 76, Origin = "Europe", Weight = 3160 },
           new Car() { Model = "Toyota Cressida", MilesPerGalon = 25.4, AccelerationTime = 12.6, Cylinders = 6, HorsePower = 116, Origin = "Japan", Weight = 2900 },
           new Car() { Model = "Datsun 810 Maxima", MilesPerGalon = 24.2, AccelerationTime = 13.8, Cylinders = 6, HorsePower = 120, Origin = "Japan", Weight = 2930 },
           new Car() { Model = "Buick Century", MilesPerGalon = 22.4, AccelerationTime = 15.8, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 3415 },
           new Car() { Model = "Oldsmobile Cutlass LS", MilesPerGalon = 26.6, AccelerationTime = 19, Cylinders = 8, HorsePower = 105, Origin = "US", Weight = 3725 },
           new Car() { Model = "Ford Grenada gl", MilesPerGalon = 20.2, AccelerationTime = 17.1, Cylinders = 6, HorsePower = 88, Origin = "US", Weight = 3060 },
           new Car() { Model = "Chrysler Lebaron Salon", MilesPerGalon = 17.6, AccelerationTime = 16.6, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 3465 },
           new Car() { Model = "Chevrolet Cavalier", MilesPerGalon = 28, AccelerationTime = 19.6, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2605 },
           new Car() { Model = "Chevrolet Cavalier Wagon", MilesPerGalon = 27, AccelerationTime = 18.6, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2640 },
           new Car() { Model = "Chevrolet Cavalier 2-door", MilesPerGalon = 34, AccelerationTime = 18, Cylinders = 4, HorsePower = 88, Origin = "US", Weight = 2395 },
           new Car() { Model = "Pontiac J2000 SE Hatchback", MilesPerGalon = 31, AccelerationTime = 16.2, Cylinders = 4, HorsePower = 85, Origin = "US", Weight = 2575 },
           new Car() { Model = "Dodge Aries SE", MilesPerGalon = 29, AccelerationTime = 16, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2525 },
           new Car() { Model = "Pontiac Phoenix", MilesPerGalon = 27, AccelerationTime = 18, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2735 },
           new Car() { Model = "Ford Fairmont Futura", MilesPerGalon = 24, AccelerationTime = 16.4, Cylinders = 4, HorsePower = 92, Origin = "US", Weight = 2865 },
           new Car() { Model = "AMC Concord DL", MilesPerGalon = 23, AccelerationTime = 20.5, Cylinders = 4, HorsePower = 0, Origin = "US", Weight = 3035 },
           new Car() { Model = "Volkswagen Rabbit l", MilesPerGalon = 36, AccelerationTime = 15.3, Cylinders = 4, HorsePower = 74, Origin = "Europe", Weight = 1980 },
           new Car() { Model = "Mazda GLC Custom l", MilesPerGalon = 37, AccelerationTime = 18.2, Cylinders = 4, HorsePower = 68, Origin = "Japan", Weight = 2025 },
           new Car() { Model = "Mazda GLC Custom", MilesPerGalon = 31, AccelerationTime = 17.6, Cylinders = 4, HorsePower = 68, Origin = "Japan", Weight = 1970 },
           new Car() { Model = "Plymouth Horizon Miser", MilesPerGalon = 38, AccelerationTime = 14.7, Cylinders = 4, HorsePower = 63, Origin = "US", Weight = 2125 },
           new Car() { Model = "Mercury Lynx l", MilesPerGalon = 36, AccelerationTime = 17.3, Cylinders = 4, HorsePower = 70, Origin = "US", Weight = 2125 },
           new Car() { Model = "Nissan Stanza XE", MilesPerGalon = 36, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 88, Origin = "Japan", Weight = 2160 },
           new Car() { Model = "Honda Accord", MilesPerGalon = 36, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 75, Origin = "Japan", Weight = 2205 },
           new Car() { Model = "Toyota Corolla", MilesPerGalon = 34, AccelerationTime = 16.9, Cylinders = 4, HorsePower = 70, Origin = "Japan", Weight = 2245 },
           new Car() { Model = "Honda Civic", MilesPerGalon = 38, AccelerationTime = 15, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1965 },
           new Car() { Model = "Honda Civic (auto)", MilesPerGalon = 32, AccelerationTime = 15.7, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1965 },
           new Car() { Model = "Datsun 310 GX", MilesPerGalon = 38, AccelerationTime = 16.2, Cylinders = 4, HorsePower = 67, Origin = "Japan", Weight = 1995 },
           new Car() { Model = "Buick Century Limited", MilesPerGalon = 25, AccelerationTime = 16.4, Cylinders = 6, HorsePower = 110, Origin = "US", Weight = 2945 },
           new Car() { Model = "Oldsmobile Cutlass Ciera (diesel)", MilesPerGalon = 38, AccelerationTime = 17, Cylinders = 6, HorsePower = 85, Origin = "US", Weight = 3015 },
           new Car() { Model = "Chrysler Lebaron Medallion", MilesPerGalon = 26, AccelerationTime = 14.5, Cylinders = 4, HorsePower = 92, Origin = "US", Weight = 2585 },
           new Car() { Model = "Ford Grenada l", MilesPerGalon = 22, AccelerationTime = 14.7, Cylinders = 6, HorsePower = 112, Origin = "US", Weight = 2835 },
           new Car() { Model = "Toyota Celica GT", MilesPerGalon = 32, AccelerationTime = 13.9, Cylinders = 4, HorsePower = 96, Origin = "Japan", Weight = 2665 },
           new Car() { Model = "Dodge Charger 2,2", MilesPerGalon = 36, AccelerationTime = 13, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2370 },
           new Car() { Model = "Chevrolet Camaro", MilesPerGalon = 27, AccelerationTime = 17.3, Cylinders = 4, HorsePower = 90, Origin = "US", Weight = 2950 },
           new Car() { Model = "Ford Mustang GL", MilesPerGalon = 27, AccelerationTime = 15.6, Cylinders = 4, HorsePower = 86, Origin = "US", Weight = 2790 },
           new Car() { Model = "Volkswagen Pickup", MilesPerGalon = 44, AccelerationTime = 24.6, Cylinders = 4, HorsePower = 52, Origin = "Europe", Weight = 2130 },
           new Car() { Model = "Dodge Rampage", MilesPerGalon = 32, AccelerationTime = 11.6, Cylinders = 4, HorsePower = 84, Origin = "US", Weight = 2295 },
           new Car() { Model = "Ford Ranger", MilesPerGalon = 28, AccelerationTime = 18.6, Cylinders = 4, HorsePower = 79, Origin = "US", Weight = 2625 },
           new Car() { Model = "Chevy S-10", MilesPerGalon = 31, AccelerationTime = 19.4, Cylinders = 4, HorsePower = 82, Origin = "US", Weight = 2720 },
       };
            }
            

            }
      
        } 

