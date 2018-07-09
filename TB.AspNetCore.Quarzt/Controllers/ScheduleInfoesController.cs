using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TB.AspNetCore.Data.Entity;
using TB.AspNetCore.Quarzt.Service.Quartz;

namespace TB.AspNetCore.Quarzt.Controllers
{
    public class ScheduleInfoesController : Controller
    {
        protected ScheduleManage _context = new ScheduleManage();
        ggb_offlinebetaContext ggb_OfflinebetaContext = new ggb_offlinebetaContext();


        // GET: ScheduleInfoes
        public async Task<IActionResult> Index()
        {
            var info = _context.GetAllScheduleList().ToListAsync();
            return View(await info);
        }


        // GET: ScheduleInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduleInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,JobGroup,JobName,RunStatus,CromExpress,StarRunTime,EndRunTime,NextRunTime,Token,AppId,ServiceCode,InterfaceCode,TaskDescription,DataStatus,CreateAuthr,CreateTime")] ScheduleInfo scheduleInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleInfo);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleInfo);
        }

        public void StartTask(int? id)
        {
            var info= ggb_OfflinebetaContext.ScheduleInfo.SingleOrDefault(t => t.Id == id);
            _context.AddSchedule(info);
        }

        public void StopTask(int? id)
        {
            var info = ggb_OfflinebetaContext.ScheduleInfo.SingleOrDefault(t => t.Id == id);
            _context.UpdateScheduleStatus(info);
        }

        // GET: ScheduleInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleInfo = await ggb_OfflinebetaContext.ScheduleInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleInfo == null)
            {
                return NotFound();
            }

            return View(scheduleInfo);
        }

        // POST: ScheduleInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleInfo = await ggb_OfflinebetaContext.ScheduleInfo.FindAsync(id);
            ggb_OfflinebetaContext.ScheduleInfo.Remove(scheduleInfo);
            await ggb_OfflinebetaContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
