using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayBtnSound : MonoBehaviour
{

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClickPlayAud);
    }

    private void OnClickPlayAud()
    {
        MenuManager.sfxSource.PlayOneShot(MenuManager.onClickAud);
    }

}
