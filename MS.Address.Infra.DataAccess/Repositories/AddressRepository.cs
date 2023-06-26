using Microsoft.EntityFrameworkCore;
using MS.Address.Domain.Entities;
using MS.Address.Infra.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Infra.DataAccess.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private AddressContext _addressContext;

        public AddressRepository(AddressContext addressContext)
        {
            _addressContext = addressContext;
        }

        public async Task<AddressEntity> GetByIdAsync(Guid addressID)
        {
            var customer = await _addressContext.Address.FindAsync(addressID);
            return customer;
        }

        public async Task<IList<AddressEntity>> GetAsync()
        {
            var address = await _addressContext.Address.ToListAsync();
            return address;
        }

        public async Task<AddressEntity> PostAsyncAdress(AddressEntity addressToAdd)
        {
            await _addressContext.Address.AddAsync(addressToAdd);
            await _addressContext.SaveChangesAsync();

            return addressToAdd ;
        }

        public async Task DeleteAddress(AddressEntity addressEntity)
        {
            _addressContext.Address.Remove(addressEntity);
            await _addressContext.SaveChangesAsync();
        }

        public async Task<AddressEntity> UpdateAddressAsync(AddressEntity addressEntity)
        {
            var entry = _addressContext.Entry(addressEntity);

            entry.State = EntityState.Modified;
            entry.Property(x => x.CustomerID).IsModified = false;
            entry.Property(x => x.EstablishmentID).IsModified = false;
            entry.Property(x => x.IsActive).IsModified = false;


            await _addressContext.SaveChangesAsync();

            return addressEntity;

        }

        public async Task<AddressEntity> ActiveCustomer(AddressEntity address)
        {
            var entry = _addressContext.Entry(address);

            entry.State = EntityState.Unchanged;
            entry.Property(x => x.IsActive).IsModified = true;

            await _addressContext.SaveChangesAsync();

            return address;
        }
    }
}
