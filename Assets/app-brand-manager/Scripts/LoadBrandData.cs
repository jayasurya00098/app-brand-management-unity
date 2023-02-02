using UnityEngine;
using Branding;
using TMPro;
using UnityEngine.UI;

public class LoadBrandData : MonoBehaviour
{
    [SerializeField] private BrandManager brandManager;

    [Space]

    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        background.color = brandManager.CurrentBrand.PrimaryBrandColor;
        text.color = brandManager.CurrentBrand.SecondaryBrandColor;
    }
}
