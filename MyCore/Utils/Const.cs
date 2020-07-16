using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Utils
{
    public class Const
    {
        /// <summary>
        /// 日期时间格式化
        /// </summary>
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期时间格式化
        /// </summary>
        public const string DateHmFormatString = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// 日期格式化
        /// </summary>
        public const string DateFormatString = "yyyy-MM-dd";

        /// <summary>
        /// utc 1601-1-1 到 utc 1970-1-1 的 Ticks
        /// </summary>
        public const long TiksUtc1970 = 621355968000000000;

        public const long TimestampMax = 9999999999;

        /// <summary>
        /// 米=》英尺
        /// </summary>
        public const double M2FT = 3.28084;
        public const double MI2M = 1609.34;
        public const double FT2MI = 0.000189394;
        public const double DEG2RAD = 0.017453292519943295;
        public const double RAD2DEG = 57.29577951308232;
    }
}
