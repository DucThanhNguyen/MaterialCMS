using System.Drawing;
using MaterialCMS.Entities.Documents.Media;

namespace MaterialCMS.Services
{
    public interface ICropService
    {
        Crop CreateCrop(MediaFile file, CropType cropType, Rectangle details);
    }
}