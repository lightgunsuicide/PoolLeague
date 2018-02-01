using System.Collections.Generic;
using LeagueAPI.Application.Dtos.Interfaces;
using LeagueAPI.Application.Dtos;
using MongoDB.Bson;

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
        List<PlayerDto> ReturnTopTen();
        List<PlayerDto> FindAll();
    }
}
