﻿using AutoMapper;
using DoFest.Business.Models.BucketList;
using DoFest.Business.Services.Interfaces;
using DoFest.Entities.Lists;
using DoFest.Persistence.Activities;
using DoFest.Persistence.BucketLists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoFest.Business.Services.Implementations
{
    public class BucketListService:IBucketListService
    {
        private readonly IMapper _mapper;
        private readonly IBucketListRepository _repository;

        public BucketListService(IBucketListRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BucketListModel> Get(Guid bucketListId)
        {

            var bucketList = await _repository.GetById(bucketListId);

            return _mapper.Map<BucketListModel>(bucketList);

        }

        public async Task<BucketListModel> Add(Guid bucketListId, Guid activityId)
        {
            var bucketList = await _repository.GetById(bucketListId);
            var bucketListActivity = new BucketListActivity();
            bucketListActivity.BucketListId = bucketListId;
            bucketListActivity.ActivityId = activityId;

            bucketList.AddBucketListActivity(bucketListActivity);

            _repository.Update(bucketList);

            await _repository.SaveChanges();

            return _mapper.Map<BucketListModel>(bucketList);

        }

    }
}