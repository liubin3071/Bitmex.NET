﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET
{
    public static class StringExtensions
    {
        public static string FirstToLower(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
                return str;

            return char.ToLowerInvariant(str[0]) + str.Substring(1);
        }
    }
}