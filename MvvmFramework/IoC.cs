﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MvvmFramework {
    public static class IoC {
        /// <summary>
        /// Gets an instance by type and key.
        /// </summary>
        public static Func<Type, string, object> GetInstance =
            (service, key) => { throw new InvalidOperationException("IoC is not initialized."); };

        /// <summary>
        /// Gets all instances of a particular type.
        /// </summary>
        public static Func<Type, IEnumerable<object>> GetAllInstances =
            service => { throw new InvalidOperationException("IoC is not initialized."); };

        /// <summary>
        /// Passes an existing instance to the IoC container to enable dependencies to be injected.
        /// </summary>
        public static Action<object> BuildUp =
            instance => { throw new InvalidOperationException("IoC is not initialized."); };

        /// <summary>
        /// Gets an instance from the container.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <param name="key">The key to look up.</param>
        /// <returns>The resolved instance.</returns>
        public static T Get<T>(string key = null) {
            return (T) GetInstance(typeof (T), key);
        }

        public static object Get(Type type, string key = null) {
            return GetInstance(type, key);
        }

        /// <summary>
        /// Gets all instances of a particular type.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The resolved instances.</returns>
        public static IEnumerable<T> GetAll<T>() {
            return GetAllInstances(typeof (T)).Cast<T>();
        }
    }
}