using BusinessObject.BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IPropertieRepo
    {
   
        public List<Propertie> GetAllPropertie();
        public void AddNewProperties(Propertie propertie);
        public void UpdateProperties(Propertie propertie);
        public Propertie GetPropertiesByID(int id);
        public void DeletePropertiesById(Propertie propertie);


    }
}
