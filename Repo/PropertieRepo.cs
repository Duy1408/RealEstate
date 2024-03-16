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
    public class PropertieRepo : IPropertieRepo
    {

        PropertieDAO dao = new PropertieDAO();
        public void AddNewProperties(Propertie propertie)
        {
            dao.AddNewPropertie(propertie);
        }

        public void DeletePropertiesById(Propertie propertie)
        {
            dao.DeletePropertie(propertie);
        }

        public List<Propertie> GetAllPropertie()
        {
            return dao.GetAllRealPropertie();
        }

        public Propertie GetPropertiesByID(int id)
        {
            return dao.GetPropertieByID(id);
        }

        public void UpdateProperties(Propertie propertie)
        {
            dao.UpdatePropertie(propertie);
        }
    }
}
