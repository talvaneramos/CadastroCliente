using Projeto05.Abstracts;
using Projeto05.Entities;
using Projeto05.Repositories;
using System;

namespace Projeto05
{
    public class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var cliente = new Cliente(Guid.NewGuid(),
                "Talvane S. Ramos",
                "123.456.789-10",
                new DateTime(1989, 04, 03),
                Sexo.Masculino,
                EstadoCivil.Casado);                

                Console.WriteLine("\nDADOS DO CLIENTE: ");
                Console.WriteLine("Id.....................: " + cliente.IdCliente);
                Console.WriteLine("Nome...................: " + cliente.Nome);
                Console.WriteLine("CPF....................: " + cliente.Cpf);
                Console.WriteLine("Data Nascimento........: " + cliente.DataNascimento.ToString("dd/MM/yyyy"));
                Console.WriteLine("Sexo...................: " + cliente.Sexo);
                Console.WriteLine("Estado Civíl...........: " + cliente.EstadoCivil);                               

                ClienteRepositoryAbstract clienteRepository = null;

                Console.Write("\nInforme (1)TXT ou (2)CSV......: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        clienteRepository = new ClienteRepositoryTxt();
                        break;

                        case 2:
                        clienteRepository = new ClienteRepositoryCsv();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! ");
                        break;
                }

                if (clienteRepository != null)
                {
                    clienteRepository.Exportar(cliente);

                    if(clienteRepository is ClienteRepositoryTxt)
                    {
                        Console.WriteLine("\nDados em .txt gerado com sucesso! ");
                    }
                    else if(clienteRepository is ClienteRepositoryCsv)
                    {
                        Console.WriteLine("\nDados em .csv gerado com sucesso! ");
                    }                    
                }

            }
			catch (Exception ex)
			{
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("\nFim do programa! ");
            }
            Console.ReadKey();
        }
    }
}
