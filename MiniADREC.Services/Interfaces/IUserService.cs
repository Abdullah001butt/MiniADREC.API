using MiniADREC.DTO.User;

namespace MiniADREC.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(UserDto dto);
        Task DeleteUserAsync(int id);
    }
}
