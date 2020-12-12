using Domain.Model.Entities;
using Domain.Model.Interfaces.Infrastructure;
using Domain.Model.Interfaces.Repositores;
using Domain.Model.Interfaces.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Services.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _repository;
        private readonly IBlobService _blobService;

        public JogoService(IJogoRepository repository, IBlobService blobService)
        {
            _repository = repository;
            _blobService = blobService;
        }

        public async Task DeleteAsync(Jogo jogo)
        {
            await _blobService.DeleteAsync(jogo.ImageUri);

            await _repository.DeleteAsync(jogo);
        }

        public async Task<IEnumerable<Jogo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Jogo> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(Jogo jogo, Stream stream)
        {
            var newUri = await _blobService.UploadAsync(stream);
            jogo.ImageUri = newUri;

            await _repository.InsertAsync(jogo);
        }

        public async Task UpdateAsync(Jogo jogo, Stream stream)
        {
           if(stream != null)
            {
                await _blobService.DeleteAsync(jogo.ImageUri);

                var newUri = await _blobService.UploadAsync(stream);
                jogo.ImageUri = newUri;
            }

            await _repository.UpdateAsync(jogo);
        }
    }
}