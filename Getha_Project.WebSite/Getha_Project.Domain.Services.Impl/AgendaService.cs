using Getha_Project.Domain.Entities.DTO;
using Getha_Project.Domain.Services.Impl.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getha_Project.Domain.Services.Impl
{
    public class AgendaService : IAgendaService
    { 
           private readonly IConfiguration _configuration;
            public AgendaService(IConfiguration configuration)
            {
                _configuration = configuration;
            }

       public IList<AgendaDTO> consultaUsuarioPorId(int idUsuario)
        {
            var baseAddress = _configuration.GetConnectionString("urlGeroOlandaAPI");;
            IList<AgendaDTO> exibicaoAgenda = new List<AgendaDTO>();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseAddress);
                http.DefaultRequestHeaders.Accept.Clear();
                http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                http.Timeout = TimeSpan.FromMinutes(30);

                HttpResponseMessage response = http.GetAsync($"{baseAddress}/api/UserLogin?id={idUsuario}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string stringContent = response.Content.ReadAsStringAsync().Result;
                    var resposta = JsonConvert.DeserializeObject<IList<RespostaAgendaDTO>>(stringContent);

                    if(resposta != null) { 
                        exibicaoAgenda = AddRangeRespostaAgenda(resposta).ToList();
                    }


                }
            }
            return exibicaoAgenda;
        }

        private IList<AgendaDTO> AddRangeRespostaAgenda(IList<RespostaAgendaDTO> dtoList)
        {
            IList<AgendaDTO> agendaDTO = new List<AgendaDTO>();

            foreach(var itemAgenda in agendaDTO)
            {
                foreach(var dto in dtoList) { 
                itemAgenda.Id_Agenda = dto.Id_Agenda;
                itemAgenda.Titulo = dto.Titulo;
                itemAgenda.Descricao = dto.Descricao;
                itemAgenda.Observacoes = dto.Observacoes;
                itemAgenda.Detalhes = dto.Detalhes;
                itemAgenda.flagExibir = dto.flagExibir;
                }
            }

            return agendaDTO;
        }
    }
}
