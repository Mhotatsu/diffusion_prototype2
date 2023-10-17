using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class GetTarget2 : MonoBehaviour
{
        //リストの宣言
    public List<GameObject> myList2 = new List<GameObject>();
    public List<Vector3> myList3 = new List<Vector3>();
    bool One;
    public int TargetCount = 0;
    public Vector3 EyeTargetPosition;
    //private Vector3 APos;
  

    // Start is called before the first frame update
    void Start()
    {
        One = true;
    }

    void Update(){
        //Debug.Log(EyeTargetPosition);
    }


    public void InitTargetCount()
    {
        TargetCount = 0;
        myList2 = new List<GameObject>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        //tagの変更
        other.gameObject.tag = "Selected";

        if(One){
            EyeTargetPosition = EyeTrackingTarget.LookedAtEyeTarget.transform.position;
            //EyeTargetPosition = flourDeployment.ETP;
            //Invoke("showFlourLayout", 2.0f);
            //Debug.Log("After Trigger"+ EyeTargetPosition);
            One = false;
            
        }

        if (other.gameObject.tag == "Selected" && other.gameObject.transform.position != EyeTargetPosition)
        {
            //other.gameObject.transform.SetParent(parentObject.transform);
            myList2.Add(other.gameObject);
            Vector3 Intrct =  CalculateDestination(CameraCache.Main.transform.position, EyeTargetPosition, other.gameObject.transform.position);
            //Debug.Log(other.gameObject.transform.position);
            Debug.Log("Posiは"+Intrct);
            myList3.Add(Intrct);

            Invoke("setactive", 0.5f);
            //Invoke("MoveBvr", 1.0f);
            iTween.MoveTo(other.gameObject, iTween.Hash("x", Intrct.x, "y", Intrct.y, "z", Intrct.z));
        
           

        }

    }


    Vector3 CalculateDestination(Vector3 A, Vector3 B, Vector3 C)
    {
        Vector3 PosAB = B - A;
        Vector3 PosAC = C - A;
        Vector3 Posi;

        //AX = k * AB の k を求める
        float K = ((PosAC.x * PosAB.x) + (PosAC.y * PosAB.y) + (PosAC.z * PosAB.z)) / ((PosAB.x * PosAB.x) + (PosAB.y * PosAB.y) + (PosAB.z * PosAB.z));
        Vector3 X = (K * PosAB) + A;
        //進む方向
        Vector3 PosXC = C - X;
        //Vector3 Posi = C + (PosXC.normalized);
        if(C.z<2.6){
            Posi = C + (0.16f * PosXC.normalized);
        }
        else{
            Posi = C + (0.43f * PosXC.normalized);

        }
        
        //Debug.Log("C"+C);
        //Debug.Log("X"+X);
        //Debug.Log("PosXC"+PosXC);
        //Debug.Log("normaXC"+PosXC.normalized);
        return(Posi);
    }

    void setactive(){
        this.gameObject.SetActive(false);

        GameObject[] NonSelected = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject otherobj in NonSelected) {
            var collideron = otherobj.gameObject.GetComponent<Collider>();
            collideron.enabled = false;
            otherobj.SetActive(false);
        }

    }

    // void MoveBvr(){
    //     //Rigidboyの削除

    //     int count = 0;
    //     //int count = myList2.Count - 1;
    //     foreach (GameObject target in myList2) {


    //         // 順番に座標を決める
    //         Vector3 Intrct2 = myList3[count];
    //         Debug.Log("Intrct2"+Intrct2);
    //         Debug.Log("Count"+count);

    //         //物体の移動
    //         iTween.MoveTo(target, iTween.Hash("x", Intrct2.x, "y", Intrct2.y, "z", Intrct2.x));
    //         count++;

    //     }

    // }

    //IEnumerator でないといけない

    // IEnumerator MoveBehavior(Vector3 XC, GameObject MoveObj)
    // {
    //     Debug.Log("MoveBehavior");

    //     Vector3 posi = MoveObj.transform.position + XC;

    //     //while(MoveObj.transform.position.y < posi.y)
    //     while(true)
    //     {
    //         MoveObj.transform.position = Vector3.MoveTowards(MoveObj.transform.position, XC, 0.02f);
    //         yield return new WaitForSeconds(0.01f);
    //     }


    // }
}


