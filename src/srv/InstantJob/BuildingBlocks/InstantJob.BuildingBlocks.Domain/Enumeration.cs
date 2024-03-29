﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InstantJob.BuildingBlocks.Domain
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // json ctor
        protected Enumeration()
        {
        }

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return typeof(T)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue))
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public static bool operator ==(Enumeration e1, Enumeration e2)
        {
            if (Equals(e1, null))
            {
                if (Equals(e2, null))
                {
                    return true;
                }

                return false;
            }
            return e1.Equals(e2);
        }

        public static bool operator !=(Enumeration e1, Enumeration e2)
        {
            return !(e1 == e2);
        }

        public int CompareTo(object other)
            => Id.CompareTo(((Enumeration)other).Id);

        public static explicit operator int(Enumeration enumeration)
            => enumeration.Id;

        public static bool ContainsId<T>(int id) where T : Enumeration
            => GetAll<T>().Any(e => e.Id == id);

        public static T FromInt<T>(int id) where T : Enumeration
            => GetAll<T>().Single(e => e.Id == id);

        public static T FromString<T>(string name) where T : Enumeration
            => GetAll<T>().SingleOrDefault(e => e.Name == name);
    }
}
