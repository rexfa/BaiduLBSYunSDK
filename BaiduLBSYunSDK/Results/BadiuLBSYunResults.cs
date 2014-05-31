using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduLBSYunSDK.Results
{
    #region Results
    [Serializable]
    public struct BadiuLBSYunResult
    {
        //success = 0,others...........
        public int status;
        //describe for status
        public string message;
        // new data id
        public string id;
        public UInt32 size;
        public UInt32 total;
        public List<Geotable> geotables;
        public Geotable geotable;
        public List<Column> columns;
        public Column column;
    }
    [Serializable]
    public struct Geotable
    {
        public string id;
        public int Geotype;
        public string Name;
        public int Is_published;
        public string Create_time;
        public string Modify_time;
    }
    [Serializable]
    public struct Column
    {
        public string id;
        public string geotable_id;
        public string name;
        public string key;
        public UInt32 type;
        public UInt32 max_length;
        public string default_value;
        public UInt32 create_time;
        public UInt32 modify_time;
        public UInt32 is_sortfilter_field;
        public UInt32 is_search_field;
        public UInt32 is_index_field;
        public UInt32 is_unique_field;
    }

    public interface IPoi
    { }
    [Serializable]
    public class PoiBase :IPoi
    {
        public string title;
        public string Address;
        public string tags;
        public double latitude;
        public double longitude;
        public UInt32 coord_type;
        public string Geotable_id;
        public string Ak;
        public string Sn;
    }
    #endregion
}
