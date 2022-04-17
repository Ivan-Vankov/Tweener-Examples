using UnityEngine;

namespace Vaflov {
    public class Translator : MonoBehaviour {
        public Transform moveAnchor;
        public EaseType easeType;
        public TweenLoopMode loopMode;
        [Range(0, 5)] public float duration;

        void Start() {
            Tweener.Move(transform, moveAnchor.position)
                   .Ease(easeType)
                   .Duration(duration)
                   .LoopMode(loopMode)
                   .Continuous();
        }
    }
}