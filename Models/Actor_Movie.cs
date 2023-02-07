namespace Ecommerce.Models
{
    public class Actor_Movie
    {
#nullable disable
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actors Actors { get; set; }
    }
}
