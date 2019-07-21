using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CopaFilmes.Infra.Services
{
    public class ServiceBase
    {
        private readonly HttpClient httpClient;
        protected string Address { get; set; }
        public ServiceBase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Result Get<Result>(string address)
        {
            var response
                = httpClient.GetAsync(address).Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Erro {response.StatusCode} ao tentar obter o recurso: {address}!");

            Result resource
                = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);

            return resource;
        }
    }
}
