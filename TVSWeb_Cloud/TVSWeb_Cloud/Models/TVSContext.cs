using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public class TVSContext : DbContext
    {
        public DbSet<TypeOfQuestion> TypeOfQuestions { get; set; }

        public DbSet<Question> Questions { get; set; }
        public TVSContext()
            :base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeOfQuestion>().HasKey(t => t.TypeID);
            modelBuilder.Entity<Question>().HasKey(q => q.QuestionID);

            modelBuilder.Entity<TypeOfQuestion>().HasMany(t => t.Questions).WithRequired(q => q.Type).HasForeignKey(q => q.TypeID);
            base.OnModelCreating(modelBuilder);
        }
    }
}