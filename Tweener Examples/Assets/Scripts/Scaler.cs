using UnityEngine;

namespace Vaflov {
    public class Scaler : MonoBehaviour {
        public Vector2 targetSizeDelta;
        public EaseType easeType;
        public TweenLoopMode loopMode;
        [Range(0, 5)] public float duration;

        void Start() {
            // For scaling of non-UI objects there is Tweener.Scale
            Tweener.SizeDelta(GetComponent<RectTransform>(), targetSizeDelta)
                   .Ease(easeType)
                   .Duration(duration)
                   .LoopMode(loopMode)
                   .Continuous();
        }
    }
}