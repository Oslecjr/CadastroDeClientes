using System;
using System.Collections.Generic;

namespace CadastroDeClientes
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Sistema de Cadastro de Clientes");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Visualizar Clientes");
                Console.WriteLine("3. Editar Cliente");
                Console.WriteLine("4. Excluir Cliente");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            } while (opcao != 5);
        }

        static void AdicionarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Id = idCounter++;
            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Telefone: ");
            cliente.Telefone = Console.ReadLine();
            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com sucesso!");
            Console.ReadKey();
        }

        static void VisualizarClientes()
        {
            Console.WriteLine("Lista de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}");
            }
            Console.ReadKey();
        }

        static void EditarCliente()
        {
            VisualizarClientes(); // Exibe a lista de clientes antes de solicitar o ID
            Console.Write("Digite o ID do cliente que deseja editar: ");
            int id;
            bool idValido = int.TryParse(Console.ReadLine(), out id);
            if (!idValido)
            {
                Console.WriteLine("ID inválido! Por favor, insira um número válido.");
                Console.ReadKey();
                return;
            }

            Cliente cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                Console.Write("Novo Nome (deixe em branco para manter o atual): ");
                string novoNome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoNome))
                {
                    cliente.Nome = novoNome;
                }

                Console.Write("Novo Email (deixe em branco para manter o atual): ");
                string novoEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoEmail))
                {
                    cliente.Email = novoEmail;
                }

                Console.Write("Novo Telefone (deixe em branco para manter o atual): ");
                string novoTelefone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(novoTelefone))
                {
                    cliente.Telefone = novoTelefone;
                }

                Console.WriteLine("Cliente editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
            Console.ReadKey();
        }

        static void ExcluirCliente()
        {
            VisualizarClientes(); // Exibe a lista de clientes antes de solicitar o ID
            Console.Write("Digite o ID do cliente que deseja excluir: ");
            int id;
            bool idValido = int.TryParse(Console.ReadLine(), out id);
            if (!idValido)
            {
                Console.WriteLine("ID inválido! Por favor, insira um número válido.");
                Console.ReadKey();
                return;
            }

            Cliente cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }
            Console.ReadKey();
        }
    }
}
