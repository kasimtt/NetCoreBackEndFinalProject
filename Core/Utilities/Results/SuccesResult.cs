using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccesResult:Result
    {
        public SuccesResult(string message):base(true,message)  // işlemimizin başarılı olduğunu burada gösteriyoruz.
        {
            
        }
        public SuccesResult():base(true)
        {

        }
    }
}
