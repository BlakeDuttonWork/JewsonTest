using Jewson.BranchData.WebApi.Data;
using Jewson.BranchData.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TRex.Metadata;

namespace Jewson.BranchData.WebApi.Controllers
{
    public class BranchesController : ApiController
    {
        private IBranchRepository repo; // = new BranchRepository();

        public BranchesController(IBranchRepository repository)
        {
            repo = repository;
        }

        // GET: api/Branches
        [HttpGet]
        [Route("api/branch/")]
        [Metadata("Get All Branch Data", "Gets details of all branches")]
        public IEnumerable<Branch> GetBranches()
        {
            return repo.GetAll();
        }

        // GET: api/Branches/5
        [HttpGet]
        [Route("api/branch/{branchNumber}")]
        [Metadata("Get Branch Details", "Gets details of the branch")]
        [ResponseType(typeof(Branch))]
        public IHttpActionResult GetBranch(int branchNumber)
        {
            Branch branch = repo.GetBranchByNumber(branchNumber);
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }
    }
}
