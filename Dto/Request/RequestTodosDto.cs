using System.ComponentModel.DataAnnotations;

namespace server_to_do.Dto.Request
{
    public class RequestTodosDto
    {
        [Required]
        [System.ComponentModel.DefaultValue(null)]
        public string Title {  get; set; }
        [System.ComponentModel.DefaultValue(null)]
        public string? Description { get; set; }
        public DateTime DueDate{ get; set; }
        [System.ComponentModel.DefaultValue(false)]
        public bool IsCompleted {  get; set; }
        public DateTime? Reminder {  get; set; }
    }
}
