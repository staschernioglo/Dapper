using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet
{
    public interface IRepository<T>
    {
        void Insert(T item);
        List<T> Read();
        void Update(T item);
        void Delete(int id);
    }
}
