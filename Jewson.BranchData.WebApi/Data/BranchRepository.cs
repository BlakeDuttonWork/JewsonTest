using Jewson.BranchData.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewson.BranchData.WebApi.Data
{
    public interface IBranchRepository : IDisposable
    {
        IEnumerable<Branch> GetAll();
        Branch GetBranchByNumber(int number);
    }

    public class BranchRepository : IBranchRepository
    {
        IJsonDataService jsonData;
        IEnumerable<Branch> branches;

        public BranchRepository(IJsonDataService jsonService)
        {
            jsonData = jsonService;
        }

        public IEnumerable<Branch> GetAll()
        {
            if (branches == null)
            {
                branches = jsonData.GetAllBranchData();
            }

            return branches;
        }

        public Branch GetBranchByNumber(int number)
        {
            return GetAll().Where(x => x.Number == number).FirstOrDefault();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BranchRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}