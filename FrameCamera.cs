using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCamera : MonoBehaviour {

	public int Frame;
	public List<Vector3> Rotation;
	public List<Vector3> Position;
	public float TimePause = 5;
	public bool Loop=false;
	private bool one;

	void Start () {

		transform.position = Position[Frame];
		transform.rotation = Quaternion.Euler (Rotation [Frame]);

		if (Loop) {
			StartCoroutine (ToPose ());
		} else {
			StartCoroutine (ToPoseOne ());
		}
	}

	IEnumerator ToPoseOne(){
		yield return new WaitForSeconds (TimePause);
		transform.position = Position[Frame];
		transform.rotation = Quaternion.Euler (Rotation [Frame]);
		Frame++;
		if (Frame >= Position.Count) {
		
		} else {
			StartCoroutine (ToPoseOne ());
		}
	}
	
	IEnumerator ToPose(){
		yield return new WaitForSeconds (TimePause);
		transform.position = Position[Frame];
		transform.rotation = Quaternion.Euler (Rotation [Frame]);
		Frame++;

		if (Frame >= Position.Count) {

		
		Frame = 0;
			
		}
		StartCoroutine (ToPose ());
	}

}

#if UNITY_EDITOR 
[UnityEditor.CustomEditor(typeof(FrameCamera))]
public class Button : UnityEditor.Editor{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();
		var pose = (FrameCamera)target;

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Add Pose")) {
			pose.Position.Add (pose.transform.position);
			pose.Rotation.Add (pose.transform.rotation.eulerAngles);
		}
		if (GUILayout.Button ("Remove Pose")) {

			pose.Position.Remove (pose.Position[0]);
			pose.Rotation.Remove (pose.Rotation[0]);
			
			
		}
		GUILayout.EndHorizontal ();
	}

}


#endif
