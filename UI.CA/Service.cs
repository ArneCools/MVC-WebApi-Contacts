using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Security;
using Contacts.BL.Models;
using Newtonsoft.Json;

namespace Contacts.UI.CA
{
    public class Service
    {
        private const string baseUri = "https://localhost:5001/api/";

        public Service()
        {
            
        }

        private HttpClient GetNewHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = 
                    (request,certificate,chain,SslPolicyErrors) => true
            };
            HttpClient httpClient = new HttpClient(httpClientHandler);
            return httpClient;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            IEnumerable<Contact> contacts = null;
            using (HttpClient httpClient = GetNewHttpClient())
            {
                string uri = baseUri + "contacts";
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
                request.Headers.Add("Accept","application/json");

                HttpResponseMessage response = httpClient.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contentAsString = response.Content.ReadAsStringAsync().Result;
                    contacts = JsonConvert.DeserializeObject<List<Contact>>(contentAsString);
                }
                else
                {
                    throw new Exception(response.StatusCode +" " + response.ReasonPhrase);
                }
                
            }

            return contacts;
        }
        
        public void DeleteContact(int id)
        {
            using (HttpClient httpClient = GetNewHttpClient())
            {
                string uri = baseUri + "contacts/" + id;
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);
                HttpResponseMessage response = httpClient.SendAsync(request).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode +" " + response.ReasonPhrase);
                }
            }
        }
        
        
    }
}