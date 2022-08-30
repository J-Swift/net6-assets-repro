namespace lib;

public class LibClass
{
    public static UIImage GetLibImage()
    {
        return UIImage.FromBundle("image_lib");
    }

    public static UIImage GetSharedImage()
    {
        return UIImage.FromBundle("image_shared");
    }
}
