using UnityEngine;
using UnityEngine.UI;

public class SettingBehaviour : MonoBehaviour
{
    private Toggle toggle1, toggle2, toggle3;
    private Toggle toggleImage1, toggleImage2, toggleImage3, toggleImage4;
    private Image image1, image2, image3, image4;
    public static SettingBehaviour settingBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        settingBehaviour = GetComponent<SettingBehaviour>();
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);

        toggle1 = GameObject.Find("Toggle1").GetComponent<Toggle>();
        toggle2 = GameObject.Find("Toggle2").GetComponent<Toggle>();
        toggle3 = GameObject.Find("Toggle3").GetComponent<Toggle>();

        toggleImage1 = GameObject.Find("Game_Scene_Image1").GetComponent<Toggle>();
        toggleImage2 = GameObject.Find("Game_Scene_Image2").GetComponent<Toggle>();
        toggleImage3 = GameObject.Find("Game_Scene_Image3").GetComponent<Toggle>();
        toggleImage4 = GameObject.Find("Game_Scene_Image4").GetComponent<Toggle>();

        image1 = GameObject.Find("Game_Scene_Image1").GetComponent<Image>();
        image2 = GameObject.Find("Game_Scene_Image2").GetComponent<Image>();
        image3 = GameObject.Find("Game_Scene_Image3").GetComponent<Image>();
        image4 = GameObject.Find("Game_Scene_Image4").GetComponent<Image>();

        if (MenuBehaviour.addTime != 0)
        {
            switch (MenuBehaviour.addTime)
            {
                case 3:
                    toggle1.isOn = true;
                    break;
                case 1.75f:
                    toggle2.isOn = true;
                    break;
                case 1:
                    toggle3.isOn = true;
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
                changeColorOfImageToGrey(image1);
                break;
            case 1:
                toggleImage4.isOn = true;
                changeColorOfImageToGrey(image4);
                break;
            case 2:
                toggleImage2.isOn = true;
                changeColorOfImageToGrey(image2);
                break;
            case 3:
                toggleImage3.isOn = true;
                changeColorOfImageToGrey(image3);
                break;
        }

    }

    public void SetDifficultyToEasy(Toggle toggle)
    {
        toggle1 = toggle;
        bool status = toggle1.isOn;
        
        if (status)
        {
            MenuBehaviour.addTime = 3;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }

    public void SetDifficultyToMedium(Toggle toggle)
    {
        toggle2 = toggle;
        bool status = toggle2.isOn;

        if (status)
        {
            MenuBehaviour.addTime = 1.75f;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }

    public void SetDifficultyToHard(Toggle toggle)
    {
        toggle3 = toggle;
        bool status = toggle3.isOn;

        if (status)
        {
            MenuBehaviour.addTime = 1;
        }
        Debug.Log("addTime in Settings: " + MenuBehaviour.addTime);
    }
    /////////////////////////////////////////////////////////////////
    //Hier beginnt der Abschnitt mit den Methode für die ImageToggles
    /////////////////////////////////////////////////////////////////
    public void SetBackgroundToImage1(Toggle toggle)
    {
        toggleImage1 = toggle;
        bool status = toggleImage1.isOn;

        if (status)
        {
            changeColorOfImageToGrey(image1);
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
            changeColorOfImageToGrey(image2);
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
            changeColorOfImageToGrey(image3);
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
            changeColorOfImageToGrey(image4);
            MenuBehaviour.currentSprite = 1;
            //desert
        }
    }

    private void highlightImagesInWhite(int selectedImage)
    {
        switch (selectedImage)
        {
            case 0:
                changeColorOfImageToWhite(image2);
                changeColorOfImageToWhite(image3);
                changeColorOfImageToWhite(image4);
                break;
            case 2:
                changeColorOfImageToWhite(image1);
                changeColorOfImageToWhite(image3);
                changeColorOfImageToWhite(image4);
                break;
            case 3:
                changeColorOfImageToWhite(image1);
                changeColorOfImageToWhite(image2);
                changeColorOfImageToWhite(image4);
                break;
            case 1:
                changeColorOfImageToWhite(image1);
                changeColorOfImageToWhite(image2);
                changeColorOfImageToWhite(image3);
                break;
        }
    }

    private void Update()
    {
        highlightImagesInWhite(MenuBehaviour.currentSprite);
    }

    private void changeColorOfImageToWhite(Image image)
    {
        image.color = new Color(1, 1, 1, 1);
    }

    private void changeColorOfImageToGrey(Image image)
    {
        image.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    public void BackToMenu()
    {
        MenuBehaviour.LoadMainMenu();
    }
}
