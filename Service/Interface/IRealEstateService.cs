using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRealEstateService
    {
        List<RealEstate> GetRealEstates();
        void AddNewRealEstate(RealEstate realestate);

        void DeleteRealEstate(RealEstate realestate);
        RealEstate GetRealEstateById(int id);

        void UpdateRealEstate(RealEstate realestate);

        IQueryable<RealEstate> SearchRealEstate(string name);
    }
}
