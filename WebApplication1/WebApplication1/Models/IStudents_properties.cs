namespace WebApplication1.Models
{                                           
    public interface IStudents_properties
    {
        public List<Students> Get_All();
        public Students GetByID(int id);
        public void Insert(Students student);
        public void Update(int id, Students student);
        public void Delete(int id);
    }
}
