namespace Commerce.Products.Infrastructure.Configurations
{
    public class RabbitMqConfiguration
    {
        public string? HostName { get; set; }
        public string? UserName { get; set; }
        public int? Port { get; set; }
        public string? Password { get; set; }
        public Exchanges? Exchanges { get; set; }
    }

    public class Exchanges
    {
        public string? ProductEvents { get; set; }
    }
}
