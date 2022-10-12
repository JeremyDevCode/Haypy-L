using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holaaa : MonoBehaviour
{
public  CombatManager level;

[Header("Dependencies")]
    public SceneLoader SceneLoader;
    public SceneLoader SceneLoader1;
    public SceneLoader SceneLoader2;
        public SceneLoader SceneLoader3;


    public void Actualizar()
    {
        level = FindObjectOfType<CombatManager>();

         if(level._currentLevel>0){
SceneLoader.LoadScene();
 }
  if(level._currentLevel>11){
SceneLoader1.LoadScene();
 }
 if(level._currentLevel>21){
SceneLoader2.LoadScene();
    }
     if(level._currentLevel>31){
SceneLoader3.LoadScene();
    }
    
    }
}
