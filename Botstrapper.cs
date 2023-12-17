using JourneyJoy.Controllers;
using JourneyJoy.Interface.LogIn;
using JourneyJoy.Interface.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;

namespace JourneyJoy
{
    public static class Botstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ILogIn, Login>();
            container.RegisterType<IVehicle, Vehicle>();
            return container;
        }
    }
}