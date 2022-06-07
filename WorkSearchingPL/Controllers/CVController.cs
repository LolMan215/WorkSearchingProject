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
    [Route("api/CVs")]
    public class CVController: Controller
    {
        private readonly ICVService _cvService;

        public CVController(ICVService cvService)
        {
            _cvService = cvService;
        }

        /*[HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateNew([FromBody] CVDTO data, [FromQuery] List<ExperienceUnitDTO> experiences, [FromQuery] List<LanguageUnitDTO> languages, [FromQuery] List<SkillDTO> skills)
        {
            return Ok(_cvService.AddAsync(data, experiences, languages, skills));
        }*/

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateNew([FromBody] CVDTO data)
        {
            return Ok(_cvService.AddAsync(data));
        }

        [HttpPatch]
        [Route("{id}/edit")]
        public async Task<ActionResult> Edit(int id, [FromBody] CVDTO data)
        {
            await _cvService.UpdateAsync(id, data);

            return StatusCode(204); // NoContent
        }

        [HttpDelete]
        [Route("{id:int}/delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _cvService.DeleteByIdAsync(id);

            return StatusCode(204); // NoContent
        }

        [HttpGet]
        [Route("userId/{id}")]
        public async Task<ActionResult> GetCVByUserId(string id)
        {
            return Ok(await _cvService.GetCVByUserId(id));
        }
    }
}
