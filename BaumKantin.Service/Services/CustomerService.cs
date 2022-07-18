using AutoMapper;
using BaumKantin.Core;
using BaumKantin.Core.DTOs;
using BaumKantin.Core.Repositories;
using BaumKantin.Core.Services;
using BaumKantin.Core.UnitOfWorks;
using BaumKantin.Repository;

namespace BaumKantin.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
       
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> genericRepository, IUnitOfWork unitOfWork,
                ICustomerRepository customerRepository, IMapper mapper): base(genericRepository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<RoomDTO>>> GetCustomerRooms(int id)
        {
            var rooms =await _customerRepository.GetCustomerRooms(id);
            var roomDto= _mapper.Map<List <RoomDTO>>(rooms);
            return CustomResponseDTO<List<RoomDTO>>.Success(200,roomDto);
        }
    }
}
