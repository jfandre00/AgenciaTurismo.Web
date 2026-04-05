using System.ComponentModel.DataAnnotations;
using AgenciaTurismo.Web.Validations;

namespace AgenciaTurismo.Web.Models
{
    public class PacoteTuristico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do pacote é obrigatório.")]
        [MinLength(3, ErrorMessage = "O título deve ter pelo menos 3 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, 100, ErrorMessage = "A capacidade deve ser entre 1 e 100 participantes.")]
        public int CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        // Tarefa 6
        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        [DataFutura(ErrorMessage = "A data do pacote deve ser hoje ou no futuro")]
        public DateTime DataInicio { get; set; }

        public List<Destino> Destinos { get; set; } = new List<Destino>();

        public List<Reserva> Reservas { get; set; } = new List<Reserva>();

        // Tarefa 12
        public DateTime? DeletedAt { get; set; }
    }
}