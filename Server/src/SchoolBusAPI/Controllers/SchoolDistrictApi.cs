/*
 * REST API Documentation for the MOTI School Bus Application
 *
 * The School Bus application tracks that inspections are performed in a timely fashion. For each school bus the application tracks information about the bus (including data from ICBC, NSC, etc.), it's past and next inspection dates and results, contacts, and the inspector responsible for next inspecting the bus.
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using SchoolBusAPI.Models;
using SchoolBusAPI.ViewModels;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SchoolDistrictApiController : Controller
    {
        private readonly ISchoolDistrictApiService _service;

        /// <summary>
        /// Create a controller and set the service
        /// </summary>
        public SchoolDistrictApiController(ISchoolDistrictApiService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Returns a list of SchoolDistricts for a given region</remarks>
        /// <param name="id">id of Region to fetch SchoolDistricts for</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/api/regions/{id}/schooldistricts")]
        [SwaggerOperation("RegionsIdSchooldistrictsGet")]
        [SwaggerResponse(200, type: typeof(List<SchoolDistrict>))]
        public virtual IActionResult RegionsIdSchooldistrictsGet([FromRoute]int id)
        {
            return this._service.RegionsIdSchooldistrictsGetAsync(id);
        }
    }
}
