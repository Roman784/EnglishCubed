using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageScroller : MonoBehaviour
{
    private RawImage _image;

    [SerializeField, Range(0, 10)] private float _scrollSpeed = 0.1f;

    [SerializeField, Range(-1, 1)] private float _xDirection = 1;
    [SerializeField, Range(-1, 1)] private float _yDirection = 1;

    [Space]

    [SerializeField] private float _defaultAspect = 1.7777f;

    private void Awake() => _image = GetComponent<RawImage>();


    private void Update()
    {
        var position = new Vector2(-_xDirection * _scrollSpeed, _yDirection * _scrollSpeed) * Time.time / 10f;
        var size = new Vector2(((float)Screen.width / Screen.height) * _defaultAspect, 1f);
        _image.uvRect = new Rect(position, size);
    }
}
