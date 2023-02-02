using UnityEngine;

namespace Branding
{
    [CreateAssetMenu(fileName = "New Brand", menuName = "Branding/New Brand")]
    public class Brand : ScriptableObject
    {
        [Header("Basic Information")]

        [SerializeField] 
        private string companyName;
        public string CompanyName { get { return companyName; } }
        [SerializeField] private string productName;
        public string ProductName { get { return productName; } }
        [SerializeField] private string version;
        public string Version { get { return version; } }
        [SerializeField] private Sprite defaultIcon;
        public Sprite DefaultIcon { get { return defaultIcon; } }
        [SerializeField] private Sprite logo;
        public Sprite Logo { get { return logo; } }

        [Header("Application Color Theme")]

        [SerializeField] private Color primaryBrandColor = Color.white;
        public Color PrimaryBrandColor { get { return primaryBrandColor; } }
        [SerializeField] private Color secondaryBrandColor = Color.black;
        public Color SecondaryBrandColor { get { return secondaryBrandColor; } }

        [Header("Splash Screen")]

        [SerializeField] private Sprite splashLogo;
        public Sprite SplashLogo { get { return splashLogo; } }
        [SerializeField] private Color splashBackground = Color.white;
        public Color SplashBackground { get { return splashBackground; } }

        [Header("Bundle Details")]

        [SerializeField] private int bundleNumber;
        public int BundleNumber { get { return bundleNumber; } }
        [SerializeField] private string bundleIdentifierIOS;
        public string BundleIdentifierIOS { get { return BundleIdentifierIOS; } }
        [SerializeField] private string bundleIdentifierAndroid;
        public string BundleIdentifierAndroid { get { return BundleIdentifierAndroid; } }
    }
}


