using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;
using SQLitePCL;
using AutoMapper;
using BusinessObject.DTO.Response;
using GroupProject.Mapper;
using BusinessObject.DTO.Request;

namespace GroupProject.Controllers.PropertiesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private IPropertieService _service;
        private readonly IMapper _mapper;

        public PropertiesController(IPropertieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Properties
        [HttpGet]
        public ActionResult<IEnumerable<Propertie>> GetProperties()
        {
            if (_service.GetAllPropertie() == null)
            {
                return NotFound();
            }

            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new PropertieProfile())
            );
            // create mapper
            var mapper = config.CreateMapper();



            var data = _service.GetAllPropertie().ToList().Select(properties => mapper.Map<Propertie, PropertiResponseDTO>(properties));

            return Ok(data);
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public IActionResult GetPropertiesByID(int id)
        {
            var properties = _service.GetPropertiesByID(id);

            var responese = _mapper.Map<PropertiResponseDTO>(properties);

            return Ok(responese);
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult UpdatePropertie(int id, PropertieUpdateDTO propertieUpdateDTO)
        {
            try
            {
                if (propertieUpdateDTO.PID != id)
                {
                    return NotFound();
                }
                var _propertie = _mapper.Map<Propertie>(propertieUpdateDTO);
                _service.UpdateProperties(_propertie);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Propertie> PostAuction(PropertiesCreateDTO propertiesCreateDTO)
        {
            var config = new MapperConfiguration(
                cfg => cfg.AddProfile(new PropertieProfile())
            );
            var mapper = config.CreateMapper();
            var properties = mapper.Map<Propertie>(propertiesCreateDTO);
            _service.AddNewProperties(properties);


            return Ok(properties);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public IActionResult DeletePropertie(int id)
        {
            if (_service.GetAllPropertie() == null)
            {
                return NotFound();
            }
            var propertie = _service.GetPropertiesByID(id);
            if (propertie == null)
            {
                return NotFound();
            }

            _service.DeletePropertiesById(propertie);

            return NoContent();
        }

    }
}
