using UnityEditor;
using UnityEngine;
using System.IO;

public class GenerateTemplateDirectory : MonoBehaviour
{

	/// <summary>
	/// Assets内生成Common样式文件夹
	/// </summary>
	[MenuItem ("Assets/Generate Assets Template Directory")]
	public static void GenerateForAssets ()
	{
		GenerateDirectory ("Assets/Common");
		GenerateSceneTemplate ("Assets/Common");

		GenerateDirectory ("Assets/Resources");

		AssetDatabase.Refresh ();
		Debug.Log ("Generate is done!");
	}

	/// <summary>
	/// Asset内生成Scene样式文件夹
	/// </summary>
	[MenuItem ("Assets/Generate Scene Template Directory")]
	public static void GenerateForScene ()
	{
		string scenePath = GetSelectFile ();

		if (!string.IsNullOrEmpty (scenePath)) {
			GenerateSceneTemplate (scenePath);

			AssetDatabase.Refresh ();
			Debug.Log ("Generate is done!");
		}
	}

	static void GenerateSceneTemplate (string path)
	{
		GenerateDirectory (path + "/Animations");
		GenerateDirectory (path + "/Audios");
		GenerateDirectory (path + "/Materials");
		GenerateDirectory (path + "/Plugins");
		GenerateDirectory (path + "/Prefabs");
		GenerateDirectory (path + "/Scenes");
		GenerateDirectory (path + "/Scripts");
		GenerateDirectory (path + "/Textures");
	}

	static void GenerateDirectory (string path)
	{
		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
		}
	}

	static string GetSelectFile ()
	{
		if (Selection.assetGUIDs != null && Selection.assetGUIDs.Length == 1) {
			return AssetDatabase.GUIDToAssetPath (Selection.assetGUIDs [0]);
		} else {
			Debug.LogError ("请选择单一文件夹");
			return "";
		}
	}
}
