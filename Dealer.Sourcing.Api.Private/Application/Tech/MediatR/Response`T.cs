namespace Dealer.Sourcing.Api.Private.Application.Tech.MediatR
{
    public class Response<T> : Response where T : class
    {
        public Response(T result)
        {
            SetResult(result);
        }
    }
}
