using FluentValidation;

namespace TestAPI.Models.CustomModels
{
    public class RequestModel
    {
        public int PageIndex { get; set; }  

        public int PageSize { get; set; }


      
    }


    public class RequestModelValidator : AbstractValidator<RequestModel>
    {
        public RequestModelValidator() 
        {
            RuleFor(r => r.PageIndex)
                .NotEmpty().GreaterThanOrEqualTo(1).WithMessage("PageIndex Must be greater than or equal 1");

            RuleFor(r => r.PageSize)
                .NotEmpty().GreaterThan(1).WithMessage("Page size must be greater than 1");
        }

    }
}
