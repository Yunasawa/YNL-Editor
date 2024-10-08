﻿#if UNITY_EDITOR
using System;
using UnityEngine.UIElements;
using YNL.EditorsObsoleted.Extensions;
using YNL.Extensions.Methods;

namespace YNL.EditorsObsoleted.UIElements.Styled
{
    public class StyledSwitchToggle : Button
    {
        public const string _styleSheet = "Style Sheets/Elements/Styled/StyledSwitchToggle";

        public bool Enable = false;

        public Image Background;
        public Image Toggle;

        public Action<bool> OnSwitch;

        public StyledSwitchToggle(bool enable = false) : base()
        {
            Enable = enable;

            this.AddStyle(_styleSheet, ESheet.Font).AddClass("Main");

            Toggle = new Image().AddClass("Toggle").EnableClass(Enable, "Toggle_Enable");
            Background = new Image().AddClass("Background").EnableClass(Enable, "Background_Enable").AddElements(Toggle);
            Background.SetBackgroundImage("Textures/Styles/Switch Toggle/Shadowed/Shadowed - Background");

            this.clicked += Switch;
            this.AddElements(Background);
        }

        public void Switch()
        {
            Enable = !Enable;

            Toggle.EnableClass(Enable, "Toggle_Enable");
            Background.EnableClass(Enable, "Background_Enable");

            OnSwitch?.Invoke(Enable);
        }

        public void SetEnable(bool enable)
        {
            Enable = enable;

            Toggle.EnableClass(Enable, "Toggle_Enable");
            Background.EnableClass(Enable, "Background_Enable");
        }
    }
}
#endif