using UniRx;

public class ProfileViewModel
{
    public readonly ReactiveProperty<string> UserName;

    public ProfileViewModel()
    {
        UserName = new StringReactiveProperty();
    }
}