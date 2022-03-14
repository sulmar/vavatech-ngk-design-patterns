namespace PrototypePattern
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public string FullName => string.Format("{0} {1}", FirstName, LastName);

        public string FullName => $"{FirstName} {LastName}";

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
