using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipay_Cohorts_HW3.Api.BookOperations;
using Sipay_Cohorts_HW3.DataAccess.Context;
using Sipay_Cohorts_HW3.Entities.DbSets;
using static Sipay_Cohorts_HW3.Api.BookOperations.GetByIdQuery;
using static Sipay_Cohorts_HW3.Api.BookOperations.UpdateBookCommand;

namespace Sipay_Cohorts_HW3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _dbContext;
        public BookController(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            GetByIdQuery query = new GetByIdQuery(_dbContext);
            BooksViewModel result =new BooksViewModel();
            try
            {
                 result = query.Handle(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
            
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook (int id, [FromBody]UpdateBookModel updatedBook )
        {
            UpdateBookCommand command = new UpdateBookCommand(_dbContext);
            try
            {
                command.Model = updatedBook;
                command.Handle(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction("GetByID", new {id=id});
        }
    }
}
