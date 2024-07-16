namespace DevFreela.Infrastruture.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
