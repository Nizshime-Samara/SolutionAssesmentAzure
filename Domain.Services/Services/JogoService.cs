using Domain.Model.Entities;
using Domain.Model.Interfaces.Infrastructure;
using Domain.Model.Interfaces.Repositores;
using Domain.Model.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _repository;
        private readonly IBlobService _blobService;
        private readonly IQueueService _queueService;

        public JogoService(IJogoRepository repository, IBlobService blobService, IQueueService queueService)
        {
            _repository = repository;
            _blobService = blobService;
            _queueService = queueService;
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
             var jogo =  await _repository.GetByIdAsync(id);
             var jsonJogo = JsonConvert.SerializeObject(jogo);
             var bytesJsonJogo = UTF8Encoding.UTF8.GetBytes(jsonJogo);
             string jsonJogoBase64 = Convert.ToBase64String(bytesJsonJogo);

            //await _queueService.SendAsync(jsonJogoBase64);

            return jogo;

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