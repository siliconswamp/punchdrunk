using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class DictionaryExtensions
{
    public static Dictionary<Key, Value> Shuffle<Key, Value>(
       this Dictionary<Key, Value> set)
    {
        System.Random r = new System.Random();
        return set.OrderBy(x => r.Next())
           .ToDictionary(item => item.Key, item => item.Value);
    }
}