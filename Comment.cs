namespace les3
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
