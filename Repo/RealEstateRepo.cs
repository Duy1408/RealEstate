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
    public class RealEstateRepo : IRealEstateRepo
    {
        private RealEstateDAO dao;
        public RealEstateRepo()
        {
            dao = new RealEstateDAO();
        }
        public void AddNewRealEstate(RealEstate realestate)
        {
            dao.AddNewRealEstate(realestate);

        }

        public void DeleteRealEstate(RealEstate realestate)
        {
            dao.DeleteRealEstate(realestate);
        }

        public RealEstate GetRealEstateById(int id)
        {
            return dao.GetRealEstateByID(id);
        }

        public List<RealEstate> GetRealEstates()
        {
            return dao.GetAllRealEstate();
        }

        public IQueryable<RealEstate> SearchRealEstate(string name)
        {
            return dao.SearchRealEstateByName(name); 
        }

        public void UpdateRealEstate(RealEstate realestate)
        {
            dao.UpdateRealEstate(realestate);
        }
    }
}
