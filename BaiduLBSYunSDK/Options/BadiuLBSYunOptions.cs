using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduLBSYunSDK.Options
{
    #region Options
    public enum BadiuLBSYunMethods
    {
        POST , GET
    }
    public enum BadiuLBSYunEntitys
    {
        geotable,column,poi,job
    }
    public enum BadiuLBSYunOperations
    {
        create, list,detail,update,delete,upload,listimportdata
    }
    /// <summary>
    /// 百度地理信息类型
    /// </summary>
    public enum BadiuGeoDatatypes:uint
    {
        POINT = 1, LINE = 2, FLAT = 3
    }
    /// <summary>
    /// 是否发布
    /// </summary>
    public enum BaiduIsPublisheds:uint
    {
        No = 0, Yes = 1
    }
    #region Column
    public enum ColumnType:uint
    {
        IsInt64 = 1, IsDouble = 2, IsString = 3, IsPicUrl = 4
    }
    /// <summary>
    /// 是否检索引擎的数值排序筛选字段
    /// </summary>
    public enum ColumnIsSortFilterField:uint
    {
       No = 0, Yes = 1
    }
    /// <summary>
    /// 是否检索引擎的文本检索字段
    /// </summary>
    public enum ColumnIsSearchFilterField:uint
    {
        No = 0, Yes = 1
    }
    /// <summary>
    /// 是否存储引擎的索引字段
    /// </summary>
    public enum ColumnIsIndexField:uint
    {
        NotSupported = 0, Supported = 1
    }
    /// <summary>
    /// 是否云存储唯一索引字段
    /// </summary>
    public enum ColumnIsUniqueField:uint
    {
        NotSupported = 0, Supported = 1
    }
    #endregion
    #region POI
    public enum PoiCoordType:uint
    {
        IsGPS = 1, IsCSBSM = 2, IsBaidu = 3, IsBaiduMercator = 4
    }
    #endregion
    public enum StatusCode
    {
 
    }
    #endregion
}
