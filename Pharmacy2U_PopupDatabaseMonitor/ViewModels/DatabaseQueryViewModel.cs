using EntityFrameworkDatabase;
using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Pharmacy2U_PopupDatabaseMonitor
{
    /// <summary>
    /// A class that controls the reading and retrieving of order data from the data base
    /// TODO:  Move this to .CORE project -- issues with namespace naming in the meantime
    ///        but need to merge this with the local version in Pharmacy2UApplication
    /// </summary>
    public class DatabaseQueryViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The previous number of records detected in the database
        /// </summary>
        private static int PreviousRecordCount { get; set; }

        /// <summary>
        /// The current number of records detected in the database
        /// </summary>
        private static int CurrentRecordCount { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DatabaseQueryViewModel()
        {
            // Initialize our counter variables
            PreviousRecordCount = 0;
            CurrentRecordCount = CountOrders();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The collection entity to store our list of full order data queries
        /// </summary>
        public static ObservableCollection<OrderListItemViewModel> FullOrderInfoList { get; set; }

        /// <summary>
        /// The collection entity for all food items  data queries
        /// </summary>
        public static ObservableCollection<FoodListItemViewModel> FullFoodInfoList { get; set; }

        #endregion

        #region DB Interaction Commands

        private int CountOrders()
        {
            // Count the current number of records in the orders database
            using (var context = new Pharm2UEntities3())
            {
                // Query the P2U_Order database
                return context.P2U_Order.Count();
            }
        }

        #endregion


        #region Helper Methods

        /// <summary>
        /// Helper function that returns the last acknowledge count number
        /// </summary>
        /// <returns></returns>
        public int GetPreviousRecordCount()
        {
            return PreviousRecordCount;
        }

        /// <summary>
        /// Helper function that sets the prevous record count to a specific value
        /// </summary>
        /// <param name="num"></param>
        public void SetPreviousRecordCount(int num)
        {
            PreviousRecordCount = num;
        }

        /// <summary>
        /// Helper function that returns the current count of records in the database
        /// </summary>
        /// <returns></returns>
        public int GetCurrentRecordCount()
        {
            // Check the count of the number of records currently
            CurrentRecordCount = CountOrders();

            return CurrentRecordCount;
        }

        /// <summary>
        /// Update the previous count
        /// </summary>
        public void UpdatePreviousCount()
        {
            // do nothing
            if (PreviousRecordCount == CurrentRecordCount)
                return;

            // Update the previous count
            PreviousRecordCount = CurrentRecordCount;

            return;
        }

        #endregion
    }
}
