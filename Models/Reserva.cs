using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaTurismo.Web.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A data da reserva é obrigatória.")]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("PacoteTuristico")]
        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico? PacoteTuristico { get; set; }

        // TAREFA 5: Campo para interface (Opcional para não travar o ModelState)
        [NotMapped]
        public string? NomeCliente { get; set; }

        // Tarefa 4: Delegate e Evento
        public delegate void CapacityReachedHandler(string mensagem);
        public event CapacityReachedHandler? CapacityReached;

        public bool TentarReservar(int totalReservasAtuais)
        {
            if (PacoteTuristico != null && totalReservasAtuais >= PacoteTuristico.CapacidadeMaxima)
            {
                CapacityReached?.Invoke($"ALERTA: Capacidade máxima de {PacoteTuristico.CapacidadeMaxima} vagas atingida!");
                return false;
            }
            return true;
        }
    }
}