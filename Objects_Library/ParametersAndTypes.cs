using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Objects_Library
{
    public class ParametersAndTypes:IEquatable<ParametersAndTypes>
    {
        public ParameterInfo[] Parameters;
        public Type Type;

        public ParametersAndTypes(ParameterInfo[] parameters, Type type)
        {
            if (parameters == null)
                throw new ArgumentNullException("Parameters cannot be null");
            Parameters = new ParameterInfo[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                Parameters[i] = parameters[i];
            }
            Type = type;
        }

        public void Clear()
        {
            Parameters = null;
            Type = null;
        }

        public bool Equals(ParametersAndTypes obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals(Parameters, obj.Parameters) && Equals(Type, obj.Type);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((ParametersAndTypes)obj);
        }
    }
}
