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
    /// Подразделение
    /// </summary>
    [DisplayName("Подразделение")]
    public class Department
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Подразделение")]
        public string Name { get; set; }
    }
}