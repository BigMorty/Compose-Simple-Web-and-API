using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWeb.Pages
{
    public class PrivacyModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var httpClient = new HttpClient();
            using (HttpResponseMessage response = await httpClient.GetAsync(new Uri("http://mywebapi/api/values/1")))
            {
                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewData["Message"] = "Call failed to 'MyAPI'";
                }
            }

            return Page();
        }
    }
}