using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoFest.Persistence.BucketLists
{
      
    public sealed class BucketListRepository: Repository<BucketList>, IBucketListRepository
    {
        public BucketListRepository(DoFestContext context) : base(context)
        {
        }
        public async Task<IList<BucketList>> GetBucketListById(Guid userId)
            => await context
                .BucketLists
                .Where(bucketList => bucketList.UserId == userId)
                .ToListAsync();


    }
}
