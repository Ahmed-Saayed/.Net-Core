namespace WebApplication1.Models
{                                           // To Make Dependency Inversion Principle  video row 3 last video min 40
    public interface IStudents_properties
    {
        public List<Students> Get_All();
        public Students GetByID(int id);
        public void Insert(Students student);
        public void Update(int id, Students student);
        public void Delete(int id);
    }
}
