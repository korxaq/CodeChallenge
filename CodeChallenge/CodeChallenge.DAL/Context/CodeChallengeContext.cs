using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using CodeChallenge.Common.JsonConverter;
using CodeChallenge.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeChallenge.DAL.Context
{
    public class CodeChallengeContext : DbContext
    {
        public CodeChallengeContext(DbContextOptions options) : base(options) { }

        public DbSet<CodeChallengeUser> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CodeChallengeUserProject> UserProjects { get; set; }

        public async Task DatabaseSetUp()
        {
            if (!AllMigrationsApplied(this))
            {
                await Database.MigrateAsync();
            }

            await DatabaseSeeding(@"./Data/Users.json", Users, this);
            await DatabaseSeeding(@"./Data/Projects.json", Projects, this);
            await DatabaseSeeding(@"./Data/User-projects.json", UserProjects, this);
        }

        public static async Task DatabaseSeeding<T>(string jsonPath, DbSet<T> dbSet, DbContext context) where T : class
        {
            if (!dbSet.Any())
            {
                string source;

                using (var sourceReader = File.OpenText(@jsonPath))
                {
                    source = await sourceReader.ReadToEndAsync();
                }

                var jsonConverter = new JsonConverter();
                var elements = jsonConverter.DeserializeObject<List<T>>(source);

                await dbSet.AddRangeAsync(elements);

                context.SaveChanges();
            }
        }

        public static bool AllMigrationsApplied(DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}
