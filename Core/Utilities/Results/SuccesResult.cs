using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)  // işlemimizin başarılı olduğunu burada gösteriyoruz.
        {
            
        }
        public SuccessResult():base(true)
        {

        }
    }
}
