using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAppsSuportados.Models
{
    public class AppSuportadoModel
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;

    }
}
