
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.SceneManagement;


public class flourDeployment : MonoBehaviour
{
    public Vector3 EyeTargetPosition;
    //public static Vector3 ETP;
    public static Vector3 TargetPosition;
    public static bool flag;
    // Start is called before the first frame update
    void Start()
    {
        //flag = true;
    }

    public GameObject Cone1;
    public GameObject Cone2;
    // Update is called once per frame

    public void dwell(){
        Debug.Log("dweeeeeeell");
    }

    public void Fdeployment()
    {
        Debug.Log("OnDwell");
        //現在の見ているターゲットの位置を取得
        //EyeTargetPosition = EyeTrackingTarget.LookedAtEyeTarget.transform.position;
        //Debug.Log("Before Trigger" + EyeTrackingTarget.LookedAtEyeTarget.transform.position);
        string aobjname = ("target_x"+flourDeployment.TargetPosition.x+"_y"+flourDeployment.TargetPosition.y+"_z"+flourDeployment.TargetPosition.z);
        GameObject aobj = GameObject.Find(aobjname);
        aobj.tag = "Selected";

        //Vector3 APos = EyeTrackingTarget.LookedAtEyeTarget.transform.position - CameraCache.Main.transform.position;
        Vector3 APos = EyeTrackingTarget.LookedAtEyeTarget.transform.position - CameraCache.Main.transform.position;
        //ETP = EyeTrackingTarget.LookedAtEyeTarget.transform.position;
        // 方向を、回転情報に変換
        Quaternion rotation = Quaternion.LookRotation (-APos);
        //Debug.Log(rotation);
        //Instantiate( 生成するオブジェクト,  場所, 回転 );
        if(flag){
            Instantiate (Cone2, CameraCache.Main.transform.position, rotation);
        }
        else{
            Instantiate (Cone1, CameraCache.Main.transform.position, rotation);
        }
         
    }

    void Update()
    {
        //Debug.Log("flagは"+flag);
        if (Input.GetKeyDown (KeyCode.Alpha9))
        {
            if(flag == true){
                flag = false;
            }
            else{
                flag = true;
            }
        }

        //フラワー型
        if (Input.GetKeyDown (KeyCode.Alpha1)){
            //現在の見ているターゲットの位置を取得
            //EyeTargetPosition = EyeTrackingTarget.LookedAtEyeTarget.transform.position;
            //Debug.Log("Before Trigger" + EyeTrackingTarget.LookedAtEyeTarget.transform.position);
            string aobjname = ("target_x"+flourDeployment.TargetPosition.x+"_y"+flourDeployment.TargetPosition.y+"_z"+flourDeployment.TargetPosition.z);
            GameObject aobj = GameObject.Find(aobjname);
            aobj.tag = "Selected";
            //Debug.Log(aobj.tag);

            Vector3 APos = EyeTrackingTarget.LookedAtEyeTarget.transform.position - CameraCache.Main.transform.position;
            // 方向を、回転情報に変換
            Quaternion rotation = Quaternion.LookRotation (-APos);
            //Debug.Log(rotation);
            //Instantiate( 生成するオブジェクト,  場所, 回転 );
            Instantiate (Cone1, CameraCache.Main.transform.position, rotation);

        }

        //拡散型
        if (Input.GetKeyDown (KeyCode.Alpha2)){

            Vector3 APos = EyeTrackingTarget.LookedAtEyeTarget.transform.position - CameraCache.Main.transform.position;
            // 方向を、回転情報に変換
            Quaternion rotation = Quaternion.LookRotation (-APos);
            string aobjname = ("target_x"+flourDeployment.TargetPosition.x+"_y"+flourDeployment.TargetPosition.y+"_z"+flourDeployment.TargetPosition.z);
            GameObject aobj = GameObject.Find(aobjname);
            aobj.tag = "Selected";
            //Debug.Log(rotation);
            //Instantiate( 生成するオブジェクト,  場所, 回転 );
            Instantiate (Cone2, CameraCache.Main.transform.position, rotation);

        }

        //リセットボタンはスペースキー
        if (Input.GetKeyDown (KeyCode.Space)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //z=0の層　A～Iまで

        if(Input.GetKeyDown(KeyCode.A)){
            TargetPosition = new Vector3(0f, 2f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.B)){
            TargetPosition = new Vector3(1f, 2f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.C)){
            TargetPosition = new Vector3(2f, 2f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.D)){
            TargetPosition = new Vector3(0f, 1f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.E)){
            TargetPosition = new Vector3(1f, 1f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.F)){
            TargetPosition = new Vector3(2f, 1f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.G)){
            TargetPosition = new Vector3(0f, 0f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.H)){
            TargetPosition = new Vector3(1f, 0f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.I)){
            TargetPosition = new Vector3(2f, 0f, 0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

       

        //z=1の層　J～Rまで

        if(Input.GetKeyDown(KeyCode.J)){
            TargetPosition = new Vector3(0f, 2f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.K)){
            TargetPosition = new Vector3(1f, 2f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.L)){
            TargetPosition = new Vector3(2f, 2f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.M)){
            TargetPosition = new Vector3(0f, 1f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.N)){
            TargetPosition = new Vector3(1f, 1f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.O)){
            TargetPosition = new Vector3(2f, 1f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.P)){
            TargetPosition = new Vector3(0f, 0f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            TargetPosition = new Vector3(1f, 0f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.R)){
            TargetPosition = new Vector3(2f, 0f, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        //z=2の層 Ｓ～＠まで

        if(Input.GetKeyDown(KeyCode.S)){
            TargetPosition = new Vector3(0f, 2f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.T)){
            TargetPosition = new Vector3(1f, 2f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.U)){
            TargetPosition = new Vector3(2f, 2f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.V)){
            TargetPosition = new Vector3(0f, 1f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.W)){
            TargetPosition = new Vector3(1f, 1f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.X)){
            TargetPosition = new Vector3(2f, 1f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.Y)){
            TargetPosition = new Vector3(0f, 0f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            TargetPosition = new Vector3(1f, 0f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        if(Input.GetKeyDown(KeyCode.Alpha0)){
            TargetPosition = new Vector3(2f, 0f, 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            string str = "";
            Gettext.SetText(str);
        }

        
    }
}
