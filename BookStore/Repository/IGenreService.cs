﻿using BookStore.Models;

namespace BookStore.Repository
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        bool Delete(int id);
        Genre FindById(int id);
        IEnumerable<Genre> GetAll();
    }
}
