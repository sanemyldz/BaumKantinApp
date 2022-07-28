using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Repositories;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;

namespace BaumKantin.Service.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IGenericRepository<Customer> genericRepository,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDTO<CustomerRoomDTO>> AddCustomer(CustomerRoomDTO customerDTO)
        {
            await _genericRepository.AddAsync(_mapper.Map<Customer>(customerDTO));
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<CustomerRoomDTO>.Success(200, customerDTO);
        }

        public async Task<CustomResponseDTO<RoomDTO>> GetCustomerRoom(int Id)
        {
            var room = await _customerRepository.GetCustomerRoom(Id);
            var roomDto = _mapper.Map<RoomDTO>(room);
            return CustomResponseDTO<RoomDTO>.Success(200, roomDto);
        }

        public async Task<CustomResponseDTO<NoContentResponseDTO>> RemoveCustomerAsync(int Id)
        {
            var customer = await _genericRepository.GetByIdAsync(Id);
            _genericRepository.Remove(customer);
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<NoContentResponseDTO>.Success(204);
        }

        public async Task<CustomResponseDTO<UpdateCustomerDTO>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO)
        {
            _genericRepository.Update(_mapper.Map<Customer>(updateCustomerDTO));
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<UpdateCustomerDTO>.Success(200, updateCustomerDTO);
        }

        public async Task<CustomResponseDTO<CustomerDTO>> GetByIdAsync(int Id)
        {
            var customer = await _genericRepository.GetByIdAsync(Id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CustomResponseDTO<CustomerDTO>.Success(200, customerDTO);
        }

        public async Task<CustomResponseDTO<List<CustomerRoomDTO>>> GetAllCustomersAsync()
        {        
            var customerRoomDTO=_mapper.Map<List<CustomerRoomDTO>>(_customerRepository.GetAll());
            return CustomResponseDTO<List<CustomerRoomDTO>>.Success(200, customerRoomDTO);
        }

    }
}
