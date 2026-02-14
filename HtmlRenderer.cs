namespace les3
{
    public static class HtmlRenderer
    {
        private static string GetCommentsDiv(IEnumerable<Comment> comments)
        {
            return $@"
<div class=""comments"">
                {string.Join('\n', comments.Select(GetCommentDiv))}
</div>
        ";
        }

        private static string GetCommentDiv(Comment comment)
        {
            return $@"
<div class=""comment"">
<div class=""comment-id"">ID: {comment.Id}</div>
<div class=""comment-username"">Username: {comment.Username}</div>
<div class=""comment-text"">{comment.Text}</div>
<div class=""comment-date"">Created at: {comment.CreateDate}</div>
</div>
        ";
        }

        public static string GetHtmlPage(IEnumerable<Comment> comments)
        {
            return $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""UTF-8"">
<title>Comments</title>
<style>
                    body {{
                        font-family: Arial, sans-serif;
                        max-width: 800px;
                        margin: 40px auto;
                        padding: 0 20px;
                        background-color: #f4f4f4;
                    }}
 
                    h1 {{
                        text-align: center;
                    }}
 
                    .comment-form {{
                        background: #ffffff;
                        padding: 20px;
                        border-radius: 8px;
                        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
                        margin-bottom: 40px;
                    }}
 
                        .comment-form label {{
                            display: block;
                            margin-top: 10px;
                            font-weight: bold;
                        }}
 
                        .comment-form input,
                        .comment-form textarea {{
                            width: 100%;
                            padding: 8px;
                            margin-top: 5px;
                            border-radius: 4px;
                            border: 1px solid #ccc;
                            box-sizing: border-box;
                        }}
 
                        .comment-form button {{
                            margin-top: 15px;
                            padding: 10px 15px;
                            border: none;
                            border-radius: 4px;
                            background-color: #4CAF50;
                            color: white;
                            cursor: pointer;
                        }}
 
                            .comment-form button:hover {{
                                background-color: #45a049;
                            }}
 
                    .comments {{
                        display: flex;
                        flex-direction: column;
                        gap: 20px;
                    }}
 
                    .comment {{
                        background: #ffffff;
                        padding: 15px;
                        border-radius: 8px;
                        box-shadow: 0 2px 6px rgba(0,0,0,0.08);
                    }}
 
                    .comment-id {{
                        font-size: 12px;
                        color: #888;
                    }}
 
                    .comment-username {{
                        font-weight: bold;
                        margin-top: 5px;
                    }}
 
                    .comment-text {{
                        margin-top: 10px;
                    }}
 
                    .comment-date {{
                        margin-top: 10px;
                        font-size: 12px;
                        color: #666;
                    }}
</style>
</head>
<body>
 
                <h1>Leave a Comment</h1>
 
                <div class=""comment-form"">
<form method=""POST"">
<label for=""username"">Username</label>
<input type=""text"" id=""username"" name=""username"" placeholder=""Enter your name"">
 
                        <label for=""text"">Comment</label>
<textarea id=""text"" name=""text"" rows=""4"" placeholder=""Enter your comment""></textarea>
 
                        <button type=""submit"">Submit</button>
</form>
</div>
 
                <h1>Comments</h1>
 
                {GetCommentsDiv(comments)}
 
            </body>
</html>
        ";
        }
    }
}
