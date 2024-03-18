using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IRealEstateRepo
    {
        List<RealEstate> GetRealEstates();
        void AddNewRealEstate(RealEstate realestate);

        void DeleteRealEstate(RealEstate realestate);
        RealEstate GetRealEstateById(int id);

        void UpdateRealEstate(RealEstate realestate);

        IQueryable<RealEstate> SearchRealEstate(string name);
        IQueryable<RealEstate> GetRealEstateByUserID(int id);

    }
}
