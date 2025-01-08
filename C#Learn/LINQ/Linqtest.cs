using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace C_Learn.LINQ
{
    public class Linqtest
    {
        // Linq extends Inumerable do any method in Inumerable
        //The first LINQ query(res) is deferred and re-evaluated each time it is enumerated(make for loop), meaning it reflects the current state of arr.
        //The second LINQ query (res2) is executed immediately and stored as a static list, which does not change even if arr is updated later.
        public void DO()    // Try DO2
        {
            var arr = new List<int>{ 1, 2, 3, 4, 5, 6, 7 };
            var res = from i in arr where i > 3 select i;

            // or res = arr.Where(i => i > 3);  // you can put Tolist()
            res = arr.Where(i => i > 3).OrderByDescending(i => i);        // and check for more functions
            
            foreach(var i in res)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------");
            arr.AddRange(new[] { 20, 21});
            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
            // we must convert it to array or list

            Console.WriteLine("--------------");
            var res2 = (from i in arr where i > 3 select i).ToList();
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------");
            arr.AddRange(new[] { 20, 40 });
            foreach (var i in res2)
            {
                Console.WriteLine(i);
            }

        }
        //========================================================
        public void DO2()   //check DO3()  XD
        {
            var arr = new List<Emploees>
            {
                new("ahmed",3,2),
                new("ahmed",1,2),
                new("uouo",1,2)
            };

            var query = arr.OrderBy(x => x.name).OrderBy(x=>x.age).ToList(); // it sorts by name and finally sort by age only we must use ThenBy
            var query2 = arr.OrderBy(x => x.name).ThenBy(x=>x.age).Reverse().ToList();
            var query3 = arr.OrderBy(x => x.name).ThenBy(x => x.age).Reverse().Select(x => new {x.name,x.age });
            

            foreach (var i in query2)
                Console.WriteLine(i.name+"  " + i.age+ "  "+i.salaly);

            foreach (var i in query3)
                Console.WriteLine(i.name + "  " + i.age);       // cant acceess the salary becuse select above
        }

        public void DO3()   // GO to DO4 and its Last
        {                                                       // search by (by) like a DistinctBy , UnionBy ,ExceptBy ...
            var arr = new List<int> { 1, 2, 3, 4, 4, 5, 6 };  // all this next function walk linear from begining and take until condition matches
            var query1 = arr.All(x => x != 0);
            var query2 = arr.Any(x => x == 0);
            var query3 = arr.Contains(5);
            var query4 = arr.Skip(2).Take(3);     // skip first n element // take first n 3 element 
            var query5 = arr.TakeWhile(x => x <4);
            var query6 = arr.SkipWhile(x => x < 4);
            var query7 = arr.Chunk(3);
            var query8 = arr.Order().Distinct();
            var o = new List<int> { 2, 3, 4 };   var query9 = arr.Except(o);        // Intersect  get the only in this passed list (o) //Union get all 2 list 
            //var res2 = arr.Any(); emplt function means return (arr.size())


            Console.WriteLine(query1);
            Console.WriteLine(query2);
            Console.WriteLine(query3);

            foreach (var i in query4)
                Console.WriteLine(i);

            Console.WriteLine();

            foreach (var i in query5)
                Console.WriteLine(i);

            Console.WriteLine();

            foreach (var i in query6)
                Console.WriteLine(i);

            Console.WriteLine();

            foreach (var i in query7)
            {
                foreach (var j in i)
                {
                    Console.Write(j+ " ");
                }
                Console.WriteLine("---------");
            }

            Console.WriteLine();

            foreach (var i in query8)
                Console.WriteLine(i);

            Console.WriteLine();

            foreach (var i in query9)
                Console.Write(i+" ");

        }


        public void DO4()
        {
            var dp = new List<Department>
            {
                new Department{Name="WEB" ,IdDP=1},
                new Department{Name="Cyper Sec" ,IdDP=2},
                new Department{Name="Database" ,IdDP=3}
            };
            var st = new List<Student>
            {
                new("Ahmed", 1, 21),
                new("PATO", 2, 22),
                new("EZZO", 3, 23),
                new("Hoda", 3, 23),
                new("TOTA", 1, 23),
                new("TETE", 2, 23),
            };

            st.Add(new("MOs", 4, 21));

            var query1 = st.Join(dp, p => p.IdSt, g => g.IdDP, (x, y) => new{ STUname=x.Name, DEPname =y.Name });    //in last parametar is function with parametars(studet,depart) and return any thing what u want 
            var query2 = st.GroupBy(stuuu => stuuu.IdSt);

            var query3 = from Student in st
                         join Department in dp on Student.IdSt equals Department.IdDP
                         group Student by Department.Name;
                                                                     

            foreach (var i in query1)
                Console.WriteLine(i.STUname + " " + i.DEPname);

            Console.WriteLine();

            foreach(var i in query2)
            {
                var tmp = string.Join(",", i.Select(x => x.Name).ToArray());
                Console.WriteLine($"Group {i.Key } : {tmp}");
            }
            Console.WriteLine();
            foreach (var i in query3)
            {
                var tmp = string.Join(",", i.Select(x => x.Name).ToArray());
                Console.WriteLine($"{i.Key} : {tmp}");
            }
        }
    }



    internal class Department
    {
          public Department() { }
          public int IdDP { get; set; }
          public string Name { get; set; }
    }


    internal class Student
    {
        public Student(string name,int id,int age)
        {
            this.Name = name;
            IdSt = id;
            Age= age;
        }
        public int IdSt { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


    internal class Emploees
        {
            public string name { get; set; }
            public int age { get; set; }
            public int salaly { get; set; }
            public Emploees(string nn,int ag,int sa)
            {
                  name = nn; age = ag; salaly = sa;
            }
        }
}
