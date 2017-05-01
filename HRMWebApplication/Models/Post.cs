using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMWebApplication.Models
{
    /// <summary>
    /// Должность сотрудника
    /// </summary>
    [DisplayName("Должность")]
    public class Post
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Должность")]
        public string Name { get; set; }
        [DisplayName("Зарплата")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
    }
}