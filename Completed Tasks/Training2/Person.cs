namespace Training2
{
    public struct Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string CompareWithAge(int compareAge)
        {
            if (compareAge > 0)
            {
                return Age > compareAge ? $"{Name} {Surname} older than {compareAge}" : $"{Name} {Surname} younger than {compareAge}";
            }
            else
            {
                throw new InvalidArgumentException("Invalid compare age");
            }
        }
    }
}
