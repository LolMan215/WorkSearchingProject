using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkSearchingBLL.DTOs;
using WorkSearchingBLL.Interfaces;

namespace WorkSearchingPL.Controllers
{
    [ApiController]
    [Route("api/jobOffers")]
    public class JobOfferController: Controller
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _jobOfferService.GetAllTop());
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateNew([FromBody] JobOfferDTO data)
        {
            return Ok(_jobOfferService.AddAsync(data));
        }

        [HttpPatch]
        [Route("{id}/edit")]
        public async Task<ActionResult> Edit(int id, [FromBody] JobOfferDTO data)
        {
            await _jobOfferService.UpdateAsync(id, data);

            return StatusCode(204); // NoContent
        }

        [HttpDelete]
        [Route("{id:int}/delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _jobOfferService.DeleteByIdAsync(id);

            return StatusCode(204); // NoContent
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _jobOfferService.GetByIdAsync(id));
        }

        [HttpPatch]
        [Route("{offerId}/accept")]
        public async Task<ActionResult> AcceptOffer(int offerId, string userId)
        {
            await _jobOfferService.AcceptOffer(offerId, userId);
            return StatusCode(204);
        }

    }
}
