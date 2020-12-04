﻿using Microsoft.EntityFrameworkCore;
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

        public static List<ActorDB> getActors(String nameFilter, String surnameFilter, DateTime lastUpdate, int midaPagina, int numPagina)
        {
            try
            {
                using (SakilaDB context = new SakilaDB())
                {
                    using (var connexio = context.Database.GetDbConnection())
                    {
                        connexio.Open();

                        using (DbCommand consulta = connexio.CreateCommand())
                        {
                            // A) definir la consulta
                            consulta.CommandText = $@"select * from actor 
                                                    where
                                                    (@nameFilter = '%%' or  first_name like @nameFilter ) and
                                                    (@surnameFilter = '%%' or last_name like @surnameFilter) and
                                                    last_update > @lastUpdate
                                                    limit {numPagina*midaPagina}, {midaPagina}
                                                    ";
                            //                                                                      posem el % per tal que el like funcioni !!
                            DBUtils.crearParametre(consulta, "nameFilter", System.Data.DbType.String, "%"+nameFilter+"%");
                            DBUtils.crearParametre(consulta, "surnameFilter", System.Data.DbType.String, "%" + surnameFilter + "%");
                            DBUtils.crearParametre(consulta, "lastUpdate", System.Data.DbType.DateTime, lastUpdate);

                            /*if(nameFilter!=null && !nameFilter.Equals(""))
                            {
                                consulta.CommandText += " and first_name like @name_filter";
                                DbParameter p = consulta.CreateParameter();
                                p.ParameterName = "name_filter";
                                p.DbType = System.Data.DbType.String;
                                p.Value = "%"+nameFilter+"%";
                                consulta.Parameters.Add(p);
                            }*/


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


        public static int getNumeroActors(String nameFilter, String surnameFilter, DateTime lastUpdate)
        {
            Int32 numeroActors = 0;
            try
            {
                using (SakilaDB context = new SakilaDB())
                {
                    using (var connexio = context.Database.GetDbConnection())
                    {
                        connexio.Open();
                        using (DbCommand consulta = connexio.CreateCommand())
                        {
                            // A) definir la consulta
                            consulta.CommandText = $@"select count(1) from actor 
                                                    where
                                                    (@nameFilter = '%%' or  first_name like @nameFilter ) and
                                                    (@surnameFilter = '%%' or last_name like @surnameFilter) and
                                                    last_update > @lastUpdate
                                                    ";
                            //                                                                      posem el % per tal que el like funcioni !!
                            DBUtils.crearParametre(consulta, "nameFilter", System.Data.DbType.String, "%" + nameFilter + "%");
                            DBUtils.crearParametre(consulta, "surnameFilter", System.Data.DbType.String, "%" + surnameFilter + "%");
                            DBUtils.crearParametre(consulta, "lastUpdate", System.Data.DbType.DateTime, lastUpdate);



                            // B) llançar la consulta
                            var r = consulta.ExecuteScalar();
                            numeroActors = (Int32)((long)r);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Deixar registre al log (coming soon)
            }
            return numeroActors;
        }

        public bool Update()
        {
            DbTransaction trans = null;
            try
            {
                using (SakilaDB context = new SakilaDB())
                {
                    using (var connexio = context.Database.GetDbConnection())
                    {
                        connexio.Open();
                        using (DbCommand consulta = connexio.CreateCommand())
                        {
                            trans = connexio.BeginTransaction();
                            consulta.Transaction = trans;
                            // A) definir la consulta
                            consulta.CommandText = $@"
                                    update actor  
	                                    set first_name = @firstName,
	                                    last_name = @lastName,
	                                    last_update =@lastUpdate
                                     where actor_id= @actorId";
                            DBUtils.crearParametre(consulta, "firstName", System.Data.DbType.String, this.First_name);
                            DBUtils.crearParametre(consulta, "lastName", System.Data.DbType.String, this.Last_name);
                            DBUtils.crearParametre(consulta, "lastUpdate", System.Data.DbType.DateTime, this.Last_update);
                            DBUtils.crearParametre(consulta, "actorId", System.Data.DbType.Int32, this.Actor_id);



                            // B) llançar la consulta
                            int  filesAfectades = consulta.ExecuteNonQuery();
                            if(filesAfectades!=1)
                            {
                                trans.Rollback();
                            } else
                            {
                                trans.Commit();
                                return true;
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Deixar registre al log (coming soon)
            }

            return false;
        }
    }
}