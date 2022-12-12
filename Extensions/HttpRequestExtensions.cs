namespace WEB_053502_Selhanovich.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest httpRequest)
        {
            return httpRequest.Headers["x-requested-with"]
                .ToString().ToLower().Equals("xmlhttprequest");
        }
    }
}
