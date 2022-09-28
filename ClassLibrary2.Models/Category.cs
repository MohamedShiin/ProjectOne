using System.ComponentModel.DataAnnotations;

namespace ClassLibrary2.Models;

public class category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100 ")]
    public int DisplyOrger { get; set; }
    public DateTime CteatingDate { get; set; } = DateTime.Now;
}

