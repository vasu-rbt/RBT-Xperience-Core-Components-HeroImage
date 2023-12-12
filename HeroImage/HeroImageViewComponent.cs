
using AngleSharp.Media;

using CMS.Core;
using CMS.MediaLibrary;
using CMS.SiteProvider;

using DocumentFormat.OpenXml.EMMA;

using Kentico.PageBuilder.Web.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

using RBT.Xperience.Core.Components.HeroImage.HeroImage;

[assembly: RegisterWidget(HeroImageViewComponent.IDENTIFIER, typeof(HeroImageViewComponent), "Hero Image Widget", typeof(HeroImageProperties), Description = "Displays an Text, Image", IconClass = "icon-badge")]

namespace RBT.Xperience.Core.Components.HeroImage.HeroImage
{
    public class HeroImageViewComponent : ViewComponent
    {

        /// <summary>
        /// Identifier for the HerobannerImage Widget
        /// </summary>
        public const string IDENTIFIER = "RBT.Xperience.Widget.HeroImage";

        private readonly IEventLogService _eventLogService;

        public HeroImageViewComponent(IEventLogService eventLogService)
        {
            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
        }

        public async Task<IViewComponentResult> InvokeAsync(HeroImageProperties properties, CancellationToken? cancellationToken = null)
        {
            try
            {
                string imagelargeURL = string.Empty;
                string imagesmallURL = string.Empty;
                string imagemediumURL = string.Empty;
                string imagexlargeURL = string.Empty;
                if (properties != null)
                {
                    if (properties.ImageLarge != null)
                    {

                        var imagelargeguid = properties?.ImageLarge?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (imagelargeguid != null)
                        {
                            var imagelargeInfo = MediaFileInfoProvider.GetMediaFileInfo(imagelargeguid, SiteContext.CurrentSiteName);
                            if (imagelargeInfo != null)
                            {
                                imagelargeURL = MediaFileURLProvider.GetMediaFileUrl(imagelargeInfo.FileGUID, imagelargeInfo.FileName) ?? string.Empty;
                            }
                        }
                    }

                    if (properties.ImageMedium != null)
                    {
                        var imagemediumguid = properties?.ImageMedium?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (imagemediumguid != null)
                        {
                            var imagemediumInfo = MediaFileInfoProvider.GetMediaFileInfo(imagemediumguid, SiteContext.CurrentSiteName);
                            if (imagemediumInfo != null)
                            {
                                imagemediumURL = MediaFileURLProvider.GetMediaFileUrl(imagemediumInfo.FileGUID, imagemediumInfo.FileName) ?? string.Empty;
                            }
                        }
                    }

                    if (properties.ImageSmall != null)
                    {

                        var imagesmallguid = properties?.ImageSmall?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (imagesmallguid != null)
                        {
                            var imagesmallInfo = MediaFileInfoProvider.GetMediaFileInfo(imagesmallguid, SiteContext.CurrentSiteName);
                            if (imagesmallInfo != null)
                            {
                                imagesmallURL = MediaFileURLProvider.GetMediaFileUrl(imagesmallInfo.FileGUID, imagesmallInfo.FileName) ?? string.Empty;
                            }
                        }
                    }

                    if (properties.ImageXLarge != null)
                    {

                        var imagexlargeguid = properties?.ImageSmall?.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                        if (imagexlargeguid != null)
                        {
                            var imagexlargeInfo = MediaFileInfoProvider.GetMediaFileInfo(imagexlargeguid, SiteContext.CurrentSiteName);
                            if (imagexlargeInfo != null)
                            {
                                imagexlargeURL = MediaFileURLProvider.GetMediaFileUrl(imagexlargeInfo.FileGUID, imagexlargeInfo.FileName) ?? string.Empty;
                            }
                        }
                    }

                    HeroImageViewModel _bannerModel = new();
                    _bannerModel.Visible = properties.Visible;
                    _bannerModel.HeroTitle = properties.HeroTitle;
                    _bannerModel.HeroDescription = properties.HeroDescription;
                    _bannerModel.ImageLarge = imagelargeURL;
                    _bannerModel.ImageSmall = imagesmallURL;
                    _bannerModel.ImageMedium = imagemediumURL;
                    _bannerModel.ImageXLarge = imagexlargeURL;
                    _bannerModel.AddButton = properties.AddButton;
                    _bannerModel.ButtonText = properties.ButtonText;
                    _bannerModel.ButtonUrl = properties.ButtonUrl;
                    _bannerModel.ButtonTarget = properties.ButtonTarget;
                    return await Task.FromResult((IViewComponentResult)View("~/Views/Shared/HeroImage/" + properties.ViewName + ".cshtml", _bannerModel));

                }

                else { return await Task.FromResult<IViewComponentResult>(Content(string.Empty)); }


            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(HeroImageViewComponent), nameof(InvokeAsync), ex);
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
        }

    }
}