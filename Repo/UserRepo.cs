using BusinessObject.BusinessObject;
using DAO;
using Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class UserRepo : IUserRepo
    {
        UserDAO dao = new UserDAO();
        public void AddNewUser(User user) => dao.AddNewUser(user);

        public bool ChangeStatusUser(User user) => dao.ChangeStatusUser(user);

        public User CheckLogin(string email, string password) => dao.CheckLogin(email, password);

        public List<User> GetAllUser() => dao.GetAllUser();

        public User GetUserByID(int id) => dao.GetUserByID(id);

        public IQueryable<User> SearchUser(string name) => dao.SearchUserByName(name);

        public void UpdateUser(User user) => dao.UpdateUser(user);

    }
}
