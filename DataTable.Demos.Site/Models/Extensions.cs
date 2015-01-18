using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTable.Demos.Site.Models.Extensions
{
    public static class StringExtensions
    {

        public static string TrimToLower(this string value) {
            return value.Trim().ToLower();
        }
    }
}