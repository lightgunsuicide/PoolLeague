using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Configuration
{
    public interface IMongoSettings
    {           
         string connectionUri { get; set; }
         string connectionPort { get; set; }
         string connectionUsername { get; set; }
         string connectionPassword { get; set; }
         string mongoDataBase { get; set; }
    }
}

