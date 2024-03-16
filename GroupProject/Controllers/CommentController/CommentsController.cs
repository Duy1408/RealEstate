using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.BusinessObject;
using Service.Interface;
using AutoMapper;
using BusinessObject.DTO;
using Service;
using BusinessObject.ViewModels;


namespace GroupProject.Controllers.CommentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _comment;
        private readonly IMapper _mapper;
        public CommentsController(ICommentService comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
        }


        // GET: api/Comments
        [HttpGet]
        public IActionResult GetAllComment()
        {
            try
            {
                if (_comment.GetAllComment() == null)
                {
                    return NotFound();
                }
                var comments = _comment.GetAllComment();
                var response = _mapper.Map<List<CommentDTO>>(comments);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public IActionResult GetCommentByID(int id)
        {
            var comment = _comment.GetCommentByID(id);


            var responese = _mapper.Map<CommentDTO>(comment);


            return Ok(responese);
        }

        [HttpPost]
        public IActionResult AddNewComment(CommentVM comment)
        {
            try
            {
                var comments = _mapper.Map<Comment>(comment);
                _comment.AddNewComment(comments);
                

                return Ok("Create successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public IActionResult UpdateComment(CommentDTO comment, int id)
        {
            try
            {
                if (comment.CommentID != id)
                {
                    return NotFound();
                }
                var comments = _mapper.Map<Comment>(comment);
                _comment.UpdateComment(comments);

                return Ok("Update successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (_comment.GetAllComment() == null)
            {
                return NotFound();
            }
            var comment = _comment.GetCommentByID(id);
            if (comment == null)
            {
                return NotFound();
            }
            _comment.DeleteComment(comment);

            return Ok("Delete successful");
        }


    }
}
