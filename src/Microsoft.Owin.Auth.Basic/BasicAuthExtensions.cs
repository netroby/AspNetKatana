﻿// <copyright file="BasicAuthExtensions.cs" company="Katana contributors">
//   Copyright 2011-2012 Katana contributors
// </copyright>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Owin.Auth.Basic;

namespace Owin
{
    using AuthCallback = Func<IDictionary<string, object> /*env*/, string /*user*/, string /*psw*/, Task<bool>>;

    public static class BasicAuthExtensions
    {
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, BasicAuthMiddleware.Options options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, Func<string, string, Task<bool>> authenticate)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                Authenticate = (env, user, pass) => authenticate(user, pass)
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, AuthCallback authenticate)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                Authenticate = authenticate
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, Func<string, string, Task<bool>> authenticate, string realm)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                Realm = realm,
                Authenticate = (env, user, pass) => authenticate(user, pass)
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, AuthCallback authenticate, string realm)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                Realm = realm,
                Authenticate = authenticate
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, Func<string, string, Task<bool>> authenticate, bool requireEncryption)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                RequireEncryption = requireEncryption,
                Authenticate = (env, user, pass) => authenticate(user, pass)
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
        public static IAppBuilder UseBasicAuth(this IAppBuilder builder, AuthCallback authenticate, bool requireEncryption)
        {
            if (authenticate == null)
            {
                throw new ArgumentNullException("authenticate");
            }

            var options = new BasicAuthMiddleware.Options
            {
                RequireEncryption = requireEncryption,
                Authenticate = authenticate
            };
            return builder.UseType<BasicAuthMiddleware>(options);
        }
    }
}