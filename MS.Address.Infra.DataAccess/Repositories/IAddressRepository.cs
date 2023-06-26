using MS.Address.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Infra.DataAccess.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressEntity> GetByIdAsync(Guid addressID);
        Task<AddressEntity> PostAsyncAdress(AddressEntity addressToAdd);
        Task<IList<AddressEntity>> GetAsync();
        Task DeleteAddress(AddressEntity addressEntity);
        Task<AddressEntity> UpdateAddressAsync(AddressEntity addressToUpdate);
        Task<AddressEntity> ActiveCustomer(AddressEntity address);
    }
}
