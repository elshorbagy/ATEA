using Atea.Framework.Model;
using System;

namespace Atea.Framework
{
    public interface IRepository
    {
        event EventHandler<ResultArgs> ReadResult;

        void Create(int id, string message);

        void Read(int id);

        bool Delete(int id);

        void Update(int id, string message);
    }
}