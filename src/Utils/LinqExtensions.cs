﻿using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModIOManagerCLI.Utils;
public static class LinqExtensions
{
    public static T? FuzzyFind<T>(this IEnumerable <T> source, Func<T, string> propertySelector, string searchText, int minMatchPercent = 60)
    {
        var item = (from x in source
                      let ratio = Fuzz.Ratio(propertySelector(x), searchText)
                      orderby ratio descending
                      where ratio > minMatchPercent
                      select x).FirstOrDefault();
        return item;
    }
}
