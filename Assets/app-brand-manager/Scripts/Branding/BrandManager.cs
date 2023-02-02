using UnityEditor;
using UnityEngine;

namespace Branding
{
    [CreateAssetMenu(fileName = "New Brand Manager", menuName = "Branding/New Brand Manager")]
    public class BrandManager : ScriptableObject
    {
        [Header("References")]
        [SerializeField] private Sprite referenceDefaultIcon;
        [SerializeField] private Sprite referenceLogo;
        [SerializeField] private Sprite referenceSplashLogo;

        [Header("Brand File")]
        [SerializeField] private Brand brand;
        public Brand CurrentBrand { get { return brand; } }

#if UNITY_EDITOR
        public void LoadBranding()
        {
            Debug.Log("Loading Branding...");

            PlayerSettings.companyName = brand.CompanyName;
            PlayerSettings.productName = brand.ProductName;
            PlayerSettings.bundleVersion = brand.Version;

            RewriteAsset(AssetDatabase.GetAssetPath(brand.DefaultIcon), AssetDatabase.GetAssetPath(referenceDefaultIcon));
            RewriteAsset(AssetDatabase.GetAssetPath(brand.Logo), AssetDatabase.GetAssetPath(referenceLogo));

            RewriteAsset(AssetDatabase.GetAssetPath(brand.SplashLogo), AssetDatabase.GetAssetPath(referenceSplashLogo));
            PlayerSettings.SplashScreen.backgroundColor = brand.SplashBackground;

            PlayerSettings.Android.bundleVersionCode = brand.BundleNumber;

            PlayerSettings.iOS.buildNumber = brand.BundleNumber.ToString();
            PlayerSettings.macOS.buildNumber = brand.BundleNumber.ToString();

            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, brand.BundleIdentifierIOS);
            PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, brand.BundleIdentifierAndroid);

            Debug.Log("Brand Loaded Successfully...");
        }

        private void RewriteAsset(string sourcePath, string destinyPath)
        {
            Debug.Log(GetFixedPath(sourcePath) + " -> " + GetFixedPath(destinyPath));
            SaveTextureToFile(LoadTextureToFile(GetFixedPath(sourcePath)), GetFixedPath(destinyPath));

            AssetDatabase.ImportAsset(destinyPath);
        }

        void SaveTextureToFile(Texture2D texture, string filename)
        {
            System.IO.File.WriteAllBytes(filename, texture.EncodeToPNG());
        }

        Texture2D LoadTextureToFile(string filename)
        {
            Texture2D load_texture;
            byte[] bytes;
            bytes = System.IO.File.ReadAllBytes(filename);
            load_texture = new Texture2D(1, 1);
            load_texture.LoadImage(bytes);
            return load_texture;
        }

        private string GetFixedPath(string path)
        {
            return (Application.dataPath.Remove(Application.dataPath.Length - 6)) + path;
        }
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(BrandManager))]
    public class BrandManagerEditor : Editor
    {
        BrandManager manager;

        public void OnEnable()
        {
            manager = (BrandManager)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();

            if (GUILayout.Button("Load"))
            {
                if (!EditorApplication.isPlaying)
                    manager.LoadBranding();
                else
                    Debug.LogError("Cannot Load a Brand - Editor in Play Mode.");
            }
        }
    }
#endif
}

