using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRadioApi.Radio;
using RazorRadioApi.Radio.Podfiles;

namespace RazorRadioApi.Pages
{
    public class SingleProgramModel : PageModel
    {
        public ListPodfiles ListPodfiles { get; set; }
        public void OnGet(int id)
        {
            ListPodfiles =  RadioApiService.GetPodFiles(id).Result;
        }
    }
}
