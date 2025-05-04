using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   public Button mode2d, mode3d;
   private bool is2Dmode = false;

   private void Start()
   {
      ModeSwitch();
   }
   public void ModeSwitch()
   {
      is2Dmode = !is2Dmode;
      if (is2Dmode)
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
      SceneManager.LoadScene(is2Dmode ? 1 : 2);
   }
}
