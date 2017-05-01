using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMWebApplication.Models
{
    public enum OrderState { Отсутствует, Подписан };

    /// <summary>
    /// Договор с сотрудником
    /// </summary>
    [DisplayName("Договор")]
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("DepartmentID")]
        [DisplayName("Подразделение")]
        public virtual Department Department { get; set; }
        [DisplayName("Подразделение")]
        public int DepartmentID { get; set; }
        [ForeignKey("EmployeeID")]
        [DisplayName("Сотрудник")]
        public virtual Employee Employee { get; set; }
        [DisplayName("Сотрудник")]
        public int EmployeeID { get; set; }
        [ForeignKey("PostID")]
        [DisplayName("Должность")]
        public virtual Post Post { get; set; }
        [DisplayName("Должность")]
        public int PostID { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Текст договора")]
        [Required]
        public string ContractText { get; set; }
        [DisplayName("Состояние приказа")]
        [Required]
        public OrderState OrderState { get; set; }
        [Column(TypeName = "ntext")]
        [DisplayName("Текст приказа")]
        [Required]
        public string OrderText { get; set; }
    }
}