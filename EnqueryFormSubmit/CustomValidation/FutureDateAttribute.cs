using System.ComponentModel.DataAnnotations;

namespace EnqueryFormSubmit.CustomValidation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            DateTime dt;
            if (DateTime.TryParse(value.ToString(), out dt))
            {
                return dt.Date >= DateTime.Now.Date;
            }

            return false;
        }
    }
}
