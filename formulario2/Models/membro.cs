using System.ComponentModel.DataAnnotations;

namespace formulario2.Models
{
    public class membro
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string UltimoNome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Endereco2 { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Est { get; set; }
        [Required]
        public int Postal { get; set; }
    }
}
