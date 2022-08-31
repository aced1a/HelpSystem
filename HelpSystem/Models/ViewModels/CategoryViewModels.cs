namespace HelpSystem.Models.ViewModels
{
    public class CategoryViewModels
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Subcategories { get; set; }
        public Article Article { get; set; }
    }
}
