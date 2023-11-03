namespace Learn80
{
    public struct  Person
    {
        private  static Person _origin=new Person();
        public readonly int Age { get; }
        public readonly string LastName { get; } // set; - error
        public override readonly string ToString() => $"{FirstName} {LastName}";
        public readonly ref readonly Person Origin => ref _origin;
        public string FirstName { get; set; }
        public Person(string firstName,string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = 1;
        }
        public void SetPerson(string firstName)
        {
            FirstName = firstName;
        }
    }
}