

namespace Frontend.Client
{
    using Caliburn.Micro;
    using Frontend.Core.ViewModels;
    using Frontend.Core.ViewModels.Interfaces;

    public class ShellViewModel : IShell 
    {
        private IEventAggregator eventAggregator;
        private IFrameViewModel frameViewModel;

        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public IFrameViewModel FrameViewModel 
        { 
            get
            {
                if (this.frameViewModel == null)
                {
                    this.frameViewModel = new FrameViewModel(this.eventAggregator);
                    var welcomeViewModel = new WelcomeViewModel(this.eventAggregator);

                    this.frameViewModel.Steps.Add(welcomeViewModel);
                    this.FrameViewModel.MoveToStep(welcomeViewModel);
                }

                return this.frameViewModel;
            }
        }
    }
}