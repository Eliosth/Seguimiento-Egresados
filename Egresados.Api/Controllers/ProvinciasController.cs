using AutoMapper;
using Egresados.Api.Models;
using Egresados.Model.Entities;
using Egresados.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Egresados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProvinciasController : ControllerBase
    {
        private readonly ILogger<ProvinciasController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly IProvinciaServices _provinciaServices;

        public ProvinciasController(ILogger<ProvinciasController> logger,
                               IMapper mapper,
                               UserManager<Usuario> userManager,
                               IProvinciaServices _provinciaServices
                          )
        {
            _logger = logger;
            _mapper = mapper;
            _provinciaServices = _provinciaServices;
        }

        /// <summary>
        /// Obtiene listado para los select.
        /// </summary>     
        [HttpGet("selectList")]
        public async Task<ActionResult<List<Provincia>>> SelectList()
        {
            var result = await _provinciaServices.GetListAsync();
            return result;
        }
    }
}
