using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using InstantJob.BuildingBlocks.Domain;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace InstantJob.Database.Persistence.CustomTypes
{
    internal class EnumerationType<T> : IUserType where T : Enumeration 
    {
        public SqlType[] SqlTypes => new[] { new SqlType(DbType.Int32) };

        public Type ReturnedType => typeof(T);

        public bool IsMutable => false;

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        bool IUserType.Equals(object x, object y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x?.GetHashCode() ?? 0;
        }

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var obj = NHibernateUtil.Int32.NullSafeGet(rs, names, session, owner);
            if (obj == null)
            {
                return null;
            }
            return Enumeration.FromInt<T>((int)obj);
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            Debug.Assert(cmd != null);

            if (value == null)
            {
                ((IDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
            }
            else
            {
                ((IDataParameter)cmd.Parameters[index]).Value = (int)(Enumeration)value;
            }
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}
