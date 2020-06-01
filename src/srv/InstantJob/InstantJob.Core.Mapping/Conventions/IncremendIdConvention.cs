﻿using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;

namespace InstantJob.Core.NHibernate.Conventions
{
    public class IncrementIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            if (instance.Type.Name.Contains("int", StringComparison.InvariantCultureIgnoreCase))
            {
                instance.GeneratedBy.Increment();
            }
        }
    }
}
