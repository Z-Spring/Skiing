using UnityEngine;

namespace Skiing2
{
    public class SoundEntity : MonoBehaviour
    {
        public AudioSource AudioSource { get; set; }
        public AudioClip Bgm { get; set; }
        public AudioClip Dead { get; set; }
        public AudioClip Fever { get; set; }
        public AudioClip LevelUp { get; set; }
        public AudioClip Ski { get; set; }
        public AudioClip Perfect { get; set; }
    }
}