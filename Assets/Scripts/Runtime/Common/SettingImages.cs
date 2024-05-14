using System;
using UnityEngine;

namespace Skiing2
{
    [Serializable]
    public struct SettingImages
    {
        [Header("name")] public string name;
        public Sprite music;
        public Sprite cheerful;
        public Sprite background;
    }
}