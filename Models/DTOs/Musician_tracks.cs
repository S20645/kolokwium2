using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models.DTOs
{
    public class Musician_tracks
    {
        public IEnumerable<Models.DTOs.Track> tracks { get; set; }
        public IEnumerable<Models.DTOs.Musician> musicians { get; set; }

    }
}
