using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IJogoService
    {
        Task<IEnumerable<Jogo>> GetAllAsync();
        Task<Jogo> GetByIdAsync(int id);
        Task InsertAsync(Jogo jogo, Stream stream);
        Task UpdateAsync(Jogo jogo, Stream stream);
        Task DeleteAsync(Jogo jogo);
    }
}
