using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TB.AspNetCore.Data.Entity
{
    public partial class ScheduleInfo
    {
        public int Id { get; set; }
        [DisplayName("任务组")]
        public string JobGroup { get; set; }
        [DisplayName("JobName")]
        public string JobName { get; set; }
        [DisplayName("运行状态")]
        public int RunStatus { get; set; }
        [DisplayName("Cron表达式")]
        public string CromExpress { get; set; }
        [DisplayName("开始运行时间")]
        public DateTime? StarRunTime { get; set; }
        [DisplayName("结束运行时间")]
        public DateTime? EndRunTime { get; set; }
        [DisplayName("下次运行时间")]
        public DateTime? NextRunTime { get; set; }
        public string Token { get; set; }
        public string AppId { get; set; }
        public string ServiceCode { get; set; }
        public string InterfaceCode { get; set; }
        public string TaskDescription { get; set; }
        [DisplayName("数据状态")]
        public int? DataStatus { get; set; }
        [DisplayName("任务添加者")]
        public string CreateAuthr { get; set; }
        [DisplayName("创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
