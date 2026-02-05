using UnityEngine;


namespace Core.Utils
{
    public static class DataUtility
    {
        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }


        public static T ToDeserialized<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }
}
