using CMS;
using Kentico.PageBuilder.Web.Mvc;
using RBT.Xperience.Core.Components.HeroImage.HeroImage;

[assembly: AssemblyDiscoverable]
[assembly: RegisterWidget(HeroImageViewComponent.IDENTIFIER, typeof(HeroImageViewComponent), "Hero Image Widget", typeof(HeroImageProperties), Description = "Displays an Text, Image", IconClass = "icon-badge")]
