using UniRx;

public class MenuPanelController 
{
    private readonly MenuPanelViewModel _menuPanelViewModel;
    private readonly HomePanelViewModel _homePanelViewModel;
    private readonly ScorePanelViewModel _scorePanelViewModel;

    public MenuPanelController(MenuPanelViewModel viewModel, HomePanelViewModel homePanelViewModel, ScorePanelViewModel scorePanelViewModel)
    {
        _menuPanelViewModel = viewModel;
        _homePanelViewModel = homePanelViewModel;
        _scorePanelViewModel = scorePanelViewModel;

        _menuPanelViewModel
            .HomeButtonPressed
            .Subscribe((_) =>
            {
                _homePanelViewModel.IsVisible.Value = true;
                _scorePanelViewModel.IsVisible.Value = false;
            });

        _menuPanelViewModel
         .ScoreButtonPressed
         .Subscribe((_) =>
         {
             _scorePanelViewModel.IsVisible.Value = false;
             _scorePanelViewModel.IsVisible.Value = true;
         });
    }
}
