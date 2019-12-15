using System;
using UnityEngine;

namespace Tools
{
    public static class Logger
    {
        static readonly Color black = Color.black;
        const char Period = '.';
        const string OpenBrackets = "[";
        const char CloseBrackets = ']';
        const string OpenColor = ": <color=#{0}><b>";
        const string CloseColor = "</b></color>";

        public static void Log<T>(object log)
        {
            var coloredText = BuildColor(log); 
            var context = BuildContext<T>();
            PrintLog(context, coloredText, black);
        }

        public static void Log<T>(object log, Color color)
        {
            var coloredText = BuildColor(log); 
            var context = BuildContext<T>();
            PrintLog(context, coloredText, color);
        }

        static object BuildColor(object log) => $"{OpenColor}{log}{CloseColor}";

        static object BuildContext<T>() => $"{OpenBrackets}{GetTypeString(typeof(T))}{CloseBrackets}";

        static void PrintLog(object context, object log, Color color)
        {
            Debug.Log(string.Format($"{context}{log}", ColorUtility.ToHtmlStringRGBA(color)));
        }

        static string GetTypeString(Type t)
        {
            var split = t.ToString().Split(Period);
            return split[split.Length - 1];
        }
    }
}