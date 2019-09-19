using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Pharmacy2UApplication.Core
{
    public class TreeHelperExtensions
    {
        #region Tree Writing
        /// <summary>
        /// Writes the visual tree for a given dependency object
        /// </summary>
        /// <param name="parent">The dependency object</param>
        /// <returns></returns>
        public static string WriteVisualTree(DependencyObject parent)
        {
            if (parent == null)
                return "No Visual Tree Available. DependencyOBject is bull.";

            using (var stringWriter = new StringWriter())
            using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "  "))
            {
                WriteVisualTreeRecursive(indentedTextWriter, parent, 0);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Recursive writing of visual tree for a parent dependency object
        /// </summary>
        /// <param name="writer">The writer to use</param>
        /// <param name="parent">The parent object</param>
        /// <param name="indentLevel">The indent level for formatting</param>
        private static void WriteVisualTreeRecursive(IndentedTextWriter writer, DependencyObject parent, int indentLevel)
        {
            if (parent == null)
                return;

            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            string typeName = parent.GetType().Name;
            string objName = parent.GetValue(FrameworkElement.NameProperty) as string;

            writer.Indent = indentLevel;
            writer.WriteLine(String.Format("[{0:0000}] {1} ({2}) {3}", indentLevel,
                String.IsNullOrEmpty(objName) ? typeName : objName,
                typeName, childCount)
            );

            for (int childIndex = 0; childIndex < childCount; ++childIndex)
                WriteVisualTreeRecursive(writer, VisualTreeHelper.GetChild(parent, childIndex), indentLevel + 1);
        }

        /// <summary>
        /// Writes the logical tree for a given dependency object
        /// </summary>
        /// <param name="parent">The dependency object</param>
        /// <returns></returns>
        public static string WriteLogicalTree(DependencyObject parent)
        {
            if (parent == null)
                return "No Logicial Tree Available. DependencyObject is null.";

            using (var stringWriter = new StringWriter())
                using (var indentedTextWriter = new IndentedTextWriter(stringWriter, "  "))
            {
                WriteLogicalTreeRecursive(indentedTextWriter, parent, 0);
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// Recursive writing of logical tree for a parent dependency object
        /// </summary>
        /// <param name="writer">The writer to use</param>
        /// <param name="parent">The parent object</param>
        /// <param name="indentLevel">The indent level for formatting</param>
        private static void WriteLogicalTreeRecursive(IndentedTextWriter writer, DependencyObject parent, int indentLevel)
        {
            if (parent == null)
                return;

            var children = LogicalTreeHelper.GetChildren(parent).OfType<DependencyObject>();
            int childCount = children.Count();

            string typeName = parent.GetType().Name;
            string objName = parent.GetValue(FrameworkElement.NameProperty) as string;

            double actualWidth = (parent.GetValue(FrameworkElement.ActualWidthProperty) as double?).GetValueOrDefault();
            double actualHeight = (parent.GetValue(FrameworkElement.ActualHeightProperty) as double?).GetValueOrDefault();

            writer.Indent = indentLevel;
            writer.WriteLine(String.Format("[{0:000}] {1} ({2}) {3}", indentLevel,
                String.IsNullOrEmpty(objName) ? typeName : objName,
                typeName,
                childCount)
            );

            foreach (object child in LogicalTreeHelper.GetChildren(parent))
            {
                if (child is DependencyObject)
                    WriteLogicalTreeRecursive(writer, (DependencyObject)child, indentLevel + 1);
            }
        }
        #endregion

        #region Tree Searching
        /// <summary>
        /// Used to find ancestors of items in the visual tree
        /// Usage:  "var grid = VisualTreeHelperExtensions.FindAncestor<Grid>(this);"
        /// </summary>
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
        #endregion
    }
}
