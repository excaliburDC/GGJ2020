using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    Animator anim;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject LoadGamePanel;
    public GameObject LoadingPanel;

    public Text EditableText;
    public GameObject Monitor;

    //Audio
    public GameObject volOn;
    public GameObject volOff;
    public AudioSource bgVol;
    public bool isActive = true;
    // Use this for initialization

    void Start()
    {
        if (isActive)
        {
            PlayerPrefs.SetInt("CharacterVal", 1);
            PlayerPrefs.SetInt("BGVolume", 1);
            isActive = false;
        }
        EditableText.text = "Welcome To " + " DOT.EXE ";
        anim = GetComponent<Animator>();
    }

    #region Open Different panels


    public void volumeOn()
    {
        volOn.SetActive(true);
        volOff.SetActive(false);
        bgVol.volume = 0f;
        PlayerPrefs.SetInt("BGVolume", 0);

    }
    public void volumeOff()
    {
        volOn.SetActive(false);
        volOff.SetActive(true);
        bgVol.volume = 1f;
        PlayerPrefs.SetInt("BGVolume", 1);

    }
    public void openOptions()
    {
        //editable text display
        EditableText.text = "OPTION.exe";

        //enable respective panel
        MainOptionsPanel.SetActive(true);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();
    }
    IEnumerator LoadingScreen()
    {
        //editable text display
        EditableText.text = "START.exe";
        yield return new WaitForSeconds(0.5f);
        //to add the clip
        EditableText.text = " ";

        EditableText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        LoadingPanel.SetActive(true);

        yield return new WaitForSeconds(5f);
        LoadingPanel.SetActive(false);
        SceneManager.LoadScene("Level 0");

    }
    public void openStartGameOptions(int mode)
    {
        //enable respective panel
        MainOptionsPanel.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        PersistManager.Instance.mode = (StateManager.Modes)mode;

        //to display the loading screen
        StartCoroutine(LoadingScreen());

        //play click sfx
        playClickSound();

    }

    public void openOptions_Game()
    {
        //editable text display
        EditableText.text = "VOLUME.exe";

        //enable respective panel
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);

        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Controls()
    {
        //editable text display
        EditableText.text = "CONTROL.exe";

        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);

        LoadGamePanel.SetActive(false);

        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    #endregion

    #region Back Buttons
    public void back_options()
    {
        //editable text display
        EditableText.text = "Welcome to DOT.EXE";

        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");


        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        //editable text display
        EditableText.text = "OPTION MENU.exe";
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");

        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {
    }

    void playClickSound()
    {

    }
    #endregion
}






