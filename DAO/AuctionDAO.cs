using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AuctionDAO
    {
        private static AuctionDAO instance;

        public static AuctionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuctionDAO();
                }
                return instance;
            }
        }

        public List<Auction> GetAllAuction()
        {
            var _context = new TheRealEstateDBContext();
            return _context.Auctions.Include(c => c.RealEstate).Include(c => c.Bid).ToList();
        }

        public bool AddNewAuction(Auction auction)
        {
            var _context = new TheRealEstateDBContext();
            var a = _context.Auctions.SingleOrDefault(c => c.AuctionID == auction.AuctionID);

            if (a != null)
            {
                return false;
            }
            else
            {
                _context.Auctions.Add(auction);
                _context.SaveChanges();
                return true;

            }
        }

        public void UpdateAuction(Auction auction)
        {
            var _context = new TheRealEstateDBContext();
            try
            {
                _context.Attach(auction).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Auction GetAuctionByID(int id)
        {
            var _context = new TheRealEstateDBContext();
            return _context.Auctions.Include(c => c.RealEstate).Include(c => c.Bid).SingleOrDefault(a => a.AuctionID == id);
        }

        public void DeleteAuction(Auction auction)
        {
            var _context = new TheRealEstateDBContext();

            var a = _context.Auctions.FirstOrDefault(a => a.AuctionID == auction.AuctionID);
            _context.Auctions.Remove(a);

            _context.SaveChanges();
        }




    }
}
