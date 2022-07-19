﻿using AutoMapper;
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

        public CustomerService(ICustomerRepository customerRepository, IGenericRepository<Customer> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDTO<CustomerDTO>> AddCustomer(CustomerDTO customerDTO)
        {
            await _genericRepository.AddAsync(_mapper.Map<Customer>(customerDTO));
            await _unitOfWork.CommitAsync();
            return CustomResponseDTO<CustomerDTO>.Success(200, customerDTO);
        }

        public async Task<CustomResponseDTO<List<RoomDTO>>> GetCustomerRooms(int Id)
        {
            var rooms =await _customerRepository.GetCustomerRooms(Id);
            var roomDto= _mapper.Map<List <RoomDTO>>(rooms);
            return CustomResponseDTO<List<RoomDTO>>.Success(200,roomDto);
        }

        public async Task<CustomResponseDTO<List<CustomerRoomsDTO>>> GetDataAsync()
        {
            var customer = await _customerRepository.GetDataAsync();
            var customerDTO = _mapper.Map<List<CustomerRoomsDTO>>(customer);
            return CustomResponseDTO<List<CustomerRoomsDTO>>.Success(200, customerDTO);
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
            var customer= await _genericRepository.GetByIdAsync(Id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return CustomResponseDTO<CustomerDTO>.Success(200, customerDTO);
        }
    }
}
