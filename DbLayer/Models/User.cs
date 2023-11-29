namespace DbLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public List<FavoritesList> Favorites { get; set; } = new List<FavoritesList>();
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
