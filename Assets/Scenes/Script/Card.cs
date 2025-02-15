using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;
public class Card : MonoBehaviour
{
    [SerializeField] private Image iconImage;

    public Sprite HiddenIconSprite;
    public Sprite IconSprite;

    public bool isSelected;

    public CardController controller;

    public void OnCardClicked()
    {
        controller.SetSelected(this);
        Debug.Log("Card Clicked");
    }

    public void SetIconSprite(Sprite sp)
    {
        IconSprite = sp;
    }

    public void Show()
    {
        Tween.Rotation(transform,
            new Vector3(0f, 180f, 0f),
            0.2f);

        Tween.Delay(0.1f, () => iconImage.sprite = IconSprite);
        isSelected = true;
    }

    public void Hide()
    {
        Tween.Rotation(transform,
            new Vector3(0f, 0f, 0f),
            0.2f);

        Tween.Delay(0.1f, () => iconImage.sprite = HiddenIconSprite);

        isSelected = false;
    }
}
