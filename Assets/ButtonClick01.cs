using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

	int n;
 
   public void OnButtonPress(){
      n++;
      Debug.Log("Button clicked " + n + " times.");
   }
}
