using MS.Address.Domain.Base;
using MS.Address.Domain.DTO;
using MS.Address.Domain.Paging;
using MS.Address.Domain.ViewModels;
using MS.Address.DTO.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Service.Interfaces
{
    public interface IAddressService
    {
        Task<ResponseAddressDTO> GetByIdAsync(Guid addressID);
        Task<ResponsePaging<ResponseAddressDTO>> GetAsyncPage(string guidID,PagingFiltersBase pagingFiltersBase, string expand);
        Task<ResponseAddressDTO> PostAsyncAdress(AddressDTO addressDTO);
        Task DeleteAddress(Guid addressID);
        Task<ResponseAddressDTO> UpdateAddress(Guid addressId, AddressUpdateDTO customerDTO);
        Task ActiveCustomer(Guid addressId, AddressActiveDeactiveViewModel addressActiveDeactiveViewModel);
    }
}
