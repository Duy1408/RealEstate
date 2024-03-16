using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPropertieService
    {
        public List<Propertie> GetAllPropertie();
        public void AddNewProperties(Propertie propertie);
        public void UpdateProperties(Propertie propertie);
        public Propertie GetPropertiesByID(int id);
        public void DeletePropertiesById(Propertie propertie);
    }
}
