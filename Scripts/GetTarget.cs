using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class GetTarget : MonoBehaviour
{
        //リストの宣言
    public List<GameObject> myList = new List<GameObject>();
    bool One;
    public int TargetCount = 0;
    public GameObject parentObject;
    public Vector3 EyeTargetPosition;
    //private Vector3 APos;
  

    // Start is called before the first frame update
    void Start()
    {
        One = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitTargetCount()
    {
        TargetCount = 0;
        myList = new List<GameObject>();
    }
/*
    void OnCollisionEnter(Collision collision)
    {
        // もし衝突した相手オブジェクトの名前が"Cube"ならば
        if (collision.gameObject.name == "Cube") {
            // 衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
        }   
    }
*/
    void OnTriggerStay(Collider other)
    {
        /*
        Debug.Log("当たっている");
        if (other.gameObject.tag == "Target" )
        {
           myList.Add(other.gameObject);
           //リストのカウント
           TargetCount++;
           //Debug.Log(TargetCount);
           //other.gameObject.SetActive(false);
           other.gameObject.transform.position = new Vector3(10, 10, 10);

           if(One){
           Instantiate (FlourLayoutObj, EyeTrackingTarget.LookedAtEyeTarget.transform.position, Quaternion.identity);
           //場所と向きは後でやる
           One = false;
           }
        }
        */
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter");
        //tagの変更
        other.gameObject.tag = "Selected";

        if(One){
            EyeTargetPosition = EyeTrackingTarget.LookedAtEyeTarget.transform.position;
            Invoke("showFlourLayout", 0.3f);
            //Debug.Log("After Trigger"+ EyeTargetPosition);
            One = false;
        }

        if (other.gameObject.tag == "Selected")
        {
            // 必要なら、ここで親となるGameObjectの子供としてオブジェクトを作る
            //新しくオブジェクトを生成したら、元のオブジェクトはfalsにする
            //Debug.Log("Target Position " +  other.gameObject.transform.position);
            other.gameObject.transform.SetParent(parentObject.transform);
            myList.Add(other.gameObject);
            
            
            

           
            //Debug.Log("change tag");

            //showFlourLayout();

        }

    }

    void showFlourLayout()
    {
        this.gameObject.SetActive(false);
        //Collierのfalse
        // if(gameObject.tag == "Target"){
        //     var colliderTest = gameObject.GetComponent<Collider>();
        //     colliderTest.enabled = false;
        // }

        GameObject[] NonSelected = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject otherobj in NonSelected) {
            var collideron = otherobj.gameObject.GetComponent<Collider>();
            collideron.enabled = false;
            otherobj.SetActive(false);
        }

        //リストを数える
        int ObjCount = myList.Count;
        Debug.Log(ObjCount);

        //  レイアウトを決める。個数で決まる
        int count = 0;
        foreach (GameObject target in myList) {

            // 順番に座標を決める
            float x = 0.3f * Mathf.Cos(Mathf.Deg2Rad * 360 * count / ObjCount + 90);
            float y = 0.3f * Mathf.Sin(Mathf.Deg2Rad * 360 * count / ObjCount + 90);
            float z = 0;
            target.transform.localPosition = new Vector3(x, y, z);
            count ++;

        }

        //親のposition，向きの変更
        //parentObject.transform.position = EyeTargetPosition;
        Vector3 Pos = EyeTargetPosition - CameraCache.Main.transform.position;
        Vector3 Nlz = Pos.normalized;
        parentObject.transform.position = CameraCache.Main.transform.position + 2.0f * Nlz;
        parentObject.transform.rotation = Quaternion.LookRotation(Pos);

        // 他のGameObject見えなくする
        // 他のGameObjectのcolliderを外す
        // GameObject[] others = GameObject.FindGameObjectsWithTag("Target");
        // foreach (GameObject otherobj in others) {
        //    otherobj.SetActive(false);
        //    collideron.enabled = false;

        // }

        //Colliderを有効にする
        // GameObject[] Selecter = GameObject.FindGameObjectsWithTag("Selected");
        // foreach (GameObject otherobj in Selecter) {
        //     var collideron = otherobj.gameObject.GetComponent<Collider>();
        //     collideron.enabled = true;
        // }


            
    }
}

