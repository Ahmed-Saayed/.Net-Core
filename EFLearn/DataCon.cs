using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//One-to-One (1:1): Foreign key can be placed in either one of the tables, or both (though this is less common).
//One - to - Many(1:N): Foreign key is placed in the table on the "many" side of the relationship.
// (For Work on a specific Database)   Scaffold-DbContext "Server=localhost;Database=WORK;Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Cloned_DataBase -Force
// Back to vedio  37!!!!!!!!!!!
// better work with fluent API not Data Annotation
// i can create a table if i make a column that refrence on another table (forigen key)
// change the name of key and make composite keys by using fluent API only
// when HasComputedColumnSql u can not alter in column it add the value automatically u cant add a value
// a foreign key primarily points to a primary key, it can also point to a unique key in another table
// when make forign key with any something not primary key u must make it unique and if u didnt make it unique it automatically be unique after add migration
// Composite keys are used when the combination of two or more columns that didnt appears twice with the same value like if we have (id=1,name ahmed ) we can add (id=1,name mo)oe (id=2,name ahmed) but we cant add (id=1,name ahmed) again
// Join  compines between two tables foiegn key or without forign key must data matches to be connected (id in the first table match id in the second table to return any thing u want)  go to c#Learn Linqtest query1 ;) 
// GroupJoin to if make any prop empty didnt affect and must use it !!
// use always groupjoin to handle null values
// Eager Loading ally ho al Include() to call property from second table using the first table (for sure we using foriegn key)
// Lazy Loading we download a package proxiy and we make all navigations property virtual and dont use Include when use prop from second table from first table
// Focus pls when remove row of parent table that connect with another table has foriegn key all rows that connect with that row table parent will be deleted if it on cascade ||when make it restrict id gives runtime error if you try to delete parent || when it on SetNull it will set the forign key to null
// if it on restiric and wanna to delete parent row that have child forign keys rows delete first the child then parents 
// !!when update back to any migration must make every constraint correct any field non null must have value and etc ...
namespace EFLearn
{
   // [Table("Students",schema = "to")]       ===== give name table 
    public class Student
    {
        // [Key]
        public int StudentID { get; set; }
        // [NotMapped]     // ==== not create column in table
        // [Column("NAAME")]
        // [Column(TypeName="varchar(200)")]
        // [MaxLength(200)]
        // [Comment("Hellow  World")]
        public string StudentName { get; set; }
        public string? StudentAddress { get; set; }    // ? to make it nullable
        public string Dis_Name_Address { get; set; }
        public DateTime Time { get; set; }
    }
        public class DataCon : DbContext
    {

        /*
        // test on Student class!!!
         public DbSet<Student> st { get; set; }


         // by using fluent API i can alter the table
         //protected override void OnModelCreating(ModelBuilder MB) // another way to alter a tables public DbSet<Student> st { get; set; }
         //{
         //    MB.Entity<Student>();                         //===== create table instead of 
         //    MB.Entity<Student>().ToTable("sstt");         // rename the table
         //    // MB.Entity<Student>().ToTable("Students", schema: "new schema");      make schema for table
         //    // MB.HasDefaultSchema("new scema 2");               make defult schema for any table
         //    // MB.Entity<Student>().ToTable("Studnts", b => b.ExcludeFromMigrations());    remove the table from migration not from data base

         //    MB.Entity<Student>(op =>
         //    {
         //        op.Property(b => b.StudentID).HasColumnType("int");

         //        op.Property(b => b.StudentName).HasColumnType("varchar(300)");

         //        op.Property(b => b.StudentAddress).HasMaxLength(100);

         //        op.Property(b => b.StudentAddress).IsRequired(false);

         //        op.Property(b => b.StudentName).HasColumnName("NAAMEE");

         //        op.Property(b => b.StudentAddress).HasComment("Hellow World");

         //        op.HasKey(b => b.StudentID).HasName("IDDD__KKEEYY");            // primary key

         //       // op.HasKey(b => new {b.StudentID,b.StudentName }).HasName("IDDD2__KKEEYY");    composit key search more for it!!

         //        op.HasIndex(b => b.StudentName).IsUnique().HasFilter(null).HasDatabaseName("Name OF Index");

         //        op.Property(b => b.StudentAddress).HasDefaultValue("Elsadat");

         //        op.Property(b => b.Time).HasDefaultValueSql("GETDATE()");       // get the current date and time using mysql commands

         //        op.Property(b => b.Dis_Name_Address).HasComputedColumnSql("[NAAMEE] + ' === ' + [StudentAddress]");

         //        // op.Ignore(b => b.StudentAddress);
         //    });          
         //}
        */
        //==================================================================================================================

        /* 
         // test on OneToOne class!!!!
         public DbSet<Person> Person { get; set; }
         public DbSet<Depatment> Depatments { get; set; }

         protected override void OnModelCreating(ModelBuilder MB)
         {
             MB.Entity<Person>(op =>
             {
                 op.HasKey(b => b.PersonID);
             });

             MB.Entity<Depatment>(op =>
             {
                 op.HasKey(b => b.DepatmentID);

                 op.HasIndex(b => b.DepatmentName).IsUnique();

                 op.HasOne(b => b.Personn)
                 .WithOne(b => b.Depatmentt)
                 .HasForeignKey<Person>(b => b.DepID)
                 .HasPrincipalKey<Depatment>(b => b.DepatmentID);
             });
         }*/


        //==================================================================================================================
/*
        // test on one to many
        public class Author
        {
            public int AuthorId { get; set; } 
            public string AuthName { get; set; }
            public virtual List<Book> Books { get; set; } = new List<Book>();

            public int? NationalityID { get; set; }
            public virtual Nationality Nationality { get; set; }
        }

        public class Book
        {
            public int BookId { get; set; } // Primary Key
            public string BookTitle { get; set; }
            public int? AuthorId { get; set; }
            public virtual Author Author { get; set; }
        }

        public class Nationality
        {
            public int NationalityId { get; set; }
            public string NatName { get; set; }
            public virtual List<Author> Author { get; set; } = new List<Author>();

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Nationality>Nationalities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(op =>
         {
             op.HasOne(a => a.Author)
             .WithMany(a => a.Books)
             .HasForeignKey(b => b.AuthorId)     // in book table
             .HasPrincipalKey(a => a.AuthorId);  // in author table

             op.HasOne(a => a.Author)
             .WithMany(a => a.Books)
             .OnDelete(DeleteBehavior.Restrict);
         });



            modelBuilder.Entity<Author>(op =>
            {
                op.Property(a=>a.NationalityID).IsRequired(false);
              //  op.HasQueryFilter(a => a.NationalityID != 2);             filter lime a make where(x=>x....)

                op.HasOne(a => a.Nationality)
                .WithMany(a => a.Author)
                .HasForeignKey(a => a.NationalityID)   // in author table
                .HasPrincipalKey(a => a.NationalityId); // in nationalty table
            });
          
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer();
        }
    }
}
