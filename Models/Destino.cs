using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaTurismo.Web.Models
{
    public class Destino
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        // FK - 1 Destino pertence a 1 Pacote
        [ForeignKey("PacoteTuristico")]
        public int? PacoteTuristicoId { get; set; }
        public PacoteTuristico? PacoteTuristico { get; set; }
    }
}