using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<MusicLabel> musicLabels { get; set; }
        public DbSet<Track> tracks { get; set; }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var musicians = new List<Musician>
            {
                new Musician
                {
                    IdMusician = 1,
                    FirstName = "Janus",
                    LastName = "Janusz",
                    Nickname = "Janno"
                }
            };

            var tracks = new List<Track>
            {
                new Track
                {
                    IdTrack = 1,
                    TrackName = "asd",
                    Duration = 1,
                    IdMusicAlbum = 1
                },

                new Track
                {
                    IdTrack = 2,
                    TrackName = "sasa",
                    Duration = 2,
                    IdMusicAlbum = 1
                }
            };

            var musician_track = new List<Musician_Track>
            {
                new Musician_Track
                {
                    IdMusician = 1,
                    IdTrack = 1
                },
                new Musician_Track
                {
                    IdMusician = 1,
                    IdTrack = 2
                }
            };

            var albums = new List<Album>
            {
                new Album
                {
                    IdAlbum = 1,
                    AlbumName = "asd",
                    PublishDate = DateTime.Today,
                    IdMusicLabel = 1
                }
            };

            var musiclabels = new List<MusicLabel>
            {
                new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "kaka"
                }
            };



            modelBuilder.Entity<Musician>(e =>
            {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20);

                e.HasData(musicians);

                e.ToTable("Musician");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();
                e.Property(e => e.IdMusicAlbum);

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasData(tracks);

                e.ToTable("Track");
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.HasKey(e => e.IdTrack);
                e.HasKey(e => e.IdMusician);

                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musican_Tracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(e => e.Track)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasData(musician_track);

                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();
                e.Property(e => e.IdMusicLabel).IsRequired();

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Restrict);

                e.HasData(albums);

                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musiclabels);

                e.ToTable("MusicLabel");
            });
        }

    }
}
