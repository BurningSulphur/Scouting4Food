using System.Collections.Generic;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using PEAKLib.Core;
using PEAKLib.Items.UnityEditor;

namespace Scouting4Food;

// Here are some basic resources on code style and naming conventions to help
// you in your first CSharp plugin!
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
// https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
// https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces

// This BepInAutoPlugin attribute comes from the Hamunii.BepInEx.AutoPlugin
// NuGet package, and it will generate the BepInPlugin attribute for you!
// For more info, see https://github.com/Hamunii/BepInEx.AutoPlugin
[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    private void Awake()
    {
        // BepInEx gives us a logger which we can use to log information.
        // See https://lethal.wiki/dev/fundamentals/logging
        Log = Logger;

        // BepInEx also gives us a config file for easy configuration.
        // See https://lethal.wiki/dev/intermediate/custom-configs

        // We can apply our hooks here.
        // See https://lethal.wiki/dev/fundamentals/patching-code

        // Log our awake here so we can see it in LogOutput.log file
        Log.LogInfo($"Plugin {Name} is loading");

        LocalizationFix();
        
        this.LoadBundleWithName(
            "chrisps.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("Chrisps items are loaded!");
        this.LoadBundleWithName(
            "extraextremeenergydrink.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("Extra Extreme Energy Drink item is loaded!");
        
        this.LoadBundleWithName(
            "icecream.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("icecream item is loaded!");
        
        this.LoadBundleWithName(
            "gob_stopper.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("gob_stopper item is loaded!");
        this.LoadBundleWithName(
            "melon.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("melon item is loaded!");
        this.LoadBundleWithName(
            "beans.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("beans item is loaded!");
        this.LoadBundleWithName(
            "bandaid.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("bandaid item is loaded!");
        this.LoadBundleWithName(
            "climberschalk.peakbundle", bundle => { bundle.Mod.RegisterContent(); }
        );
        Log.LogInfo("climbers chalk item is loaded!");
    }

    private static void LocalizationFix()
    {
        LocalizedText.mainTable["NAME_SALTY CHRISPS"] = ["Salty Chrisps"];
        LocalizedText.mainTable["NAME_FLAMING HOT CHRISPS"] = ["Flaming Hot Chrisps"];
        LocalizedText.mainTable["NAME_EXTRA EXTREME ENERGY DRINK"] = ["Extra Extreme Energy Drink"];
        LocalizedText.mainTable["NAME_ICECREAM"] = ["Ice Lolly"];
        LocalizedText.mainTable["NAME_POPCICLE STICK"] = ["Popcicle Stick"];
        LocalizedText.mainTable["NAME_GOB STOPPER"] = ["Gob Stopper"];
        LocalizedText.mainTable["NAME_WATERMELON"] = ["Watermelon"];
        LocalizedText.mainTable["NAME_WATERMELON SLICE"] = ["Watermelon Slice"];
        LocalizedText.mainTable["NAME_CAN O' BEANS"] = ["Can O' Beans"];
        LocalizedText.mainTable["NAME_STICKY PLASTER"] = ["Sticky Plaster"];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] = ["Climber's Chalk"];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] = ["Climber's Chalk"];
        LocalizedText.mainTable["chalk up"] = ["chalk up"];
    }
}
