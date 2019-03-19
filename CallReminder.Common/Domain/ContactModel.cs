namespace CallReminder.Core.Domain
{
    public class ContactModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string PhotoUri { get; set; }

        public long PhotoFileId { get; set; }
    }
}
