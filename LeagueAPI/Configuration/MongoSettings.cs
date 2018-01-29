namespace LeagueAPI.Configuration
{
    public class MongoSettings : IMongoSettings
    {
        public string connectionUri { get; set; }
        public string connectionPort { get; set; }
        public string connectionUsername { get; set; }
        public string connectionPassword { get; set; }
        public string mongoDataBase { get; set; }
    }
}
