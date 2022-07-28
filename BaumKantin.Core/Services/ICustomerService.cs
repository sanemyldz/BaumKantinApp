using BaumKantin.Core.DTOs;

namespace BaumKantin.Core.Services
{
    public interface ICustomerService 
    {
        Task<CustomResponseDTO<RoomDTO>> GetCustomerRoom(int Id);
        Task<CustomResponseDTO<CustomerRoomDTO>> AddCustomer(CustomerRoomDTO customerDTO);
        Task<CustomResponseDTO<UpdateCustomerDTO>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<CustomResponseDTO<NoContentResponseDTO>> RemoveCustomerAsync(int Id);
        Task<CustomResponseDTO<CustomerDTO>> GetByIdAsync(int Id);
        Task<CustomResponseDTO<List<CustomerRoomDTO>>> GetAllCustomersAsync();
    }
}
