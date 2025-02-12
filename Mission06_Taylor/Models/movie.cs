namespace Mission06_Taylor.Models;

using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key] // Marks this as the primary key
    public int Id { get; set; } // Auto-incrementing primary key

    [Required]
    public string Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [Range(1888, 2100, ErrorMessage = "Enter a valid year.")]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Rating { get; set; }

    public bool Edited { get; set; } = false; // Store as boolean

    public string? LentTo { get; set; } // Nullable

    [MaxLength(25, ErrorMessage = "Notes limited to 25 characters.")] // ✅ Limit Notes
    public string? Notes { get; set; }
}