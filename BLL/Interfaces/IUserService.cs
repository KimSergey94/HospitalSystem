using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(UserDTO userDTO);
        string GetUserRole(UserDTO userDTO);
        List<UserDTO> GetUsers();
        void AddUser(UserDTO userDTO);
        UserDTO GetUser(string email);
        void Dispose();
    }
}
