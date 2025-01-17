using System;

namespace EFLearn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var con = new DataCon();


            // test on Student class!!!
            /* var stt = new Student
            {
                //StudentID = 2,
                StudentName = "SHO",
                // StudentAddress = "Sadat"   has defualt value
            };
            
            con.st.Add(stt);
            con.st.Add(new Student {StudentName="PATO", StudentAddress="City"});
          
            var x = con.st.Find(3);         //find on primary key only !!!!
            x.StudentAddress = "Sadat";
            
            //con.st.FirstOrDefault(x=>x.StudentID==3).StudentName="to";    // find on any thing u want
            */


           /*
           // test on OneToOne class!!!
           // con.Add(new Depatment { DepatmentName = "IT" });
           // con.Add(new Depatment { DepatmentName = "Web" });
           // con.Add(new Person { PersonName = "Ahmed " ,DepID = 3 });
           // con.Add(new Person { PersonName = "PATO ", DepID = 4 });
           */
            
            /*
            // test on OneToMany class!!!
            con.Add(new Car {CarName ="Tyota" });
            con.Add(new Car { CarName = "Honda" });
            con.Add(new CarSale { SaleName = "Ahmed", CN = "Tyota" });
            con.Add(new CarSale { SaleName = "Ahmed", CN = "Honda" });
            */

            con.SaveChanges();

        }
    }
}