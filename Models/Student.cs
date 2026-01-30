using System.ComponentModel.DataAnnotations;

namespace FaceRecognition.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Имя обязательно")]
        [StringLength(50, ErrorMessage="Имя не должно превышать 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z\s]+$", ErrorMessage = "Имя может содержать только буквы")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Фамилия обязательна")]
        [StringLength(50, ErrorMessage = "Фамилия не должно превышать 50 символов")]
        [RegularExpression(@"^[а-яА-ЯёЁa-zA-Z\s]+$", ErrorMessage = "Фамилия может содержать только буквы")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Название группы обязательно")]
        [StringLength(20, ErrorMessage = "Название группы не должно превышать 20 символов")]
        public string GroupName { get; set; } = string.Empty;

        public byte[]? Photo { get; set; }

        public float[]? FaceEmbedding { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public string FullName => $"{LastName} {FirstName}";


    }
}
