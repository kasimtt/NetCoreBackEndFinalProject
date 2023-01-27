using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //İş kurallarını çalıştırma motoru.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)   // hatalı olan iş kuralını business'a bildiriyoruz.
            {
                if(!logic.Success)
                {
                    return logic;
                }

            }
            return null;
        }
    }
}
