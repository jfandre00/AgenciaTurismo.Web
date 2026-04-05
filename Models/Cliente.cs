using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgenciaTurismo.Web.Models
{
    public class Cliente
    {
        [Key] // PK
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        // Um Cliente tem VÁRIAS Reservas
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}