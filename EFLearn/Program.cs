using EFLearn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Threading.Tasks.Dataflow;
using static EFLearn.DataCon;

namespace EFLearn
{
    internal class Program
    {
        /*  public static void Openning_Values()
          {
              var con=new DataCon();
              var ok = con.st.FirstOrDefault(p=>p.StudentName=="PATO");

              if (ok == null)
                  con.st.Add(new Student {StudentName="PATO" });

              con.SaveChanges();
          }*/

        static void Main(string[] args)
        {
            var con = new DataCon();
            /*
             // test on Student class!!!
             Openning_Values();  // add the Initial Values

             //Console.WriteLine("=================================================");

             //con.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // to make the tracking off for all queries 
             var checkfortrack = con.st.AsNoTracking().FirstOrDefault(p=>p.StudentName == "PATO");
             checkfortrack.StudentName = "PATO2";

            //============================================================================ Tracking and non tracking


             Console.WriteLine(con.st.Any(x => x.StudentName == "ahmed"));       // return boolean if it match any one
             Console.WriteLine(con.st.All(x => x.StudentName == "ahmed"));   // return boolean if it match all or not

             Console.WriteLine("=================================================");

             var lst2 = con.st.Where(x => x.StudentName == "ahmed").ToList().Append(new Student { StudentName = "SHaco" }); // retrive data then append didnt append in database 
             foreach (var item in lst2)
                 Console.WriteLine(item.StudentName + " ");

             Console.WriteLine("=================================================");

             var lst3 = con.st.OrderByDescending(x => x.StudentID).ThenByDescending(x => x.StudentID).ToList().Prepend(new Student { StudentName = "SHaco" }); // retrive data then appent didint appent in database 
             foreach (var item in lst3)
                 Console.WriteLine(item.StudentName + " ");

             Console.WriteLine("=================================================");

             Console.WriteLine(con.st.Where(x => x.StudentAddress == "Elsadat").Average(x => x.StudentID));

             Console.WriteLine(con.st.Where(x => x.StudentAddress == "Elsadat").Count());

             Console.WriteLine(con.st.Where(x => x.StudentAddress == "Elsadat" && x.StudentID > 1).Sum(x => x.StudentID));

             Console.WriteLine(con.st.Count());

             Console.WriteLine(con.st.Max(x => x.StudentID));

             Console.WriteLine(con.st.Where(x => x.StudentID > 0).Distinct().ToList().Count);

             Console.WriteLine(con.st.Skip(1).Take(1).ToList()[0].StudentName);

            //========================================================================================== Some Extinsion methods

             Console.WriteLine("=================================================");
             var lst4 = con.st.Select(x => new { x.StudentAddress }).Distinct().ToList(); // select return anonomus type single objects ,int,strings,...
             foreach (var i in lst4)
                 Console.WriteLine(i.StudentAddress);

             var stt = new Student
              {
                 //StudentID = 2,
                 StudentName = "SHO",
                 // StudentAddress = "Sadat"   has defualt value
             };

             // con.st.Add(stt);
             // con.st.Add(new Student {StudentName="PATO", StudentAddress="City"});

                var x = con.st.Find(3);         //find on primary key only !!!!
                x.StudentAddress = "Sadat";

             //con.st.FirstOrDefault(x=>x.StudentID==3).StudentName="to";    // find on any thing u want

             */

            //============================================================================================================================
            //============================================================================================================================


            // test on OneToOne class!!!
            // con.Add(new Depatment { DepatmentName = "IT" });
            // con.Add(new Depatment { DepatmentName = "Web" });
            // con.Add(new Person { PersonName = "Ahmed " ,DepID = 3 });
            // con.Add(new Person { PersonName = "PATO ", DepID = 4 });



            //============================================================================================================================
            //============================================================================================================================

            /*
            var mn = con.Authors.Min(o => o.NationalityID);
            var mx = con.Authors.Max(o => o.NationalityID);

            Console.WriteLine(con.Authors.FirstOrDefault(o=>o.NationalityID==mn).AuthName + " " +
                con.Authors.FirstOrDefault(o => o.NationalityID == mx).AuthName);
            */
            //============================================================================ Min and Max 

            // test on OneToMany class!!!


            // con.Authors.Find(1).Books.Add(new Book { Title="Cyper"});

            // var obj2=con.Books.Include(o=>o.Author).FirstOrDefault(x=>x.BookId==1);  // Include to get the data from the other table
            // we can use ThenInclude search for it!!

            //Console.WriteLine(obj2.Author.AuthName);
            // Console.WriteLine(obj2.NationalityID);


            //============================================================================ Includes

            /*
            var lst = new List<Author>
            {
                new Author{ 
                            AuthName="new1",
                            Books=
                            new List<Book>{new Book{ BookTitle="geography"},
                                           new Book{BookTitle="History"}
                            } },

                new Author{
                            AuthName="new2",
                            Books=
                            new List<Book>{new Book{ BookTitle="geography2"},
                                           new Book{BookTitle="History2"}
                            } }

            };

            con.Authors.AddRange(lst);            //  add ranges add lists
            */
            //============================================================================ Add 


            /*var x = new Author { AuthorId = 1, AuthName = "Ahmed2" };       // make null for other nulable field
            con.Update(x);
            con.Entry(x).Property(o => o.NationalityID).IsModified = false; // to prevent the update for this field (to null)

            var lst = con.Authors.Where(o => o.NationalityID == 2);
            foreach (var i in lst)
                i.NationalityID = 1;

            con.UpdateRange(lst);
          
            con.Authors.Where(x => x.NationalityID == 1).ToList().ForEach(x => x.NationalityID = 2);
            con.SaveChanges();

            */

            //con.Authors.Where(x => x.AuthName == "PATO").ExecuteUpdate(x=>x.SetProperty(o=>o.AuthName,"PATO2"));


            //============================================================================ Update 


            //   var x2 = con.Books.Where(o=>o.AuthorId==3);      // Focus pls when remove row of parent table that connect with another table has foriegn key all rows that connect with that row table parent will be deleted if it on cascade ||when make it restrict id gives runtime error if you try to delete parent || when it on SetNull it will set the forign key to null   
            //   con.Books.RemoveRange(x2);                      // if it on restiric and wanna to delete parent row that have child forign keys rows delete first the child then parents 

            //   var x = con.Authors.Find(4);
            //   con.Authors.Remove(x);


            // con.Authors.Where(o=>o.AuthorId ==5).ExecuteDelete();

            //============================================================================ Remove 

            /*
            using var trans =con.Database.BeginTransaction();        // to make transaction
            try
            {
                con.Authors.Add(new Author { AuthName = "PATO" });
                con.SaveChanges();
              
                con.Authors.Add(new Author { AuthorId = 1 });        // somthing invalid   
                con.SaveChanges();
            }
            catch
            {
                trans.Rollback();                       // it back to before tha try
            }

            try
            {
                con.Authors.Add(new Author { AuthName = "PATO1" });
                con.SaveChanges();

                trans.CreateSavepoint("GO here");

                con.Authors.Add(new Author { AuthName = "PATO2" });

                con.Authors.Add(new Author { AuthorId = 1 });        // somthing invalid   
                con.SaveChanges();

                trans.Commit();
            }
            catch(System.Exception)
            {
                trans.RollbackToSavepoint("GO here");                  // it back to this line
                trans.Commit();                                        // execute every line before rollback
            }
          */

            //============================================================================ Transaction 

            /*
            
            var obj = con.Authors.Join(             // join can connect between two tables (with out or with having foreign keys)
                    con.Books,
                    a => a.AuthorId,        // from first table
                    a => a.AuthorId,        // from second table
                    (authobj, bkobj) => new
                    {
                        PersonName = authobj.AuthName,
                        BookName = bkobj.BookTitle,
                        Ay_7aga_34an_aconnect_join_be_join_e3ne_aconnect_tableWithOtherTable = authobj.NationalityID, // any thing just to connect it with another join
                    }
                )

                // use always groupjoin to handle null values
                .GroupJoin(          // this join connects between table Nationalities and anonomus object (join before it)

                    con.Nationalities,
                    a => a.Ay_7aga_34an_aconnect_join_be_join_e3ne_aconnect_tableWithOtherTable,
                    a => a.NationalityId,
                    (anonomusobj, natobj) => new
                    {
                        FirstJoin = anonomusobj,
                        ObjFromNat = natobj
                   }
                )
                .SelectMany(
                    o => o.ObjFromNat.DefaultIfEmpty(),
                    (a, b) => new {a.FirstJoin ,IamObjFromNationality=b }
                );
            
            foreach(var i in obj)
                Console.WriteLine(i.FirstJoin.PersonName + " " + i.FirstJoin.BookName + " " + i.IamObjFromNationality?.NatName);
            */

            //============================================================================ Joins

            con.SaveChanges();
           
           HashSet<int>s=new HashSet<int>();
            s.Add(1);
            s.Add(12);
            s.Remove(s.Min());

            while (s.Count > 0)
                s.Remove(s.Max());

        }
    }
}