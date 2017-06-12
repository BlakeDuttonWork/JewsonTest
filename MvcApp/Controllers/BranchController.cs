using Jewson.BranchData.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Controllers
{
    public class BranchController : Controller
    {
        private string BaseUrl = "http://jewsonbranchdatawebapp.azurewebsites.net/";

        // GET: Branch/Details/101
        public async Task<ActionResult> Details(int id)
        {
            Branch branch = new Branch();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/branch/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var branchJson = response.Content.ReadAsStringAsync().Result;

                    branch = JsonConvert.DeserializeObject<Branch>(branchJson);
                }
            }

            return View(branch);
        }
    }
}