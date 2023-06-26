using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Address.Domain.Base;
using MS.Address.Domain.DTO;
using MS.Address.Domain.ViewModels;
using MS.Address.DTO.Address;
using MS.Address.Service.Interfaces;
using System;
using System.Threading.Tasks;

namespace MS.Address.Controller
{


    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;

        public AddressController(IMapper mapper, IAddressService addressService, ILogger<BaseController> log, IHttpContextAccessor httpContextAccessor) : base(log, httpContextAccessor)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet("{addressId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid addressID)
        {
            return CustomResponse(await _addressService.GetByIdAsync(addressID));

        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAddressCustomer([FromRoute] string customerId, [FromQuery] PagingFiltersBase pagingFiltersBase)
        {
            return CustomResponse(await _addressService.GetAsyncPage(customerId, pagingFiltersBase, "customer"));

        }

        [HttpGet("establishment/{establishmentId}")]
        public async Task<IActionResult> GetAddressEstablishment([FromRoute] string establishmentId, [FromQuery] PagingFiltersBase pagingFiltersBase)
        {
            return CustomResponse(await _addressService.GetAsyncPage(establishmentId, pagingFiltersBase, "establishment"));

        }

        [HttpPost]
        public async Task<IActionResult> PostAsyncAdress([FromBody] AddressViewModel addressViewModel)
        {
            var addressDTO = _mapper.Map<AddressDTO>(addressViewModel);
            var address = await _addressService.PostAsyncAdress(addressDTO);
            return Ok(new ResultViewModel("Endreço criado com sucesso!", address));

        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] Guid addressId, [FromBody] UpdateAddressViewModel     updateAddressViewModel)
        {
            var customerDTO = _mapper.Map<AddressUpdateDTO>(updateAddressViewModel);
            var address = await _addressService.UpdateAddress(addressId, customerDTO);
            return Ok(new ResultViewModel("Endereço atualizado com sucesso!", address));

        }

        [HttpPost("{addressId}/active_deactivate")]
        public async Task<IActionResult> ActiveCustomer([FromRoute] Guid addressId, [FromBody] AddressActiveDeactiveViewModel addressActiveDeactiveViewModel)
        {
            await _addressService.ActiveCustomer(addressId, addressActiveDeactiveViewModel);
            var messageResponse = addressActiveDeactiveViewModel.IsActive.Equals(true) ? "Endereço ativado com sucesso!" : "Endereço desativado com sucesso!";
            return Ok(new ResultViewModel(messageResponse));
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] Guid addressID)
        {
            await _addressService.DeleteAddress(addressID);
            return Ok(new ResultViewModel("Endereço removido com sucesso!"));
        }
    }
}
