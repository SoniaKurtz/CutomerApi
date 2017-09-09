using CustomerWebApi.Domain.Faults;

namespace CustomerWebApi.Domain
{
    public sealed class TelephoneNumber
    {
        private string _value;

        public TelephoneNumber(string value)
        {
            Validate(value);
            _value = value;
        }

        private void Validate(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ValidationException("Telephone number should not be null or empty");
            }

            if(value.Length != 9)
            {
                throw new ValidationException("Telephone number should have lenght equal to 9 characters.");
            }
        }

        public static implicit operator TelephoneNumber(string value)
        {
            return new TelephoneNumber(value);
        } 

        public static implicit operator string(TelephoneNumber telephone)
        {
            return telephone._value;
        }
    }
}