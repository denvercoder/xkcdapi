using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xkcdapi.Services.Cron
{
    [Serializable]
    public enum CrontabFieldKind
    {
        Minute,
        Hour,
        Day,
        Month,
        DayOfWeek
    }
}
