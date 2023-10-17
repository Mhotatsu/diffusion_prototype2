using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown (KeyCode.N)) {
            //ターゲットのポジション
            Debug.Log(EyeTrackingTarget.LookedAtEyeTarget.transform.position);

            Vector3 DfVector = new Vector3(0,0,-1);

            float Fxpoint = EyeTrackingTarget.LookedAtEyeTarget.transform.position.x;
            float Fypoint = EyeTrackingTarget.LookedAtEyeTarget.transform.position.y;
            float Fzpoint = EyeTrackingTarget.LookedAtEyeTarget.transform.position.z;
            Vector3 YzeroVector = new Vector3(Fxpoint, 0.0f, Fzpoint);
            Vector3 AVector = new Vector3(Fxpoint,Fypoint,Fzpoint);
            
            //角度の計算
            float angleY = Vector3.SignedAngle(DfVector, YzeroVector, Vector3.up);
            float angleX = Vector3.SignedAngle(YzeroVector, AVector, Vector3.right);

            Debug.Log("Y(軸)の回転"+angleY);
            Debug.Log("X(軸)の回転"+angleX);
        }
    }
}
