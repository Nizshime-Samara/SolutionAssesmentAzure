using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositores
{
   public interface IJogoRepository
    {
        Task<IEnumerable<Jogo>> GetAllAsync();
        Task<Jogo> GetByIdAsync(int id);
        Task InsertAsync(Jogo jogo);
        Task UpdateAsync(Jogo jogo);
        Task DeleteAsync(Jogo jogo);
    }
}
