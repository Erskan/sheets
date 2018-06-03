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
            RuleFor(sheet => sheet.Attacks).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.WeaponSkill).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.BallisticSkill).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.InvulnerableSave).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Save).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Wounds).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Leadership).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Movement).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Strength).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Toughness).GreaterThanOrEqualTo(0);
            RuleFor(sheet => sheet.Name).NotEmpty();
        }
    }
}
