using AMS.Model.Relotional;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı  en az 5 karakterli olmak zorundadır");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Blog başlığı  en fazla 100 karakterli olmak zorundadır");
            RuleFor(x => x.BlogContent).MinimumLength(250).WithMessage("İçerik en az 8 karakterli olmak zorundadır");
        }
    }
}
