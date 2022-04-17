using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vaflov {
    public class Rotator : MonoBehaviour {
        public EaseType easeType;
        public TweenLoopMode loopMode;
        [Range(0, 5)] public float duration;

        void Start() {
            Tweener.Rotate(transform, 0, 0, 360)
                   .Ease(easeType)
                   .Duration(duration)
                   .LoopMode(loopMode)
                   .Continuous();
        }
    }
}