using System.ComponentModel.DataAnnotations;

namespace Crud.WebApi.Dto
{
    public class UsuarioDto
    {
        [Required (ErrorMessage = "Campo Name obrigatorio")]
        public string Name {get;set;}
        
        [Required(ErrorMessage = "Campo Email obrigatorio")]
        public string Email {get;set;}
        
        [StringLength (12, MinimumLength = 12 , ErrorMessage = "Phone precisa ter 12 caracteres")]
        public string Phone { get; set; }
    }
}