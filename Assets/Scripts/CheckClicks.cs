using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClicks : MonoBehaviour
{
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, 10000))
         {
            var cellView = hit.transform.gameObject.GetComponent<CellView>();
            if (cellView != null)
            {
               cellView.Click(0);
            }
         }
      }
      if (Input.GetMouseButtonDown(1))
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

         if (Physics.Raycast(ray, out hit, 10000))
         {
            var cellView = hit.transform.gameObject.GetComponent<CellView>();
            if (cellView != null)
            {
               cellView.Click(1);
            }
         }
      }
   }
}
