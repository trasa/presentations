﻿/* Copyright 2008 Tony Rasa trasa@meancat.com
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under 
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF 
 * ANY KIND, either express or implied. See the License for the specific language 
 * governing permissions and limitations under the License.
 */
//-----------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Template File Name: Exception.cst 
//     Generated: 2/27/2008 12:19:37 PM
// </autogenerated>
//-----------------------------------------------------------------------------
using System;
using System.Security.Permissions;

namespace MissileCommand.Core
{

    /// <summary>
    /// An exception that occurs during a Demo :)  
    /// Usually because there was some specific piece of setup that wasn't done.
    /// </summary>
    [Serializable]
    public class DemoException : Exception
    {

        #region Constructors

        /// <summary>
        /// Create a DemoException.
        /// </summary>
        public DemoException() { }

        /// <summary>
        /// Create a DemoException.
        /// </summary>	
        /// <param name="msg">A Message describing the details of the exception.</param>
        public DemoException(string msg) : base(msg) { }

        /// <summary>
        /// Create a DemoException.
        /// </summary>
        /// <param name="msg">A Message describing the details of the exception</param>
        /// <param name="inner">Details of an inner exception</param>
        public DemoException(string msg, Exception inner) : base(msg, inner) { }

        /// <summary>
        /// Create a DemoException. 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DemoException(System.Runtime.Serialization.SerializationInfo info,
                                System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        #endregion

        /// <summary>
        /// Streams all the exception properties into the SerializationInfo class for the given StreamingContext.
        /// </summary>
        /// <param name="info">The SerializationInfo object.</param>
        /// <param name="context">The StreamingContext object.</param>
        /// <example>
        ///		<code>
        ///			base.GetObjectData(info, context);
        ///			info.AddValue("variableName", variableName);
        ///		</code>
        /// </example>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            base.GetObjectData(info, context);
            // info.AddValue("variableName", variableName);
        }
    }
}
