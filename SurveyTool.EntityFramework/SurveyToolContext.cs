using Microsoft.EntityFrameworkCore;

namespace SurveyTool.EntityFramework
{
    public class SurveyToolContext : DbContext
    {
        public SurveyToolContext(DbContextOptions options) : base(options)
        {
        }

        public SurveyToolContext()
        {
        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionPart> QuestionParts { get; set; }
        public DbSet<SurveyPage> SurveyPages { get; set; }

        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<QuestionPartAnswer> QuestionPartAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .ToTable("Survey")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Survey>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.Survey);
            modelBuilder.Entity<Survey>()
                .HasMany(x => x.Pages);

            modelBuilder.Entity<SurveyPage>()
                .ToTable("SurveyPage")
                .HasKey(x => x.Id);
            modelBuilder.Entity<SurveyPage>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.SurveyPage);

            modelBuilder.Entity<Question>()
                .ToTable("Question")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Question>()
                .HasMany(x => x.Parts)
                .WithOne(x => x.Question);

            modelBuilder.Entity<QuestionPart>()
                .ToTable("QuestionPart")
                .HasKey(x => x.Id);

            modelBuilder.Entity<SurveyAnswer>()
                .ToTable("SurveyAnswer")
                .HasKey(x => x.Id);
            modelBuilder.Entity<SurveyAnswer>()
                .HasMany(x => x.QuestionAnswers)
                .WithOne(x => x.SurveyAnswer);

            modelBuilder.Entity<QuestionAnswer>()
                .ToTable("QuestionAnswer")
                .HasKey(x => x.Id);
            modelBuilder.Entity<QuestionAnswer>()
                .HasOne(x => x.Question)
                .WithMany(x => x.Answers);
            modelBuilder.Entity<QuestionAnswer>()
                .HasMany(x => x.QuestionPartAnswers)
                .WithOne(x => x.QuestionAnswer);

            modelBuilder.Entity<QuestionPartAnswer>()
                .ToTable("QuestionPartAnswer")
                .HasKey(x => x.Id);
            modelBuilder.Entity<QuestionPartAnswer>()
                .HasOne(x => x.QuestionPart)
                .WithMany(x => x.QuestionPartAnswers);
        }
    }
}
