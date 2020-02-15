using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }
        
        public void Dispose()
        {
            Database.Dispose();
        }

        public string GetUserRole(UserDTO userDTO) 
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>()).CreateMapper();
            RoleDTO userRole = mapper.Map<Role, RoleDTO>(Database.Roles.Get(userDTO.RoleId));
            return userRole.Name;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public void AddUser(UserDTO userDTO)
        {
            User user = new User
            {
                Login = userDTO.Login,
                Password = userDTO.Password,
                RoleId = userDTO.RoleId
            };
            Database.Users.Create(user);
            Database.Save();
        }
        public UserDTO GetUser(string login)
        {
            if (login == null)
                throw new ValidationException("Не установлен login пользователя", "");
            var user = Database.Users.Find(x => x.Login == login).ElementAtOrDefault(0); 
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");
            return new UserDTO
            {
                UserId = user.UserId, 
                Login = user.Login,
                RoleId = user.RoleId,
                Password = user.Password
            };
        }
    }
}
