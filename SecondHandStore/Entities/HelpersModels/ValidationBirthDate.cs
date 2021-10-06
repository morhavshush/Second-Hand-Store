using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.HelpersModels
{
    public class ValidationBirthDate: RangeAttribute
    {
        public ValidationBirthDate()
          : base(typeof(DateTime),
                  DateTime.Now.AddYears(-90).ToShortDateString(),
                  DateTime.Now.AddYears(-12).ToShortDateString())
        { }

    }
}
