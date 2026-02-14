using les3;
using les3.Storage;
using System.Net;
using System.Web;

ICommentStorage commentStorage = new DbCommentStorage();

await commentStorage.CreateCommentAsync("Nikita", "First");
await commentStorage.CreateCommentAsync("Oleg", "Second");

HttpListener httpServer = new HttpListener();
httpServer.Prefixes.Add("http://localhost:5000/");
httpServer.Start();

while (true)
{
    HttpListenerContext context = await httpServer.GetContextAsync();

    if(context.Request.HttpMethod == "POST")
    {
        using (var reader = new StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
        {
            string body = reader.ReadToEnd();

            var formData = HttpUtility.ParseQueryString(body);

            string username = formData["username"];
            string text = formData["text"];

            await commentStorage.CreateCommentAsync(username, text);
        }
    }


    var comments = await commentStorage.GetAllCommentsAsync();
    var html = HtmlRenderer.GetHtmlPage(comments);
    context.Response.ContentType = "text/html";

    using (StreamWriter sw = new StreamWriter(context.Response.OutputStream))
    {
        await sw.WriteAsync(html);
    }
    context.Response.OutputStream.Close();
}






















//using System.Net;

//HttpListener httpServer = new HttpListener();
//httpServer.Prefixes.Add("http://localhost:5000/");
//httpServer.Start();
//Console.WriteLine("http server Started");

//while (true)
//{
//    HttpListenerContext context = httpServer.GetContext();
//    HttpListenerRequest request = context.Request;
//    HttpListenerResponse response = context.Response;
//    Console.WriteLine($"new reques to {request.RawUrl}");

//    response.ContentType = "text/html";
//    response.StatusCode = 200;

//    using (StreamWriter streamWriter = new StreamWriter(response.OutputStream))
//    {
//        streamWriter.WriteLine("<h1><u style=\"color: red;\">Hello World</u></h1>");
//    }
//    response.OutputStream.Close();
//}