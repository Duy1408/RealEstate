using BusinessObject.BusinessObject;
using Repo.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RealEstateService : IRealEstateService
    {
        private IRealEstateRepo _repo;
        public RealEstateService(IRealEstateRepo repo)
        {
            _repo = repo;
        }

        public void AddNewRealEstate(RealEstate realestate)
        {
            _repo.AddNewRealEstate(realestate);
        }

        public void DeleteRealEstate(RealEstate realestate)
        {
            _repo.DeleteRealEstate(realestate);
        }

        public RealEstate GetRealEstateById(int id)
        {
            return _repo.GetRealEstateById(id);
        }

        public IQueryable<RealEstate> GetRealEstateByUserID(int id)
        {
            return _repo.GetRealEstateByUserID(id);
        }

        public List<RealEstate> GetRealEstates()
        {
            return _repo.GetRealEstates();
        }

        public IQueryable<RealEstate> SearchRealEstate(string name)
        {
            return _repo.SearchRealEstate(name);
        }

        public void UpdateRealEstate(RealEstate realestate)
        {
            _repo.UpdateRealEstate(realestate);
        }
    }
}
