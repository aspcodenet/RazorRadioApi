using Newtonsoft.Json;
using RazorRadioApi.Radio.Podfiles;
using RazorRadioApi.Radio.ProgramsForPage;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace RazorRadioApi.Radio
{
    public class RadioApiService
    {
        // getprogramsforpage
        // GetProgramsForPage

        public static async Task<ListPodfiles> GetPodFiles(int id)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.sr.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // api.sr.se svarar 403 Forbidden om anropet saknar User-Agent
            client.DefaultRequestHeaders.UserAgent.ParseAdd("KrisInfoConsole/1.0");
            HttpResponseMessage response = await client.GetAsync("/api/v2/podfiles?format=json&programid=" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var podFiles = JsonConvert.DeserializeObject<ListPodfiles>(responseBody);
                return podFiles;
            }
            return null;
        }

        // denna servicemethod förenklar koden för UI
        public static async Task<List<Radio.ProgramsForPage.Program>> GetAllPrograms()
        {
            List<Radio.ProgramsForPage.Program> allPrograms = new List<Radio.ProgramsForPage.Program>();
            int page = 1;
            while (true) {                 
                var listPrograms = await GetProgramsForPage(page);
                if (listPrograms == null || listPrograms.Programs.Count == 0)
                {
                    break;
                }
                allPrograms.AddRange(listPrograms.Programs);
                page++;
            }
            return allPrograms;
        }

        public static async Task<ListPrograms> GetProgramsForPage(int page = 1)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.sr.se");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // api.sr.se svarar 403 Forbidden om anropet saknar User-Agent
            client.DefaultRequestHeaders.UserAgent.ParseAdd("KrisInfoConsole/1.0");

            HttpResponseMessage response;
            if (page == 1)
            {
                response = await client.GetAsync("/api/v2/programs?format=json");
            }
            else
            {
                response = await client.GetAsync($"/api/v2/programs?format=json&page={page}");
            }


            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var listPrograms = JsonConvert.DeserializeObject<ListPrograms>(responseBody);
                return listPrograms;
            }
            return null;

        }

    }
}
