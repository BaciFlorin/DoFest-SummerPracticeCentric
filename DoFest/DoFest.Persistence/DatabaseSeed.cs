using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace DoFest.Persistence
{
    internal static class DatabaseSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region UserType
            var userTypes = new List<UserType>()
            {
                new UserType("Admin", "Full access"),
                new UserType("Normal user", "Normal access"),
            };
            modelBuilder.Entity<UserType>().HasData(userTypes);
            #endregion

            #region Admin
            var admin = new User("DoFestAdmin",
                                 "DoFestAdmin@gmail.com",
                                 CreateHash("passwordAdmin"), 
                                 userTypes[0].Id, 
                                 null
                                 );
            modelBuilder.Entity<User>().HasData(admin);

            var bucketListAdmin = new BucketList(admin.Id, "Admin bucketList");
            modelBuilder.Entity<BucketList>().HasData(bucketListAdmin);
            #endregion

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Activities.json"));
            string result = string.Empty;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }


            var activityData = JObject.Parse(result)["Activities"];
           
            #region City
            var citiesData = (from activity in activityData select (string) activity["Location"]).Distinct();
            var cities = citiesData.Select(cityName => new City(cityName)).ToList();
            modelBuilder.Entity<City>().HasData(cities);
            #endregion

            #region ActivityType
            var activityTypeData = (from activity in activityData select (string) activity["Category"]).Distinct();
            var activityTypes =
                activityTypeData.Select(activityTypeName => new ActivityType(activityTypeName)).ToList();
            modelBuilder.Entity<ActivityType>().HasData(activityTypes);
            #endregion

            var cityMap = cities.ToDictionary(city => city.Name, city => city.Id);

            var activityTypeMap = activityTypes.ToDictionary(aType => aType.Name, aType => aType.Id);

            #region Activity
            var activities = activityData!
                .Select(activity => new Activity(activityTypeMap[((string)activity["Category"])!],
                                                 cityMap[((string)activity["Location"])!], 
                                                 (string)activity["Name"], 
                                                 (string) activity["Address"],
                                                 (string)activity["Description"]
                                                  )).ToList();
            modelBuilder.Entity<Activity>().HasData(activities);
            #endregion
        }

        private static string CreateHash(string password)
        {
            const int saltSize = 16;
            const int keySize = 32;
            const int iterations = 1000;
            using var algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA256);
            var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
            var salt = Convert.ToBase64String(algorithm.Salt);
            return $"{salt}.{key}";
        }
    }
}