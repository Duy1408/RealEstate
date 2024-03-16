using BusinessObject.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IAuctionRepo
    {
        List<Auction> GetAuction();
        void AddNewAuction(Auction auction);

        void DeleteAuction(Auction auction);
        Auction GetAuctionById(int id);

        void UpdateAuction(Auction auction);

       
    }
}
