using System.Runtime.CompilerServices;
using UnityEngine;

namespace Skiing2
{
    public static class SkiingLog
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Log(string msg)
        {
            Debug.Log(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogWarning(string msg)
        {
            Debug.LogWarning(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogError(string msg)
        {
            Debug.LogError(msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogAssert(bool condition, string msg)
        {
            Debug.Assert(condition, msg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogAssertWithoutMsg(bool condition)
        {
            Debug.Assert(condition);
        }
    }
}