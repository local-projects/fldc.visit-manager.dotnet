﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMSDataLayer;
using CMSDataLayer.Models;
using DBManager;
using DBManager.Models;
using FLDCVisitManagerBackend.BL;
using FLDCVisitManagerBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FLDCVisitManager.Controllers
{
    [ApiController]
    [Route("")]
    public class VisitManagerController : ControllerBase
    {

        private readonly ILogger<VisitManagerController> _logger;
        private static IBusinessLogic _businessLogic;

        public VisitManagerController(ILogger<VisitManagerController> logger, IBusinessLogic bl)
        {
            _logger = logger;
            _businessLogic = bl;
        }

        [Route("getVisitorCollectabileItems")]
        [HttpGet]
        public async Task<IActionResult> GetVisitorCollectabileItems(string lampId)
        {
            var collectabileItems = await _businessLogic.GetVisitorCollectabileItems(lampId);
            return new JsonResult(collectabileItems);
        }

        [Route("cpLamp")]
        [HttpGet]
        public async void CollectionPointLamp()//(CPLampIncomingRequest req)
        {
            var req = new CPLampIncomingRequest() { Id = "1", LampId = "1" };
            _businessLogic.CollectionPointLamp(req.Id, req.LampId);
        }

        [Route("cd_lamp")]
        public IActionResult ChargerDockerLamp(ChargerDockerLampIncomingRequest cdLampReq)
        {
            var result = _businessLogic.ChargerDockerLamp(cdLampReq);
            if (result.Status != 200)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Message);
        }

        [Route("hello")]
        public IActionResult UpdateCollectionPointHeartBeat(CPHeartBeatIncomingRequestParams req)
        {
            var response = _businessLogic.UpdateCollectionPointHeartBeat(req);
            if (response.Status != 200)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Message);
        }

        [Route("fwUpdate")]
        public IActionResult GetFirmwareFtpDetails()
        {
            var result = _businessLogic.GetFirmwareFtpDetails(); 
            return new JsonResult(result);
        }
    }
}
