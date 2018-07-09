using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TB.AspNetCore.Data.Entity;

namespace TB.AspNetCore.Quarzt.Service
{
    public class BaseService
    {
        protected static object obj = new object();
        public ggb_offlinebetaContext _context;
        protected ggb_offlinebetaContext DataContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new ggb_offlinebetaContext();
                }
                return _context;
            }
        }


        public BaseService()
        {

        }

        #region 封装基crud
        /// <summary>
        /// 只能是唯一记录 多记录引发异常
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TSource Single<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class
        {
            if (predicate == null)
            {
                return this.DataContext.Set<TSource>().SingleOrDefault();
            }

            return this.DataContext.Set<TSource>().SingleOrDefault(predicate);
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TSource First<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class
        {
            if (predicate == null)
            {
                return this.DataContext.Set<TSource>().FirstOrDefault();
            }
            return this.DataContext.Set<TSource>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// where条件查询
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TSource> Where<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class
        {
            if (predicate == null)
            {
                return this.DataContext.Set<TSource>().AsQueryable();
            }
            return this.DataContext.Set<TSource>().Where(predicate);
        }

        /// <summary>
        /// 记录数
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count<TSource>(Expression<Func<TSource, bool>> predicate = null)
            where TSource : class
        {
            if (predicate == null)
            {
                return this.DataContext.Set<TSource>().Count();
            }
            return this.DataContext.Set<TSource>().Count(predicate);
        }

        /// <summary>
        /// 根据条件判断记录是否存在
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// Any确定序列是否包含任何元素
        public bool Exists<TSource>(Expression<Func<TSource, bool>> predicate = null) where TSource : class
        {
            if (predicate == null)
            {
                return this.DataContext.Set<TSource>().Any();
            }
            return this.DataContext.Set<TSource>().Any(predicate);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public IQueryable<TSource> Query<TSource>()
            where TSource : class
        {
            return this.DataContext.Set<TSource>();
        }

        /// <summary>
        /// paging the query 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex">page index</param>
        /// <param name="pageSize">page size </param>
        /// <param name="count">total row record count</param>
        /// <returns></returns>
        public IQueryable<T> Pages<T>(IQueryable<T> query, int pageIndex, int pageSize, out int count) where T : class
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            count = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> Pages<T>(int pageIndex, int pageSize, out int count) where T : class
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }
            var query = this.DataContext.Set<T>().AsQueryable();
            count = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
        #endregion

        /// <summary>
        /// 做一次提交
        /// </summary>
        #region Save Changes
        public void Save()
        {
            //todo 需要验证是否需要释放
            using (this.DataContext)
            {
                this.DataContext.SaveChanges();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        public void Add(object entity, bool save = false)
        {
            this.DataContext.Add(entity);
            if (save)
            {
                this.Save();
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        public void Update(object entity, bool save = false)
        {
            this.DataContext.Update(entity);
            if (save)
            {
                this.Save();
            }
        }
        /// <summary>
        /// 更新2
        /// </summary>
        /// <param name="list"></param>
        /// <param name="save"></param>
        public void Update(IEnumerable<object> list, bool save = false)
        {
            this.DataContext.UpdateRange(list);
            if (save)
            {
                this.Save();
            }
        }
        /// <summary>
        /// 删除1
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        public void Delete(object entity, bool save = false)
        {
            this.DataContext.Remove(entity);
            if (save)
            {
                this.Save();
            }
        }
        /// <summary>
        /// 删除2
        /// </summary>
        /// <param name="list"></param>
        /// <param name="save"></param>
        public void Delete(IEnumerable<object> list, bool save = false)
        {
            this.DataContext.RemoveRange(list);
            if (save)
            {
                this.Save();
            }
        }
        #endregion

        ///// <summary>
        ///// 释放资源
        ///// </summary>
        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
