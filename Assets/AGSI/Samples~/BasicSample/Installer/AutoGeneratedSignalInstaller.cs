using Zenject;
using Sample.Scripts.Signals;

public class AutoGeneratedSignalInstaller : MonoInstaller 
{ 
     public override void InstallBindings()
     {
          SignalBusInstaller.Install(Container);
          Container.DeclareSignal<BackButtonClickSignal>();
          Container.DeclareSignal<PlayButtonClickSignal>();
     }
}