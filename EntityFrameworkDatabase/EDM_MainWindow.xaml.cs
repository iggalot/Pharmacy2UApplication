using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Windows;

namespace EntityFrameworkDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class EDM_MainWindow : Window
    {
        // Save the changes for a given EDM context
        public void SaveChanges(Pharm2UEntities context)
        {
            // Save the data changes
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
        }

        #region Cancellation Reason
        public void CreateCancellationReasons()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the cancellation table
                for(int i=0; i<300; i++)
                {
                    P2U_CancellationReason newOrder = context.P2U_CancellationReason.Add(new P2U_CancellationReason()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Reason = i.ToString() + "I never placed this order"
                    });

                }

                // Save the data changes
                SaveChanges(context);
            }
        }
        #endregion

        #region Customer
        public void CreateCustomer()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the zipcode table

                for (int i = 0; i < 300; i++)
                {
                    P2U_Customer newCustomer = context.P2U_Customer.Add(new P2U_Customer()
                    {
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        FirstName = "FirstName" + i.ToString(),
                        LastName = "LastName" + i.ToString(),
                        ContactMethod = "By phone",
                        Phone = "555-555-5555",
                        Email = "abc@abc.com" + i.ToString(),
                        StreetAddress = "StreetAddy" + i.ToString(),
                        Zip = ((i % 10)*10000 + (i % 10)*1000 + (i % 10) * 100 + (i % 10) * 10 + (i % 10) * 1).ToString(),
                        AddressType = "Single-family"
                    });
                }

                SaveChanges(context);
            }
        }
        #endregion

        #region Delivery Area Data
        public void CreateDeliveryArea()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                for (int i = 0; i < 300; i++)
                {
                    P2U_DeliveryArea newDeliveryArea = context.P2U_DeliveryArea.Add(new P2U_DeliveryArea()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Zip = ((i % 10) * 10000 + (i % 10) * 1000 + (i % 10) * 100 + (i % 10) * 10 + (i % 10) * 1).ToString(),
                        PharmacyID = i % 20,
                        DeliveryPrice = (decimal)i
                    });
                }

                // Save the data changes
                SaveChanges(context);
            }
        }
        #endregion

        #region Delivery Company

        public void CreateDeliveryCompany()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    P2U_DeliveryCompany newDeliveryCompany = context.P2U_DeliveryCompany.Add(new P2U_DeliveryCompany()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-1),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-1),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Name = "Delivery Company" + i.ToString(),
                        Phone = "555-555-5555",
                        Fax = "555-555-5555",
                        Email = "abc@abc.com" + i.ToString(),
                        Address = "DeliveryCompanyStreetAddy" + i.ToString(),
                        Zip = ((i % 10) * 10000 + (i % 10) * 1000 + (i % 10) * 100 + (i % 10) * 10 + (i % 10) * 1).ToString(),
                    });
                }

                SaveChanges(context);
            }
        }

        #endregion

        #region Food

        public void CreateFood()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the Food table
                    P2U_Food newFood = context.P2U_Food.Add(new P2U_Food()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Name = "FoodItem" + i.ToString(),
                        Description = "FoodDescript" + i.ToString(),
                        Price = (decimal)i,
                        Taxable = true,
                        Type = "solid"
                    });
                }

                SaveChanges(context);
            }
        }

        #endregion

        #region Order

        public void CreateOrder()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 33; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i*1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i*1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = null,
                        ReadyForPaymentWhen = null,
                        ReadyForPackagingWhen = null,
                        ReadyForPickupWhen = null,
                        OutForDeliveryWhen = null,
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason"+i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason"+i.ToString()
                    });
                }

                for (int i = 34; i < 66; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1-i),
                        ReadyForPaymentWhen = null,
                        ReadyForPackagingWhen = null,
                        ReadyForPickupWhen = null,
                        OutForDeliveryWhen = null,
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 67; i < 99; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = null,
                        ReadyForPickupWhen = null,
                        OutForDeliveryWhen = null,
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 100; i < 133; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = null,
                        OutForDeliveryWhen = null,
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 134; i < 166; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = DateTime.Now.AddHours(4 - i),
                        OutForDeliveryWhen = null,
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 167; i < 199; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = DateTime.Now.AddHours(4 - i),
                        OutForDeliveryWhen = DateTime.Now.AddHours(5 - i),
                        DeliveredWhen = null,
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 200; i < 233; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = DateTime.Now.AddHours(4 - i),
                        OutForDeliveryWhen = DateTime.Now.AddHours(5 - i),
                        DeliveredWhen = DateTime.Now.AddHours(6 - i),
                        CanceledWhen = null,
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 234; i < 266; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),


                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = DateTime.Now.AddHours(4 - i),
                        OutForDeliveryWhen = DateTime.Now.AddHours(5 - i),
                        DeliveredWhen = DateTime.Now.AddHours(6 - i),
                        CanceledWhen = DateTime.Now.AddHours(7 - i),
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = null,
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                for (int i = 267; i < 300; i++)
                {
                    // Build the order table
                    P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        CustomerID = i,
                        PharmacyID = i,
                        DeliveryCompanyID = i,
                        ProviderUsername = "Provider" + i.ToString(),
                        Status = "Status" + i.ToString(),
                        DeliveryWindow = "DeliveryWindow" + i.ToString(),
                        DeliveryInstructions = "Instructions" + i.ToString(),
                        DeliveryCost = (decimal)(i * 1.11),
                        FoodCost = (decimal)(i * 1.12),
                        OTCMedCost = (decimal)(i * 1.13),
                        PrescriptionCost = (decimal)(i * 1.14),
                        Tax = (decimal)1.50,
                        AuthCode = "authcode" + i.ToString(),
                        TransactionKey = "TransactionKey" + i.ToString(),
                        CardNumber = "11111111",

                        OrderInitiatedWhen = DateTime.Now.AddHours(-i),
                        NewOrderCreatedWhen = DateTime.Now.AddHours(1 - i),
                        ReadyForPaymentWhen = DateTime.Now.AddHours(2 - i),
                        ReadyForPackagingWhen = DateTime.Now.AddHours(3 - i),
                        ReadyForPickupWhen = DateTime.Now.AddHours(4 - i),
                        OutForDeliveryWhen = DateTime.Now.AddHours(5 - i),
                        DeliveredWhen = DateTime.Now.AddHours(6 - i),
                        CanceledWhen = DateTime.Now.AddHours(7 - i),
                        CanceledReason = "CanceledReason" + i.ToString(),
                        ReturnedWhen = DateTime.Now.AddHours(7 - i),
                        ReturnedReason = "ReturnedReason" + i.ToString()
                    });
                }

                SaveChanges(context);
            }
        }

        #endregion

        #region OrderFood
        public void CreateOrderFood()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the Delivery area table
                    P2U_OrderFood newOrderFood = context.P2U_OrderFood.Add(new P2U_OrderFood()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        OrderID = i,
                        FoodID = i,
                        Price = (decimal)(i*1.11),
                        Qty = i,
                        Taxable = true

                    });
                }

                SaveChanges(context);
            }
        }



        #endregion

        #region Order OTC Meds
        public void CreateOrderOTCMeds()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the Delivery area table
                    P2U_OrderOTCMeds newOTCMeds = context.P2U_OrderOTCMeds.Add(new P2U_OrderOTCMeds()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        OrderID = i,
                        OTCMedID = i,
                        Price = (decimal)(i * 1.11),
                        Qty = i,
                        Taxable = true

                    });
                }

                SaveChanges(context);               
            }
        }

        #endregion

        #region OTC Medication

        public void CreateOTCMedication()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the Food table
                    P2U_OTCMedication newOTCMed = context.P2U_OTCMedication.Add(new P2U_OTCMedication()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Name = "OTCMed" + i.ToString(),
                        Description = "OTCMedDescription" + i.ToString(),
                        Price = (decimal)(i*2.22),
                        Taxable = true,
                    });
                }               

                SaveChanges(context);
            }
        }

        #endregion

        #region Pharmacy

        public void CreatePharmacy()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the Delivery area table
                    P2U_Pharmacy newPharmacy = context.P2U_Pharmacy.Add(new P2U_Pharmacy()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Name = "Pharm" + i.ToString(),
                        Address = "PharmAddress" + i.ToString(),
                        Zip = ((i % 10) * 10000 + (i % 10) * 1000 + (i % 10) * 100 + (i % 10) * 10 + (i % 10) * 1).ToString(),

                        Phone = "111-111-1111",
                        UseGlobalPricing = true,
                        GlobalDeliveryPrice = (decimal)(i*10.00),
                        UseMinDeliveryAmt = true,
                        MinDeliveryAmt = (decimal)20.00,
                        OrderTimeout = null,
                        PaymentTimeout = null,
                        GLNumber = "GLString" + i.ToString(),
                        DefaultDeliveryCompany = i,
                        TaxRate = null,
                        OrderEmailAddress = "EmailAddress"+i.ToString(),
                        OrderEmailSubject = "EmailSubject"+i.ToString()

                    });
                }
                
                SaveChanges(context);
            }
        }

        #endregion

        #region Provider

        public void CreateProvider()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the provider table
                    P2U_Provider newProvider = context.P2U_Provider.Add(new P2U_Provider()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        ProviderID = "Provider" +i.ToString(),
                        FullName = "FullName" + i.ToString(),
                        Email = "email" + i.ToString()
                    });
                }

                SaveChanges(context);
            }
        }


        #endregion

        #region Returned Reason
        public void CreateReturnedReasons()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the returned reason table
                    P2U_ReturnedReason newReturnedReason = context.P2U_ReturnedReason.Add(new P2U_ReturnedReason()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Reason = "Reason" + i.ToString()
                    });
                }
                

                SaveChanges(context);
            }
        }
        #endregion

        #region Statuses

        public void CreateStatuses()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                for (int i = 0; i < 300; i++)
                {
                    // Build the cancellation table
                    P2U_Statuses newStatus = context.P2U_Statuses.Add(new P2U_Statuses()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Status = "Status" + i.ToString(),
                        ActiveStatus = true,
                        DisplayText = "StatusDisplayText" + i.ToString()
                });
            }

                SaveChanges(context);
            }
        }
        #endregion

        #region Zip Codes
        public void CreateZipCodes()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // create a new random instance for faking zipcode data
                Random ziprand = new Random();
                for (int i = 0; i < 300; i++)
                {
                    // Build the zipcode table
                    P2U_ZipCodes newOrder = context.P2U_ZipCodes.Add(new P2U_ZipCodes()
                    {
                        ItemID = i,
                        ItemCreatedBy = i,
                        ItemCreatedWhen = DateTime.Now.AddHours(-i),
                        ItemModifiedBy = i,
                        ItemModifiedWhen = DateTime.Now.AddHours(-i),
                        ItemOrder = i,
                        ItemGUID = Guid.NewGuid(),

                        Zip = ((i % 10) * 10000 + (i % 10) * 1000 + (i % 10) * 100 + (i % 10) * 10 + (i % 10) * 1).ToString(),

                        City = "Evansville",
                        County = "Vanderburgh",
                        State = "IN",
                        Country = "USA",
                        Latitude = 41.37,
                        Longitude = 56.54
                    });
                }

                SaveChanges(context);
            }
        }

        #endregion


        public void CreateDatabaseDatas()
        {
            //// populate our tables with dummy data
            CreateCancellationReasons();
            CreateCustomer();
            CreateDeliveryArea();
            CreateDeliveryCompany();
            CreateFood();
            CreateOrder();
            CreateOrderFood();
            CreateOrderOTCMeds();
            CreateOTCMedication();
            CreatePharmacy();
            CreateProvider();
            CreateReturnedReasons();
            CreateStatuses();
            CreateZipCodes();
        }
        public EDM_MainWindow()
        {
            InitializeComponent();

            // // Now initialize all of the database tables
//            CreateDatabaseDatas();
    
        }
    }
}
