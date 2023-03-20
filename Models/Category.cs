using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvcProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Number Of Books")]
        public int NumOfBooks { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [Required]
        public string? Name { get; set; }

    }
}
