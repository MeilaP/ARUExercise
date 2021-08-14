using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
 //Membuat variabel untuk resize layar 
  public GUISkin guiSkin;
  private float guiRatio;
  private float sWidth;
  private Vector3 GUIsF;

  public GameObject ArutalaLogo;
  public float kecepatanRotasi = 50f;
  bool statusRotasi = false;

  //string folderPath = "C:/ArutalaSS";
  string folderPath = "/storage/sdcard0/ArutalaSS";
  string fileName = "ARU.png";

  void Awake(){
    sWidth = Screen.width;
    guiRatio = sWidth/1920;
    GUIsF = new Vector3(guiRatio,guiRatio,1);
  }

  void OnGUI(){
    GUI.skin = guiSkin;
    //letakkan function disini
    Rotasi();
    Capture();
  }

  void Rotasi(){
    //Meletakkan tombol dipojok kanan atas
    GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width-258*GUIsF.x,GUIsF.y,0), Quaternion.identity, GUIsF);

    if (statusRotasi==false){
      if(GUI.Button(new Rect(-208,10,238,59),"Rotasi")){
      statusRotasi = true;
      }
    }else{
      if(GUI.Button(new Rect(-208,10,238,59),"Stop Rotasi")){
      statusRotasi = false;
     }      
    }

    if(GUI.Button(new Rect(40,10,208,59),"Keluar")){
      Application.Quit(); //Keluar dari aplikasi
    }
  }

  void Capture(){
    //Buat tombol dulu ngab
     GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width-258*GUIsF.x,GUIsF.y,0), Quaternion.identity, GUIsF);

     if(GUI.Button(new Rect(-458,10,238,59),"Capture")){
     
    
     if(!System.IO.Directory.Exists(folderPath))
      System.IO.Directory.CreateDirectory(folderPath);      
         
      ScreenCapture.CaptureScreenshot(folderPath + "/"+fileName);
      
    }
  }

  void Update(){
    if(statusRotasi==true){
      ArutalaLogo.transform.Rotate(Vector3.up, kecepatanRotasi * Time.deltaTime);
    }
  }
}
