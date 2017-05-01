using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMWebApplication.Models
{
    public enum Gender { М, Ж }

    /// <summary>
    /// Сотрудник
    /// </summary>
    [DisplayName("Сотрудник")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Табельный номер")]
        public int ID { get; set; }
        [DisplayName("Пол")]
        [Required]
        public Gender Gender { get; set; }
        [DisplayName("ФИО")]
        [Required]
        public string FullName { get; set; }
        [DisplayName("Дата рождения")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [DisplayName("Место рождения")]
        public string BirthPlace { get; set; }
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [DisplayName("Номер телефона")]
        [MaxLength(16, ErrorMessage = "максимум 16 символов"), MinLength(11, ErrorMessage = "минимум 11 символов")]
        [RegularExpression(@"^\+(\d+)[ ]?\(?([0-9]{3})\)?[ .-]?(\d{3})[ .-]?(\d{2})[ .-]?(\d{2})$", ErrorMessage = "Номер телефона должен иметь формат вида +7(123)4567890")]
        public string PhoneNumber { get; set; }
        [DisplayName("Паспортные данные")]
        public string PassportDetails { get; set; }
        [DisplayName("Удалено")]
        public bool IsDeleted { get; set; }
    }
}