using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class DrawFrustumRefined : MonoBehaviour {

	private Camera cam = null;
	public bool showCamGizmo = true;

	void Start()
	{
		cam = GetComponent<Camera>();
	}

	void OnDrawGizmos()
	{
		if (!showCamGizmo) return;

		//get dimensions of game gab
		Vector2 v = DrawFrustumRefined.GetGameViewSize();
		float gameAspect = v.x / v.y;							//calculate tab ratio
		float finalAspect = gameAspect / cam.aspect;            //divide by cam aspect ratio
		Matrix4x4 localToWorld = transform.localToWorldMatrix;
		Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(cam.aspect * (cam.rect.width / cam.rect.height), finalAspect, 1));                  //build a scaling matrix for drawing camera gizmo
		Gizmos.matrix = localToWorld * scaleMatrix;
		Gizmos.DrawFrustum(transform.position, cam.fieldOfView, cam.nearClipPlane, cam.farClipPlane, finalAspect);						//draw camera fustrum
		Gizmos.matrix = Matrix4x4.identity;					//reset gizmo matrix
	}

	//function to get dimensions of game tab
	public static Vector2 GetGameViewSize()
	{
		System.Type t = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo getSizeOfMainGameView = t.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

		return (Vector2)getSizeOfMainGameView.Invoke(null, null);
	}
}
