using System;

namespace Tee.Collectables.Services.Extensions
{
    public static class Guard
    {
        public static void AgainstNull(object data, string operation)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"Expected not to be null while {operation}");
            }
        }
    }
}