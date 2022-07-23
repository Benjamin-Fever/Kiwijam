using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayBtnSound : MonoBehaviour, ISelectHandler
{
    private bool clickAudIsOn;

    void Start()
    {
        clickAudIsOn = false;
        GetComponent<Button>().onClick.AddListener(OnClickPlayAud);
    }

    private void OnClickPlayAud()
    {
        MenuManager.sfxSource.PlayOneShot(MenuManager.onClickAud);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (clickAudIsOn)
        {
            MenuManager.sfxSource.PlayOneShot(MenuManager.onSelectedAud);
        }
        else
        {
            clickAudIsOn = true;
        }

    }
}
