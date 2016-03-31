using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GS_Data_API.Models;
namespace GS_Data_API.Controllers
{
    public class GSDataController : ApiController
    {

        public GSData _repo = new GSData();

        public List<GSData> getData()
        {
          
           return  _repo.getData();
        }

    }
}
