using System;
using UnityEngine;

namespace Common.Attributes
{
    public class TitleAttribute : PropertyAttribute
    {
        public string Title { get; private set; }
        
        public TitleAttribute(string title)
        {
            Title = title;
        }
    }
}