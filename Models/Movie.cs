﻿using Ecommerce.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class Movie
    {

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
     
        public string Description { get; set; }
        
        public double Price { get; set; }
        
        public string ImageURL { get; set; }
       
        public DateTime StartDate { get; set; }
       
        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //rel
        
        public IEnumerable<Actor_Movie> Actor_Movies { get; set; }

        //cinema
        public int CinemaId { get; set; }
        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; }
        //rel
        public int ProducerId { get; set; }
        [ForeignKey(nameof(ProducerId))]
        public Producer Producer { get; set; }

    }
}
