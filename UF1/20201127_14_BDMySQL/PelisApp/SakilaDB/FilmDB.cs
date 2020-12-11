using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;

namespace SakilaDB
{
    public class FilmDB
    {
        int film_id;
        string title;
        string description;
        int release_year;
        string languages;
        string rating;
        string special_features;

        public FilmDB(int film_id, string title, string description, int release_year, string languages, string rating, string special_features)
        {
            this.film_id = film_id;
            this.title = title;
            this.description = description;
            this.release_year = release_year;
            this.languages = languages;
            this.rating = rating;
            this.special_features = special_features;
        }
        #region properties
        public int Film_id { get => film_id; set => film_id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }

        public string DescriptionShort
        {
            get
            {
                if (Description.Length > 20)
                {
                    return Description.Substring(0, 20)+"...";
                }
                else return Description;
            }
        }
        public int Release_year { get => release_year; set => release_year = value; }
        public string Languages { get => languages; set => languages = value; }
        public string Rating { get => rating; set => rating = value; }
        public string Special_features { get => special_features; set => special_features = value; }
        #endregion



        public static ObservableCollection<FilmDB> getFilms(int actorId)
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
                            consulta.CommandText = 
                                $@"select f.film_id, f.title, f.description,
                                f.release_year, l.name as languages, f.rating, 
                                f.special_features
                                from film f, language l, film_actor fa
                                where 
                                 f.language_id = l.language_id and
                                 fa.film_id = f.film_id and
                                 fa.actor_id = @actorId
                                 ";
                            
                            DBUtils.crearParametre(consulta, "actorId", System.Data.DbType.Int32, actorId);

 
                            // B) llançar la consulta
                            DbDataReader reader = consulta.ExecuteReader();
                            // C) recórrer els resultats de la consulta
                            ObservableCollection<FilmDB> films = new ObservableCollection<FilmDB>();
                            while (reader.Read())
                            {

                                int film_id = reader.GetInt32(reader.GetOrdinal("film_id"));
                                string title = readString(reader, "title", "");
                                string description = readString(reader, "description", "");
                                int release_year = reader.GetInt32(reader.GetOrdinal("release_year"));//*
                                string languages = readString(reader, "languages","");
                                string rating = readString(reader, "rating", "");//*
                                string special_features = readString(reader, "special_features", "");//*

                                // Creem un actor
                                FilmDB a = new FilmDB(film_id, title, description, release_year, languages, rating, special_features);
                                films.Add(a);
                            }
                            return films;
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

        private static string readString(DbDataReader reader, string nomColumna, string valorPerDefecte)
        {
            string value = valorPerDefecte;
            int ordinal = reader.GetOrdinal(nomColumna);
            if (!reader.IsDBNull(ordinal))
            {
                value = reader.GetString(ordinal);//*
            }
            return value;
        }
    }
}
