using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Environment.Zone.Model
{
    public class ModelZone : MonoBehaviour
    {
        [SerializeField] private float _durationPop = 0.4f;
        [SerializeField] private float _scalePop = 1.05f;
        [SerializeField] private float _durationScale = 0.5f;
        [SerializeField] private Image _image;
        [SerializeField] private Image _outline;
        [Space][SerializeField] private DetectorCharacter _detector;
        [SerializeField] private LevelZone _levelZone;
        private Color _color;

        #region Enable / Disable
        private void OnEnable()
        {
            _levelZone.OnUpdate += SetSize;
            _detector.OnEnter += PopUp;
            _detector.OnExit += PopDown;
        }
        private void OnDisable()
        {
            _levelZone.OnUpdate -= SetSize;
            _detector.OnEnter -= PopUp;
            _detector.OnExit -= PopDown;
        }
        #endregion

        private void Start()
        {
            _color = _image.color;
            _image.color = Color.white;
        }

        private void SetSize()
        {
            var currentTempate = _levelZone.CurrentTemplate;
            _image.sprite = currentTempate.Background;
            _outline.sprite = currentTempate.Outline;
                
            var detectorTransform = _detector.transform;
            var tempVector = detectorTransform.localScale;
            var size = _levelZone.CurrentTemplate.Size;
            tempVector.x = size.x;
            tempVector.z = size.y;
            detectorTransform.DOScale(tempVector,_durationScale);
        }
        private void PopUp()
        {
            _image.DOColor(_color, _durationPop);
            transform.DOScale(Vector3.one * _scalePop, _durationPop).SetEase(Ease.Flash);
            
        }
        private void PopDown()
        {
            _image.DOColor(Color.white, _durationPop);
            transform.DOScale(Vector3.one, _durationPop).SetEase(Ease.Flash);
           
        }
    }
}