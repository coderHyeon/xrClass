using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{   
   public Transform ContentContainer;

   private void Start()
   {
      GameObject prefab = Resources.Load("StageItem") as GameObject;

      for (int i=0; i<20; i++)
      {         
         Transform stage = Instantiate(prefab).transform;
         StageItem stageItem = stage.GetComponent<StageItem>();
         stageItem.Init(i, this);
      }
   }

   public void OnStageClicked(StageItem stageItem)
   {
      print(string.Format("Stage {0}이 선택되었습니다.", (stageItem.stageIndex + 1)));
   }
}
