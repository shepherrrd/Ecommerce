using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Producer : IRequest<Unit>
    {
        # nullable disable
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "FullName")]

        public string FullName { get; set; }
        [Display(Name = "Bio")]

        public string Bio { get; set; }


        public IEnumerable<Movie> Movies { get; set; }
    }
}
