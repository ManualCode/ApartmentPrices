using ApartmentPrices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentPrices.Domain.Abstractions.Repositories
{
    public interface IApartmentRepository
    {
        Task<Apartment> FindOrCreateAsync(Apartment team);

        Task<List<Apartment>> GetAllAsync();
    }
}
