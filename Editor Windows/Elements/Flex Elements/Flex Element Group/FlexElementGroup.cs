#if UNITY_EDITOR && YNL_UTILITIES
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;

namespace YNL.Editors.UIElements.Flexs
{
    public class FlexElementGroup : VisualElement
    {
        private const string _styleSheet = "Style Sheets/Elements/Specials/Flex Element Group/FlexElementGroup";

        public FlexElementGroup(params VisualElement[] elements)
        {
            this.AddStyle(_styleSheet).AddClass("Main");

            this.AddElements(elements);  
        }
    }
}
#endif