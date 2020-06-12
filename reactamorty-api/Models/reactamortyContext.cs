using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace reactamorty_api.Models
{
    public partial class reactamortyContext : DbContext
    {
        public reactamortyContext()
        {
        }

        public reactamortyContext(DbContextOptions<reactamortyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterHasEpisode> CharacterHasEpisode { get; set; }
        public virtual DbSet<Episode> Episode { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationHasCharacter> LocationHasCharacter { get; set; }
        
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"), x => x.ServerVersion("8.0.20-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("character");

                entity.HasIndex(e => e.Origin)
                    .HasName("fk_origin_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.Property(e => e.Species)
                    .HasColumnName("species")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.OriginNavigation)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.Origin)
                    .HasConstraintName("fk_origin");
            });

            modelBuilder.Entity<CharacterHasEpisode>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.EpisodeId })
                    .HasName("PRIMARY");

                entity.ToTable("character_has_episode");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_character_has_episode_character1_idx");

                entity.HasIndex(e => e.EpisodeId)
                    .HasName("fk_character_has_episode_episode1_idx");

                entity.Property(e => e.CharacterId).HasColumnName("character_id");

                entity.Property(e => e.EpisodeId).HasColumnName("episode_id");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterHasEpisode)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_character_has_episode_character1");

                entity.HasOne(d => d.Episode)
                    .WithMany(p => p.CharacterHasEpisode)
                    .HasForeignKey(d => d.EpisodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_character_has_episode_episode1");
            });

            modelBuilder.Entity<Episode>(entity =>
            {
                entity.ToTable("episode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirDate)
                    .HasColumnName("air_date")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Episode1)
                    .HasColumnName("episode")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AirDate)
                    .HasColumnName("air_date")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Episode)
                    .HasColumnName("episode")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<LocationHasCharacter>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.CharacterId })
                    .HasName("PRIMARY");

                entity.ToTable("location_has_character");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("fk_location_has_character_character1_idx");

                entity.HasIndex(e => e.LocationId)
                    .HasName("fk_location_has_character_location1_idx");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.CharacterId).HasColumnName("character_id");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.LocationHasCharacter)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_has_character_character1");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationHasCharacter)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_location_has_character_location1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
