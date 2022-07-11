using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Service;
using Microsoft.AspNetCore.Mvc;

namespace BaumKantin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly IService<Customer> _customerService;
        private readonly IMapper _mapper;

        public CustomerController(IService<Customer> customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet(Name ="GetAll")]
        public async Task<IActionResult> All()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);
            return CreateActionResult(CustomResponseDTO<List<CustomerDTO>>.Success(200, customerDTOs));
        }

        [HttpPost(Name ="Add")]
        public async Task<IActionResult> AddAsync(CustomerDTO customerDTO)
        {
            var customer = await _customerService.AddAsync(_mapper.Map<Customer>(customerDTO));
            var _customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(200, _customerDTO));
        }

        [HttpGet("{id}",Name ="GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(200, customerDTO));
        }

        [HttpPut(Name ="Update")]
        public async Task<IActionResult> UpdateAsync(CustomerDTO customerDTO)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDTO));
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(204));///////////////////////////////////
        }

        [HttpDelete("{id}",Name ="Delete")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Fail(404,"Kullanıcı bulunamadı!"));
            }
            await _customerService.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDTO<NoContentResponseDTO>.Success(204));
        }

    }
}

