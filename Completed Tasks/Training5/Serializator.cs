using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Training5
{
    public class Serializator
    {
        public void SerializeListOfCars()
        {
            var cars = new List<Car>();

            for (int i = 1; i < 10; i++)
            {
                var car = new Car()
                {
                    carld = i,
                    price = i * 1000,
                    quantity = i * 2,
                    total = i * i
                };

                cars.Add(car);
            }

            var binFormatter = new BinaryFormatter();

            using (var file = new FileStream("cars.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, cars);
            }

            using (var file = new FileStream("cars.bin", FileMode.OpenOrCreate))
            {
                var deserializedCars = binFormatter.Deserialize(file) as List<Car>;

                if (deserializedCars != null)
                {
                    Console.WriteLine("BIN Serialization:");

                    foreach (var car in deserializedCars)
                    {
                        Console.WriteLine(car);
                    }
                }
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Car>));

            using (var file = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, cars);
            }

            using (var file = new FileStream("cars.xml", FileMode.OpenOrCreate))
            {
                var deserializedCars = xmlSerializer.Deserialize(file) as List<Car>;

                if (deserializedCars != null)
                {
                    Console.WriteLine("XML Serialization:");

                    foreach (var car in deserializedCars)
                    {
                        Console.WriteLine(car);
                    }
                }
            }

            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Car>));

            using (var file = new FileStream("cars.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(file, cars);
            }

            using (var file = new FileStream("cars.json", FileMode.OpenOrCreate))
            {
                var deserializedCars = jsonFormatter.ReadObject(file) as List<Car>;

                if (deserializedCars != null)
                {
                    Console.WriteLine("JSON Serialization:");

                    foreach (var car in deserializedCars)
                    {
                        Console.WriteLine(car);
                    }
                }
            }
        }
    }
}