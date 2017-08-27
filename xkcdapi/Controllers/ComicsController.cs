using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using xkcdapi.Dtos;
using xkcdapi.Entities;
using xkcdapi.Repositories;

namespace xkcdapi.Controllers
{
    [Route("api/[controller]")]
    public class ComicsController: Controller
    {
        private readonly IComicRepository _comicRepository;

        public ComicsController(IComicRepository comicRepository)
        {
            _comicRepository = comicRepository;
        }

        [HttpGet]
        public IActionResult GetAllComics()
        {
            var allComics = _comicRepository.GetAll().OrderBy(o => o.Num).ToList();

            var allComicsDto = allComics.Select(Mapper.Map<ComicDto>);
            
            return Ok(allComicsDto);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingleComic(int id)
        {
            Comic comicFromRepo = _comicRepository.GetSingle(id);

            if (comicFromRepo == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ComicDto>(comicFromRepo));
        }
        //Put all comics


    }
}
