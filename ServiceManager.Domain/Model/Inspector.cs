namespace ServiceManager.Domain.Model
{
    public class Inspector
    {
        public Inspector(string firstName, string lastName, CityEnum city, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public CityEnum City { get; }
        public string PhoneNumber { get; }
    }
}