using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Ecommerce.Models
{
    public class Cinema : IRequest<Unit>
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Picture")]
        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
