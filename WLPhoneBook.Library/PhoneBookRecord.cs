namespace WLPhoneBook.Library
{
    public class PhoneBookRecord
    {
        public string Building { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBookRecord(string building, string section, string subsection, string position, string name, string description, string phoneNumber)
        {
            Building = building;
            Section = section;
            Subsection = subsection;
            Position = position;
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Building} | {Section} | {Subsection} | {Position} | {Name} | {Description} | {PhoneNumber}";
        }
    }
}
