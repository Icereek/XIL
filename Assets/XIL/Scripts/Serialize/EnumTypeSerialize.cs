﻿using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

namespace wxb
{
    // 枚举类型
    class EnumTypeSerialize : ITypeSerialize
    {
        public EnumTypeSerialize(System.Type type)
        {
            enumType = type;
        }

        System.Type enumType;

        byte ITypeSerialize.typeFlag { get { return TypeFlags.enumType; } } // 类型标识

        void ITypeSerialize.WriteTo(object obj, IStream ms)
        {
            ms.WriteInt32((int)obj);
        }

        void ITypeSerialize.MergeFrom(ref object value, IStream ms)
        {
            int id = ms.ReadInt32();
            value = System.Enum.ToObject(enumType, id);
        }
    }
}