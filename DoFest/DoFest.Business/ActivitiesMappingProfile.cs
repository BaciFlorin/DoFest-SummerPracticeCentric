using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DoFest.Business.Models.Photos;
using DoFest.Entities.Activities.Content;

namespace DoFest.Business
{
     public class ActivitiesMappingProfile:Profile
    {
        public ActivitiesMappingProfile()
        {
            CreateMap<CreatePhotoModel, Photo>();
            CreateMap<Photo, PhotoModel>();

        }
    }
}
