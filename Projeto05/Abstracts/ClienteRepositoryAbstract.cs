using Projeto05.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto05.Abstracts
{
    public abstract class ClienteRepositoryAbstract
    {
        protected string path = "c:\\temp\\";        
        
        protected void CriarDiretorio()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public abstract void Exportar(Cliente cliente);
    }
}
