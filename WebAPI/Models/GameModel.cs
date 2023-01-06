namespace WebAPI.Models
{
    public class GameModel
    {
        public int GID { get; set; }
        public int PID { get; set; }    
        public Byte Score { get; set; }
        public Boolean Team { get; set; }
        public string? Player { get; set; }
        public Decimal Age { get; set; }
        public string? Sex { get; set; }
    }
}
