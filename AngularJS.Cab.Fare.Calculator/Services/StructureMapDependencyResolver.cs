using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using AngularJS.Cab.Fare.Calculator.DependencyResolution;
using System.Web.Mvc;
using System.Web.Http.Dependencies;

namespace AngularJS.Cab.Fare.Calculator.Services
{
    public class StructureMapDependencyResolver : StructureMapDependencyScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
        }
        public IDependencyScope BeginScope()
        {
            IContainer child = this.Container.GetNestedContainer();
            return new StructureMapDependencyResolver(child);
        }
    }
}