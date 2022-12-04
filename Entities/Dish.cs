namespace WEB_053502_Selhanovich.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public string MimeType { get; set; }
    }
}
