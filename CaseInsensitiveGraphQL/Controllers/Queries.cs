using CaseInsensitiveGraphQL.Db;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseInsensitiveGraphQL.Controllers
{
    public class Queries
    {
        [UseOffsetPaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<User>> GetUsers([Service] DemoContext context) =>
            await Task.Run(() => context.Users.Include(x => x.Addresses).AsQueryable());

    }
}
