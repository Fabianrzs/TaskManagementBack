using System.Runtime.CompilerServices;
namespace Domain.Commons
{
    public class CallerMember
    {
        public static string GetNameMethod([CallerMemberName] string caller = null)
        {
            return caller;
        }

        public static string GetClassName(dynamic model)
        {
            return model.GetType().ToString();
        }
    }
}
