using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {

        private readonly TheRealEstateDBContext _context;
        public UserDAO()
        {
            _context = new TheRealEstateDBContext();
        }

        public User CheckLogin(string email, string password)
        {
            return _context.Users.Where(u => u.Email!.Equals(email) && u.Password!.Equals(password)).FirstOrDefault();
        }

        public List<User> GetAllUser()
        {
            try
            {
                return _context.Users.Include(a => a.RealEstates)
                                     .Include(a => a.Comments)
                                     .Include(a => a.Role)
                                     .Include(a => a.Bid).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewUser(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateUser(User user)
        {
            try
            {
                _context.Attach(user).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User GetUserByID(int id)
        {
            try
            {
                var account = _context.Users.Include(a => a.Role).Include(a => a.Bid).SingleOrDefault(c => c.UserID == id);
                return account;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatusUser(User user)
        {
            var _user = _context.Users.FirstOrDefault(c => c.UserID.Equals(user.UserID));


            if (_user == null)
            {
                return false;
            }
            else
            {
                _user.Status = false;
                _context.Entry(_user).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

        public IQueryable<User> SearchUserByName(string searchvalue)
        {
            var a = _context.Users.Where(a => a.UserName.ToUpper().Contains(searchvalue.Trim().ToUpper()));


            return a;
        }

        public IQueryable<User> GetUserByBidID(int id)
        {
            try
            {
                var users = _context.Users!.Where(a => a.BidID == id).Include(a => a.Role).Include(a => a.Bid);

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
