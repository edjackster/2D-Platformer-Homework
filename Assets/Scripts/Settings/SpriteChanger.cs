using System;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Image))]
public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _firstSprite;
    [SerializeField] private Sprite _secondSprite;
    
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeSprite(bool isChanged)
    {
        if (isChanged)
            _image.sprite = _firstSprite;
        else
            _image.sprite = _secondSprite;
    }
}
