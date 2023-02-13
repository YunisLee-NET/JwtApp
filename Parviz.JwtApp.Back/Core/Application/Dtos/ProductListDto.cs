namespace Parviz.JwtApp.Back.Core.Application.Dtos
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
