namespace Parviz.JwtApp.Back.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
        //public Category(List<Product> products)
        //{
        //    Products = products;
        //}
    }
}
