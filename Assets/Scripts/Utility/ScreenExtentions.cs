using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Utility
{
    public static class ScreenExtentions
    {
        public static void FillResolutions(this TMP_Dropdown dropdown, Func<Resolution, string> format)
        {
            dropdown.ClearOptions();

            List<string> options = new();

            foreach(var resolution in Screen.resolutions)
            {
                options.Add(format(resolution));
            }

            dropdown.AddOptions(options);
        }

        public static int GetCurrentResolution()
        {
            Resolution currentResolution = Screen.currentResolution;
            Resolution[] resolutions = Screen.resolutions;
            for (int i = 0; i < resolutions.Length; i++)
            {
                var resolution = resolutions[i];
                if (resolution.width == currentResolution.width &&
                    resolution.height == currentResolution.height &&
                    resolution.refreshRate == currentResolution.refreshRate
                    )
                {
                    return i;
                }
            }

            throw new System.Exception("Resolution do not exist!");
        }
    }
}
