using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Data;
using WebAPIApplication.Entities;

namespace WebAPIApplication.Infrastructure
{
    public class CampRepository : ICampRepository
    {
        private CampDbContext Context ;
        public CampRepository(CampDbContext ctx)
        {
            Context = ctx;
        }
        public void Add<T>(T entity) where T : class
        {
             Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public IEnumerable<Camp> GetAllCamps()
        {
            return Context.Camps.Include(c => c.Location)
                            .OrderBy(c => c.EventDate)
                            .ToList();
        }

        public Camp GetCamp(int id)
        {
           return Context.Camps
            .Include(c => c.Location)
            .Where(c => c.Id == id)
            .FirstOrDefault();
        }

        public Camp GetCampByMoniker(string moniker)
        {
             return Context.Camps
            .Include(c => c.Location)
            .Where(c => c.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault();
        }

        public Camp GetCampByMonikerWithSpeakers(string moniker)
        {
        return Context.Camps
        .Include(c => c.Location)
        .Include(c => c.Speakers)
        .ThenInclude(s => s.Talks)
        .Where(c => c.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
        .FirstOrDefault();
        }

        public Camp GetCampWithSpeakers(int id)
        {
        return Context.Camps
        .Include(c => c.Location)
        .Include(c => c.Speakers)
        .ThenInclude(s => s.Talks)
        .Where(c => c.Id == id)
        .FirstOrDefault();
        }

        public Speaker GetSpeaker(int speakerId)
        {
             return Context.Speakers
        .Include(s => s.Camp)
        .Where(s => s.Id == speakerId)
        .FirstOrDefault();
        }

        public IEnumerable<Speaker> GetSpeakers(int id)
        {
            return Context.Speakers
            .Include(s => s.Camp)
            .Where(s => s.Camp.Id == id)
            .OrderBy(s => s.Name)
            .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersByMoniker(string moniker)
        {
            return Context.Speakers
            .Include(c => c.Camp)
            .Where(s => s.Camp.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
            .OrderBy(s => s.Name)
            .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersByMonikerWithTalks(string moniker)
        {
        return Context.Speakers
        .Include(s => s.Camp)
        .Include(s => s.Talks)
        .Where(s => s.Camp.Moniker.Equals(moniker, StringComparison.CurrentCultureIgnoreCase))
        .OrderBy(s => s.Name)
        .ToList();
        }

        public IEnumerable<Speaker> GetSpeakersWithTalks(int id)
        {
            return Context.Speakers
            .Include(c =>c.Camp)
            .Include(c =>c.Talks)
            .Where(c => c.Id == id)
            .ToList();
        }

        public Speaker GetSpeakerWithTalks(int speakerId)
        {
             return Context.Speakers
            .Include(s => s.Camp)
            .Include(s => s.Talks)
            .Where(s => s.Id == speakerId)
            .FirstOrDefault();
        }

        public Talk GetTalk(int talkId)
        {
            return Context.Talks.
            Include(c =>c.Speaker)
            .ThenInclude(c =>c.Camp)
            .Where(t => t.Id == talkId)
            .OrderBy(t =>t.Title)
            .FirstOrDefault();
        }

        public IEnumerable<Talk> GetTalks(int speakerId)
        {
            return Context.Talks
            .Include(t => t.Speaker)
            .ThenInclude(s => s.Camp)
            .Where(t => t.Speaker.Id == speakerId)
            .OrderBy(t => t.Title)
            .ToList();
        }

        public CampUser GetUser(string userName)
        {
             return Context.Users
            .Include(u => u.Claims)
            .Include(u => u.Roles)
            .Where(u => u.UserName == userName)
            .Cast<CampUser>()
            .FirstOrDefault();
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }
    }
}