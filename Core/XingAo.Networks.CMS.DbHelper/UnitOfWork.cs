using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Common;
using System.Data;
using XingAo.Networks.CMS.Common;
using System.Data.Entity.Validation;
using XingAo.Core;

namespace XingAo.Networks.CMS.DbHelper
{
    public class UnitOfWork : IDisposable
    {

        DbConnectionProvider provider { get; set; }
        private bool lazyLoadingEnabled = true;
        /// <summary>
        /// 数据库操作类
        /// </summary>
        public UnitOfWork()
        {
 
            provider = new DbConnectionProvider("DefaultConnectionString", ConfigStringType.appSettings);
        }
        /// <summary>
        /// 多库操作时使用，指定哪个连接名称
        /// </summary>
        /// <param name="DefaultConnectionString">配置多库操作，先在appconfig指定连接名称，再在Connection.config写上此名称对应连接字符串</param>
        public UnitOfWork(string DefaultConnectionString = "DefaultConnectionString")
        {

            provider = new DbConnectionProvider(DefaultConnectionString, ConfigStringType.appSettings);
        }
        /// <summary>
        /// 数据库操作类
        /// </summary>
        /// <param name="LazyLoadingEnabled">是否启用延时加载</param>
        public UnitOfWork(bool LazyLoadingEnabled)
        {
            lazyLoadingEnabled = LazyLoadingEnabled;
            provider = new DbConnectionProvider("DefaultConnectionString", ConfigStringType.appSettings);
        }
        private AppDbContext dbContext;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public AppDbContext DbContext
        {
            get {
                if (dbContext == null)
                {
                    string dbEncry = string.Empty;
                    try
                    {
                        dbEncry = DbConnectionProvider.GetSetting("ConStringEncrypt");
                    }
                    catch { }

                    if (!string.IsNullOrEmpty(dbEncry) && dbEncry == "true")
                    {
                        provider.ConnectionString = provider.ConnectionString.DecryptStr();
                    }

                    dbContext = new AppDbContext(provider.ConnectionString);
                   
                }
                dbContext.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
                return dbContext;
            }


        }

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (DbContext != null)
                DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 提交事务返回影响行数
        /// </summary>
        public int Commit()
        {
            string info = string.Empty;
            return Commit(out info);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="errMsg">成功返回空，否则返回错误信息</param>
        /// <returns>影响数量</returns>
        public int Commit(out string errMsg)
        {
            errMsg = "";
            int result = 0;
            try
            {
                result = DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// 检测能否链接数据库
        /// </summary>
        /// <returns></returns>
        public bool CheckConnect(out string err)
        {
            try
            {
                if (DbContext.Database.Connection.State ==System.Data.ConnectionState.Closed)
                {
                    DbContext.Database.Connection.Open();
                    DbContext.Database.Connection.Close();
                }
                err = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                err = ">>" + ex.Message;
                return false;
            }

        }

       /// <summary>
       /// 查找所有数据
       /// </summary>
       /// <typeparam name="TEntity"></typeparam>
       /// <returns></returns>
        public IQueryable<TEntity> FindAll<TEntity>() where TEntity : class
        {
            return DbContext.Set<TEntity>();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="KeyId">对象的主键值，0为插入 否则为更新</param>
        /// <returns></returns>
        public TEntity Save<TEntity>(TEntity entity,int KeyId) where TEntity : class
        {
            return KeyId > 0 ? Update(entity) : Insert(entity);
        } 
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
        {
            TEntity e = DbContext.Set<TEntity>().Add(entity);
            return e;
        }        
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry<TEntity>(entity).State = System.Data.EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// 通过ID来找数据（注意如果主键名称不是ID为会出错）
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
        {
            //需要改进，当主键不为Id的时候，将会报错
            return GetByKey<TEntity>("ID", keyValue);
        }
        /// <summary>
        /// 通过主键字段名来找数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="PrimaryKey">主键字段名</param>
        /// <param name="keyValue">主键的值</param>
        /// <returns></returns>
        public TEntity GetByKey<TEntity>(string PrimaryKey, object keyValue) where TEntity : class
        {
            try
            {
                Type type = typeof(TEntity).GetType();
                TableAttribute att = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).Single();
                string eSql = string.Format(
                    "SELECT * FROM {0} AS entity WHERE entity.{2}={1}", att.Name, keyValue, PrimaryKey);
                var objectQuery = DbContext.Database.SqlQuery<TEntity>(eSql, new object[] { });
                return objectQuery.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> FindBySpecification<TEntity>(Expression<Func<TEntity, bool>> spec) where TEntity : class
        {
            return DbContext.Set<TEntity>().Where(spec);
        }
        /// <summary>
        /// 通过自定义条件来查找数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="spec">条件表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindByFunc<TEntity>(Func<TEntity, bool> spec) where TEntity : class
        {
            return DbContext.Set<TEntity>().Where(spec);
        }

        /// <summary>
        /// 根据条件返回第一条数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="spec">条件表达式</param>
        /// <returns></returns>
        public TEntity FindSigne<TEntity>(Expression<Func<TEntity, bool>> spec) where TEntity : class
        {
            return DbContext.Set<TEntity>().Where(spec).FirstOrDefault();
        }

        /// <summary>
        /// 设置删除标识并未删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public bool Remove<TEntity>(Func<TEntity, bool> whereLambda) where TEntity : class
        {
            return Remove<TEntity>(whereLambda,false);
        }

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="whereLambda">要删除的条件表达式</param>
        /// <param name="isCommit">是否马上删除，false时将等待事务提交后才会删除</param>
        /// <param name="errMsg">返回错误信息</param>
        /// <returns>返回是否删除成功，true-成功，false-不成功</returns>
        public bool Remove<TEntity>(Func<TEntity, bool> whereLambda, bool isCommit, out string errMsg) where TEntity : class
        {
            errMsg = "";
            try
            {
                var tmp = DbContext.Set<TEntity>().Where(whereLambda);//根据条件从数据库中获取对象集合
                foreach (var entity in tmp)
                    DbContext.Entry<TEntity>(entity).State = System.Data.EntityState.Deleted;
                if (isCommit)
                    return Commit() > 0;
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        ///  删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="whereLambda">要删除的条件表达式</param>
        /// <param name="isCommit">是否马上删除，false时将等待事务提交后才会删除</param>
        /// <returns>返回是否删除成功，true-成功，false-不成功</returns>
        public bool Remove<TEntity>(Func<TEntity, bool> whereLambda, bool isCommit) where TEntity : class
        {
            string errMsg = string.Empty;
            return Remove<TEntity>(whereLambda, isCommit, out errMsg);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="entity">需要删除的实体</param>
        /// <param name="isCommit">是否马上删除，false时将等待事务提交后才会删除</param>
        /// <returns>返回是否删除成功，true-成功，false-不成功</returns>
        public bool Remove<TEntity>(TEntity entity, bool isCommit) where TEntity : class
        {
            try
            {
                DbContext.Entry<TEntity>(entity).State = System.Data.EntityState.Deleted;
                if (isCommit)
                    return Commit() > 0;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 执行存储过程语句（不建议使用）
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TEntity> ExecPro<TEntity>(string query, params object[] parameters) where TEntity : class
        {
            return DbContext.Database.SqlQuery<TEntity>(query, parameters).ToList();
        }

       

        #region 分页
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="Lambda">条件表达式</param>
        /// <returns></returns>
        public IEnumerable<TEntity> LoadWhereLambda<TEntity>(Expression<Func<TEntity, bool>> Lambda) where TEntity : class
        {
            return DbContext.Set<TEntity>().Where(Lambda);
        }
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="Lambda">条件表达式</param>
        /// <param name="orderBy">排序表达式</param>
        /// <param name="CurPage">当前页码（第一页为1）</param>
        /// <param name="PageSize">每页显示数据数量</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public IEnumerable<TEntity> LoadWhereLambda<TEntity>(Expression<Func<TEntity, bool>> Lambda, Func<IQueryable<TEntity>,
          IOrderedQueryable<TEntity>> orderBy, int CurPage, int PageSize, out int RecordCount) where TEntity : class
        {
            var source = DbContext.Set<TEntity>().Where(Lambda);
            RecordCount = source.Count();
            return orderBy(source).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList();
        }


        /// <summary>
        /// 分页条件查询 不返回记录条数
        /// </summary>
        /// <typeparam name="TEntity">Model.xxxx</typeparam>
        /// <param name="Lambda">条件</param>
        /// <param name="orderBy">排序</param>
        /// <param name="CurPage">当前第几页，【注意：第一页为1，不是0】</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <returns></returns>
        public IEnumerable<TEntity> LoadWhereLambda<TEntity>(Expression<Func<TEntity, bool>> Lambda, Func<IQueryable<TEntity>,
          IOrderedQueryable<TEntity>> orderBy, int CurPage, int PageSize) where TEntity : class
        {
            var source = DbContext.Set<TEntity>().Where(Lambda);
            return orderBy(source).Skip((CurPage - 1) * PageSize).Take(PageSize);
        }
        #endregion

        /// <summary>
        /// 执行存储过程，并返回是否执行成功
        /// </summary>
        /// <param name="CommandText">存储过程名</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public bool ExecPro(string CommandText, Dictionary<string, object> parameters)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = CommandText;
                
                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value= parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行存储过程返回dataset
        /// </summary>
        /// <param name="CommandText">要执行的存储过程名</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public DataSet ExecDataSetByPro(string CommandText, Dictionary<string, object> parameters)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = CommandText;

                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value = parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        /// <summary>
        /// 使用sql语句来取dataset
        /// </summary>
        /// <param name="CommandText">sql语句</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public DataSet ExecSql(string CommandText, Dictionary<string, object> parameters)
        {
            int RecordCount=0;
            return ExecSql(CommandText, parameters, 1, int.MaxValue, out RecordCount);
        }
        /// <summary>
        /// 使用sql语句来分页取dataset
        /// </summary>
        /// <param name="CommandText">sql语句或存储过程（注意：CommandText带空格的就认为是sql语句，无空格的则认为是存储过程）</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <param name="CurPage">当前第几页，从1开始</param>
        /// <param name="PageSize">每页显示记录数</param>
        /// <param name="RecordCount">返回总记录数</param>
        /// <returns></returns>
        public DataSet ExecSql(string CommandText, Dictionary<string, object> parameters,int CurPage,int PageSize,out int RecordCount)
        {
            DataSet ds = new DataSet();
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = CommandText;

                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value = parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                if (CommandText.IndexOf(" ") > -1)
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                RecordCount = ds.Tables[0].Rows.Count;
                if (CurPage < 1)
                    CurPage = 1;
                ds = new DataSet();
                adapter.Fill(ds,(CurPage - 1) * PageSize, PageSize, "srcTable");
               
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            finally
            {
                conn.Close();               
            }
            return ds;
        }
        /// <summary>
        /// 使用sql语句来操作数据库
        /// </summary>
        /// <param name="CommandText">sql语句</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string CommandText, Dictionary<string, object> parameters)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = CommandText;

                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value = parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.CommandType = CommandType.Text;
               return  cmd.ExecuteNonQuery()>0;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 使用sql语句或存储过程来取首行首列
        /// </summary>
        /// <param name="CommandText">sql语句</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public object ExecuteScalar(string CommandText, Dictionary<string, object> parameters)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();                
                cmd.CommandText = CommandText;
                
                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value = parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                if (CommandText.IndexOf(" ") > 0 && CommandText.ToLower().IndexOf("select") >= 0)
                    cmd.CommandType = CommandType.Text;
                else
                   cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteScalar() ;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 取DataTable
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public DataTable GetProDataTable(string CommandText)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection sqlconn = DbContext.Database.Connection;
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();

                DbCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = CommandText;
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            finally
            {
                sqlconn.Close();
            }
        }
        /// <summary>
        /// 取dataset
        /// </summary>
        /// <param name="CommandText">存储过程名</param>
        /// <param name="parameters">参数(参数的key不要加@,没有参数则为null)</param>
        /// <returns></returns>
        public DataSet GetProDataSet(string CommandText, Dictionary<string, object> parameters)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection conn = DbContext.Database.Connection;
            DataSet ds = new DataSet();
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = CommandText;
                if (parameters != null)
                {
                    DbParameter param;
                    cmd.Parameters.Clear();
                    foreach (string key in parameters.Keys)
                    {
                        param = factory.CreateParameter();
                        param.Value = parameters[key];
                        param.ParameterName = key;
                        cmd.Parameters.Add(param);
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string ConectString()
        {
            return DbContext.Database.Connection.ConnectionString;
        }

        public DataTable GetProDataTable(string CommandText, out DbDataAdapter adapter)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider.ProviderName);
            DbConnection sqlconn = DbContext.Database.Connection;
            try
            {
                if (sqlconn.State == ConnectionState.Closed)
                    sqlconn.Open();
                DbCommand cmd = sqlconn.CreateCommand();
                cmd.CommandText = CommandText;

                adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = cmd;
                DbCommandBuilder scb = factory.CreateCommandBuilder();
                scb.DataAdapter = adapter;

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            finally
            {
                sqlconn.Close();
            }
        }
    }
}
