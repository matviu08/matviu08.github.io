using Microsoft.Data.SqlClient;

namespace les3.Storage
{
    public class DbCommentStorage : ICommentStorage
    {
        private List<Comment> _comments = [];

        public async Task<Comment> CreateCommentAsync(string username, string text)
        {
            Comment comment = new Comment
            {
                Username = username,
                Text = text
            };
            _comments.Add(comment);
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {
            return _comments;
        }
    }
}
