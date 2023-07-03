using AutoMapper;
using BugTracker.Api.Models;
using BugTracker.Core.Entities;
using BugTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly BugTrackerDbContext _bugContext;
        public BugsController(IMapper mapper, BugTrackerDbContext context)
        {
            _mapper = mapper;
            _bugContext = context;
        }

        // GET api/Books
        private IQueryable<BugDTO> GetBugs()
        {
            var bugs = from b in _bugContext.Bugs
                        select new BugDTO()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Description = b.Description,
                            Category = b.Category,
                            Criticality = b.Criticality,
                            CreatedAt = b.CreatedAt,
                            CreatedBy = b.CreatedBy

                        };

            return bugs;
        }


        //retrieve allbugs
        [Route("api/getAllBugs")]
        [HttpGet]
       // [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> GetAllBugs() 
        {

            //var bugs = GetBugs();
            var bugs = await _bugContext.Bugs.ToArrayAsync();

            return Ok(_mapper.Map<IEnumerable<Bug>, IEnumerable<BugDTO>>((IEnumerable<Bug>)bugs));
           

        }

        //retrieve bug by ID
        [Route("api/getBug/{id}")]
        [HttpGet]
       // [Authorize(Roles = "Admin,User")]
        public ActionResult GetBugById(int id)
        {
            var bug = _bugContext.Bugs.FirstOrDefault(b => b.Id == id);
            if (bug == null)
            {
                return NotFound();
            }
            return Ok(bug);

        }

        //Insert
        [Route("api/insert")]
        [HttpPost]
       //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Bug>> PostProduct (Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _bugContext.Bugs.Add(bug);
            _bugContext.SaveChanges();

            return CreatedAtAction(
                "PostProduct", new {id = bug.Id, bug}
                );

        }

        //Update Bug by ID
        [Route("api/update/{id}")]
        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> PutBug(int id, BugDTO bug)
        {
            if (id != bug.Id)
            {
                return BadRequest();
            }

            _bugContext.Entry(bug).State = EntityState.Modified;

            try
            {
                await _bugContext.SaveChangesAsync();

            }catch (DbException ex)
            {
                if(!_bugContext.Bugs.Any(b => b.Id == id))
                {
                    return NotFound(ex);
                }else
                {
                    throw ex;
                }

            }
            return NoContent();

        }

        //Delete By ID
        [Route("api/delete/{id}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Bug>> DeleteBug(int id)
        {
            var bug = await _bugContext.Bugs.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }

            _bugContext.Bugs.Remove(bug);
            await _bugContext.SaveChangesAsync();
            return NoContent();

        }


    }
}
