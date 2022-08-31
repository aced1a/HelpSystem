using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpSystem.Models
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Body { get; set; }
       
        public Category Category { get; set; }
        public int CategoryId { get; set; }


        //public User Author { get; set; }
    }
}
