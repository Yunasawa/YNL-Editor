#if UNITY_EDITOR
using UnityEngine.UIElements;
using YNL.Editors.Extensions;

namespace YNL.Editors.Windows.TextureImageResizer
{
    public class Instruction : PopupWindow<Instruction>
    {
        private const string _styleSheet = "Style Sheets/Windows/W - Utilities/Texture - Image Resizer/WTextureImageResizer_Popup";

        public ScrollView Scroll;
        public Image Image;

        protected override void CreateUI()
        {
            this.rootVisualElement.AddStyle(_styleSheet).AddClass("Main");

            Image = new Image().AddClass("Image");

            Scroll = new ScrollView().AddClass("Scroll").AddElements(Image);

            this.rootVisualElement.AddElements(Scroll);
        }
    }
}
#endif