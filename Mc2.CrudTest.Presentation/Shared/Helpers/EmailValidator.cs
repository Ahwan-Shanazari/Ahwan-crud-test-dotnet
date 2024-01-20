using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Presentation.Shared.Helpers;

public static class EmailValidator
{
    private static readonly Regex EmailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    public static bool IsValid(string email)
    {
       
        Match match = EmailRegex.Match(email);
        
        return match.Success;
    }
}