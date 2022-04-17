using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Vaflov {
    public class FancyTweener : MonoBehaviour {

        public Transform targetLeft;
        public Transform targetRight;

        void Start() {
            _ = FancyTween(gameObject.GetCancellationTokenOnDestroy());
        }

        public async UniTaskVoid FancyTween(CancellationToken token) {
            var rectTransform = GetComponent<RectTransform>();
            rectTransform.position = targetLeft.position;
            var image = GetComponent<Image>();
            var targets = new Transform[] { targetRight, targetLeft };
            var targetIndex = 1;
            while (true) {
                _ = Tweener.Color(image, Color.red)
                           .Duration(2)
                           .Ease(EaseType.IN_SLOW)
                           .WithCancellation(token);
                await Tweener.SizeDelta(rectTransform, new Vector2(200, 50))
                             .Duration(1.9f)
                             .Ease(EaseType.IN_SLOW)
                             .WithCancellation(token);
                if (token.IsCancellationRequested) { return; }

                targetIndex = 1 - targetIndex;
                var target = targets[targetIndex];
                _ = Tweener.Move(rectTransform, target.position)
                           .Duration(1)
                           .Ease(EaseType.OUT_ELASTIC)
                           .WithCancellation(token);
                _ = Tweener.Color(image, Color.white)
                           .Duration(1)
                           .Ease(EaseType.OUT_BOUNCE)
                           .WithCancellation(token);
                await Tweener.SizeDelta(rectTransform, new Vector2(50, 200))
                             .Duration(0.9f)
                             .Ease(EaseType.OUT_OVERSHOOT)
                             .WithCancellation(token);
                if (token.IsCancellationRequested) { return; };

                _ = Tweener.SizeDelta(rectTransform, new Vector2(100, 100))
                           .Duration(1)
                           .Ease(EaseType.IN_OUT_OVERSHOOT)
                           .WithCancellation(token);
                _ = Tweener.Rotate(rectTransform, Vector3.forward, 180)
                           .Duration(2)
                           .Ease(EaseType.IN_OUT_OVERSHOOT)
                           .Start(rectTransform)
                           .WithCancellation(token);
                await UniTask.Delay(1300, cancellationToken: token).SuppressCancellationThrow();
                if (token.IsCancellationRequested) { return; };
            }
        }
    }
}