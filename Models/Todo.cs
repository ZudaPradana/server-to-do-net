using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server_to_do.Models
{
    [Table("todos")]
    public class Todo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("duedate")]
        public DateTime DueDate { get; set; }
        [Column("iscompleted")]
        public bool IsCompleted { get; set; } = false;
        [Column("reminder")]
        public DateTime? Reminder { get; set; }
    }
}
