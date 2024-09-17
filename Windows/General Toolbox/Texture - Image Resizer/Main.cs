﻿#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Editors.UIElements.Styled;

namespace YNL.Editors.Windows.TextureImageResizer
{
    [System.Serializable]
    public class Main : IMain
    {
        #region ▶ Editor Properties
        public EditorWindow Root;

        public Visual Visual;
        public Handler Handler;
        #endregion
        #region ▶ Actions
        public static Action<UnityEngine.Object[]> OnAddImage;
        public static Action<Texture2D> OnRemoveImage;
        #endregion

        public Main(EditorWindow root, StyledWindowTagPanel tagPanel)
        {
            Root = root;

            Handler = new(this);
            Visual = new(tagPanel, this);
        }

        public void OpenInstruction()
        {

            Instruction.Open(660, 500, WPopupPivot.BottomLeft);
        }
    }
}
#endif