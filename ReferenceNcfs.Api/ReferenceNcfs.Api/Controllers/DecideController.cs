﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReferenceNcfs.Api.Configuration;
using ReferenceNcfs.Api.Models;

namespace ReferenceNcfs.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult DecideAction([Required]NcfsRequestModel ncfsRequestModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Response.Headers.Add("ncfs-decision", _ncfsPolicy.NcfsDecision.ToString());
            Response.Headers.Add("ncfs-status-message", $"Reference NCFS policy decision was '{_ncfsPolicy.NcfsDecision}'");

            return Ok(
                new
                {
                    Base64Replacement = ncfsRequestModel.Base64Body
                });
        }
    }
}
