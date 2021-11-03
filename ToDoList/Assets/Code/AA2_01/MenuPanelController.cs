using UniRx;

public class MenuPanelController 
{
    private readonly MenuPanelViewModel _menuPanelViewModel;
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly ScorePanelViewModel _scorePanelViewModel;
    private readonly SettingsPanelViewModel _settingsPanelViewModel;

    public MenuPanelController(MenuPanelViewModel viewModel, HomePanelViewModel homePanelViewModel, 
        ScorePanelViewModel scorePanelViewModel , SettingsPanelViewModel settingsPanelViewModel)
    {
        _menuPanelViewModel = viewModel;
        _homePanelViewModel = homePanelViewModel;
        _scorePanelViewModel = scorePanelViewModel;
        _settingsPanelViewModel = settingsPanelViewModel;

        _menuPanelViewModel
            .HomeButtonPressed
            .Subscribe((_) =>
            {
                _homePanelViewModel.IsVisible.Value = true;
            });

        _menuPanelViewModel
         .ScoreButtonPressed
         .Subscribe((_) =>
         {
             _scorePanelViewModel.IsVisible.Value = true;
         });

       _menuPanelViewModel
      .SettingsButtonPressed
      .Subscribe((_) =>
      {
          _settingsPanelViewModel.IsVisible.Value = true;
      });
    }
}
