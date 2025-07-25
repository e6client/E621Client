﻿using System;
using System.IO;

namespace Noppes.E621.Extensions
{
    /// <summary>
    /// Provides extra functionality to strings.
    /// </summary>
    internal static class StringExtensions
    {
        public static string GetPathExtensionWithoutDot(this string value, string? defaultValue = null)
        {
            string extension = Path.GetExtension(value).ToLower();

            if (string.IsNullOrEmpty(extension))
            {
                if (defaultValue != null)
                    return defaultValue.TrimStart('.');
                throw new ArgumentException($"{nameof(value)} is not a path with an extension.", nameof(value));
            }

            return extension.Substring(1, extension.Length - 1);
        }
    }
}
