﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Models;

namespace BdMarketWebApp.Gateway.IRepositories
{
    public interface IDesignationRepository:IRepository<Designation>
    {
        int Rows();
    }
}
