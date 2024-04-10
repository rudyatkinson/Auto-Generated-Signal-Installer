using Zenject;
using RudyAtkinson.AGSI.Tests;

public class AutoGeneratedSignalInstaller : MonoInstaller 
{ 
     public override void InstallBindings()
     {
          SignalBusInstaller.Install(Container);
          Container.DeclareSignal<ASignal>();
          Container.DeclareSignal<BSignal>();
     }
}