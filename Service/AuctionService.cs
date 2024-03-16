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
    public class AuctionService : IAuctionService
    {

        private IAuctionRepo _repo;
        public AuctionService(IAuctionRepo repo)
        {
            _repo = repo;
        }
        public void AddNewAuction(Auction auction)
        {
            _repo.AddNewAuction(auction);
        }

        public void DeleteAuction(Auction auction)
        {
            _repo.DeleteAuction(auction);
        }

        public List<Auction> GetAuction()
        {
            return _repo.GetAuction();
        }

        public Auction GetAuctionById(int id)
        {
            return _repo.GetAuctionById(id);
        }

        public void UpdateAuction(Auction auction)
        {
            _repo.UpdateAuction(auction);
        }
    }
}
