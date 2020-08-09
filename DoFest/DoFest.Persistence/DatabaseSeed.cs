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
                new UserType() {Name = "Admin", Description = "Full access"},
                new UserType() {Name = "Normal user", Description = "Normal access"},
            };
            modelBuilder.Entity<UserType>().HasData(userTypes);
            #endregion

            #region Admin
            var admin = new User()
            {
                Email = "DoFestAdmin@gmail.com",
                Username = "DoFestAdmin",
                UserTypeId = userTypes[0].Id,
                PasswordHash = CreateHash("passwordAdmin"),
                StudentId = null
            };
            modelBuilder.Entity<User>().HasData(admin);

            var bucketListAdmin = new BucketList()
            {
                UserId = admin.Id,
                Name = "Admin bucketList"
            };
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
            var cities = citiesData.Select(cityName => new City() {Name = cityName}).ToList();
            modelBuilder.Entity<City>().HasData(cities);
            #endregion

            #region ActivityType
            var activityTypeData = (from activity in activityData select (string) activity["Category"]).Distinct();
            var activityTypes =
                activityTypeData.Select(activityTypeName => new ActivityType() {Name = activityTypeName}).ToList();
            modelBuilder.Entity<ActivityType>().HasData(activityTypes);
            #endregion

            var cityMap = cities.ToDictionary(city => city.Name, city => city.Id);

            var activityTypeMap = activityTypes.ToDictionary(aType => aType.Name, aType => aType.Id);

            #region Activity
            var activities = activityData!.Select(activity => new Activity()
            {
                Name = (string)activity["Name"],
                ActivityTypeId = activityTypeMap[((string)activity["Category"])!],
                CityId = cityMap[((string)activity["Location"])!],
                Address = (string) activity["Address"],
                Description = (string) activity["Description"],
            }).ToList();
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