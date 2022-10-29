using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            Thread.Sleep(5000);
            //Dependency chain
            var result = _seriesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _seriesService.GetBySeriesId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result)
;
        }

        [HttpPost("add")]
        public IActionResult Post(Series series)
        {
            var result = _seriesService.Add(series);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbygenre")]
        public IActionResult GetByCategory(int genreId)
        {
            var result = _seriesService.GetAllByGenreId(genreId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result)
;
        }
    }
}
