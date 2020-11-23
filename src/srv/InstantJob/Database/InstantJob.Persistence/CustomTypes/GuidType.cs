using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace InstantJob.Database.Persistence.CustomTypes
{
    internal class GuidType : IUserType
    {
        public SqlType[] SqlTypes => new[] { new SqlType(DbType.String) };

        public Type ReturnedType => typeof(Guid);

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
            var obj = NHibernateUtil.String.NullSafeGet(rs, names, session, owner);
            if (obj == null)
            {
                return null;
            }
            return Guid.Parse((string)obj);
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
                ((IDataParameter)cmd.Parameters[index]).Value = value.ToString();
            }
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    }
}
