using Microsoft.EntityFrameworkCore;

namespace Students.Model.Models
{
    public partial class StudentsContext : DbContext
    {
        public StudentsContext()
        {
        }

        public StudentsContext(DbContextOptions<StudentsContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBEntities");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Student_ID).HasName("PK_Student");
                entity.ToTable("Student");
                entity.Property(e => e.Student_ID).HasColumnName("Student_ID");
                entity.Property(e => e.Student_Name).HasColumnName("Student_Name").HasMaxLength(250);
                entity.Property(e => e.Student_Address).HasColumnName("Student_Address").HasMaxLength(250);
                entity.Property(e => e.Student_BirthDate).HasColumnName("Student_BirthDate");
                entity.Property(e => e.Student_EmailAddress).HasColumnName("Student_EmailAddress").HasMaxLength(250);
                entity.HasOne(e => e.StudentClass)
            .WithMany(p => p.Students)
            .HasForeignKey(e => e.StudentClass_ID)
            .HasConstraintName("FK_Student_StudentClass");
            });
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Subject_ID).HasName("PK_Subject");
                entity.ToTable("Subject");
                entity.Property(e => e.Subject_ID).HasColumnName("Subject_ID");
                entity.Property(e => e.Subject_Name).HasColumnName("Subject_Name").HasMaxLength(250);
            });
            modelBuilder.Entity<StudentSubject>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_StudentSubject");
                entity.ToTable("StudentSubject");
                entity.Property(e => e.Student_ID).HasColumnName("Student_ID");
                entity.Property(e => e.Subject_ID).HasColumnName("Subject_ID");
                entity.HasOne(e => e.Student)
            .WithMany(p => p.StudentSubjects)
            .HasForeignKey(e => e.Student_ID)
            .HasConstraintName("FK_StudentSubject_Student");
                entity.HasOne(e => e.Subject)
            .WithMany(p => p.StudentSubjects)
            .HasForeignKey(e => e.Subject_ID)
            .HasConstraintName("FK_StudentSubject_Subject");
            });
            modelBuilder.Entity<StudentClass>(entity =>
            {
                entity.HasKey(e => e.StudentClass_ID).HasName("PK_StudentClass");
                entity.ToTable("StudentClass");
                entity.Property(e => e.StudentClass_ID).HasColumnName("StudentClass_ID");
                entity.Property(e => e.StudentClass_Name).HasColumnName("StudentClass_Name").HasMaxLength(250);
            });
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
