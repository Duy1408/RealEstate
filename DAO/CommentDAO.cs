using BusinessObject.BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CommentDAO
    {
        private readonly TheRealEstateDBContext _context;
        public CommentDAO()
        {
            _context = new TheRealEstateDBContext();
        }

        public List<Comment> GetAllComment()
        {
            try
            {
                return _context.Comments.Include(a => a.RealEstate)
                                     .Include(a => a.User).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddNewComment(Comment comment)
        {
            try
            {
                _context.Add(comment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public void UpdateComment(Comment comment)
        {
            try
            {
                _context.Attach(comment).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Comment GetCommentByID(int id)
        {
            try
            {
                var comment = _context.Comments.SingleOrDefault(c => c.CommentID == id);
                return comment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteComment(Comment comment)
        {
            var a = _context.Comments.FirstOrDefault(a => a.CommentID == comment.CommentID);
            _context.Comments.Remove(a);

            _context.SaveChanges();
        }

    }
}
