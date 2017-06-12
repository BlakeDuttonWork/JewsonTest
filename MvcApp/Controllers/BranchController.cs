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

        public ActionResult Search()
        {
            return View();
        }

        // GET: Branch/Details/101
        public async Task<ActionResult> Details(int id)
        {
            Branch branch = await GetBranchAsync(id);

            if (branch == null)
            {
                return View("NotFound");
            }

            return View(branch);
        }

        public async Task<PartialViewResult> DetailsPartial(int id)
        {
            ViewBag.hasSearched = true;
            return PartialView("_BranchDetails", await GetBranchAsync(id));
        }

        private async Task<Branch> GetBranchAsync(int branchId)
        {
            Branch branch = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"api/branch/{branchId}");

                if (response.IsSuccessStatusCode)
                {
                    var branchJson = response.Content.ReadAsStringAsync().Result;

                    branch = JsonConvert.DeserializeObject<Branch>(branchJson);
                }
            }

            return branch;
        }
    }
}