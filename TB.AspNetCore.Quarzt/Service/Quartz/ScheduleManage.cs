using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TB.AspNetCore.Data.Entity;

namespace TB.AspNetCore.Quarzt.Service.Quartz
{
    public class ScheduleManage : BaseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddSchedule(ScheduleInfo model)
        {
            var info = base.Single<ScheduleInfo>(t => t.Id == model.Id || (t.JobGroup == model.JobGroup && t.JobName == model.JobName));
            if (info == null)
            {
                base.Add(model, true);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void UpdateScheduleStatus(ScheduleInfo model)
        {
            var info = base.Where<ScheduleInfo>(t => t.JobName == model.JobName && t.JobGroup == model.JobGroup).FirstOrDefault();
            if (info != null)
            {
                info.RunStatus = model.RunStatus;
            }
            base.Update(info, true);
        }

        /// <summary>
        /// 查询任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ScheduleInfo GetScheduleModel(ScheduleInfo model)
        {
            var info = base.Where<ScheduleInfo>(t => t.JobGroup == model.JobGroup && t.JobName == model.JobName).FirstOrDefault();
            return info;
        }

        //
        /// <summary>
        /// 获取所有的定时任务
        /// </summary>
        /// <returns></returns>
        public IQueryable<ScheduleInfo> GetAllScheduleList()
        {
            var info = base.Where<ScheduleInfo>(t => true);
            return info;
        }
    }
}
