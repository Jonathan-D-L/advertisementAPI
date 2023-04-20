using advertisementAPI.Data;
using advertisementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace advertisementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    public class AdvertController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AdvertController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieve ALL Adverts from the database
        /// </summary>
        /// <returns>
        /// A full list of ALL Adverts
        /// </returns>
        /// <remarks>
        /// Example end point: GET /Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully returned a full list of ALL Adverts
        /// </response>
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<Advert>>> GetAll()
        {
            return Ok(await _dbContext.Adverts.ToListAsync());
        }

        /// <summary>
        /// Retrieve ONE Advert from the database
        /// </summary>
        /// <returns>
        /// One Advert by id
        /// </returns>
        /// <remarks>
        /// Example end point: GET /Advert/{id}
        /// </remarks>
        /// <response code="200">
        /// Successfully returned One Advert by id
        /// </response>
        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Advert>> GetOne(int id)
        {
            var advert = await _dbContext.Adverts.FindAsync(id);
            if (advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(advert);
        }

        /// <summary>
        /// Add Advert to the database
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// Example end point: POST /Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully Added Advert to the database
        /// </response>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Advert>> PostAvert(Advert advert)
        {
            _dbContext.Adverts.Add(advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.ToListAsync());
        }

        /// <summary>
        /// Update Advert in the database
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// Example end point: PUT /Advert
        /// </remarks>
        /// <response code="200">
        /// Successfully Updated Advert in the database
        /// </response>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Advert>> UpdateAdvert(Advert advert)
        {
            var advertToUpdate = await _dbContext.Adverts.FindAsync(advert.Id);
            if (advertToUpdate == null)
            {
                return BadRequest("Advert not found");
            }
            advertToUpdate.Header = advert.Header;
            advertToUpdate.Img = advert.Img;
            advertToUpdate.Description = advert.Description;
            advertToUpdate.CallToAction = advert.CallToAction;
            advertToUpdate.Clicks = advert.Clicks;

            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.ToListAsync());
        }

        /// <summary>
        /// Update partial of Advert in the database
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// Example end point: PATCH /Advert/{id}
        /// </remarks>
        /// <response code="200">
        /// Successfully Updated partial of Advert in the database
        /// </response>
        [HttpPatch]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Advert>> PatchAdvert(JsonPatchDocument advert, int id)
        {
            var advertToUpdate = await _dbContext.Adverts.FindAsync(id);
            if (advertToUpdate == null)
            {
                return BadRequest("Advert not found");

            }
            advert.ApplyTo(advertToUpdate);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Adverts.ToListAsync());
        }

       
    
        /// <summary>
        /// Delete Advert in the database
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <remarks>
        /// Example end point: DELETE /Advert/{id}
        /// </remarks>
        /// <response code="200">
        /// Successfully Deleted Advert in the database
        /// </response>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Advert>> Delete(int id)
        {
            var advertToDelete = await _dbContext.Adverts.FindAsync(id);
            if (advertToDelete == null)
            {
                return BadRequest("Advert not found");
            }
            _dbContext.Adverts.Remove(advertToDelete);
            return Ok(await _dbContext.Adverts.ToListAsync());
        }
    }
}
