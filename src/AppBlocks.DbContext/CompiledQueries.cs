using AppBlocks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlocks.DbContext
{
    public static partial class CompiledQueries
    {
        public static Func<AppBlocksDbContext, string, Task<Member>> MemberByUserIdAsync =
            EF.CompileAsyncQuery((AppBlocksDbContext db, string userId) =>
                db.Members
                    .AsNoTracking()
                    .FirstOrDefault(m => userId != null && m.UserId == userId));

    }
}
