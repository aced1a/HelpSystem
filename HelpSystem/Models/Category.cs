using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HelpSystem.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public Article? Article { get; set; }

        [InverseProperty(nameof(Category.Childs))]
        public Category? Parent { get; set; }
        [InverseProperty(nameof(Category.Parent))]
        public IEnumerable<Category> Childs { get; set; }
    }
}
