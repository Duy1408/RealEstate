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
    public class PropertiesService : IPropertieService
    {
        private IPropertieRepo _service;
        public PropertiesService(IPropertieRepo service)
        {
            _service = service;
        }
        public void AddNewProperties(Propertie propertie)
        {
            _service.AddNewProperties(propertie);
        }

        public void DeletePropertiesById(Propertie propertie)
        {
           _service.DeletePropertiesById(propertie);
        }

        public List<Propertie> GetAllPropertie()
        {
            return _service.GetAllPropertie();
        }

        public Propertie GetPropertiesByID(int id)
        {
           return _service.GetPropertiesByID(id);
        }

        public void UpdateProperties(Propertie propertie)
        {
           _service.UpdateProperties(propertie);
        }
    }
}
