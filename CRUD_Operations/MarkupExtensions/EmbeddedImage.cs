using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD_Operations.MarkupExtensions
{
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public EmbeddedImage()
        {
        }
        public string ResourceId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            //check if resourceid is null or empty string
            if (string.IsNullOrWhiteSpace(ResourceId))
                return null;
            return ImageSource.FromResource(ResourceId);
            //return ImageSource.FromResource("CRUD_Operations.Assets.Images.cdc-logo.png");
        }
    }
}
