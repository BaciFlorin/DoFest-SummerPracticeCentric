using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
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

            var activityData = JObject.Parse(File.ReadAllText("../DoFest.Persistence/DatabaseData/Activities.json"))["Activities"];
           
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

            var cityMap = new Dictionary<string,Guid>();
            foreach (var city in cities)
            {
                cityMap.Add(city.Name, city.Id);
            }

            var activityTypeMap = new Dictionary<string, Guid>();
            foreach (var activityType in activityTypes)
            {
                activityTypeMap.Add(activityType.Name, activityType.Id);
            }

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
    }
}