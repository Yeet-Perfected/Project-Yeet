using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public Player player;
    public Slider healthBar;
    public Image imageSelected;
    public Image regMask;
    public Image mapMask;


    public void selectImage(Sprite sprite)
    {
        imageSelected.sprite = sprite;
    }

    public void setHealthBar(float val)
    {
        healthBar.value = val;
    }
    public void setRegMaskSize(Vector3 newScale)
    {
        regMask.transform.localScale = newScale;
    }
    public void setMapMaskSize(Vector3 newScale)
    {
        mapMask.transform.localScale = newScale;
    }


    void Update()
    {
        
    }
}
