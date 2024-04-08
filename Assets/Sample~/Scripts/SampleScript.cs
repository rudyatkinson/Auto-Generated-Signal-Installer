using Sample.Scripts.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SampleScript : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _backButton;

    private SignalBus _signalBus;
    
    [Inject]
    private void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }
    
    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _backButton.onClick.AddListener(OnBackButtonClick);
        
        _signalBus.Subscribe<PlayButtonClickSignal>(OnPlayButtonClickSignalReceived);
        _signalBus.Subscribe<BackButtonClickSignal>(OnBackButtonClickSignalReceived);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _backButton.onClick.RemoveListener(OnBackButtonClick);
        
        _signalBus.Unsubscribe<PlayButtonClickSignal>(OnPlayButtonClickSignalReceived);
        _signalBus.Unsubscribe<BackButtonClickSignal>(OnBackButtonClickSignalReceived);
    }

    private void OnPlayButtonClick()
    {
        _signalBus.Fire<PlayButtonClickSignal>();
    }
    
    private void OnBackButtonClick()
    {
        _signalBus.Fire<BackButtonClickSignal>();
    }
    
    private void OnPlayButtonClickSignalReceived()
    {
        _playButton.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(true);
    }

    private void OnBackButtonClickSignalReceived()
    {
        _playButton.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(false);
    }
}
