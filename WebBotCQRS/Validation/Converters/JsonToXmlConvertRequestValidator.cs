using FluentValidation;
using WebBotCQRS.Queries.Converters;

namespace WebBotCQRS.Validation.Converters
{
    public class JsonToXmlConvertRequestValidator : AbstractValidator<JsonToXmlConvertRequest>
    {
        public JsonToXmlConvertRequestValidator()
        {
            RuleFor(c => c.JsonEndPoint)
                .Matches("^https*.+$")
                .WithMessage("JsonEndPont should start with https or http");
        }
    }
}
