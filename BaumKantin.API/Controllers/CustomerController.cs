using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Services;
using BaumKantin.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaumKantin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerservice;

        public CustomerController(IMapper mapper, ICustomerService customerservice)
        {
            _customerservice = customerservice;
            _mapper = mapper;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerRooms(int id)
        {
            return CreateActionResult(await _customerservice.GetCustomerRooms(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var customers = await _customerservice.GetAllAsync();
            var customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);
            return CreateActionResult(CustomResponseDTO<List<CustomerDTO>>.Success(200, customerDTOs));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(CustomerDTO customerDTO)
        {
            var customer = await _customerservice.AddAsync(_mapper.Map<Customer>(customerDTO));
            var _customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(200, _customerDTO));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customer = await _customerservice.GetByIdAsync(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(200, customerDTO));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(CustomerDTO customerDTO)
        {
            await _customerservice.UpdateAsync(_mapper.Map<Customer>(customerDTO));
            //TODO
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(204));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var customer = await _customerservice.GetByIdAsync(id);
            if (customer == null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Fail(404,"Kullanıcı bulunamadı!"));
            }
            await _customerservice.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(204));
        }

    }
}

