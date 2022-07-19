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
        private readonly IRoomService _roomService;

        public CustomerController(IMapper mapper, ICustomerService customerservice, IRoomService roomService)
        {
            _customerservice = customerservice;
            _mapper = mapper;
            _roomService = roomService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerRooms(int Id)
        {
            return CreateActionResult(await _customerservice.GetCustomerRooms(Id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return CreateActionResult(await _customerservice.GetDataAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            return CreateActionResult(await _customerservice.AddCustomer(customerDTO));
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int Id)
        {
            return CreateActionResult(await _customerservice.GetByIdAsync(Id));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerDTO customerDTO)
        {
            return CreateActionResult(await _customerservice.UpdateCustomerAsync(customerDTO));
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAsync(int Id)
        {
            return CreateActionResult(await _customerservice.RemoveCustomerAsync(Id));
        }
    }
}

