using SakilaDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PelisApp.ViewModel
{
    public class ActorViewModel:INotifyPropertyChanged
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
        public int Actor_id { get => actor_id;
            set {
                actor_id = value;
                RaisePropertyChange();
            }
        }
        public string First_name { get => first_name; set
            {
                first_name = value;
                RaisePropertyChange();
            }
        }
        public string Last_name { get => last_name;
            set { last_name = value;
                RaisePropertyChange();
            } }
        public DateTimeOffset Last_update { get => last_update;
            set { last_update = value;
                RaisePropertyChange(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {   
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));     
        }




        #endregion
    }
}
