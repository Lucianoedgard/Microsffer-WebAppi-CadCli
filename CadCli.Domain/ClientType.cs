using System;
using System.ComponentModel.DataAnnotations;

namespace CadCli.Domain
{
    public class ClientType
    {
        public ClientType()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "Código")]
        public string Code { get; set; }
        [Display(Name ="Descrição")]
        public string Description { get; set; }
        [Display(Name ="Ativo")]
        public bool IsActive { get; set; }
        [Display(Name ="Data de criação")]
        public DateTime CreationDate { get; set; }
    }
}
