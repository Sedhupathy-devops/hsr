using System;
using System.Collections.Generic;
using System.Text;

namespace ICS.DAL.Repos
{
    public interface IGenericRepository<TDto> where TDto : class
    {
        IEnumerable<TDto> GetAll();
        TDto Get(int Id); //Use long if needed
        void Add(TDto dto);
        void Update(TDto dto);
        TDto Delete(int Id); //Use long if neded
    }

    public class GenericRepository<TDto> : IGenericRepository<TDto> where TDto : class, new()
    {
        public IEnumerable<TDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TDto Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Add(TDto dto)
        {
            throw new NotImplementedException();
        }

        public void Update(TDto dto)
        {
            throw new NotImplementedException();
        }

        public TDto Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
