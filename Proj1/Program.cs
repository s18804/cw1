﻿using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proj1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //int tmp1 = 1;
            //double tmp2 = 2.0;

            //string tmp3 = "ala ma kota";
            //bool tmp4 = true;

            //var tmp5 = 1;

            //var tmp6 = "kot ma ale";

            //Console.WriteLine(tmp3 + tmp6 + tmp5);
            //Console.WriteLine($"{tmp3} {tmp6} {tmp5+tmp2}");

            //var path = @"Z:\APBD\cw1";

            //var newPerson = new Person {
            //    FirstName = "Janusz"
            //};
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            var httpClient = new HttpClient();

            //wywolanie metody asynchronicznej 
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
