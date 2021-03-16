namespace Dealer.Sourcing.Api.Private.Application.Tech.Validation
{
    public class ValidationError
    {
        public string ErrorMessage { get; }
        public string MemberName { get; }

        public ValidationError(string memberName, string errorMessage)
        {
            ErrorMessage = errorMessage;
            MemberName = memberName;
        }
    }
}
