﻿using Sipay_Cohorts_HW3.DataAccess.Context;
using Sipay_Cohorts_HW3.Entities.DbSets;
using Sipay_Cohorts_HW3.Entities.Enums;

namespace Sipay_Cohorts_HW3.Api.BookOperations
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                throw new ArgumentNullException("Belirtilen ID ile bir kayıt bulunamadı.");

            }

            book.Title = Model.Title !=default ? Model.Title: book.Title ;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            _dbContext.Update(book);
            _dbContext.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }
            public Genre GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
