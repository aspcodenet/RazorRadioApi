using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorRadioApi.Radio;

namespace RazorRadioApi.Pages
{
    public class IndexModel : PageModel
    {
        public List<Radio.ProgramsForPage.Program> Programs { get; set; }
        public void OnGet()
        {
              Programs = RadioApiService.GetAllPrograms().Result;
        }
    }
}
