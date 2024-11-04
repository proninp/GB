namespace Timesheets.Infrastructure.Extensions;

public static class ObjectExtension
{
    public static void EnsureNotNull(this object @object, string name)
    {
        if (@object == null)
        {
            throw new ArgumentNullException(name, $"Parameter {name} can not be Null.");
        }
    }
}
