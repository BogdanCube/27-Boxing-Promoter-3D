using DG.Tweening;
using UnityEngine;

namespace Toolkit.Extensions
{
    public static class DOTweenExtensions 
    {
        public static Tween DOLocalMoveArc(this Transform transform, Vector3 position,float timeUp,float timeDown)
        {
            transform.DOLocalMoveX(position.x, timeUp).SetEase(Ease.OutQuad);
            transform.DOLocalMoveZ(position.z, timeDown).SetEase(Ease.OutQuad);
            return transform.DOLocalMoveY(position.y, timeDown).SetEase(Ease.InQuart);
        }
    }
}