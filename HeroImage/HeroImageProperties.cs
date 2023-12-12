using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

using System.ComponentModel.DataAnnotations;


namespace RBT.Xperience.Core.Components.HeroImage.HeroImage
{
    public class HeroImageProperties : IWidgetProperties

    {
        /// <summary>
        /// Declaring to set the visibility for the widget
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Visible")]
        public bool? Visible { get; set; } = true;
        /// <summary>
        /// Declaring to set the Hero title
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Hero Title")]
        [EditingComponentProperty("Size", 1000)]
        public string? HeroTitle { get; set; }
        /// <summary>
        /// Declaring to set the Hero description
        /// </summary>
        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 2, Label = "Hero Description", Tooltip = "Add Description")]
        [EditingComponentProperty("Size", 1000)]
        public string? HeroDescription { get; set; }
        /// <summary>
        /// Declaring Hero Image - Small
        /// </summary>
        /// 
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 3, Label = "Hero Image - Small*")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        public IEnumerable<MediaFilesSelectorItem>? ImageSmall { get; set; }

        /// <summary>
        /// Declaring Hero Image - Medium
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 4, Label = "Hero Image - Medium*")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        public IEnumerable<MediaFilesSelectorItem>? ImageMedium { get; set; } 
        /// <summary>
        /// Declaring Hero Image - Large
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 5, Label = "Hero Image - Large*")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        [Required(ErrorMessage = "Please Select Hero Image - Large")]
        public IEnumerable<MediaFilesSelectorItem>? ImageLarge { get; set; }
        /// <summary>
        /// Declaring Hero Image - X Large
        /// </summary>
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 6, Label = "Hero Image - X Large*")]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 1)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.AllowedExtensions), ".gif;.png;.jpg;.jpeg;.svg;.webp")]
        public IEnumerable<MediaFilesSelectorItem>? ImageXLarge { get; set; }
        /// <summary>
        /// Declaring add the button
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 7, Label = "Add Button", Tooltip = "Enable to add the Button")]
        public bool? AddButton { get; set; } = false;
        /// <summary>
        /// Declaring Button Text
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 8, Label = "Button Text")]
        [VisibilityCondition(nameof(AddButton), ComparisonTypeEnum.IsTrue)]
        public string? ButtonText { get; set; }
        [EditingComponent(UrlSelector.IDENTIFIER, Order = 9, Label = "Button URL")]
        [VisibilityCondition(nameof(AddButton), ComparisonTypeEnum.IsTrue)]
        public string? ButtonUrl { get; set; }
        /// <summary>
        /// Declaring Button target
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "Button Target", Order = 10, Tooltip = "select the Target")]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "_Self \r\n _Blank")]
        [VisibilityCondition(nameof(AddButton), ComparisonTypeEnum.IsTrue)]
        public string? ButtonTarget { get; set; }
        /// <summary>
        /// Select the transformation or view name
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Transformation", Order = 11)]
        public string? ViewName { get; set; }

    }
}
