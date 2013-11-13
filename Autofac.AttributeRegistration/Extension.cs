using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Autofac
{
    public static class Extension
    {
        public static void RegisterByAttributes(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            var registrations = from a in assemblies
                                from type in a.GetTypes()
                                from attribute in type.GetCustomAttributes(false)
                                where attribute is AutofacRegistrationAttribute
                                select new
                                           {
                                               Attribute = (AutofacRegistrationAttribute)attribute, 
                                               Type = type
                                           };


            foreach (var registration in registrations)
            {
                registration.Attribute.Register(builder, registration.Type);
            }
        }     
    }
}
