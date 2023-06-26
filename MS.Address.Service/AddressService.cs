using AutoMapper;
using MS.Address.Domain.Base;
using MS.Address.Domain.DTO;
using MS.Address.Domain.Entities;
using MS.Address.Domain.Paging;
using MS.Address.Domain.ViewModels;
using MS.Address.DTO.Address;
using MS.Address.Infra.DataAccess.Repositories;
using MS.Address.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Service
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<ResponseAddressDTO> GetByIdAsync(Guid addressID)
        {
            var address = await _addressRepository.GetByIdAsync(addressID);
            return _mapper.Map<ResponseAddressDTO>(address);
        }

        public async Task<ResponsePaging<ResponseAddressDTO>> GetAsyncPage(string guid,PagingFiltersBase pagingFiltersBase, string expand)
        {
            var addressBase = await _addressRepository.GetAsync();
            var addressQuery = _mapper.Map<IList<ResponseAddressDTO>>(addressBase).ToList().AsQueryable();

            #region Filtros
            if (expand.Equals("customer"))
                addressQuery = addressQuery.Where(c => c.CustomerId == guid);

            if (expand.Equals("establishment"))
                addressQuery = addressQuery.Where(c => c.EstablishmentId == guid);
            #endregion

            var responseAddress = (from a in addressQuery.ToList() select a).ToList();

            if (pagingFiltersBase.page > 0 && pagingFiltersBase.page_size > 0)
            {
                var page = PagingUtils.Paging(responseAddress.AsQueryable(), pagingFiltersBase.page, pagingFiltersBase.page_size);

                ResponsePaging<ResponseAddressDTO> responsePaging = new ResponsePaging<ResponseAddressDTO>();
                responsePaging.pagination = new PagingModel()
                {
                    page_count = page.pagination.page_count,
                    page_size = page.pagination.page_size,
                    current_page = page.pagination.current_page,
                    row_count = page.pagination.row_count
                };

                responsePaging.data = page.data;
                return responsePaging;
            }

            return new ResponsePaging<ResponseAddressDTO>()
            {
                data = responseAddress
            };

        }

        public async Task<ResponseAddressDTO> PostAsyncAdress(AddressDTO addressDTO)
        {
            var addressToAdd = _mapper.Map<AddressEntity>(addressDTO);

            CustomerOrEstablishmentValidation(addressToAdd.CustomerID, addressToAdd.EstablishmentID);

            var customer = await _addressRepository.PostAsyncAdress(addressToAdd);

            var responseAddress = _mapper.Map<ResponseAddressDTO>(customer);

            return responseAddress;
        }

        public async Task DeleteAddress(Guid addressID)
        {
            var address = await _addressRepository.GetByIdAsync(addressID);
            await _addressRepository.DeleteAddress(address);
        }

        public async Task<ResponseAddressDTO> UpdateAddress(Guid addressId, AddressUpdateDTO customerDTO)
        {
            var addressToUpdate = _mapper.Map<AddressEntity>(customerDTO);
            addressToUpdate.AddressID = addressId;

            var address = await _addressRepository.UpdateAddressAsync(addressToUpdate);
            var responseAddress = _mapper.Map<ResponseAddressDTO>(address);

            return responseAddress;
        }

        public async Task ActiveCustomer(Guid addressId, AddressActiveDeactiveViewModel addressActiveDeactiveViewModel)
        {
            var address = await _addressRepository.GetByIdAsync(addressId);
            address.IsActive = addressActiveDeactiveViewModel.IsActive;

            await _addressRepository.ActiveCustomer(address);
        }


        private bool CustomerOrEstablishmentValidation(string customerID, string establishmentID)
        {
            if (!string.IsNullOrEmpty(customerID))
                return true;
            if (!string.IsNullOrEmpty(establishmentID))
                return true;

            throw new Exception("Erro, Endereço não pode ser cadastro sem estar vinculado a um customer ou estabelecimento!");
        }
    }
}
