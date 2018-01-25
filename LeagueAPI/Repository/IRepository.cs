using LeagueAPI.Application.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueAPI.Repository
{
    public interface IRepository<TEntity> 
    {
        TEntity FindById(string id);
        TEntity FindByUsername(string username);
        void Add(TEntity entity);
        string Remove(string player);
        void Update(IGame entity);
        void UpdateLoser(IGame game);
        void UpdateWinner(IGame game);
        List<IPlayer> ReturnTopTen();
        List<IPlayer> FindAll();
    }
}
