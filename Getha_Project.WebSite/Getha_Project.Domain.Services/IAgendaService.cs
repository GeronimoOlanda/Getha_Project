using Getha_Project.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getha_Project.Domain.Services
{
    public interface IAgendaService
    {
        AgendaDTO consultaUsuarioPorId(int idUsuario);
    }
}
