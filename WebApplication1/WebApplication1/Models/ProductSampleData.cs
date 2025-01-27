namespace WebApplication1.Models
{
    public class ProductSampleData
    {
        public List<Product> v;
        public ProductSampleData()
        {
            v = new List<Product>();
            v.Add(new Product() { Id = 1, Name = "Ahmed",Images = "3eb45ba86fe8377.jpg" });
            v.Add(new Product() { Id = 2, Name = "PATO", Images = "222.png" });
        }

        public Product getid(int id)
        {
            return v.FirstOrDefault(p => p.Id == id);
        }
    }
}
