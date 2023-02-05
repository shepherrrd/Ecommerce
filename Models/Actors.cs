using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Actors
    {
        [Key]
        public int Id { get; set; }
        [Display (Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "FullName")]

        public string FullName { get; set; }
        [Display(Name = "Bio")]

        public string Bio { get; set;}

        //rel
        public IEnumerable<Actor_Movie> Actor_Movies { get; set; }

    }
}
