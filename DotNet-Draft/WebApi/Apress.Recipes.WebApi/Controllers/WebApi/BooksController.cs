﻿using Apress.Recipes.WebApi.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Apress.Recipes.WebApi.Controllers.WebApi
{
    public class BooksController : ApiController
    {
        public Book GetById(int id)
        {
            var book = Books.List.FirstOrDefault(x => x.Id == id);
            if (book == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return book;
        }
    }
}