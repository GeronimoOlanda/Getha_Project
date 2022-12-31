using Getha_Project.Domain.Entities.DTO;
using Getha_Project.Domain.Services.Impl.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getha_Project.Domain.Services.Impl
{
    public class AgendaService : IHomeService
    { 
           private readonly IConfiguration _configuration;
            public AgendaService(IConfiguration configuration)
            {
                _configuration = configuration;
            }
  
        public AgendaDTO consultaUsuarioPorId(int idUsuario)
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
                    var resposta = JsonConvert.DeserializeObject<RespostaLoginDTO>(stringContent);
                    //exibicaoAgenda.Add(resposta);


                }
            }
           // return exibicaoAgenda;
        }
    }
}
