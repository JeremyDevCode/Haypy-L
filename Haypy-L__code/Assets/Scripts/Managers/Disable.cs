using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    // Start is called before the first frame update
public  CombatManager level;
public GameObject desactivado;
public GameObject desactivado1;
public GameObject desactivado2;
public GameObject desactivado3;
public GameObject activado;



    public void Actualizar()
    {
        level = FindObjectOfType<CombatManager>();
        if(level._currentLevel>=10){
             Debug.Log(level._currentLevel);  
             desactivado.SetActive(false);
             activado.SetActive(true);
        }
    }

    public void disablelevel1(){
        level = FindObjectOfType<CombatManager>();
        if(level._currentLevel>=20){
             Debug.Log(level._currentLevel); 
             activado.SetActive(true);
             desactivado1.SetActive(false);
    }
    }
public void disablelevel2(){
        level = FindObjectOfType<CombatManager>();
         if(level._currentLevel>=30){
             Debug.Log(level._currentLevel);  
             desactivado2.SetActive(false);
             activado.SetActive(true);
    }
    }

    public void disablelevel3(){
        level = FindObjectOfType<CombatManager>();
         if(level._currentLevel>=40){
             Debug.Log(level._currentLevel);  
             desactivado3.SetActive(false);
             activado.SetActive(true);
    }
    }

    }


