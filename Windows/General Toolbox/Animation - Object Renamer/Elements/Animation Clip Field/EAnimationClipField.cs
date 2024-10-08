﻿#if UNITY_EDITOR && YNL_UTILITIES
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.EditorsObsoleted.UIElements.Styled;
using YNL.EditorsObsoleted.Extensions;

namespace YNL.EditorsObsoleted.Windows.AnimationObjectRenamer
{
    public class EAnimationClipField : Button
    {
        private const string USS_StyleSheet = "Style Sheets/Windows/General Toolbox/Animation - Object Renamer/EAnimationClipField";

        private const string _uss_field = "e-animation-clip-field__field";
        private const string _uss_color = "e-animation-clip-field__color";
        private const string _uss_clip = "e-animation-clip-field__clip";

        public Image Color;
        public StyledAssetField<AnimationClip> Clip;

        public EAnimationClipField(KeyValuePair<AnimationClip, Color> pair) : base()
        {
            this.AddStyle(USS_StyleSheet);

            Color = new Image().AddClass(_uss_color).SetBackgroundColor(pair.Value);
            Clip = new StyledAssetField<AnimationClip>(pair.Key).AddClass(_uss_clip);

            this.AddClass(_uss_field).AddElements(Clip, Color);
        }
    }
}
#endif