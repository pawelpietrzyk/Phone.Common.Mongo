using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Common.Mongo
{
    public enum DayOffType
    {
        DayOff,
        Balance        
    }
    [DataContract]
    public class MongoDayOffSum : MongoDocument
    {
        public DateTime Updated
        {
            get
            {
                return DateTime.ParseExact(this.updatedTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            set
            {
                this.updatedTime = value.ToString("yyyy-MM-dd HH:mm:ss");
                OnPropertyChanged("UpdatedTime");
            }
        }

        private string updatedTime;
        [DataMember(Name = "updatedTime")]
        public string UpdatedTime
        {
            get { return updatedTime; }
            set
            {
                updatedTime = value;
                this.Updated = this.Updated;
            }
        }

        private int state;
        [DataMember(Name = "state")]
        public int State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

    }

    [DataContract]
    public class MongoDayOff : MongoDocument
    {
        private bool edit;
        [DataMember(Name = "edit")]
        public bool Edit
        {
            get { return edit; }
            set
            {
                edit = value;
                OnPropertyChanged("Edit");
            }
        }

        private DayOffType type;
        [DataMember(Name = "type")]
        public DayOffType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public DateTime Date
        {
            get
            {
                return DateTime.ParseExact(this.date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            set
            {
                this.date = value.ToString("yyyy-MM-dd");
                OnPropertyChanged("Date");
            }
        }
        private string date;
        [DataMember(Name = "date")]
        public string DateString
        {
            get { return date; }
            set
            {
                date = value;
                this.Date = this.Date;
                OnPropertyChanged("DateString");
            }
        }        
        private int state;
        [DataMember(Name = "state")]
        public int State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        public override object Clone()
        {
            MongoDayOff day = new MongoDayOff();
            if (this.Id != null)
            {
                day.Id = this.Id.Clone() as MongoId;
            }
            day.state = this.state;
            day.type = this.type;
            day.date = this.date;
            day.edit = this.edit;
            return day;
        }
    }

    public class MongoDayOffs : ObservableCollection<MongoDayOff>
    {

    }    
}
