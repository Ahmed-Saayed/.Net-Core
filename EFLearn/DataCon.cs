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
// better work with fluent API not Data Annotation
// i can create a table if i make a column that refrence on another table (forigen key)
// change the name of key and make composite keys by using fluent API only
// when HasComputedColumnSql u can not alter in column it add the value automatically u cant add a value
// a foreign key primarily points to a primary key, it can also point to a unique key in another table
// when make forign key with any something not primary key u must make it unique and if u didnt make it unique it automatically be unique after add migration

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

        // test on Student class!!!
        /* public DbSet<Student> st { get; set; }


         // by using fluent API i can alter the table
         protected override void OnModelCreating(ModelBuilder MB) // another way to alter a tables public DbSet<Student> st { get; set; }
         {
             MB.Entity<Student>();                         //===== create table instead of 
             MB.Entity<Student>().ToTable("sstt");         // rename the table
             // MB.Entity<Student>().ToTable("Students", schema: "new schema");      make schema for table
             // MB.HasDefaultSchema("new scema 2");               make defult schema for any table
             // MB.Entity<Student>().ToTable("Studnts", b => b.ExcludeFromMigrations());    remove the table from migration not from data base

             MB.Entity<Student>(op =>
             {
                 op.Property(b => b.StudentID).HasColumnType("int");

                 op.Property(b => b.StudentName).HasColumnType("varchar(300)");

                 op.Property(b => b.StudentAddress).HasMaxLength(100);

                 op.Property(b => b.StudentAddress).IsRequired(false);

                 op.Property(b => b.StudentName).HasColumnName("NAAMEE");

                 op.Property(b => b.StudentAddress).HasComment("Hellow World");

                 op.HasKey(b => b.StudentID).HasName("IDDD__KKEEYY");            // primary key

                // op.HasKey(b => new {b.StudentID,b.StudentName }).HasName("IDDD2__KKEEYY");    composit key search more for it!!

                 op.HasIndex(b => b.StudentName).IsUnique();

                 op.Property(b => b.StudentAddress).HasDefaultValue("Elsadat");

                 op.Property(b => b.Time).HasDefaultValueSql("GETDATE()");       // get the current date and time using mysql commands

                 op.Property(b => b.Dis_Name_Address).HasComputedColumnSql("[NAAMEE] + ' ==== ' + [StudentAddress]");

                 // op.Ignore(b => b.StudentAddress);
             });          

         }*/

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
        }
        */

        //==================================================================================================================

        /*
        // test on one to many

        public DbSet<CarSale> Cars { get; set; }
        public DbSet<Car> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder MB)
        { 
            MB.Entity<Car>(op =>
            {
                op.HasKey(b => b.CarID);
                op.HasIndex(b => b.CarName).IsUnique();
            });
            
            MB.Entity<CarSale>(op =>
            {
                op.HasKey(b => b.SaleID);
                
                op.HasOne(b => b.Carr)
                .WithMany(b => b.CarSale)
                .HasForeignKey(b => b.CN)
                .HasPrincipalKey(b => b.CarName);
            });
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Add ur Connection String :)
        }
    }
}
