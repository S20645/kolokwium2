using kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
    public class IMusicService
    {
        public async Task<Musician> GetMusicianByID(int id);
        public async Task<Models.DTOs.Musician_tracks> GetMusiciansByID(int id);

    }
}
