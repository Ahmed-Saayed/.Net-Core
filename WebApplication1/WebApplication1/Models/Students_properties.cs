namespace WebApplication1.Models

{
    public class Students_properties:IStudents_properties
    {
        Datacon op = new Datacon();
        public List<Students> Get_All() {
            return op.Students.ToList();
        }

        public Students GetByID(int id){
            return op.Students.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Students student) {
            op.Students.Add(student);
            op.SaveChanges();
        }
        public void Update(int id,Students student) {
            Students oldst = GetByID(id);

            oldst.Phone = student.Phone;
            oldst.Name = student.Name;
            oldst.City = student.City;
            oldst.course = student.course;
            oldst.Dep_id = student.Dep_id;

            op.SaveChanges();
        }
        public void Delete(int id)
        {
            op.Students.Remove(GetByID(id));
            op.SaveChanges();
        }
    }
}
