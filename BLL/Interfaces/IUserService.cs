using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        string GetUserRole(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
        void AddUser(UserDTO userDTO);
        UserDTO GetUser(string email);
        void Dispose();
    }
}
