﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace InstantJob.Persistence.Conventions
{
    public class InstantJobTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table($"`IJ_{instance.TableName.Replace("`", "")}`");
        }
    }
}
