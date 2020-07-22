using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using System;

using System.Threading.Tasks;

namespace DoFest.Persistence.BucketLists
{
      
    public sealed class BucketListRepository: Repository<User>, IBucketListRepository
    {
        public BucketListRepository(DoFestContext context) : base(context)
        {
        }
        public async Task<User> GetBucketListandUsernameByUserId(Guid id)
            => await this.context.BucketLists
                .Include(user => user.BucketList && user.Username)
                .FirstAsync(user => user.Id = id);


    }
}
