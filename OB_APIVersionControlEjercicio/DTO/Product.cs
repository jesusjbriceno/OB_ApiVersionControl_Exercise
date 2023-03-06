namespace OB_APIVersionControlEjercicio.DTO
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public float price { get; set; }
        public string description { get; set; } = string.Empty;
        public string category { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
    }

    public class Product_v1 : Product
    {
        public Rating_v1 rating { get; set; } = new Rating_v1();
    }

    public class Product_v2 : Product
    {
        public Guid InternalId { get; set; }
    }
}
