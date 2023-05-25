using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GDPR.NetAPI.Models;

namespace GDPR.NetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GdprAgreementController : ControllerBase
    {
        
        private readonly GdprAgreementContext dbContext;
        private readonly ILogger<GdprAgreementController> logger;

        public GdprAgreementController(GdprAgreementContext dbContext, ILogger<GdprAgreementController> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        // GET: api/agreements/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAgreement(string id)
        {
            try
            {
                var agreement = await dbContext.Agreements.FindAsync(id);

                if (agreement != null)
                {
                    return Ok(agreement);
                }
                else
                {
                    logger.LogError("Agreement not found!");
                    return NotFound("Agreement not found!");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/agreements
        [HttpPost]
        public async Task<ActionResult> CreateAgreement([FromBody] GdprAgreement agreement)
        {
            try
            {
                var agreementDate = DateTime.UtcNow;

                if (await dbContext.Agreements.AnyAsync(a => a.identificationCode == agreement.identificationCode))
                {
                    logger.LogError("Agreement already exists!");
                    return BadRequest("Agreement already exists!");
                }

                if (!ModelState.IsValid)
                {
                    var validationErrors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return BadRequest(validationErrors);
                }

                agreement.agreementDate = agreementDate;

                dbContext.Agreements.Add(agreement);
                await dbContext.SaveChangesAsync();
                return Ok(agreement);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        // PUT: api/agreements/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgreement(string id, [FromBody] GdprAgreement agreement)
        {
            try
            {
                if (id != agreement.identificationCode)
                {
                    logger.LogError("ID doesn't match.");
                    return BadRequest();
                }

                dbContext.Entry(agreement).State = EntityState.Modified;

                if (!ModelState.IsValid)
                {
                    var validationErrors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return BadRequest(validationErrors);
                }

                try
                {
                    agreement.gdprAgreement = true;
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Agreements.Any(c => c.identificationCode == id))
                    {
                        logger.LogError("Agreement not found!");
                        return NotFound("Agreement not found!");
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(agreement);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        // DELETE: api/agreements/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgreement(string id)
        {
            try
            {
                var agreement = await dbContext.Agreements.FindAsync(id);
                if (agreement == null)
                {
                    logger.LogError("Agreement not found!");
                    return NotFound("Agreement not found!");
                }

                dbContext.Agreements.Remove(agreement);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}