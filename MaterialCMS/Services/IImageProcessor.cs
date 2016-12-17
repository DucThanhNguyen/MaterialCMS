using System.Drawing;
using System.IO;
using MaterialCMS.Entities.Documents.Media;
using MaterialCMS.Settings;

namespace MaterialCMS.Services
{
    public interface IImageProcessor
    {
        MediaFile GetImage(string imageUrl);
        Crop GetCrop(string imageUrl);

        void SetFileDimensions(MediaFile file, Stream stream);
        void SaveResizedImage(MediaFile file, Size size, byte[] fileBytes, string fileUrl);
        void SaveResizedCrop(Crop crop, Size size, byte[] fileBytes, string fileUrl);
        void SaveCrop(MediaFile file, CropType cropType, Rectangle cropInfo, byte[] fileBytes, string fileUrl);
        void EnforceMaxSize(ref Stream stream, MediaFile file, MediaSettings mediaSettings);
    }
}