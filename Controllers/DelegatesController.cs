using AgenciaTurismo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace AgenciaTurismo.Web.Controllers
{
    public delegate decimal CalculateDelegate(decimal preco);

    public class DelegatesController : Controller
    {
        // TAREFA 1
        [HttpGet]
        public IActionResult Desconto() { return View(); }

        [HttpPost]
        public IActionResult Desconto(decimal precoEntrada)
        {
            CalculateDelegate aplicarDesconto = valor => valor - (valor * 0.10m);
            ViewBag.PrecoOriginal = precoEntrada;
            ViewBag.PrecoComDesconto = aplicarDesconto(precoEntrada);
            return View();
        }


        // TAREFA 2

        private static List<string> _memoryLogs = new List<string>();

        // Método 1: Escreve no console de depuração do Visual Studio
        private void LogToConsole(string mensagem)
        {
            Console.WriteLine($"[CONSOLE LOG]: {mensagem}");
        }

        // Método 2: Escreve em um arquivo de texto .txt
        private void LogToFile(string mensagem)
        {
            string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs_sistema.txt");
            System.IO.File.AppendAllText(caminhoArquivo, $"[FILE LOG] {DateTime.Now}: {mensagem}\n");
        }

        // Método 3: Guarda na lista em memória
        private void LogToMemory(string mensagem)
        {
            _memoryLogs.Add($"[MEMORY LOG]: {mensagem}");
        }

        // Action que vai simular a criação da reserva e acionar o Multicast Delegate
        [HttpGet]
        public IActionResult SimularReservaLog()
        {
            Action<string> loggerMultiplo = LogToConsole;

            loggerMultiplo += LogToFile;
            loggerMultiplo += LogToMemory;

            string mensagemAcao = "Nova reserva criada para o cliente André no pacote de NYC.";

            // Rodará tudo de uma vez
            loggerMultiplo(mensagemAcao);

            ViewBag.MensagemOriginal = mensagemAcao;
            ViewBag.LogsMemoria = _memoryLogs;

            return View();
        }

        // TAREFA 3 

        [HttpGet]
        public IActionResult SimularValorReserva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SimularValorReserva(int quantidadeParticipantes, decimal precoPacote)
        {
            // A. DECLARAÇÃO DO FUNC COM EXPRESSÃO LAMBDA
            Func<int, decimal, decimal> calcularTotal = (qtd, preco) => qtd * preco;

            // B. EXECUÇÃO DO FUNC
            decimal valorFinal = calcularTotal(quantidadeParticipantes, precoPacote);

            // C. ENVIANDO RESULTADOS P/ TELA
            ViewBag.Quantidade = quantidadeParticipantes;
            ViewBag.PrecoPacote = precoPacote;
            ViewBag.ValorFinal = valorFinal;

            return View();
        }

        // TAREFA 4

        [HttpGet]
        public IActionResult AlertaCapacidade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AlertaCapacidade(int capacidadeMaxima, int reservasAtuais)
        {
            // Vamos simular a lógica na memória
            var pacoteSimulado = new PacoteTuristico
            {
                Titulo = "Viagem para o Rio de Janeiro",
                CapacidadeMaxima = capacidadeMaxima
            };

            var novaReserva = new Reserva
            {
                PacoteTuristico = pacoteSimulado
            };

            string alertaCapturado = null;

            // INSCRIÇÃO NO EVENTO
            novaReserva.CapacityReached += (mensagem) =>
            {
                Console.WriteLine($"[EVENTO DISPARADO]: {mensagem}");

                alertaCapturado = mensagem;
            };

            bool sucesso = novaReserva.TentarReservar(reservasAtuais);

            // Enviando para a tela!
            ViewBag.Sucesso = sucesso;
            ViewBag.AlertaCapturado = alertaCapturado;
            ViewBag.Pacote = pacoteSimulado.Titulo;
            ViewBag.Capacidade = capacidadeMaxima;
            ViewBag.Atuais = reservasAtuais;

            return View();
        }
    }
}