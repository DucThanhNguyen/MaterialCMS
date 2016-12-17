using MaterialCMS.Indexing.Management;
using MaterialCMS.Indexing.Querying;
using MaterialCMS.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace MaterialCMS.IoC.Modules
{
    public class GenericBindingsModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(typeof(ITokenProvider<>)).To(typeof(PropertyTokenProvider<>)).InRequestScope();
            Kernel.Bind(typeof(IMessageParser<,>)).To(typeof(MessageParser<,>)).InRequestScope();
            Kernel.Bind(typeof(IMessageParser<>)).To(typeof(MessageParser<>)).InRequestScope();
            Kernel.Bind(typeof(IIndexManager<,>)).To(typeof(IndexManager<,>)).InRequestScope();
            Kernel.Bind(typeof(ISearcher<,>)).To(typeof(Searcher<,>)).InRequestScope();
        }
    }
}