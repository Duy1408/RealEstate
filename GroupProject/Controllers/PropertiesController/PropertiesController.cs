﻿using System;
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

namespace GroupProject.Controllers.PropertiesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private  IPropertieService _service;
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
          if (_service.GetAllPropertie()==null)
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
        public ActionResult<Propertie> GetPropertie(int id)
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

            return propertie;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutPropertie(int id, Propertie propertie)
        {
            if (_service.GetAllPropertie() == null)
            {
                return BadRequest();
            }


            try
            {
                _service.UpdateProperties(propertie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetAllPropertie() == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Propertie> PostPropertie(Propertie propertie)
        {
            if (_service.GetAllPropertie() == null)
            {
                return Problem("Entity set 'TheRealEstateDBContext.Properties'  is null.");
            }
     _service.AddNewProperties(propertie);

            return CreatedAtAction("GetPropertie", new { id = propertie.PID }, propertie);
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