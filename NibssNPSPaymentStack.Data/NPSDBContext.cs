using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NibbssNPSPaymentStack.API.Models.Model;

using NibssNPSPaymentStack.Data.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NibssNPSPaymentStack.Data.Models.ModelView;
using NibssNPSPaymentStack.API.Models.Model;

namespace NibssNPSPaymentStack.Data
{


    public class NPSDBContext : IdentityDbContext<IdentityUser>
    {
        public NPSDBContext(DbContextOptions<NPSDBContext> options) : base(options) {   }

        public DbSet<UsersSetup> UsersSetup => Set<UsersSetup>();
        public DbSet<AvailiableEndpoints> AvailableEndpoints => Set<AvailiableEndpoints>();
        public DbSet<Grantedendpoints> Grantedendpoints => Set<Grantedendpoints>();

        public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
        public DbSet<IpWhitelistEntry> IpWhitelistEntries => Set<IpWhitelistEntry>();
        public DbSet<RateLimitRule> RateLimitRules => Set<RateLimitRule>();

        public DbSet<ActivitiesLog> ActivitiesLog => Set<ActivitiesLog>();
        public DbSet<TokenMgt> TokenMgt => Set<TokenMgt>();

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    var stringListComparer = new ValueComparer<List<string>>(
        //        (c1, c2) => c1!.SequenceEqual(c2),
        //        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        //        c => c.ToList()
        //    );



        //    // Configure relationships
        //    modelBuilder.Entity<ApiKey>()
        //        .HasOne(a => a.User)
        //        .WithMany()
        //        .HasForeignKey(a => a.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<IpWhitelistEntry>()
        //        .HasOne(i => i.ApiKey)
        //        .WithMany(a => a.IpWhitelistEntries)
        //        .HasForeignKey(i => i.ApiKeyId);

        //    modelBuilder.Entity<RateLimitRule>()
        //        .HasOne(r => r.ApiKey)
        //        .WithMany(a => a.RateLimitRules)
        //        .HasForeignKey(r => r.ApiKeyId);



        //    modelBuilder.Entity<UsersSetup>(entity =>
        //    {
        //        entity.HasIndex(e => e.Username).IsUnique();
        //        entity.HasIndex(e => e.Email).IsUnique();

        //        //// Roles as JSON column
        //        //entity.Property(e => e.Roles)
        //        //    .HasConversion(
        //        //        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        //        //        v => JsonSerializer.Deserialize<string>(v, (JsonSerializerOptions?)null))
        //        //    .Metadata.SetValueComparer(stringListComparer);
        //        //    )


        //        // AllowedEndpoints as JSON column
        //        //entity.Property(e => e.AllowedEndpoints)
        //        //    .HasConversion(
        //        //        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        //        //        v => JsonSerializer.Deserialize<string>(v, (JsonSerializerOptions?)null)                     )
        //        //    .Metadata.SetValueComparer(stringListComparer);
        //    });

        //}

    }
}

