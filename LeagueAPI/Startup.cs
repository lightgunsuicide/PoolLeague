using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Services;
using LeagueAPI.Configuration;
using LeagueAPI.Domain.Services;
using LeagueAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IGameService, GameService>();    
            services.AddTransient<IRepository<IPlayer>, PlayerRepository>();
            services.AddTransient<ILeagueService, LeagueService>();
            services.AddMvc();
            services.AddOptions();
            services.Configure<MongoSettings>(Configuration.GetSection("MongoSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
