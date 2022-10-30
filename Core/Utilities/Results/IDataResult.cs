using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        // ne döndürdüğünü ProductManager da belirtiriz
        T Data { get; }
    }
}
