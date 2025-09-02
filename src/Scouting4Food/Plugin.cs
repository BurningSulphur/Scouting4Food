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

        this.LoadBundleAndContentsWithName("chrisps.peakbundle");
        Log.LogInfo("Chrisps items are loaded!");
        this.LoadBundleAndContentsWithName("extraextremeenergydrink.peakbundle");
        Log.LogInfo("Extra Extreme Energy Drink item is loaded!");
        this.LoadBundleAndContentsWithName("icecream.peakbundle");
        Log.LogInfo("Icecream item is loaded!");
        this.LoadBundleAndContentsWithName("gob_stopper.peakbundle");
        Log.LogInfo("gob_stopper item is loaded!");
        this.LoadBundleAndContentsWithName("melon.peakbundle");
        Log.LogInfo("melon item is loaded!");
        this.LoadBundleAndContentsWithName("beans.peakbundle");
        Log.LogInfo("beans item is loaded!");
        this.LoadBundleAndContentsWithName("bandaid.peakbundle");
        Log.LogInfo("bandaid item is loaded!");
        this.LoadBundleAndContentsWithName("climberschalk.peakbundle");
        Log.LogInfo("climbers chalk item is loaded!");
        this.LoadBundleAndContentsWithName("chickenleg.peakbundle");
        Log.LogInfo("chicken leg item is loaded!");

    }

    private static void LocalizationFix()
    {//                                                                English                          Français                      Italiano                      Deutsch                       Español  (España)             Español (LatAm)               Português (BR)                Русский                       Українська                    简体中文                       繁體中文                        日本語                         한국어                              Polski                                 Türkçe
        LocalizedText.mainTable["NAME_HUGE CHICKEN LEG"] =            ["Huge Chicken Thigh"              ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"           ,"Huge Chicken Leg"               ,"OGROMNE UDKO Z KURCZAKA"                 ,"Huge Chicken Leg"                   ];
        LocalizedText.mainTable["NAME_SALTY CHRISPS"] =               ["Salty Chrisps"                 ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"              ,"Salty Chrisps"                  ,"Słone Czipsy"                          ,"Salty Chrisps"                      ];
        LocalizedText.mainTable["NAME_FLAMING HOT CHRISPS"] =         ["Flaming Hot Chrisps"           ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"        ,"Flaming Hot Chrisps"            ,"Ogniste Czipsy"                        ,"Flaming Hot Chrisps"                ];
        LocalizedText.mainTable["NAME_EXTRA EXTREME ENERGY DRINK"] =  ["Extra Extreme Energy Drink"    ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink" ,"Extra Extreme Energy Drink"     ,"Ekstremalny napój energetyczny"        ,"Extra Extreme Energy Drink"         ];
        LocalizedText.mainTable["NAME_ICECREAM"] =                    ["Ice Lolly"                     ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                  ,"Ice Lolly"                      ,"Lód na patyku"                         ,"Ice Lolly"                          ];
        LocalizedText.mainTable["NAME_POPCICLE STICK"] =              ["Popcicle Stick"                ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"             ,"Popcicle Stick"                 ,"Patyczek od loda"                      ,"Popcicle Stick"                     ];
        LocalizedText.mainTable["NAME_GOB STOPPER"] =                 ["Gob Stopper"                   ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                ,"Gob Stopper"                    ,"Łamiszczęka"                           ,"Gob Stopper"                        ];
        LocalizedText.mainTable["NAME_WATERMELON"] =                  ["Watermelon"                    ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                 ,"Watermelon"                     ,"Arbuz"                                 ,"Watermelon"                         ];
        LocalizedText.mainTable["NAME_WATERMELON SLICE"] =            ["Watermelon Slice"              ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"           ,"Watermelon Slice"               ,"Część Arbuza"                          ,"Watermelon Slice"                   ];
        LocalizedText.mainTable["NAME_CAN O' BEANS"] =                ["Can O' Beans"                  ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"               ,"Can O' Beans"                   ,"Puszka fasoli"                         ,"Can O' Beans"                       ];
        LocalizedText.mainTable["NAME_STICKY PLASTER"] =              ["Sticky Plaster"                ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"             ,"Sticky Plaster"                 ,"Plaster"                               ,"Sticky Plaster"                     ];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] =             ["Climber's Chalk"               ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"                ,"Magnezja wspinaczkowa"                 ,"Climber's Chalk"                    ];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] =             ["Climber's Chalk"               ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"            ,"Climber's Chalk"                ,"Magnezja wspinaczkowa"                 ,"Climber's Chalk"                    ];
        LocalizedText.mainTable["chalk up"] =                         ["chalk up"                      ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                   ,"chalk up"                       ,"Posyp na dłonie"                       ,"chalk up"                           ]; 
    }
}