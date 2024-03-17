using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;
using AutoMapper;
using BusinessObject.DTO.Response;
using GroupProject.Mapper;
using BusinessObject.DTO.Request;
using DAO;
using System.Xml.Linq;
using BusinessObject.ViewModels;
using Service;

namespace GroupProject.Controllers.AuctionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionService _auction;
        private readonly IMapper _mapper;

        public AuctionsController(IAuctionService auction, IMapper mapper)
        {
            _auction = auction;
            _mapper = mapper;
        }

        // GET: api/Auctions
        [HttpGet]
        public ActionResult<IEnumerable<AuctionResponseDTO>> GetAuctions()
        {
            if (_auction.GetAuction() == null)
            {
                return NotFound();
            }

            var config = new MapperConfiguration(
                 cfg => cfg.AddProfile(new AuctionProfile())
             );
            // create mapper
            var mapper = config.CreateMapper();




            var data = _auction.GetAuction().ToList().Select(auction => mapper.Map<Auction, AuctionResponseDTO>(auction));
            return Ok(data);
            ;
        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public IActionResult GetAuctionByID(int id)
        {
            var auction = _auction.GetAuctionById(id);

            var responese = _mapper.Map<AuctionResponseDTO>(auction);

            return Ok(responese);
        }

        // PUT: api/Auctions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutAuction(int id, AuctionUpdateDTO autionUpdateDTO)
        {
            try
            {
                if (autionUpdateDTO.AuctionID != id)
                {
                    return NotFound();
                }
                var action = _mapper.Map<Auction>(autionUpdateDTO);
                _auction.UpdateAuction(action);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST: api/Auctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Auction> PostAuction(AuctionCreateDTO auctioncreateDTO)
        {
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new AuctionProfile())
            );
            var mapper = config.CreateMapper();
            var auction = mapper.Map<Auction>(auctioncreateDTO);
            _auction.AddNewAuction(auction);

            return Ok(auction);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(int id)
        {
            if (_auction.GetAuction() == null)
            {
                return NotFound();
            }
            var auction = _auction.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }

            _auction.DeleteAuction(auction);

            return NoContent();
        }


    }
}
