using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IA_lab6.Models
{
    public class Song
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(100, ErrorMessage = "Maximal length of the name of a song is 100 characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Artist is required!")]
        [StringLength(100, ErrorMessage = "Maximal length of the artist name of a song is 100 characters!")]
        public string Artist { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public int Id { get; set; }

        public Genre genre { get; set; }
    }
}