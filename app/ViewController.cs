using lib;

namespace app;

public class ViewController : UIViewController
{
    public ViewController()
    {
    }

    public override void LoadView()
    {
        base.LoadView();

        var newImageView = (string text, Func<UIImage> imgGenerator) =>
        {
            var lbl = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Text = text,
            };
            var img = new UIImageView(imgGenerator.Invoke())
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            var sv = new UIStackView(new UIView[] { lbl, img })
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Alignment = UIStackViewAlignment.Center,
            };
            sv.Layer.BorderColor = UIColor.Red.CGColor;
            sv.Layer.BorderWidth = 1;
            View.AddSubview(sv);
            return sv;
        };

        var img1 = newImageView("App", () => UIImage.FromBundle("image_app"));
        var img2 = newImageView("App Shared", () => UIImage.FromBundle("image_shared"));
        var img3 = newImageView("Lib", () => LibClass.GetLibImage());
        var img4 = newImageView("Lib Shared", () => LibClass.GetSharedImage());

        NSLayoutConstraint.ActivateConstraints(new[]
        {
            img1.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
            img1.TopAnchor.ConstraintEqualTo(View.TopAnchor),
            img2.LeadingAnchor.ConstraintEqualTo(img1.TrailingAnchor),
            img2.TopAnchor.ConstraintEqualTo(View.TopAnchor),
            img3.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor),
            img3.TopAnchor.ConstraintEqualTo(img1.BottomAnchor),
            img4.LeadingAnchor.ConstraintEqualTo(img1.TrailingAnchor),
            img4.TopAnchor.ConstraintEqualTo(img1.BottomAnchor),

            img1.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, 0.5f),
            img2.WidthAnchor.ConstraintEqualTo(img1.WidthAnchor),
            img3.WidthAnchor.ConstraintEqualTo(img1.WidthAnchor),
            img4.WidthAnchor.ConstraintEqualTo(img1.WidthAnchor),

            img1.HeightAnchor.ConstraintEqualTo(View.HeightAnchor, 0.5f),
            img2.HeightAnchor.ConstraintEqualTo(img1.HeightAnchor),
            img3.HeightAnchor.ConstraintEqualTo(img1.HeightAnchor),
            img4.HeightAnchor.ConstraintEqualTo(img1.HeightAnchor),
        });
    }
}

