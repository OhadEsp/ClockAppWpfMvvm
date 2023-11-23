using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
//using DataAccess;
//using Models;
using MvvmFramework;
using Clock.ViewModels;

namespace Clock.Views {
    public class Bootstrapper : BootstrapperBase {
        private WindsorContainer container;

        protected override IEnumerable<Assembly> SelectAssemblies() {
            return new[] {typeof (MainViewModel).Assembly};
        }

        protected override void ConfigureForRuntime() {
            container = new WindsorContainer();
            //container.Register(
            //    Component.For<IDataProvider<Student>>()
            //        .ImplementedBy<StudentsXmlProvider>()
            //        .DependsOn(Dependency.OnValue<string>("StudentsRepo.xml"))
            //    );
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override void ConfigureForDesignTime() {
            container = new WindsorContainer();           
            RegisterViewModels();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override object GetInstance(Type service, string key) {
            return string.IsNullOrWhiteSpace(key)
                ? container.Resolve(service)
                : container.Resolve(key, service);
        }
   
        private void RegisterViewModels() {
            container.Register(Classes.FromAssembly(typeof(MainViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }
    }
}