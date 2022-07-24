using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayBtnSound : MonoBehaviour, IPointerEnterHandler
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickPlayAud);
    }

    private void OnClickPlayAud()
    {
        MenuManager.sfxSource.PlayOneShot(MenuManager.onClickAud);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MenuManager.sfxSource.PlayOneShot(MenuManager.onSelectedAud);
    }

}
