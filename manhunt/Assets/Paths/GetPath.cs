using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetPath : MonoBehaviour {

    private List<GameObject> allPaths = new List<GameObject>();

	// Use this for initialization
	void Start () {
        foreach (EditorPath obj in Object.FindObjectsOfType<EditorPath>())
        {
            allPaths.Add(obj.gameObject);
        }
        int num = Random.Range(0, allPaths.Count);
        transform.position = allPaths[num].transform.position;
        MoveOnPath path = GetComponent<MoveOnPath>();
        path.PathName = allPaths[num].name;
	}
}
