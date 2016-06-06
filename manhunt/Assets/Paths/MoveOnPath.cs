using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveOnPath : MonoBehaviour {

    public EditorPath Path;
    public int CurrentWayPointID = 0;
    public float Speed;
    public float RotationSpeed = 5.0f;
    public string PathName;
    private float reachDistance = 1.0f;
    private bool forward = true;

    Vector3 last_position;

	// Use this for initialization
	void Start () {
        List<GameObject> allPaths = new List<GameObject>();

        foreach (EditorPath obj in Object.FindObjectsOfType<EditorPath>())
        {
            allPaths.Add(obj.gameObject);
        }
        int num = Random.Range(0, allPaths.Count);
        transform.position = allPaths[num].transform.position;
        last_position = transform.position;

        Path = allPaths[num].GetComponent<EditorPath>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(Path.path_objs[CurrentWayPointID].position, transform.position);

        if (distance <= reachDistance)
        {
            // Rotate if reached end of path
            if (forward)
            {
                CurrentWayPointID++;
                if (CurrentWayPointID == Path.path_objs.Count)
                {
                    forward = false;
                    transform.Rotate(0, 180, 0);
                    CurrentWayPointID -= 2;
                }
            }
            else
            {
                CurrentWayPointID--;
                if (CurrentWayPointID < 0)
                {
                    forward = true;
                    transform.Rotate(0, 180, 0);
                    CurrentWayPointID = 1;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Path.path_objs[CurrentWayPointID].position, Time.deltaTime * Speed / 10f);
    }
}
