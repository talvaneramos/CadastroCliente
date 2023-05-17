using Projeto05.Abstracts;
using Projeto05.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto05.Repositories
{
    public class ClienteRepositoryCsv : ClienteRepositoryAbstract
    {
        public override void Exportar(Cliente cliente)
        {
            CriarDiretorio();

            using (var streamWriter = new StreamWriter(path + "clientes.csv", true))
            {
                var csv = $"{cliente.IdCliente };{cliente.Nome}; {cliente.Cpf};"
                        + $"{cliente.DataNascimento };"
                        + $"{cliente.Sexo };"
                        + $"{cliente.EstadoCivil }";

                streamWriter.WriteLine(csv);
            }
        }
    }
}
