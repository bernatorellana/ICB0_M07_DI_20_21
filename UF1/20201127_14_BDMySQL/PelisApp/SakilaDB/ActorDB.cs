using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SakilaDB
{
    public class ActorDB
    {
        private int actor_id;
        private string first_name;
        private string last_name;
        private DateTime last_update;

        public ActorDB(int actor_id, string first_name, string last_name, DateTime last_update)
        {
            this.Actor_id = actor_id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Last_update = last_update;
           
        }
        #region propietats
        public int Actor_id { get => actor_id; set => actor_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public DateTime Last_update { get => last_update; set => last_update = value; }
        #endregion

        public static List<ActorDB> getActors(String nameFilter="")
        {
            try
            {
                using (SakilaDB context = new SakilaDB())
                {
                    using (var connexio = context.Database.GetDbConnection())
                    {
                        connexio.Open();

                        using (var consulta = connexio.CreateCommand())
                        {
                            // A) definir la consulta
                            consulta.CommandText = "select * from actor";

                            if(nameFilter!=null && !nameFilter.Equals(""))
                            {
                                consulta.CommandText += " where first_name like '" + nameFilter + "%'";
                            }
                            // B) llançar la consulta
                            DbDataReader reader = consulta.ExecuteReader();
                            // C) recórrer els resultats de la consulta
                            List<ActorDB> actors = new List<ActorDB>();
                            while (reader.Read())
                            {
                                int actor_id = reader.GetInt32(reader.GetOrdinal("actor_id"));
                                string first_name = reader.GetString(reader.GetOrdinal("first_name"));
                                string last_name = reader.GetString(reader.GetOrdinal("last_name"));
                                DateTime last_update = reader.GetDateTime(reader.GetOrdinal("last_update"));
                                // Creem un actor
                                ActorDB a = new ActorDB(actor_id, first_name, last_name, last_update);
                                actors.Add(a);
                            }
                            return actors;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Deixar registre al log (coming soon)
            }
            return null;
        }

    }
}
