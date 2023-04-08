using Ecommerce.Data.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data.ViewModel
{
    public class MovieVM  : IRequest<Unit>
    {
        public int Id { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]

        public string Description { get; set; }

        [Display(Name = "Price")]

        public double Price { get; set; }
        [Display(Name="Movie Image Url")]

        public string ImageURL { get; set; }

        [Display(Name="StartDate ")]

        public DateTime StartDate { get; set; }

        [Display(Name = "EndDate ")]

        public DateTime EndDate { get; set; }

        [Display(Name = "Select A Category")]

        public MovieCategory MovieCategory { get; set; }

        //rel
        [Display(Name="Select Actor(s)")]

        public IEnumerable<int> ActorIds { get; set; }

        //cinema
        [Display(Name = "Select Cinema(s)")]

        public int CinemaId { get; set; }

        //rel

         [Display(Name = "Select Producer(s)")]


        public int ProducerId { get; set; }
        

    }
}
