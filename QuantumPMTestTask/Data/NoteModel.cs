using System.ComponentModel.DataAnnotations;

namespace QuantumPMTestTask.Data
{
    public class NoteModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NoteTitle { get; set; }
        [Required]
        public string NoteText { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
