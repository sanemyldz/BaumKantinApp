using BaumKantin.Core.DTOs;

namespace BaumKantin.Core.Services
{
    public interface ICustomerService 
    {
        Task<CustomResponseDTO<List<RoomDTO>>> GetCustomerRooms(int Id);
        Task<CustomResponseDTO<List<CustomerRoomsDTO>>> GetDataAsync();
        Task<CustomResponseDTO<CustomerDTO>> AddCustomer(CustomerDTO customerDTO);
        Task<CustomResponseDTO<UpdateCustomerDTO>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO);
        Task<CustomResponseDTO<NoContentResponseDTO>> RemoveCustomerAsync(int Id);
        Task<CustomResponseDTO<CustomerDTO>> GetByIdAsync(int Id);
    }
}
