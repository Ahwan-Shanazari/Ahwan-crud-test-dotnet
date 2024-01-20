using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Presentation.Shared.Helpers;

public static class BankAccountValidator
{
    private static readonly Regex BankAccountRegex = new(@"^[0-9]{9,18}$");
    public static bool IsValid(string accountNumber)
    {
       
        Match match = BankAccountRegex.Match(accountNumber);
        
        return match.Success;
    }
}