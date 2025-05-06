using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Grupo: Eduardo Paes, Giovanna de Melo, Mariana ALves

namespace APS
{
    // Classe responsável pela triagem
    class Triagem
    {
        public static string DefinirPrioridade(double pressao, double temperatura, double oxigenacao)
        {
            if (pressao > 18 || temperatura > 39 || oxigenacao < 90)
                return "Vermelha";
            else if (pressao > 14 || temperatura > 37.5 || oxigenacao < 95)
                return "Amarela";
            else
                return "Verde";
        }
    }

    // Classe Paciente
    class Paciente
    {
        public string Nome { get; set; }
        public double Pressao { get; set; }
        public double Temperatura { get; set; }
        public double Oxigenacao { get; set; }
        public string Prioridade { get; private set; }

        public Paciente(string nome, double pressao, double temperatura, double oxigenacao)
        {
            Nome = nome;
            Pressao = pressao;
            Temperatura = temperatura;
            Oxigenacao = oxigenacao;
            Prioridade = Triagem.DefinirPrioridade(pressao, temperatura, oxigenacao);
        }

        public void ImprimirInfo()
        {
            switch (Prioridade)
            {
                case "Vermelha":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Amarela":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Verde":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine($"{Nome} | PA: {Pressao} | Temp: {Temperatura}°C | O2: {Oxigenacao}% | Prioridade: {Prioridade}");
            Console.ResetColor();
        }

        public override string ToString()
        {
            return $"{Nome} | PA: {Pressao} | Temp: {Temperatura}°C | O2: {Oxigenacao}% | Prioridade: {Prioridade}";
        }
    }

    // Sistema de Atendimento
    class SistemaAtendimento
    {
        private Queue<Paciente> filaTriagem = new Queue<Paciente>();
        private Queue<Paciente> filaVermelha = new Queue<Paciente>();
        private Queue<Paciente> filaAmarela = new Queue<Paciente>();
        private Queue<Paciente> filaVerde = new Queue<Paciente>();
        private Stack<Paciente> historico = new Stack<Paciente>();

        public void ChegadaPaciente(Paciente paciente)
        {
            Console.WriteLine($"Paciente chegou: {paciente.Nome}");
            filaTriagem.Enqueue(paciente);
        }

        public void RealizarTriagem()
        {
            Console.WriteLine("\n--- Triagem ---");
            while (filaTriagem.Count > 0)
            {
                Paciente paciente = filaTriagem.Dequeue();
                paciente.ImprimirInfo();

                switch (paciente.Prioridade)
                {
                    case "Vermelha":
                        filaVermelha.Enqueue(paciente);
                        break;
                    case "Amarela":
                        filaAmarela.Enqueue(paciente);
                        break;
                    case "Verde":
                        filaVerde.Enqueue(paciente);
                        break;
                }
            }
        }

        public void AtenderPacientes()
        {
            Console.WriteLine("\n--- Atendimento Clínico ---");
            AtenderFila(filaVermelha);
            AtenderFila(filaAmarela);
            AtenderFila(filaVerde);
        }

        private void AtenderFila(Queue<Paciente> fila)
        {
            while (fila.Count > 0)
            {
                Paciente paciente = fila.Dequeue();
                Console.Write("Atendendo: ");
                paciente.ImprimirInfo();
                historico.Push(paciente);
            }
        }

        public void MostrarHistorico()
        {
            Console.WriteLine("\n--- Histórico de Atendimentos ---");
            while (historico.Count > 0)
            {
                Paciente paciente = historico.Pop();
                Console.WriteLine($"{paciente.Nome} foi atendido - Prioridade: {paciente.Prioridade}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SistemaAtendimento sistema = new SistemaAtendimento();

            Console.WriteLine("=== SIMULAÇÃO DE ATENDIMENTO MÉDICO ===");

            Console.Write("Quantos pacientes deseja cadastrar? ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0)
            {
                Console.Write("Digite um número válido: ");
            }

            for (int i = 1; i <= quantidade; i++)
            {
                Console.WriteLine($"\n--- Cadastro do {i}º paciente ---");

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Pressão arterial (ex: 18.5): ");
                double pressao = LerDouble();

                Console.Write("Temperatura corporal (°C): ");
                double temperatura = LerDouble();

                Console.Write("Nível de oxigenação (%): ");
                double oxigenacao = LerDouble();

                Paciente paciente = new Paciente(nome, pressao, temperatura, oxigenacao);
                sistema.ChegadaPaciente(paciente);
            }

            sistema.RealizarTriagem();
            sistema.AtenderPacientes();
            sistema.MostrarHistorico();

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        static double LerDouble()
        {
            double valor;
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Digite um número: ");
            }
            return valor;
        }
    }
}

