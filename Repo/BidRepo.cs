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
    public class BidRepo : IBidRepo
    {
        BidDAO dao = new BidDAO();

        public void AddNewBid(Bid bid) => dao.AddNewBid(bid);

        public void DeleteBidById(int id) => dao.DeleteBidById(id);

        public List<Bid> GetAllBid() => dao.GetAllBid();

        public Bid GetBidByID(int id) => dao.GetBidByID(id);

        public void UpdateBid(Bid bid) => dao.UpdateBid(bid);

    }
}
