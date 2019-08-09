
using Pharmacy2UApplication.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pharm2UAnimations
{
    /// <summary>
    /// A base page class that all viewable pages will inherit from.
    /// And is the basis for Animations of individual pages
    /// </summary>
    public class BasePageAnimation : Page
    {
        #region Private Member

        /// <summary>
        /// The View Model associated with this page
        /// </summary>
        private object mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The animation to play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag to indicate if this page should animate out on load
        /// Useful for when we are moving a page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        public object VieWModelObject
        {
            get => mViewModel;
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                // Update the value
                mViewModel = value;

                // Fire the view model changed method
                OnViewModelChanged();

                // Set the data context for this page
                DataContext = mViewModel;

            }
        }

        #endregion

        #region Default Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePageAnimation()
        {
            // Set our base page dimensions
            // TODO:  Move these defaults into a style that affects every Base Page automatically
            //this.Width = 800;
            //this.Height = 1100;
            //this.MinWidth = 800;
            //this.MinHeight = 500;

            // if we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload
        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            // if we are setup to animate out on load
            if (ShouldAnimateOut)
                // Animate out the page
                await AnimateOutAsync();
            // Otherwise...
            else
                // Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            // Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    // Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    //await this.SlideInFromLeft(this.SlideSeconds);
                    //await this.SlideInFromTop(this.SlideSeconds);
                    //await this.SlideInFromBottom(this.SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Animates the page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            // Make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    // Start the animation
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
                    //await this.SlideOutToRight(this.SlideSeconds);
                    //await this.SlideOutToTop(this.SlideSeconds);
                    //await this.SlideOutToBottom(this.SlideSeconds);

                    break;
            }
        }

        #endregion

        protected virtual void OnViewModelChanged()
        {

        }

    }
}

