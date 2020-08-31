using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Goibibo
{
    public enum AttributeOperationType
    {
        PreferAttribute,
        ForceAttribute,
        ForceProperty,
        Default = PreferAttribute
    }

    public static class AttributeOperationTypeParser
    {
        public static AttributeOperationType Parse(string operationTypeName)
        {
            if (string.IsNullOrEmpty(operationTypeName))
                return AttributeOperationType.Default;

            return (AttributeOperationType)Enum.Parse(typeof(AttributeOperationType), operationTypeName, true);
        }
    }
}
