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
using GroupProject.Mapper;
using BusinessObject.DTO.Response;
using BusinessObject.DTO.Request;
using Service;

namespace GroupProject.Controllers.RealEstateController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstatesController : ControllerBase
    {
        private IRealEstateService _service;
        private readonly IMapper _mapper;

        public RealEstatesController(IRealEstateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/RealEstates
        [HttpGet]
        public ActionResult<IEnumerable<RealEstate>> GetRealEstates()
        {
            if (_service.GetRealEstates() == null)
            {
                return NotFound();
            }


            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new RealEstateProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();



            var data = _service.GetRealEstates().ToList().Select(estate => mapper.Map<RealEstate, RealEstateResponseDTO>(estate));

            return Ok(data);
        }

        // GET: api/RealEstates/5
        [HttpGet("{id}")]
        public IActionResult GetRealEstateById(int id)
        {
            var realestate = _service.GetRealEstateById(id);

            var responese = _mapper.Map<RealEstateResponseDTO>(realestate);

            return Ok(responese);
        }



        // PUT: api/RealEstates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult UpdateRealEstate(int id, RealEstateUpdateDTO estateUpdateDTO)
        {
            try
            {
                if (estateUpdateDTO.RealEstateID != id)
                {
                    return NotFound();
                }
                var _realestate = _mapper.Map<RealEstate>(estateUpdateDTO);
                _service.UpdateRealEstate(_realestate);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/RealEstates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RealEstate> PostRealEstate(RealEstateCreateDTO realEstateDTO)
        {
            var config = new MapperConfiguration(
              cfg => cfg.AddProfile(new RealEstateProfile())
          );
            var mapper = config.CreateMapper();
            var estate = mapper.Map<RealEstate>(realEstateDTO);
            _service.AddNewRealEstate(estate);
            return Ok(estate);
        }


        // DELETE: api/RealEstates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int id)
        {
            try
            {
                if (_service.GetRealEstates() == null)
                {
                    return NotFound();
                }
                var realEstate = _service.GetRealEstateById(id);
                if (realEstate == null)
                {
                    return NotFound();
                }

                _service.DeleteRealEstate(realEstate);

                return Ok("Delete Successfully!!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET: api/Cats/5
        [HttpGet("search")]
        public ActionResult<RealEstateResponseDTO> GetEstate(string searchValue)
        {
            if (_service.GetRealEstates() == null)
            {
                return NotFound();
            }
            var estate = _service.SearchRealEstate(searchValue);

            if (estate == null)
            {
                return NotFound();
            }

            return Ok(estate);
        }


    }
}
