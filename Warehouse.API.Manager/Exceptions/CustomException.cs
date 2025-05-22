namespace Warehouse.API.Manager.Exceptions
{
    public class CustomException : Exception
    {
        public Dictionary<string, string> validations { get; set; }

        public CustomException(Dictionary<string, string> Validations)
        {
            validations = Validations;
        }
    }
}
