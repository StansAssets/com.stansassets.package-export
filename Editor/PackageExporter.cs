using System;
using System.Linq;
using StansAssets.Foundation.Editor;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace StansAssets.PackageExport.Editor
{
	/// <summary>
	/// Use to export package as <c>.unitypackage</c>
	/// </summary>
	public static class PackageExporter
	{
		static SearchRequest s_ActiveSearchRequest;
		static string s_ExportDestination;

		/// <summary>
		/// Export package as <c>.unitypackage</c>
		/// </summary>
		/// <param name="packageName">Package name. For example: <c>com.stansassets.package-export</c>. </param>
		/// <param name="context">Package export context. See <see cref="PackageExportContext"/> for details.</param>
		public static void Export(string packageName, PackageExportContext context)
		{
			Debug.Log(packageName);
			if(s_ActiveSearchRequest != null)
				throw new InvalidOperationException("Another export in progress");

			var packageInfo = PackageManagerUtility.GetPackageInfo(packageName);
			Debug.Log(packageInfo.assetPath);

			AssetDatabase.CopyAsset(packageInfo.assetPath + "/Test/test1.json", "Assets/test1.json");
			//AssetDatabase.Refresh();
			AssetDatabase.ExportPackage("Assets/test1.json", "my_export.unitypackage", ExportPackageOptions.Default);
			AssetDatabase.DeleteAsset("Assets/test1.json");

			/*
			s_ExportDestination = destination;
			s_ActiveSearchRequest =  Client.Search(packageName, true);
			EditorApplication.update += OnEditorApplication;*/
		}

		static void OnEditorApplication()
		{
			 if (s_ActiveSearchRequest.IsCompleted)
			 {
				 if (s_ActiveSearchRequest.Status == StatusCode.Success)
					 Export();
				 else if (s_ActiveSearchRequest.Status >= StatusCode.Failure)
					 Debug.LogError($"Export Failed: {s_ActiveSearchRequest.Error.message} Code: {s_ActiveSearchRequest.Error.errorCode}");
				 else
					 Debug.LogError($"Unsupported progress state {s_ActiveSearchRequest.Status}");
				 OnFinalize();
			 }
		}

		static void OnFinalize()
		{
			s_ExportDestination = null;
			EditorApplication.update -= OnEditorApplication;
		}

		static void Export()
		{
			var packageInfo = s_ActiveSearchRequest.Result.First();
			Debug.Log(packageInfo.assetPath);
		}
	}
}

