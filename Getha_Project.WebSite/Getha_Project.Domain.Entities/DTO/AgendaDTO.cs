using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getha_Project.Domain.Entities.DTO
{
    public class AgendaDTO
    {
        public int Id_Agenda { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Observacoes { get; set; }
        public string Detalhes { get; set; }
        public string flagExibir { get; set; }
    }
}
