using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo item in properties)
            {
                MyValidationAttribute[] attributes = item.GetCustomAttributes()
                                                     .Where(a => a is MyValidationAttribute)
                                                     .Cast<MyValidationAttribute>().ToArray();

                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(item.GetValue(obj)))
                    {
                        return false;
                    }                    
                }
            }

            return true;
        }
    }
}
