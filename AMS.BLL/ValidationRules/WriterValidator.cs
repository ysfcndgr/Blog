using AMS.Model.Relotional;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BLL.ValidationRules
{   
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Yazar adı soyadı en az 5 karakterli olmak zorundadır");
            RuleFor(x => x.WriterName).MaximumLength(100).WithMessage("Yazar adı soyadı en fazla 100 karakterli olmak zorundadır");
            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("Parola en az 8 karakterli olmak zorundadır");
        }
    }
}
