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
    {//                                                                English                          Français                      Italiano                      Deutsch                       Español  (España)                      Español (LatAm)               Português (BR)                Русский                       Українська                    简体中文                       繁體中文                        日本語                         한국어                              Polski                                 Türkçe
        LocalizedText.mainTable["NAME_CHICKEN DRUMSTICK"] =           ["CHICKEN DRUMSTICK"             ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"MUSLO DE POLLO"                       ,"PATA DE POLLO"                    ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"          ,"CHICKEN DRUMSTICK"              ,"OGROMNE UDKO Z KURCZAKA"               ,"CHICKEN DRUMSTICK"                  ];
        LocalizedText.mainTable["NAME_SALTY CHRISPS"] =               ["SALTY CHRISPS"                 ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"PATATAS FRITAS"                       ,"PAPAS FRITAS"                     ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"              ,"SALTY CHRISPS"                  ,"SŁONE CZIPSY"                          ,"SALTY CHRISPS"                      ];
        LocalizedText.mainTable["NAME_FLAMING HOT CHRISPS"] =         ["FLAMING HOT CHRISPS"           ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"PATATAS FRITAS PICANTES"              ,"PAPAS FRITAS PICANTES"            ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"        ,"FLAMING HOT CHRISPS"            ,"OGNISTE CZIPSY"                        ,"FLAMING HOT CHRISPS"                ];
        LocalizedText.mainTable["NAME_EXTRA EXTREME ENERGY DRINK"] =  ["EXTRA EXTREME ENERGY DRINK"    ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"BEBIDA ENERGÉTICA SÚPER EXTREMA"      ,"BEBIDA ENERGÉTICA SÚPER EXTREMA"  ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK" ,"EXTRA EXTREME ENERGY DRINK"     ,"EKSTREMALNY NAPÓJ ENERGETYCZNY"        ,"EXTRA EXTREME ENERGY DRINK"         ];
        LocalizedText.mainTable["NAME_ICECREAM"] =                    ["ICE LOLLY"                     ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"POLO"                                 ,"PALETA HELADA"                    ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                  ,"ICE LOLLY"                      ,"LÓD NA PATYKU"                         ,"ICE LOLLY"                          ];
        LocalizedText.mainTable["NAME_POPCICLE STICK"] =              ["POPCICLE STICK"                ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"PALITO DE POLO"                       ,"PALITO DE HELADO"                 ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"             ,"POPCICLE STICK"                 ,"PATYCZEK OD LODA"                      ,"POPCICLE STICK"                     ];
        LocalizedText.mainTable["NAME_GOB STOPPER"] =                 ["GOB STOPPER"                   ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                ,"ROMPEMUELAS"                          ,"ROMPEMUELAS"                      ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                ,"GOB STOPPER"                    ,"ŁAMISZCZĘKA"                           ,"GOB STOPPER"                        ];
        LocalizedText.mainTable["NAME_WATERMELON"] =                  ["WATERMELON"                    ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                 ,"SANDÍA"                               ,"SANDÍA"                           ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                 ,"WATERMELON"                     ,"ARBUZ"                                 ,"WATERMELON"                         ];
        LocalizedText.mainTable["NAME_WATERMELON SLICE"] =            ["WATERMELON SLICE"              ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"REBANADA DE SANDÍA"                   ,"REBANADA DE SANDÍA"               ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"           ,"WATERMELON SLICE"               ,"CZĘŚĆ ARBUZA"                          ,"WATERMELON SLICE"                   ];
        LocalizedText.mainTable["NAME_CAN O' BEANS"] =                ["CAN O' BEANS"                  ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"LATA DE HABICHUELAS"                  ,"LATA DE FRIJOLES"                 ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"               ,"CAN O' BEANS"                   ,"PUSZKA FASOLI"                         ,"CAN O' BEANS"                       ];
        LocalizedText.mainTable["NAME_STICKY PLASTER"] =              ["STICKY PLASTER"                ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"TIRITA"                               ,"CURITA"                           ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"             ,"STICKY PLASTER"                 ,"PLASTER"                               ,"STICKY PLASTER"                     ];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] =             ["CLIMBER'S CHALK"               ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"MAGNESIO DE ESCALADA"                 ,"MAGNESIO EN POLVO"                ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"                ,"MAGNEZJA WSPINACZKOWA"                 ,"CLIMBER'S CHALK"                    ];
        LocalizedText.mainTable["NAME_CLIMBER'S CHALK"] =             ["CLIMBER'S CHALK"               ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"MAGNESIO DE ESCALADA"                 ,"MAGNESIO EN POLVO"                ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"            ,"CLIMBER'S CHALK"                ,"MAGNEZJA WSPINACZKOWA"                 ,"CLIMBER'S CHALK"                    ];
        LocalizedText.mainTable["CHALKUP"] =                          ["CHALK UP"                      ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                   , "ECHARSE MAGNESIO"                    ,"PONERSE MAGNESIO"                 ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                   ,"CHALK UP"                       ,"POSYP"                                 ,"CHALK UP"                           ];
    }
}