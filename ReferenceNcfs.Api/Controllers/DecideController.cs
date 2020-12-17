using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReferenceNcfs.Api.Configuration;
using ReferenceNcfs.Api.Models;

namespace ReferenceNcfs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DecideController : ControllerBase
    {
        private readonly ILogger<DecideController> _logger;
        private readonly INcfsPolicy _ncfsPolicy;

        public DecideController(
            ILogger<DecideController> logger,
            INcfsPolicy ncfsPolicy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ncfsPolicy = ncfsPolicy ?? throw new ArgumentNullException(nameof(ncfsPolicy));
        }

        [HttpPost]
        public IActionResult DecideAction([Required]NcfsRequestModel ncfsRequestModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _logger.LogInformation($"Request triggered for file type {ncfsRequestModel.DetectedFiletype}");

            var useUnknownFileTypeAction = ncfsRequestModel.DetectedFiletype < FileType.Pdf;

            var action = useUnknownFileTypeAction
                ? _ncfsPolicy.UnprocessableFileTypeAction
                : _ncfsPolicy.GlasswallBlockedFilesAction;

            var policyUsed = useUnknownFileTypeAction
                ? nameof(_ncfsPolicy.UnprocessableFileTypeAction)
                : nameof(_ncfsPolicy.GlasswallBlockedFilesAction);

            Response.Headers.Add("ncfs-decision", action.ToString());
            Response.Headers.Add("ncfs-status-message", $"Reference NCFS policy decision was '{action}' because '{policyUsed}' was used");

            _logger.LogInformation($"Request finished for file type '{ncfsRequestModel.DetectedFiletype}' with decision to '{action}'. '{policyUsed}' was used");

            if (action == NcfsOption.Replace)
            {
                return Ok(
                    new DecideResponse
                    {
                        Base64Replacement = ncfsRequestModel.Base64Body
                    });
            }

            return Ok();
        }
    }

    public class DecideResponse
    {
        public string Base64Replacement { get; set; }
    }
}
