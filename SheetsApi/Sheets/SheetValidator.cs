using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheetsApi.Sheets
{
    public class SheetValidator : AbstractValidator<Sheet>
    {
        public SheetValidator()
        {
            RuleFor(sheet => sheet.Attacks).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.WeaponSkill).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.BallisticSkill).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.InvulnerableSave).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Save).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Wounds).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Leadership).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Movement).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Strength).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Toughness).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Name).NotEmpty();
        }
    }
}
