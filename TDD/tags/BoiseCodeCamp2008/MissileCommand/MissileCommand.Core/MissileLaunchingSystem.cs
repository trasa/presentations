﻿/* Copyright 2008 Tony Rasa trasa@meancat.com
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under 
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF 
 * ANY KIND, either express or implied. See the License for the specific language 
 * governing permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MissileCommand.Core
{
    public class MissileLaunchingSystem : IMissileLaunchingSystem
    {
        /// <summary>
        /// Sends the launch orders.
        /// </summary>
        /// <param name="solution">The solution.</param>
        /// <returns>true if successful, false otherwise</returns>
        public string SendLaunchOrders(FiringSolution solution)
        {
            #region Incredibly complicated, top-secret, and very sensitive launch system happens here

            return "Fired a Very Real Missile with warhead, caused an international incident. (Congrats)";

            #endregion
        }
    }
}
