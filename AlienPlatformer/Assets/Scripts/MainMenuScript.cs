using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void onPlayButtonClick() {
        LevelManager.loadCurrentLevel();
    }
    
    public void onLevelsButtonClick() {
        SceneManager.LoadScene("SelectLevelScene");
    }
    
    public void onSettingsButtonClick() {
        SceneManager.LoadScene("SettingsScene");
    }
    
    public void onExitButtonClick() {
        Application.Quit();
    }
    
    public void onShopButtonClick() {
        SceneManager.LoadScene("ShopScene");
    }
}
