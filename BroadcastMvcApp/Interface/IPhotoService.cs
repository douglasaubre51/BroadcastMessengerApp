using System;
using CloudinaryDotNet.Actions;

namespace BroadcastMvcApp.Interface;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

}
