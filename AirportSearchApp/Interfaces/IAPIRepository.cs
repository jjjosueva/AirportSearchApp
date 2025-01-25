using AirportSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSearchApp.Interfaces
{
    internal interface IAPIRepository
    {
        public Task<AirportModel> GetResponseFromAPI(string name);
    }
}
