using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RealEstateDAO
    {
        private static RealEstateDAO instance;

        public static RealEstateDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RealEstateDAO();
                }
                return instance;
            }
        }

        public List<RealEstate> GetAllRealEstate()
        {
            var _context = new TheRealEstateDBContext();
            return _context.RealEstates
                .Include(c => c.User)           
                .ToList();
        }

        public bool AddNewRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.RealEstates.SingleOrDefault(c => c.RealEstateID == realestate.RealEstateID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.RealEstates.Add(realestate);
                _context.SaveChanges();
                return true;

            }
        }

        public void UpdateRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();
            try
            {
                _context.Attach(realestate).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RealEstate GetRealEstateByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.RealEstates.SingleOrDefault(a => a.RealEstateID == id);
        }

        public void DeleteRealEstate(RealEstate realestate)
        {
            var _context = new TheRealEstateDBContext();

            var estate = _context.RealEstates.FirstOrDefault(a => a.RealEstateID == realestate.RealEstateID);
            if (estate != null)
            {
                var p = _context.Properties.Where(a => a.RealEstateID == estate.RealEstateID);
                if (p.Count() < 1)
                {
                    estate.Status = false;
                    //_context.Entry(estate).CurrentValues.SetValues(realestate);
                    _context.Entry(estate).State = EntityState.Modified;
                }
                else
                {
                    throw new Exception("Can't delete because they have more than 1 in properties!!!!!");
                }

            }

            _context.SaveChanges();
        }

        public IQueryable<RealEstate> SearchRealEstateByName(string searchvalue)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.RealEstates.Where(a => a.RealEstateAddress.ToUpper().Contains(searchvalue.Trim().ToUpper()));


            return a;
        }


    }
}
