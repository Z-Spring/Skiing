using UnityEngine;

namespace Skiing2
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