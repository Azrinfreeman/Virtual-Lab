using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Single source of truth for BioNutri-MM colours. See COLOR_IMPLEMENTATION_PLAN.md.
/// Colour = state: brand hues never mean correct/wrong; success/error/warning appear only after the game judges something.
/// </summary>
public static class BioPalette
{
    static Color Hex(string hex)
    {
        ColorUtility.TryParseHtmlString(hex, out var c);
        return c;
    }

    // Surfaces
    public static readonly Color SurfaceBase    = Hex("#14103F");
    public static readonly Color SurfaceRaised  = Hex("#221C5C");
    public static readonly Color SurfaceOverlay = Hex("#2C2670");
    public static readonly Color SurfacePaper   = Hex("#F6F1E4");
    public static readonly Color SurfaceField   = Hex("#FFFFFF");

    // Text (on dark) and ink (on paper)
    public static readonly Color TextPrimary    = Hex("#F4F2FF");
    public static readonly Color TextSecondary  = Hex("#C9C4EE");
    public static readonly Color TextMuted      = Hex("#A39DD6");
    public static readonly Color TextDisabled   = Hex("#8F89C4");
    public static readonly Color InkPrimary     = Hex("#1E1B3A");
    public static readonly Color InkMuted       = Hex("#5B5780");
    public static readonly Color InkPlaceholder = Hex("#6F6A94");

    // Interaction (brand, never feedback)
    public static readonly Color ActionPrimary        = Hex("#17508C");
    public static readonly Color ActionPrimaryHover   = Hex("#2A6AAE");
    public static readonly Color ActionPrimaryPressed = Hex("#0F3C6B");
    public static readonly Color FocusRing    = Hex("#FFFFFF");
    public static readonly Color Select       = Hex("#B8A9FF"); // on dark
    public static readonly Color SelectOnPaper = Hex("#5B3FD1");
    public static readonly Color FieldBorder  = Hex("#7B75AD");

    // Feedback (reserved: only after evaluation)
    public static readonly Color Success        = Hex("#3DDC97");
    public static readonly Color SuccessOnPaper = Hex("#0F7A4A");
    public static readonly Color Error          = Hex("#FF6B6B");
    public static readonly Color ErrorOnPaper   = Hex("#B3261E");
    public static readonly Color Warning        = Hex("#FFB020");
    public static readonly Color WarningOnPaper = Hex("#8A5A00");
    public static readonly Color Info           = Hex("#5CC8FF");

    /// <summary>
    /// Topic tags (activity 1..8): pastel stripes, deliberately lighter and less saturated than the feedback colours.
    /// Always accompanied by the topic name, so colour is never the only signal. Never used for correct/wrong.
    /// </summary>
    public static readonly Color[] TopicTags =
    {
        new Color32(0xC9, 0xB6, 0xF2, 255), // 1 Sistem Pencernaan - lilac
        new Color32(0xF2, 0xD4, 0x9B, 255), // 2 Karbohidrat - wheat
        new Color32(0xF0, 0xB7, 0xC8, 255), // 3 Protein - rose
        new Color32(0xF5, 0xE6, 0xA0, 255), // 4 Lipid - butter
        new Color32(0xF5, 0xB9, 0x8A, 255), // 5 Tenaga Makanan - apricot
        new Color32(0xFF, 0xC4, 0x6B, 255), // 6 Vitamin C - citrus
        new Color32(0x9E, 0xD8, 0xD0, 255), // 7 Suhu dan Vitamin C - mint
        new Color32(0x9F, 0xC7, 0xF0, 255), // 8 Pemakanan Sihat - sky
    };

    /// <summary>Tint-free ColorBlock: sprite stays full colour at rest, brightens on hover, darkens on press.</summary>
    public static ColorBlock ActionColors()
    {
        var cb = ColorBlock.defaultColorBlock;
        cb.normalColor      = Color.white;
        cb.highlightedColor = Hex("#E8F3FF");
        cb.selectedColor    = Color.white;
        cb.pressedColor     = Hex("#B9C9E0");
        cb.disabledColor    = new Color(0.62f, 0.60f, 0.78f, 0.55f);
        cb.colorMultiplier  = 1f;
        cb.fadeDuration     = 0.1f;
        return cb;
    }

    /// <summary>Quiz option block: selected state is violet, never red/green (those come only after checking).</summary>
    public static ColorBlock ChoiceSelectedColors()
    {
        var cb = ActionColors();
        cb.normalColor = Hex("#CFC4FF");
        cb.selectedColor = cb.normalColor;
        return cb;
    }
}
