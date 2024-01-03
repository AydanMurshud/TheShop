namespace DbLayer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public List<Order>? Orders { get; set; } 
        public List<FavoritesList>? Favorites { get; set; } = new List<FavoritesList>();

    }
}
