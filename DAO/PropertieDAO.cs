using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PropertieDAO
    {
        private static PropertieDAO instance;

        public static PropertieDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PropertieDAO();
                }
                return instance;
            }
        }

        public List<Propertie> GetAllRealPropertie()
        {
            var _context = new TheRealEstateDBContext();
            return _context.Properties
                .Include(c => c.RealEstate)
                .ToList();
        }

        public bool AddNewPropertie(Propertie propertie)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Properties.SingleOrDefault(c => c.PID == propertie.PID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Properties.Add(propertie);
                _context.SaveChanges();
                return true;

            }
        }

        public void UpdatePropertie(Propertie propertie)
        {
            var _context = new TheRealEstateDBContext();
            try
            {
                _context.Attach(propertie).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Propertie GetPropertieByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.Properties.Include(c => c.RealEstate).SingleOrDefault(a => a.PID == id);
        }

        public void DeletePropertie(Propertie propertie)
        {
            var _context = new TheRealEstateDBContext();

            var a = _context.Properties.FirstOrDefault(a => a.PID == propertie.PID);
            _context.Properties.Remove(a);

            _context.SaveChanges();
        }




    }
}
