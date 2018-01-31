using System.Collections.Generic;
using LeagueAPI.Application.Dtos.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LeagueAPI.Repository
{
    public interface IRepository<TEntity> 
    {
        TEntity FindById(BsonObjectId id);
        TEntity FindByUsername(string username);
        void Add(TEntity entity);
        string Remove(string player);
        void Update(IGame entity);
        void UpdateLoser(IGame game);
        void UpdateWinner(IGame game);
        List<IPlayer> ReturnTopTen();
        Task<List<IPlayer>> FindAll();
    }
}
