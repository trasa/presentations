/* Copyright 2008 Tony Rasa trasa@meancat.com
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under 
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF 
 * ANY KIND, either express or implied. See the License for the specific language 
 * governing permissions and limitations under the License.
 */
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using Blackfin.DataAccess;

namespace MissileCommand.Core
{
    public class LaunchSite
    {
        private int id;
        private string name;
        private double maxAltitude;

        public LaunchSite()
        {
        }

        public LaunchSite(SqlDataReader dr)
        {
            Id = dr.GetInt32(LaunchSiteIdField);
            Name = dr.GetString(LaunchSiteNameField);
            MaxAltitude = dr.GetDouble(MaximumAltitudeField);
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double MaxAltitude
        {
            get { return maxAltitude; }
            set { maxAltitude = value; }
        }

        #region Data Access Stuff

        public void Save()
        {
            if (Id == 0)
                AddNew();
            else
                Update();
        }

        private void AddNew()
        {
            #region string sql = "INSERT INTO ...";

            string sql = @"INSERT INTO LaunchSites (
LaunchSiteName, MaximumAltitude
) VALUES (
@LaunchSiteName, @MaximumAltitude
)";

            #endregion

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MissileCommandConnection"].ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SetParameters(cmd);
                    Id = Executor.RunSqlReturnId(cmd);
                }
            }
        }

        private void Update()
        {
            #region string sql = "UPDATE ... ";

            string sql = @"UPDATE LaunchSites SET 
LaunchSiteName = @LaunchSiteName,
MaximumAltitude = @MaximumAltitude
WHERE LaunchSiteId = @LaunchSiteId ";

            #endregion

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MissileCommandConnection"].ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SetParameters(cmd);
                    cmd.Parameters.AddWithValue("@LaunchSiteId", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SetParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@LaunchSiteName", Name);
            cmd.Parameters.AddWithValue("@MaximumAltitude", MaxAltitude);
        }


        public static string Select
        {
            get { return "SELECT LaunchSiteId, LaunchSiteName, MaximumAltitude FROM LaunchSites "; }
        }

        private const int LaunchSiteIdField = 0;
        private const int LaunchSiteNameField = 1;
        private const int MaximumAltitudeField = 2;

        #endregion

        public static Collection<LaunchSite> LaunchersInRange(Satellite sat)
        {
            // to determine what's in range (and what isn't) first we need a set of launchers,
            // then (because this information is very sensitive) we're going to use some other
            // dependencies to figure out what can hit this satellite.
            string sql = Select;
            Collection<LaunchSite> result = new Collection<LaunchSite>(); 
            foreach(LaunchSite site in DataReaderContainer.ExecuteCollection<LaunchSite>(sql, new MissileConnectionFactory()))
            {
                // TODO: perhaps there is some processing we can do up front to determine if the site is in range or not 
                // (obvious things to check: altitude)

                // targeting system needs to know: who, what, when.  it'll figure out how.
                TargetingSystem system = new TargetingSystem(new MainframeVectorProvider(), sat, site, DateTime.Now);
                if (system.IsInRange)
                {
                    result.Add(site);
                }
            }
            return result;
        }

        public static LaunchSite Get(int launcherId)
        {
            string sql = Select + " WHERE LaunchSiteId = @LaunchSiteId";
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@LaunchSiteId", launcherId);
                return DataReaderContainer.ExecuteObject<LaunchSite>(cmd, new MissileConnectionFactory());
            }
        }
    }
}