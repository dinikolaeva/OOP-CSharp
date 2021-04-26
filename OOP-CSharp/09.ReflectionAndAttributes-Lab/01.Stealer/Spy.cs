using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] namesOfFields)
        {
            Type type = Type.GetType(nameOfClass);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                BindingFlags.Static | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            Object obj = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var field in fields.Where(f => namesOfFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(obj)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
