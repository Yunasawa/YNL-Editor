#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using YNL.Extensions.Methods;

namespace YNL.Editors.Windows
{

    public class PopupWindow<T> : EditorWindow where T : PopupWindow<T>
    {
        private static T _instance;

        public static void Open(int width = 300, int height = 200, WPopupPivot pivot = WPopupPivot.TopLeft, params object[] parameters)
        {
            T window = CreateInstance<T>();
            if (!_instance.IsNull())
            {
                if (!_instance != window) _instance.Close();
            }
            _instance = window;

            Vector2 mousePos = GUIUtility.GUIToScreenPoint(Event.current.mousePosition);
            if (pivot == WPopupPivot.TopLeft) _instance.position = new Rect(mousePos.x, mousePos.y, width, height);
            if (pivot == WPopupPivot.BottomLeft) _instance.position = new Rect(mousePos.x, mousePos.y - height, width, height);

            _instance.ShowPopup();
            _instance.Initialize(parameters);
            _instance.CreateUI();
        }

        private void OnLostFocus()
        {
            _instance.Close();
        }

        protected virtual void Initialize(params object[] parameters) { }
        protected virtual void CreateUI() { }
    }

    public enum WPopupPivot
    {
        TopLeft, BottomLeft,
    }
}
#endif