using System;
using System.Collections.Generic;
using System.Linq;
using MaterialCMS.Helpers;
using Ninject.Extensions.Conventions.BindingGenerators;
using Ninject.Syntax;

namespace MaterialCMS.IoC
{
    public class NinjectServiceToInterfaceBinder : IBindingGenerator
    {
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            var list = new List<IBindingWhenInNamedWithOrOnSyntax<object>>();
            if (type.IsInterface || type.IsAbstract)
            {
                return list;
            }

            IList<Type> interfaceTypes = type.GetInterfaces()
                .Where(t => TypeHelper.GetAllMaterialCMSAssemblies().Contains(t.Assembly))
                .ToList();

            if (interfaceTypes.Any())
            {
                var bindingWhenInNamedWithOrOnSyntaxs =
                    interfaceTypes.Select(interfaceType => bindingRoot.Bind(interfaceType).To(type));
                list.AddRange(bindingWhenInNamedWithOrOnSyntaxs);
            }
            else
            {
                // if the type has no interfaces - bind to self
                list.Add(bindingRoot.Bind(type).To(type));
            }

            return list;
        }
    }
}