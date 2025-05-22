using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StageItem : MonoBehaviour
{
   public int stageIndex;
   public TextMeshProUGUI TxtStageName;

   StageManager stageManager;

   public void Init(int index, StageManager stageManager)
   {
      this.stageManager = stageManager;

      stageIndex = index;
      TxtStageName.text = "Stage " + (index + 1).ToString();
      transform.SetParent(stageManager.ContentContainer);
   }

   public void OnClicked()
   {
      stageManager.OnStageClicked(this);      
   }
}
