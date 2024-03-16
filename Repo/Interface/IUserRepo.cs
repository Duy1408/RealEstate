using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IUserRepo
    {
        User CheckLogin(string email, string password);
        List<User> GetAllUser();
        void AddNewUser(User user);

        bool ChangeStatusUser(User user);
        User GetUserByID(int id);

        void UpdateUser(User user);

        IQueryable<User> SearchUser(string name);
    }
}
