using System.Collections.Generic;
using System;
using System.Text;



namespace LinqSnippets


{
    public class Snippets
    {
        static public void BasicLinq()
        {

            string[] cars = 
            {  
            "VW Golf",
            "VW California",
            "Audi A3",
            "Audio A5",
            "Fiat Punto",
            "Seat Ibiza",
            "Seat Leon"
        };

        // 1. SELECT * of cars (SELECT ALL CARS)
        var carList = from car in cars select car;

        foreach (var car in carList)
        {
            Console.WriteLine(car);
        }

        // 2. WHERE car is Audi (SELECT Audis)
        var audiList = from car in cars where car.Contains("Audi") select car;

        foreach (var car in audiList)
        {
            Console.WriteLine(car);
        }
        
    }

        private static void NumberExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Each Number multiplied by 3
            //take all numbers, but 9
            //Order numbers by ascending value

            var processedNumberList = numbers.Select(number => number * 3).Where(number => number != 9).OrderBy(number => number);
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>()
            {
                "Hello",
                "World",
                "c",
                "Are",
                "You",
                "Today",
                "?",
                "!"
            };

            //1. First of all elements
            var first = textList.First();

            //2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));
        
        
        }   
    }
}
