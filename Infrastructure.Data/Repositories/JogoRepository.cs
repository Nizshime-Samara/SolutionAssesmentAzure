using Domain.Model.Entities;
using Domain.Model.Interfaces.Repositores;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly AzureContext _context;

        public JogoRepository(AzureContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Jogo jogo)
        {
            _context.Remove(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync()
        {
            return await _context.Jogo.ToListAsync();
        }

        public async Task<Jogo> GetByIdAsync(int id)
        {
            return await _context.Jogo.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task InsertAsync(Jogo jogo)
        {
            _context.Add(jogo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Jogo jogo)
        {
            _context.Update(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
