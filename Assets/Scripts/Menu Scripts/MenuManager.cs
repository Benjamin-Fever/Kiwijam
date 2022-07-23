using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button instBtn;
    [SerializeField] private Button credBtn;
    [SerializeField] private GameObject instScreen;
    [SerializeField] private GameObject credScreen;
    [SerializeField] private Button backInstBtn;
    [SerializeField] private Button backCredBtn;
    [SerializeField] private AudioSource sfxSourceRef;
    [SerializeField] private AudioClip onSelectedAudRef;
    [SerializeField] private AudioClip onClickAudRef;

    public static AudioSource sfxSource;
    public static AudioClip onSelectedAud;
    public static AudioClip onClickAud;

    void Start()
    {
        sfxSource = sfxSourceRef;
        onSelectedAud = onSelectedAudRef;
        onClickAud = onClickAudRef;

        instScreen.SetActive(false);
        credScreen.SetActive(false);

        playBtn.onClick.AddListener(PlayGame);
        instBtn.onClick.AddListener(ShowInstScreen);
        credBtn.onClick.AddListener(ShowCredScreen);
        backInstBtn.onClick.AddListener(BackFromInst);
        backCredBtn.onClick.AddListener(BackFromCred);
    }

    private void BackFromCred()
    {
        credScreen.SetActive(false);
    }

    private void BackFromInst()
    {
        instScreen.SetActive(false);
    }

    private void ShowCredScreen()
    {
        credScreen.SetActive(true);
    }

    private void ShowInstScreen()
    {
        instScreen.SetActive(true);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
