﻿using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Locations
{
    public interface ILocationService
    {
        Task<List<LocationDetails>> GetAllLocations();
    }
}