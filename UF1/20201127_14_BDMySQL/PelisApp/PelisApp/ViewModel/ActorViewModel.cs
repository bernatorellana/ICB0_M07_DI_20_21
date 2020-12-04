using SakilaDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PelisApp.ViewModel
{
    public class ActorViewModel
    {

        private int actor_id;
        private string first_name;
        private string last_name;
        private DateTimeOffset last_update;

        public ActorViewModel()
        {
            Actor_id = -1;
            First_name = "";
            Last_name = "";
            Last_update = DateTimeOffset.Now;
        }

        public ActorViewModel(ActorDB actor)
        {
            this.Actor_id = actor.Actor_id;
            this.Last_name = actor.Last_name;
            this.First_name = actor.First_name;
            this.Last_update = actor.Last_update;
        }

        #region propietats
        public int Actor_id { get => actor_id; set => actor_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public DateTimeOffset Last_update { get => last_update; set => last_update = value; }
        #endregion
    }
}
