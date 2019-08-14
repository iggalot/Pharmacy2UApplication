using System.Windows;
using System.Windows.Media;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Used to find ancestors of items in the visual tree
    /// Usage:  "var grid = VisualTreeHelperExtensions.FindAncestor<Grid>(this);"
    /// </summary>
    public static class VisualTreeHelperExtensions
    {
        public static T FindAncestor<T>(DependencyObject dependencyObject)
        where T : class
        {
            DependencyObject target = dependencyObject;
            do
            {
                target = VisualTreeHelper.GetParent(target);
            }
            while (target != null && !(target is T));
            return target as T;
        }
    }


}
