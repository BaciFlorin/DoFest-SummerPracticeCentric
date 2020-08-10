using DoFest.Business.Identity.Models;
using System;

namespace DoFest.UnitTests.Shared.Extensions
{
    public static class UserRegisterModelExtensions
    {
        public static RegisterModel WithEmail(this RegisterModel model, string email)
        {
            model.Email = email;
            return model;
        }

        public static RegisterModel WithUsername(this RegisterModel model, string username)
        {
            model.Username = username;
            return model;
        }

        public static RegisterModel WithPassword(this RegisterModel model, string password)
        {
            model.Password = password;
            return model;
        }

        public static RegisterModel WithName(this RegisterModel model, string name)
        {
            model.Name = name;
            return model;
        }

        public static RegisterModel WithAge(this RegisterModel model, int age)
        {
            model.Age = age;
            return model;
        }

        public static RegisterModel WithYear(this RegisterModel model, int year)
        {
            model.Year = year;
            return model;
        }

        public static RegisterModel WithCity(this RegisterModel model, Guid city)
        {
            model.City = city;
            return model;
        }

        public static RegisterModel WithBucketListName(this RegisterModel model, string bucketName)
        {
            model.BucketListName = bucketName;
            return model;
        }
    }
}