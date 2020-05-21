using Microsoft.AspNetCore.Http;
using Adventure2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPG.Helpers;

namespace Adventure2020.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string KEY = "RPG";

        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;

        }

        public void SetLocation(Location _loc)
        {

        }
    }
}
