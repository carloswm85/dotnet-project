using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace DatingAppAPI.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse res, string message)
        {
            res.Headers.Add("Application-Error", message);
            res.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            res.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalulateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }

        public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input.First().ToString().ToUpper() + input.Substring(1)
        };

        public static bool IsUrlValid(string webUrl)
        {
            if (webUrl == null) return false;
            return Regex.IsMatch(webUrl, @"(http|https)://(([www\.])?|([\da-z-\.]+))\.([a-z\.]{2,3})$");
        }
    }
}