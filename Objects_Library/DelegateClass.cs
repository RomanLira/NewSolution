using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Objects_Library
{
    public class DelegateClass
    {
        private List<MethodInfo> _methodList = new List<MethodInfo>();
        public List<MethodInfo> MethodList => _methodList;
        public ParametersAndTypes SignatureOfMethod;

        public DelegateClass(MethodInfo method)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            _methodList = new List<MethodInfo> { method };
            SignatureOfMethod = new ParametersAndTypes(method.GetParameters(), method.ReturnType);
        }

        private bool ParametersEquality(ParameterInfo[] first, ParameterInfo[] second)
        {
            if (first.Length != second.Length)
                return false;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i].ParameterType != second[i].ParameterType)
                    return false;
            }
            return true;
        }

        public void Add(MethodInfo method)
        {
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (_methodList.Count == 0)
            {
                _methodList = new List<MethodInfo>();
                SignatureOfMethod = new ParametersAndTypes(method.GetParameters(), method.ReturnType);
            }
            if (method.ReturnType != SignatureOfMethod.Type || !ParametersEquality(method.GetParameters(), SignatureOfMethod.Parameters))
                throw new InvalidOperationException("Signatures are not equal");
            _methodList.Add(method);
        }

        public static DelegateClass operator +(DelegateClass first, DelegateClass second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            if(first == second)
            {
                var newMethodList = new List<MethodInfo>();
                newMethodList = newMethodList.Concat(first.MethodList).ToList();
                return first;
            }
            foreach (var method in second.MethodList)
            {
                first.Add(method);
            }
            return first;
        }

        public static DelegateClass operator -(DelegateClass first, DelegateClass second)
        {
            if (first == second)
            {
                first._methodList.Clear();
                first.SignatureOfMethod.Clear();
            }
            if (first.MethodList.Count == 0)
                return first;
            foreach (var methodInSecond in second.MethodList)
            {
                foreach (var methodInFirst in first.MethodList)
                {
                    if (Equals(methodInSecond, methodInFirst))
                        first.MethodList.Remove(methodInFirst);
                }
            }
            return first;
        }

        public object Invoke(object classInstance, object[] parameters)
        {
            if (_methodList.Count == 0)
                return null;
            foreach (var method in _methodList)
            {
                try
                {
                    return method.Invoke(classInstance, parameters);
                }
                catch (Exception exception)
                {
                    if (exception.InnerException != null)
                        Console.WriteLine(exception.InnerException.Message);
                }
            }
            return null;
        }
    }
}
