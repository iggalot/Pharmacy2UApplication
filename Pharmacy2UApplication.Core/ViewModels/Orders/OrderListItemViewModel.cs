namespace Pharmacy2UApplication.Core
{
     public class OrderListItemViewModel : BaseViewModel
    {


        #region Public Properties

        // Fields of our property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderNumber { get; set; }

        #endregion


        #region Constructor 
        public OrderListItemViewModel(string first, string last, int num)
        {
            FirstName = first;
            LastName = last;
            OrderNumber = num;
        }

        #endregion
    }
}
