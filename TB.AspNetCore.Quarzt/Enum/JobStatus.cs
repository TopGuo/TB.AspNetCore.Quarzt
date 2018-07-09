using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TB.AspNetCore.Quarzt.Enum
{
    public enum JobStatus
    {
        [Description("已启用")]
        已启用,
        [Description("运行中")]
        待运行,
        [Description("执行中")]
        执行中,
        [Description("执行完成")]
        执行完成,
        [Description("执行任务计划中")]
        执行任务计划中,
        [Description("已停止")]
        已停止,
    }
}
