

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Styles of page animations for appearing / disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation takes place
        /// </summary>
        None = 0,
    
        /// <summary>
        /// Page slides in and fades in from Right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// Page slides in and fades out to left
        /// </summary>
        SlideAndFadeOutToLeft = 2,

        /// <summary>
        /// Page slides in from right (no fade in)
        /// </summary>
        SlideInFromRight = 3,

        /// <summary>
        /// Page slides in from left (no fade in)
        /// </summary>
        SlideInFromLeft = 4,

        /// <summary>
        /// Page slides out to left (no fade out)
        /// </summary>
        SlideOutToLeft = 5,

        /// <summary>
        /// Page slides out to right (no fade out)
        /// </summary>
        SlideOutToRight = 6,

        /// <summary>
        /// Page slides in from bottom (no fade in)
        /// </summary>
        SlideInFromBottom = 7,

        /// <summary>
        /// Page slides in from top (no fade in)
        /// </summary>
        SlideInFromTop = 8,

        /// <summary>
        /// Page slides out to top (no fade out)
        /// </summary>
        SlideOutToTop = 9,

        /// <summary>
        /// Page slides out to bottom (no fade out)
        /// </summary>
        SlideOutToBottom = 10,

    }
}
