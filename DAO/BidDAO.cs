using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BidDAO
    {
        private readonly TheRealEstateDBContext _context;
        public BidDAO()
        {
            _context = new TheRealEstateDBContext();
        }

        public List<Bid> GetAllBid()
        {
            try
            {
                return _context.Bids.Include(a => a.Auctions).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddNewBid(Bid bid)
        {
            try
            {
                _context.Add(bid);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateBid(Bid bid)
        {
            try
            {
                _context.Attach(bid).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Bid GetBidByID(int id)
        {
            try
            {
                var bid = _context.Bids.SingleOrDefault(c => c.BidID == id);
                return bid;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteBidById(int id)
        {
            var _bid = _context.Bids.SingleOrDefault(lo => lo.BidID == id);
            if (_bid != null)
            {
                _context.Remove(_bid);
                _context.SaveChanges();
            }
        }

    }
}
