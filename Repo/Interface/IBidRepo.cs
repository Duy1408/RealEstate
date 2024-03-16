using BusinessObject.BusinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IBidRepo
    {
            public List<Bid> GetAllBid();
            public void AddNewBid(Bid bid);
            public void UpdateBid(Bid bid);
            public Bid GetBidByID(int id);
            public void DeleteBidById(int id);
    }
}
