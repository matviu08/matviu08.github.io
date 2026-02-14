namespace les3.Storage
{
    public interface ICommentStorage
    {
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<Comment> CreateCommentAsync(string ussername, string text);
    }
}
