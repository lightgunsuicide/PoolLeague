using System;
using System.Collections.Generic;
using System.Text;
using LeagueAPI.Configuration;
using Microsoft.Extensions.Options;

namespace TestsAPI.Helpers
{
    public class SettingsFixture  
    {
        private IOptions<MongoSettings> _config;
        public IOptions<MongoSettings> settings { get; set;  }

        public SettingsFixture()
        {
            _config = Options.Create(new MongoSettings()
            {
              connectionUri = "localhost",
              connectionPort = "27017",
              mongoDataBase = "poolleague"
            });
            settings = _config;
        }
    }
}
