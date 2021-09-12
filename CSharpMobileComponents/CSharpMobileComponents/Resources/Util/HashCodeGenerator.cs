using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMobileComponents.Resources.Util
{
    public static class HashCodeGenerator
    {
        public static int GenerateCustomControlHashCode()
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
