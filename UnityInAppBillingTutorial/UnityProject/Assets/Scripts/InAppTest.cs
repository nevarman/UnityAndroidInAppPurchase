using UnityEngine;
using System.Collections;

public class InAppTest : MonoBehaviour {
	int coinNum;
	void Start()
	{
		coinNum = SocialPlugin.callGetCoinData();
	}
	void OnGUI ()
	{
		float h = 10f;
		for(int i = 0; i < 5; i++)
		{
			if(GUI.Button(new Rect(10,h,200,50),string.Format("Buy {0} num of coins",h)))
			{
				SocialPlugin.callBuyCoins((int)h);
			}
			h += 60f;
		}
		if(GUI.Button(new Rect(Screen.width- 200,10,150,50),"Get coins"))
		{
			coinNum = SocialPlugin.callGetCoinData();
		}
		GUI.Label(new Rect(Screen.width/2 -100,70,300,50),string.Format("Num of coins we have {0}",coinNum));
		GUI.Label(new Rect(Screen.width/2 -100,10,300,50),"Dont forget to change your packagename!");
	}
}
