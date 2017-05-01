using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMWebApplication.Models
{
    public enum UserRole { Специалист, Администратор }

    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        [Required]
        [Display(Name = "Пользователь")]
        [Key]
        [StringLength(20)]
        public string UserName { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Display(Name = "Роль")]
        public UserRole UserRole { get; set; }
    }
}