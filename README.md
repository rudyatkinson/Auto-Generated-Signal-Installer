# Auto-Generated-Signal-Installer [AGSI]

[![Test](https://github.com/rudyatkinson/Auto-Generated-Signal-Installer/actions/workflows/test.yaml/badge.svg)](https://github.com/rudyatkinson/Auto-Generated-Signal-Installer/actions/workflows/test.yaml)

Support plugin to automate signal binding.

## Installation

*Requires Unity 2018.4+*

### Install via UPM (using Git URL)

1. Navigate to your project's Packages folder and open the manifest.json file.
2. Add this line below the "dependencies": { line
    - ```json title="Packages/manifest.json"
      "com.rudyatkinson.agsi": "https://github.com/rudyatkinson/Auto-Generated-Signal-Installer.git?path=Assets/AGSI/Scripts",
      ```

    or you can use UPM directly, 
    ```
      https://github.com/rudyatkinson/Auto-Generated-Signal-Installer.git?path=Assets/AGSI/Scripts
      ```
    
3. UPM should now install the package.

## Basic Usage

1. First, create a class to use it as signal and implement IAutoGenerateSignal interface.

```csharp
public class ASignal : IAutoGenerateSignal
{
    
}
```

2. AGSI will automatically detect and create a signal installer in the default path (Assets/Installer).
3. Further, you can customize the installer path and signal installer class name, or disable automatic code generation and generate the signal installer manually.
4. At the last step, you must add the signal installer as a component into the context.

## License

MIT
