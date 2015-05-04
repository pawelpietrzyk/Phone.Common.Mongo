using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Mongo
{
    
    [DataContract]
    public class MongoId : INotifyPropertyChanged
    {
        private string _oid;
        [DataMember(Name = "$oid")]
        public string oid
        {
            get { return this._oid; }
            set
            {
                this._oid = value;
                OnPropertyChanged("oid");
            }
        }

        public override string ToString()
        {
            return oid;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }        
        public object Clone()
        {
            MongoId id = new MongoId();
            id.oid = this.oid;
            return id;
        }
        public override int GetHashCode()
        {
            if (!String.IsNullOrEmpty(this.oid))
            {
                return this.oid.GetHashCode();
            }
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            MongoId id = obj as MongoId;
            if (id != null)
            {
                return String.Equals(id.oid, this.oid);
            }
            return false;
        }
    }
    [DataContract]
    public class MongoDocument : INotifyPropertyChanged
    {
        private MongoId id;
        [DataMember(Name = "_id")]
        public MongoId Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }        
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public override string ToString()
        {
            if (Id != null)
            {
                return Id.ToString();
            }
            return String.Empty;
        }

        public virtual object Clone()
        {
            MongoDocument doc = new MongoDocument();
            if (this.id != null)
            {
                doc.id = this.id.Clone() as MongoId;
            }            
            return doc;
        }
        public override bool Equals(object obj)
        {
            MongoDocument doc = obj as MongoDocument;
            if (doc != null)
            {
                if (this.Id != null && doc.Id != null)
                {
                    return this.Id.Equals(doc.Id);
                }
            }
            return false;
        }
    }
}
