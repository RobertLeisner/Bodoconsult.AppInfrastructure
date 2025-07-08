//// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

//using System.Collections.Generic;
//using Bodoconsult.App.Interfaces;
//using RoyoTech.StSys.SQL.Model.App;

//namespace RoyoTech.StSys.Business.Helpers
//{
//    /// <summary>
//    /// Helper class for basic service methods
//    /// </summary>
//    public static class ServiceHelper
//    {
//        /// <summary>
//        /// Updates all currently loaded services implementing <see cref="IServiceRequiresAppSettingsUpdate"/>
//        /// </summary>
//        public static List<string> UpdateServices()
//        {

//            var result = new List<string>();

//            foreach (var x in Globals.Instance.DiContainer.ServiceCollection)
//            {

//                var type = x.ServiceType;

//                if (type == null || 
//                    !typeof(IServiceRequiresAppSettingsUpdate).IsAssignableFrom(type))
//                {
//                    continue;
//                }

//                var instance = (IServiceRequiresAppSettingsUpdate)Globals.Instance.DiContainer
//                                .ServiceProvider.GetService(type);

//                instance.UpdateService();

//                result.Add(instance.GetType().Name);

//            }

//            return result;
//        }
//    }
//}