﻿using Model.Users;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PSW_Wpf_Patient.Client
{
   
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }

    }

    public static class WpfPatientClient
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<Patient> GetUser(string username, string password)
        {
            //var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new LoginModel { username = username, password = password }));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseBody = await client.PostAsync("http://localhost:51393/api/user", content);
            var value = await responseBody.Content.ReadAsStringAsync();
            Patient user = JsonConvert.DeserializeObject<Patient>(value);

            return user;
        }

    }
}
