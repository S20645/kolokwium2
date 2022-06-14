using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;

        public MusicService(MusicDbContext context)
        {
            _context = context;
        }

        public async Task <Musician> GetMusicianByID(int id)
        {
            return (Musician)_context.Musicians.Where(e => e.IdMusician == id);
        }

        public async Task<Models.DTOs.Musician_tracks> GetMusiciansByID(int id)
        {
            return (Models.DTOs.Musician_tracks)_context.Musician_Tracks
                .Include(e => e.Musician)
                .Where(e => e.IdMusician == id)
                .Include(e => e.Track)
                .Select(e => new Models.DTOs.Musician_tracks);
        }
    }
}
