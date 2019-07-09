
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        #region Slide and Fade Combo Animations
        /// <summary>
        /// Slides a page in from the right and fades in
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideInFromRight(seconds, page.WindowWidth);

            // Add fade in animtion
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page in to the left and fades out
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideOutToLeft(seconds, page.WindowWidth);

            // Add fade in animtion
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        #endregion

        #region Slide Only (No Fade In/Out) Animations

        /// <summary>
        /// Slides a page in from the right (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideInFromRight(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideInFromRight(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page out to the right (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideOutToRight(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideOutToRight(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page in from the left (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideInFromLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideInFromLeft(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page out to the left (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideOutToLeft(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideOutToLeft(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page in from the bottom (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideInFromBottom(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideInFromBottom(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page out to the bottom (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideOutToBottom(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideOutToBottom(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page in from the top (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideInFromTop(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideInFromTop(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides a page out to the top (no fade)
        /// </summary>
        /// <param name="page">The page to animate </param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideOutToTop(this Page page, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideOutToTop(seconds, page.WindowWidth);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)seconds * 1000);
        }

        #endregion
    }
}
