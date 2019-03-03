namespace Rug.Domain.Team
{
    public class Address
    {
        public Address(string city, string postAddress)
        {
            // TODO: add validation

            City = city;
            PostAddress = postAddress;
        }

        public string City { get; private set; }

        public string PostAddress { get; private set; }

        public override string ToString()
        {
            return $"{City}, {PostAddress}";
        }
    }
}