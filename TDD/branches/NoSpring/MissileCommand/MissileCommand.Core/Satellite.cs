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
    /// <summary>
    /// </summary>
    /// <remarks>
    /// Your basic "entity" object.
    /// There are a lot of ways to solve this type of problem (get stuff from the database), 
    /// which aren't really the focus of this demo, which is why this is a very simple approach.
    /// </remarks>
    public class Satellite
    {
        private int id;
        private string name;
        private double altitude;

        public Satellite()
        {
        }

        public Satellite(SqlDataReader dr)
        {
            Id = dr.GetInt32(SatelliteIdField);
            Name = dr.GetString(SatelliteNameField);
            Altitude = dr.GetDouble(OrbitalAltitudeField);
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

        public double Altitude
        {
            get { return altitude; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", value, "Altitude cannot be negative");
                altitude = value;
            }
        }

        public double OrbitalVelocity
        {
            get
            {
                // v = sqrt(mG/r)
                const double EarthMass = 5.9736e+24;
                const double EarthRadiusInKilometers = 6371.01;
                const double G = 6.673e-11; // Newtonian constant of gravitation

                // we're working with km, but we need to adjust in the formula for meters
                double satRadiusInMeters = (EarthRadiusInKilometers + Altitude) * 1000;
                return System.Math.Sqrt(G * EarthMass / satRadiusInMeters) / 1000;
            }
        }


        #region Data Access Code...

        public void Save()
        {
            if (Id == 0)
                AddNew();
            else
                Update();
        }

        private void AddNew()
        {
            #region string sql = "INSERT INTO...";
            string sql = @"INSERT INTO Satellites (
SatelliteName, OrbitalAltitude
) VALUES (
@SatelliteName, @OrbitalAltitude
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
            #region string sql = "UPDATE Satellites...";
            string sql = @"UPDATE Satellites SET 
SatelliteName = @SatelliteName,
OrbitalAltitude = @OrbitalAltitude
WHERE SatelliteId = @SatelliteId ";
            #endregion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MissileCommandConnection"].ConnectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    SetParameters(cmd);
                    cmd.Parameters.AddWithValue("@SatelliteId", Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SetParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@SatelliteName", Name);
            cmd.Parameters.AddWithValue("@OrbitalAltitude", Altitude);
        }


        public static string Select
        {
            get { return "SELECT SatelliteId, SatelliteName, OrbitalAltitude FROM Satellites "; }
        }

        private const int SatelliteIdField = 0;
        private const int SatelliteNameField = 1;
        private const int OrbitalAltitudeField = 2;

        #endregion

        public static Collection<Satellite> GetList()
        {
            return DataReaderContainer.ExecuteCollection<Satellite>(Select, new MissileConnectionFactory());
        }

        public static Satellite Get(int id)
        {
            string sql = Select + " WHERE SatelliteId = @SatelliteId";
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                cmd.Parameters.AddWithValue("@SatelliteId", id);
                return DataReaderContainer.ExecuteObject<Satellite>(cmd, new MissileConnectionFactory());
            }
        }

    }
}
