using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL.DAL
{
    public class WebDataAcess
    {
        private string domain = "http://localhost:5000/api/";

        public Task<string> GetDatas(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                var res = client.GetAsync($"{domain}{uri}").GetAwaiter().GetResult();
                return res.Content.ReadAsStringAsync();
            }
        }
        private MultipartFormDataContent GetFormData(Dictionary<string, HttpContent> contents)
        {
            var postContent = new MultipartFormDataContent();
            string boundary = $"----------{DateTime.Now.Ticks.ToString("x")}";
            postContent.Headers.Add("Content-Type", $"multipart/form-data,boundary={boundary}");
            foreach (var item in contents)
            {
                postContent.Add(item.Value,item.Key);
            }
            return postContent;
        }
        public Task<string> PostDatas(string uri, Dictionary<string, HttpContent> contents)
        {
            using (HttpClient client = new HttpClient())
            {
                var res = client.PostAsync($"{domain}{uri}", GetFormData(contents)).GetAwaiter().GetResult();
                return res.Content.ReadAsStringAsync();
            }
        }
    }
}
