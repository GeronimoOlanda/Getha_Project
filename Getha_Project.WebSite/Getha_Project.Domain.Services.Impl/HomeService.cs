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
    public class HomeService : IHomeService
    { 
           private readonly IConfiguration _configuration;
            public HomeService(IConfiguration configuration)
            {
                _configuration = configuration;
            }
  
        public UserLoginDTO consultaUsuarioPorId(int idUsuario)
        {
            var baseAddress = _configuration.GetConnectionString("urlGeroOlandaAPI");;
            UserLoginDTO exibicaoUserLogin = new UserLoginDTO();
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
                    exibicaoUserLogin = UserLoginRange(resposta);


                }
            }
            return exibicaoUserLogin;
        }

        public UserLoginDTO UserLoginRange(RespostaLoginDTO userLoginDTO)
        {
            UserLoginDTO userLogin = new UserLoginDTO();

            userLogin.Id_Usuario = userLoginDTO.Id_Usuario;
            userLogin.LoginUser = userLoginDTO.LoginUser;
            userLogin.UserName = userLoginDTO.UserName;
            userLogin.flag_Setor = userLoginDTO.flag_Setor;
            userLogin.flag_UserAlive = userLoginDTO.flag_UserAlive;
            userLogin.Password = userLoginDTO.Password;
            userLogin.Password_Encrypt = userLoginDTO.Password_Encrypt;
            userLogin.Created_At = userLoginDTO.Created_At;
            userLogin.Updated_At = userLoginDTO.Updated_At;

            return userLogin;
        }
    }
}
