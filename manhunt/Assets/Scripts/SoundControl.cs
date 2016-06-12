using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
    private static SoundControl INSTANCE;

	// Use this for initialization
	void Start () {
	    if (GetComponent<AudioSource>() != null)
        {
            if (INSTANCE != null)
            {
                if (GetComponent<AudioSource>().clip != INSTANCE.GetComponent<AudioSource>().clip)
                {
                    Destroy(INSTANCE.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
            INSTANCE = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
