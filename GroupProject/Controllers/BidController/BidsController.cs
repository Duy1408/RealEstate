using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO;
using BusinessObject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interface;

namespace GroupProject.Controllers.BidController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBidService _bidServices;
        private readonly IMapper _mapper;

        public BidsController(IBidService bidServices, IMapper mapper)
        {
            _bidServices = bidServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBid()
        {
            try
            {
                if (_bidServices.GetAllBid() == null)
                {
                    return NotFound();
                }
                var bids = _bidServices.GetAllBid();
                var response = _mapper.Map<List<BidDTO>>(bids);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBidByID(int id)
        {
            var bid = _bidServices.GetBidByID(id);

            var responese = _mapper.Map<BidDTO>(bid);

            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewBid(BidVM bid)
        {
            try
            {
                var _bid = _mapper.Map<Bid>(bid);
                _bidServices.AddNewBid(_bid);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateBid(BidDTO bid, int id)
        {
            try
            {
                if (bid.BidID != id)
                {
                    return NotFound();
                }
                var _bid = _mapper.Map<Bid>(bid);
                _bidServices.UpdateBid(_bid);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBid(int id)
        {
            if (_bidServices.GetAllBid() == null)
            {
                return NotFound();
            }
            var bid = _bidServices.GetBidByID(id);
            if (bid == null)
            {
                return NotFound();
            }

            _bidServices.DeleteBidById(id);


            return Ok("Delete Successfully");
        }

    }
}
