using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogit.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Teaser { get; set; }
        [Required]
        public string Body { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }
        [Required]
        public bool Public { get; set; }

        public string OwnerId { get; set; } //Guid

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }
    }
}