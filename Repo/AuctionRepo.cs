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
    public class AuctionRepo : IAuctionRepo
    {
        private AuctionDAO dao;
        public AuctionRepo()
        {
            dao = new AuctionDAO();
        }

        public void AddNewAuction(Auction auction)
        {
            dao.AddNewAuction(auction);
        }

        public void DeleteAuction(Auction auction)
        {
            dao.DeleteAuction(auction);
        }

        public List<Auction> GetAuction()
        {
            return dao.GetAllAuction();
        }

        public Auction GetAuctionById(int id)
        {
            return dao.GetAuctionByID(id);
        }

       

        public void UpdateAuction(Auction auction)
        {
            dao.UpdateAuction(auction);
           
        }
    }
}
