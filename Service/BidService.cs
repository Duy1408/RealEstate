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
    public class BidService : IBidService
    {
        private readonly IBidRepo _bidRepo;
        public BidService(IBidRepo bidRepo)
        {
            _bidRepo = bidRepo;
        }

        public void AddNewBid(Bid bid) => _bidRepo.AddNewBid(bid);

        public void DeleteBidById(int id) => _bidRepo.DeleteBidById(id);

        public List<Bid> GetAllBid() => _bidRepo.GetAllBid();

        public Bid GetBidByID(int id) => _bidRepo.GetBidByID(id);

        public void UpdateBid(Bid bid) => _bidRepo.UpdateBid(bid);

    }
}
