using Jewson.BranchData.WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewson.BranchData.WebApi.Models;
using Newtonsoft.Json;

namespace Jewson.BranchData.WebApi.Tests.Data
{
    class TestJsonDataService : IJsonDataService
    {
        public IEnumerable<Branch> GetAllBranchData()
        {
            List<Branch> branches = new List<Branch>
            {
                new Branch {
                    Number = 101,
                    Name = "Harpenden",
                    Address1 = "8-12 Grove Road",
                    Address2 = string.Empty,
                    Address3 = string.Empty,
                    Town = "Harpenden",
                    County = "Hertfordshire",
                    Postcode = "AL5 1PY",
                    Latitude = 51.807361F,
                    Longitude = -0.3414414F,
                    Telephone1 = "01582 761241",
                    Email = "branch0101@jewson.co.uk",
                    BranchManager = "Paul Tierney",
                    OpeningHoursWeekend = "08:00",
                    OpeningHoursMonToFri = "07:30",
                    ClosingHoursWeekend = "12:00",
                    ClosingHoursMonToFri = "17:00",
                    ClosingHoursWeekDay = "17:00",
                    Specialisms = new Specialism[]
                    {
                        new Specialism { Id = 23, Name = "Tool Hire", Description = null }
                    }
                },
                new Branch {
                    Number = 102,
                    Name = "Driffield (Kellythorpe Ind Estate)",
                    Address1 = "Unit 1 - 17",
                    Address2 = "Kellythorpe Industrial Estate",
                    Address3 = string.Empty,
                    Town = "Driffield",
                    County = "East Riding of Yorkshire",
                    Postcode = "YO25 9DJ",
                    Latitude = 53.998829F,
                    Longitude = -0.45909F,
                    Telephone1 = "01377 256581",
                    Email = "branch0102@jewson.co.uk",
                    BranchManager = "Paul Hunt",
                    OpeningHoursWeekend = "08:00",
                    OpeningHoursMonToFri = "07:30",
                    ClosingHoursWeekend = "12:00",
                    ClosingHoursMonToFri = "17:00",
                    ClosingHoursWeekDay = "17:00",
                    Specialisms = new Specialism[]
                    {
                        new Specialism { Id = 23, Name = "Tool Hire", Description = null }
                    }
                }
            };
            
            return branches;
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
        // ~TestJsonDataService() {
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
