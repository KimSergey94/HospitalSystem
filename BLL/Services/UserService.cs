using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Util;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow) { Database = uow; }
        
        public RoleDTO GetUserRole(UserDTO userDTO) 
        {
            return MapperUtil.MapToRoleDTO(Database.Roles.Get(userDTO.RoleId));
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return MapperUtil.MapToUserDTOList(Database.Users.GetAll());
        }

        public void AddUser(UserDTO userDTO)
        {
            Database.Users.Create(MapperUtil.MapToUser(userDTO));
            Database.Save();
        }
        public UserDTO GetUser(string login)
        {
            if (login == null)
                throw new ValidationException("Не установлен login пользователя", "");
            var user = Database.Users.Find(x => x.Login == login).ElementAtOrDefault(0); 
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");
            return MapperUtil.MapToUserDTO(user);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
