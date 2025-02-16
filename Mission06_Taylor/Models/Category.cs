using System.ComponentModel.DataAnnotations;
namespace Mission06_Taylor.Models;


public class Category
{
    [Key]
    /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
    public int CategoryId { get; set; } // Ensure it's an integer PK

    [Required]
    public string CategoryName { get; set; }
}