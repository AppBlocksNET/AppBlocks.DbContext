using AppBlocks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBlocks.DbContext
{
    public static partial class CompiledQueries
    {
        public static Func<AppBlocksDbContext, string, Task<Item>> GroupByNameAsync =
        EF.CompileAsyncQuery((AppBlocksDbContext db, string name) =>
            db.Items
        //        .Include(g => g.Events).ThenInclude(e => e.Links).ThenInclude(l => l.Link)
        //.Include(g => g.Events).ThenInclude(e => e.Sessions).ThenInclude(s => s.Speakers).ThenInclude(s => s.Member).ThenInclude(m => m.EventSpeakers)
        //        .Include(g => g.Events).ThenInclude(e => e.Sessions).ThenInclude(s => s.Speakers).ThenInclude(s => s.Member).ThenInclude(m => m.Links).ThenInclude(l => l.Link)
        //        .Include(g => g.Events).ThenInclude(e => e.Sponsors).ThenInclude(s => s.Sponsor)
        //        //.Include(g => g.Events).ThenInclude(e => e.EventSpeakers).ThenInclude(s => s.Member).ThenInclude(m => m.Links).ThenInclude(l => l.Link)
        //        .Include(g => g.Links).ThenInclude(l => l.Link)
        //        .Include(g => g.Location)
        //        //.Include(g => g.Members).ThenInclude(m => m.Role) //not working
        //        .Include(g => g.Members).ThenInclude(m => m.Member)
        //        .Include(g => g.Members).ThenInclude(m => m.Role)
        //        .Include(g => g.Tags)
                .AsNoTracking()
        //            .FirstOrDefault(g => string.Equals(g.Name, name, StringComparison.CurrentCultureIgnoreCase)));
                .FirstOrDefault(g => g.Name.ToLower() == name.ToLower()));

        //public static async Task<List<Item>> GroupsByMemberIdAsync(AppBlocksDbContext db, Guid memberId)
        //{
        //    return await db.GroupMembers.Include(gm => gm.Role).Include(gm => gm.Group).ThenInclude(g => g.Members).Where(g => g.Member.Id == memberId).OrderByDescending(gm => gm.Role).ThenBy(gm => gm.Group.Name).Select(gm => gm.Group)
        //        .AsNoTracking().ToListAsync();
        //}

        //public static async Task<bool> GroupMemberAddAsync(AppBlocksDbContext db, Guid groupId, Guid memberId)
        //{
        //    if (groupId != Guid.Empty && memberId != Guid.Empty)
        //    {
        //        var groupMember = await db.GroupMembers.FirstOrDefaultAsync(e => e.GroupId == groupId && e.MemberId == memberId);

        //        if (groupMember == null)
        //        {
        //            groupMember = new GroupMember
        //            {
        //                GroupId = groupId,
        //                MemberId = memberId,
        //                Created = DateTime.Now,
        //                Updated = DateTime.Now
        //            };

        //            db.GroupMembers.Add(groupMember);

        //            await db.SaveChangesAsync();

        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public static Func<AppBlocksDbContext, Guid, Task<GroupMemberBaseRole>> GroupMemberBaseRoleByRoleIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, Guid roleId) =>
        //        db.GroupMemberBaseRoles
        //            .AsNoTracking()
        //            .FirstOrDefault(r => r.Id == roleId));


        //public static Func<AppBlocksDbContext, Guid, Guid, Task<GroupMember>> GroupMemberByGroupIdMemberIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, Guid groupId, Guid memberId) =>
        //        db.GroupMembers
        //            .Include(gm => gm.Member)
        //            .Include(gm => gm.Role)
        //            .AsNoTracking()
        //            .FirstOrDefault(gm => gm.GroupId == groupId && gm.Member.Id == memberId));

        //public static Func<AppBlocksDbContext, Guid, string, Task<GroupMember>> GroupMemberByGroupIdUserIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, Guid groupId, string userId) =>
        //        db.GroupMembers
        //            .Include(gm => gm.Member)
        //            .Include(gm => gm.Role)
        //            .AsNoTracking()
        //            .FirstOrDefault(gm => gm.GroupId == groupId && gm.Member.UserId == userId));


        //public static async Task<List<Group>> GroupsAsync(AppBlocksDbContext db)
        //{
        //    return await
        //        db.Groups
        //                //.Include(g => g.Events).ThenInclude(e => e.Sessions).ThenInclude(s => s.Speakers).ThenInclude(s => s.Member)
        //                //.Include(g => g.Members).ThenInclude(m => m.Member)
        //                //.Include(g => g.Location)
        //                .AsNoTracking()
        //                .OrderBy(g => g.Title)
        //                .ToListAsync();
        //}

        //public static async Task<List<Group>> GroupsByLatLonRadiusAsync(AppBlocksDbContext db, LatLonRadiusResults latLonRadiusResults)
        //{
        //    return await
        //        db.Groups
        //            .Include(g => g.Events).ThenInclude(e => e.Sessions).ThenInclude(s => s.Speakers).ThenInclude(s => s.Member)
        //            .Include(g => g.Members).ThenInclude(m => m.Member)
        //            .Include(g => g.Location)
        //            .AsNoTracking()
        //            .Where(g => g.Location.Latitude >= latLonRadiusResults.LatMin &&
        //                        g.Location.Latitude <= latLonRadiusResults.LatMax &&
        //                        g.Location.Longitude >= latLonRadiusResults.LonMin &&
        //                        g.Location.Longitude <= latLonRadiusResults.LonMax)
        //            .ToListAsync();
        //}


        //public static async Task<List<Group>> GroupsByStateCodeAsync(AppBlocksDbContext db, string stateCode)
        //{
        //    return await
        //        db.Groups
        //            //.Include(g => g.Events).ThenInclude(e => e.Sessions).ThenInclude(s => s.Speakers).ThenInclude(s => s.Member)
        //            //.Include(g => g.Members).ThenInclude(m => m.Member)
        //            //.Include(g => g.Location)
        //            .AsNoTracking()
        //            .Where(g => g.Location.State == stateCode)
        //            .ToListAsync();
        //}


        //public static Func<AppBlocksDbContext, string, Task<Member>> MemberByEmailAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, string email) =>
        //        db.Members
        //            //.Include(m => m.Groups)
        //            //.Include(m => m.Links).ThenInclude(l => l.Link)
        //            //.Include(g => g.Tags)
        //            //.Include(s => s.TalksSpeakers).ThenInclude(t => t.Talk)
        //            .AsNoTracking()
        //            .FirstOrDefault(m => m.Email == email));

        //public static Func<AppBlocksDbContext, Guid, Task<Member>> MemberOnlyByIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, Guid id) =>
        //        db.Members
        //            .AsNoTracking()
        //            .FirstOrDefault(m => m.Id == id.ToString()));

        //public static Func<AppBlocksDbContext, Guid, Task<Member>> MemberByIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, Guid id) =>
        //        db.Members
        //            //.Include(s => s.EventSpeakers).ThenInclude(e => e.Event).ThenInclude(s => s.Sessions).ThenInclude(s => s.Speakers)
        //            //.Include(m => m.Groups)
        //            //.Include(m => m.Links).ThenInclude(l => l.Link)
        //            //.Include(g => g.Tags)
        //            //.Include(s => s.TalksSpeakers).ThenInclude(t => t.Talk).ThenInclude(t => t.Speakers)
        //            .AsNoTracking()
        //            .FirstOrDefault(m => m.Id == id.ToString()));

        //public static Func<AppBlocksDbContext, string, Task<Member>> MemberByNameAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, string name) =>
        //        db.Members
        //            //.Include(s => s.EventSpeakers).ThenInclude(e => e.Event).ThenInclude(e => e.Group)
        //            //.Include(s => s.EventSpeakers).ThenInclude(e => e.Event).ThenInclude(s => s.Sessions).ThenInclude(s => s.Speakers)
        //            //.Include(m => m.Groups)
        //            //.Include(m => m.Links).ThenInclude(l => l.Link)
        //            //.Include(g => g.Tags)
        //            //.Include(s => s.TalksSpeakers).ThenInclude(t => t.Talk).ThenInclude(t => t.Speakers)
        //            .AsNoTracking()
        //            //.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.CurrentCultureIgnoreCase)));
        //            .FirstOrDefault(m => m.Name.ToLower() == name.ToLower()));

        //public static Func<AppBlocksDbContext, string, Task<Member>> MemberByUserIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, string userId) =>
        //        db.Members
        //            //.Include(s => s.EventSpeakers).ThenInclude(e => e.Event).ThenInclude(s => s.Sessions).ThenInclude(s => s.Speakers)
        //            //.Include(m => m.Groups)
        //            //.Include(m => m.Links).ThenInclude(l => l.Link)
        //            //.Include(g => g.Tags)
        //            //.Include(s => s.TalksSpeakers).ThenInclude(t => t.Talk).ThenInclude(t => t.Speakers)
        //            .AsNoTracking()
        //            .FirstOrDefault(m => userId != null && m.UserId == userId));


        //public static Func<AppBlocksDbContext, string, Task<Member>> MemberOnlyByUserIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, string userId) =>
        //        db.Members
        //            .AsNoTracking()
        //            .FirstOrDefault(m => m.UserId == userId));

        //public static Func<AppBlocksDbContext, string, Task<Member>> MemberByUserIdAsync =
        //    EF.CompileAsyncQuery((AppBlocksDbContext db, string userId) =>
        //        db.Members
        //            .AsNoTracking()
        //            .FirstOrDefault(m => userId != null && m.UserId == userId));


    }
}
