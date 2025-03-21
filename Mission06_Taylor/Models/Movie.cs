using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Taylor.Models;

using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    // Add this property to display Category Name
    

    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, 2100, ErrorMessage = "Enter a valid year.")]
    public int Year { get; set; }
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    public bool Edited { get; set; } = false;

    public string? LentTo { get; set; }

    [Required] 
    public bool CopiedToPlex { get; set; } = false;

    [MaxLength(25)]
    public string? Notes { get; set; }
}
