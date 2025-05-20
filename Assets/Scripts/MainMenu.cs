using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   public Button mode2d, mode3d;

   private void Start()
   {
      ModeSwitch(false);
   }
   public void ModeSwitch(bool isNeedSwitch)
   {
      if(isNeedSwitch)
         GameSettings.is2Dmode = !GameSettings.is2Dmode;
      if (GameSettings.is2Dmode)
      {
         mode2d.interactable = false;
         mode3d.interactable = true;
         mode2d.transform.GetComponent<Image>().color = new Color(1,1,1,1f);
         mode3d.transform.GetComponent<Image>().color = new Color(1,1,1,0.75f);
      }
      else
      {
         mode3d.interactable = false;
         mode2d.interactable = true;
         mode3d.transform.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
         mode2d.transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.75f);
      }
   }

   public void ExitBtn()
   {
      Application.Quit();
   }

   public void StartBtn()
   {
      GameSettings.RandomSeed();
      SceneManager.LoadScene(GameSettings.is2Dmode ? 1 : 2);
   }
}
