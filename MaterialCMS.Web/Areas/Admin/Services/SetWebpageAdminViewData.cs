using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialCMS.Entities.Documents.Web;
using MaterialCMS.Helpers;
using Ninject;

namespace MaterialCMS.Web.Areas.Admin.Services
{
    public class SetWebpageAdminViewData : ISetWebpageAdminViewData
    {
        private readonly IKernel _kernel;

        static SetWebpageAdminViewData()
        {
            AssignViewDataTypes = new Dictionary<Type, HashSet<Type>>();

            foreach (Type type in TypeHelper.GetAllConcreteMappedClassesAssignableFrom<Webpage>().Where(type => !type.ContainsGenericParameters))
            {
                var hashSet = new HashSet<Type>();

                var thisType = type;
                while (thisType != null && typeof(Webpage).IsAssignableFrom(thisType))
                {
                    foreach (var assignType in TypeHelper.GetAllConcreteTypesAssignableFrom(
                        typeof(BaseAssignWebpageAdminViewData<>).MakeGenericType(thisType)))
                    {
                        hashSet.Add(assignType);
                    }
                    thisType = thisType.BaseType;

                }

                AssignViewDataTypes.Add(type, hashSet);
            }
        }

        public SetWebpageAdminViewData(IKernel kernel)
        {
            _kernel = kernel;
        }

        private static readonly Dictionary<Type, HashSet<Type>> AssignViewDataTypes;

        public void SetViewData<T>(T webpage, ViewDataDictionary viewData) where T : Webpage
        {
            if (webpage == null)
            {
                return;
            }
            var type = webpage.GetType();
            if (AssignViewDataTypes.ContainsKey(type))
            {
                foreach (
                    var assignAdminViewData in
                        AssignViewDataTypes[type].Select(assignViewDataType => _kernel.Get(assignViewDataType))
                    )
                {
                    var adminViewData = assignAdminViewData as BaseAssignWebpageAdminViewData;
                    if (adminViewData != null) adminViewData.AssignViewDataBase(webpage, viewData);
                }
            }
        }
    }
}