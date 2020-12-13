using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Context
{
    public class AzureContext : DbContext
    {
        public AzureContext(DbContextOptions<AzureContext> options)
            : base(options)
        {
        }

        public DbSet<Jogo> Jogo { get; set; }
    }
    
 }
