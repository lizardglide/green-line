using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Choice1 : MonoBehaviour
{
	public Button btn;
    // Start is called before the first frame update
    void Start()
    {
			
		btn.onClick.AddListener(TestOnClick);
    }
	
	 void TestOnClick(){
		scriptMain.Log("test");
		
	}
}
