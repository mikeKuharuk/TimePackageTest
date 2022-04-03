using System.Globalization;
using TimeProvider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainExample : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

    private ITimeService _timeService = new TimeService();
    private void Start()
    {
       _button.onClick.AddListener(ButtonClickHandler);
    }

    private void ButtonClickHandler()
    {
        var providerType = (ProviderType) _dropdown.value;
        _text.text = $"{providerType.ToString()} : {_timeService.GetTime(providerType).ToString(CultureInfo.CurrentCulture)}";
    }
}
