using UnityEngine;
using UnityEngine.UI;

public class SettingBehaviour : MonoBehaviour
{
    private Toggle toggleEasy, toggleMedium, toggleHard;
    private Toggle toggleImage1, toggleImage2, toggleImage3, toggleImage4;
    private Toggle toggleSoundOff, toggleSoundOn;
    private Image image1, image2, image3, image4;
    private Image imageSoundOn, imageSoundOff;
    public static SettingBehaviour settingBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        settingBehaviour = GetComponent<SettingBehaviour>();

        toggleSoundOff = GameObject.Find("ToggleSoundOff").GetComponent<Toggle>();
        toggleSoundOn = GameObject.Find("ToggleSoundOn").GetComponent<Toggle>();

        toggleEasy = GameObject.Find("ToggleEasy").GetComponent<Toggle>();
        toggleMedium = GameObject.Find("ToggleMedium").GetComponent<Toggle>();
        toggleHard = GameObject.Find("ToggleHard").GetComponent<Toggle>();

        toggleImage1 = GameObject.Find("Game_Scene_Image1").GetComponent<Toggle>();
        toggleImage2 = GameObject.Find("Game_Scene_Image2").GetComponent<Toggle>();
        toggleImage3 = GameObject.Find("Game_Scene_Image3").GetComponent<Toggle>();
        toggleImage4 = GameObject.Find("Game_Scene_Image4").GetComponent<Toggle>();

        image1 = GameObject.Find("Game_Scene_Image1").GetComponent<Image>();
        image2 = GameObject.Find("Game_Scene_Image2").GetComponent<Image>();
        image3 = GameObject.Find("Game_Scene_Image3").GetComponent<Image>();
        image4 = GameObject.Find("Game_Scene_Image4").GetComponent<Image>();

        imageSoundOff = GameObject.Find("BackgroundSoundOff").GetComponent<Image>();
        imageSoundOn = GameObject.Find("BackgroundSoundOn").GetComponent<Image>();


        if (MenuBehaviour.addTime != 0)
        {
            switch (MenuBehaviour.addTime)
            {
                case 3:
                    toggleEasy.isOn = true;
                    break;
                case 1.75f:
                    toggleMedium.isOn = true;
                    break;
                case 1:
                    toggleHard.isOn = true;
                    break;
                default:
                    Debug.Log("MenuBehaviour.addTime hat einen anderen Wert!");
                    break;
            }
        }

        switch (MenuBehaviour.currentSprite)
        {
            case 0:
                toggleImage1.isOn = true;
                ChangeColorOfImageToGrey(image1);
                break;
            case 1:
                toggleImage4.isOn = true;
                ChangeColorOfImageToGrey(image4);
                break;
            case 2:
                toggleImage2.isOn = true;
                ChangeColorOfImageToGrey(image2);
                break;
            case 3:
                toggleImage3.isOn = true;
                ChangeColorOfImageToGrey(image3);
                break;
        }

        switch (MenuBehaviour.currentSoundStatus)
        {
            case 0:
                toggleSoundOn.isOn = true;
                ChangeColorOfImageToGrey(imageSoundOff);
                ChangeColorOfImageToWhite(imageSoundOn);
                break;
            case 1:
                toggleSoundOff.isOn = true;
                ChangeColorOfImageToGrey(imageSoundOn);
                ChangeColorOfImageToWhite(imageSoundOff);
                break;
        }

    }

    
    public void SetSoundOff(Toggle toggle)
    {
        toggleSoundOff = toggle;
        bool status = toggleSoundOff.isOn;

        if (status)
        {
            MenuBehaviour.currentSoundStatus = 1;
        }
    }

    public void SetSoundOn(Toggle toggle)
    {
        toggleSoundOn = toggle;
        bool status = toggleSoundOn.isOn;

        if (status)
        {
            MenuBehaviour.currentSoundStatus = 0;
        }
    }


    public void SetDifficultyToEasy(Toggle toggle)
    {
        toggleEasy = toggle;
        bool status = toggleEasy.isOn;
        
        if (status)
        {
            MenuBehaviour.addTime = 3;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }

    public void SetDifficultyToMedium(Toggle toggle)
    {
        toggleMedium = toggle;
        bool status = toggleMedium.isOn;

        if (status)
        {
            MenuBehaviour.addTime = 1.75f;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }

    public void SetDifficultyToHard(Toggle toggle)
    {
        toggleHard = toggle;
        bool status = toggleHard.isOn;

        if (status)
        {
            MenuBehaviour.addTime = 1;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }


    public void SetBackgroundToImage1(Toggle toggle)
    {
        toggleImage1 = toggle;
        bool status = toggleImage1.isOn;

        if (status)
        {
            ChangeColorOfImageToGrey(image1);
            MenuBehaviour.currentSprite = 0;
            //beach
        }
    }

    public void SetBackgroundToImage2(Toggle toggle)
    {
        toggleImage2 = toggle;
        bool status = toggleImage2.isOn;

        if (status)
        {
            ChangeColorOfImageToGrey(image2);
            MenuBehaviour.currentSprite = 2;
            //landscape
        }
    }

    public void SetBackgroundToImage3(Toggle toggle)
    {
        toggleImage3 = toggle;
        bool status = toggleImage3.isOn;

        if (status)
        {
            ChangeColorOfImageToGrey(image3);
            MenuBehaviour.currentSprite = 3;
            //night
        }
    }

    public void SetBackgroundToImage4(Toggle toggle)
    {
        toggleImage4 = toggle;
        bool status = toggleImage4.isOn;

        if (status)
        {
            ChangeColorOfImageToGrey(image4);
            MenuBehaviour.currentSprite = 1;
            //desert
        }
    }

    private void HighlightImagesInWhite(int selectedImage)
    {
        switch (selectedImage)
        {
            case 0:
                ChangeColorOfImageToWhite(image2);
                ChangeColorOfImageToWhite(image3);
                ChangeColorOfImageToWhite(image4);
                break;
            case 1:
                ChangeColorOfImageToWhite(image1);
                ChangeColorOfImageToWhite(image2);
                ChangeColorOfImageToWhite(image3);
                break;
            case 2:
                ChangeColorOfImageToWhite(image1);
                ChangeColorOfImageToWhite(image3);
                ChangeColorOfImageToWhite(image4);
                break;
            case 3:
                ChangeColorOfImageToWhite(image1);
                ChangeColorOfImageToWhite(image2);
                ChangeColorOfImageToWhite(image4);
                break;
        }
    }

    private void SetDisabledSoundToggleToGrey(int selectedImage)
    {
        switch (selectedImage)
        {
            case 0:
                ChangeColorOfImageToGrey(imageSoundOff);
                ChangeColorOfImageToWhite(imageSoundOn);
                break;
            case 1:
                ChangeColorOfImageToGrey(imageSoundOn);
                ChangeColorOfImageToWhite(imageSoundOff);
                break;
        }
    }

    private void Update()
    {
        HighlightImagesInWhite(MenuBehaviour.currentSprite);
        SetDisabledSoundToggleToGrey(MenuBehaviour.currentSoundStatus);
    }

    private void ChangeColorOfImageToWhite(Image image)
    {
        image.color = new Color(1, 1, 1, 1);
    }

    private void ChangeColorOfImageToGrey(Image image)
    {
        image.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    public void BackToMenu()
    {
        MenuBehaviour.LoadMainMenu();
    }
}
