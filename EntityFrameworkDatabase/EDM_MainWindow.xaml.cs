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
        #region Cancellation Reason
        public void CreateCancellationReasons()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the cancellation table
                P2U_CancellationReason newOrder = context.P2U_CancellationReason.Add(new P2U_CancellationReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason ="I never placed this order"
                });

                newOrder = context.P2U_CancellationReason.Add(new P2U_CancellationReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "Aliens have invaded"
                });

                newOrder = context.P2U_CancellationReason.Add(new P2U_CancellationReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "No one home"
                });

                newOrder = context.P2U_CancellationReason.Add(new P2U_CancellationReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "Changed my mind!"
                });

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
        }
        #endregion

        #region Customer
        public void CreateCustomer()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the zipcode table
                P2U_Customer newCustomer = context.P2U_Customer.Add(new P2U_Customer()
                {
                    ItemID = 1,
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    FirstName = "Jim",
                    LastName = "Allen",
                    ContactMethod = "By phone",
                    Phone = "555-555-5555",
                    Email = "abc@abc.com",
                    StreetAddress = "1212 Anywhere Rd",
                    Zip = "12345",
                    AddressType = "Single-family"
                });

                // Build the zipcode table
                newCustomer = context.P2U_Customer.Add(new P2U_Customer()
                {
                    ItemID = 2,
                    ItemCreatedBy = 2,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 2,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    FirstName = "Miranda",
                    LastName = "Allen",
                    ContactMethod = "By phone",
                    Phone = "666-666-6666",
                    Email = "abc@abc.com",
                    StreetAddress = "1212 Anywhere Rd",
                    Zip = "12345",
                    AddressType = "Apartment"
                });

                // Build the zipcode table
                newCustomer = context.P2U_Customer.Add(new P2U_Customer()
                {
                    ItemID =3,
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    FirstName = "LJ",
                    LastName = "Allen",
                    ContactMethod = "By email",
                    Phone = "777-777-7777",
                    Email = "abc@abc.com",
                    StreetAddress = "1212 Anywhere Rd",
                    Zip = "12345",
                    AddressType = "Office"
                });

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
        }
        #endregion

        #region Delivery Area Data
        public void CreateDeliveryArea()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                P2U_DeliveryArea newDeliveryArea = context.P2U_DeliveryArea.Add(new P2U_DeliveryArea()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Zip = "11111",
                    PharmacyID = 1,
                    DeliveryPrice = (decimal)10.00
                });

                newDeliveryArea = context.P2U_DeliveryArea.Add(new P2U_DeliveryArea()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Zip = "22222",
                    PharmacyID = 2,
                    DeliveryPrice = (decimal)20.00
                });

                newDeliveryArea = context.P2U_DeliveryArea.Add(new P2U_DeliveryArea()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Zip = "22222",
                    PharmacyID = 3,
                    DeliveryPrice = (decimal)30.00
                });


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
        }
        #endregion

        #region Delivery Company

        public void CreateDeliveryCompany()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                P2U_DeliveryCompany newDeliveryCompany = context.P2U_DeliveryCompany.Add(new P2U_DeliveryCompany()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "ABC Delivery",
                    Address = "ABC Address",
                    Zip="11111",
                    Phone="111-111-1111",
                    Fax="fax 111-1111",
                    Email="ABC@gmail.com"

                });

                newDeliveryCompany = context.P2U_DeliveryCompany.Add(new P2U_DeliveryCompany()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "XYZ Delivery",
                    Address = "XYZ Address",
                    Zip = "22222",
                    Phone = "222-222-2222",
                    Fax = "fax 111-1111",
                    Email = "ABC@gmail.com"

                });

                newDeliveryCompany = context.P2U_DeliveryCompany.Add(new P2U_DeliveryCompany()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Speedy Delivery",
                    Address = "Speedy Address",
                    Zip = "33333",
                    Phone = "333-333-3333",
                    Fax = "fax 333-3333",
                    Email = "speedy@gmail.com"
                });

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
        }

        #endregion

        #region Food

        public void CreateFood()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Food table
                P2U_Food newFood = context.P2U_Food.Add(new P2U_Food()
                {
                    ItemID = 1,
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = 3,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Tacos",
                    Description = "A taco description",
                    Price = (decimal)1.11,
                    Taxable = true,
                    Type = "solid"
                });

                // Build the Food table
                newFood = context.P2U_Food.Add(new P2U_Food()
                {
                    ItemID = 2,
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = 1,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Chicken Noodle Soup",
                    Description = "A soup description",
                    Price = (decimal)2.22,
                    Taxable = true,
                    Type = "liquid"
                });

                // Build the Food table
                newFood = context.P2U_Food.Add(new P2U_Food()
                {
                    ItemID = 3,
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = 2,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Shrimp Pad Thai",
                    Description = "A pad thai description",
                    Price = (decimal)5.00,
                    Taxable = true,
                    Type = "awesome"
                });

                // Save the data changes
                try
                {
                    context.SaveChanges();
                } catch (DbEntityValidationException e)
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
        }

        #endregion

        #region Order

        public void CreateOrder()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the zipcode table
                P2U_Order newOrder = context.P2U_Order.Add(new P2U_Order()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    CustomerID = 151,
                    PharmacyID = 1,
                    DeliveryCompanyID = 1,
                    ProviderUsername = "Provider 1",
                    Status = "Status 1",
                    DeliveryWindow = "Delivery Win 1",
                    DeliveryInstructions = "Instructions 1",
                    DeliveryCost = (decimal)1.11,
                    FoodCost = (decimal)1.12,
                    OTCMedCost = (decimal)1.13,
                    PrescriptionCost = (decimal)1.14,
                    Tax = (decimal)1.50,
                    AuthCode = "authcode1",
                    TransactionKey = "key1",
                    CardNumber = "11111111",
                    OrderInitiatedWhen = DateTime.Now,
                    NewOrderCreatedWhen = DateTime.Now,
                    ReadyForPaymentWhen = DateTime.Now,
                    ReadyForPackagingWhen = DateTime.Now,
                    ReadyForPickupWhen = DateTime.Now,
                    OutForDeliveryWhen = DateTime.Now,
                    DeliveredWhen = DateTime.Now,
                    CanceledWhen = DateTime.Now,
                    CanceledReason = "cancelreason1",
                    ReturnedWhen = DateTime.Now,
                    ReturnedReason = "returnreason1"
                });
                newOrder = context.P2U_Order.Add(new P2U_Order()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    CustomerID = 152,
                    PharmacyID = 2,
                    DeliveryCompanyID = 2,
                    ProviderUsername = "Provider 2",
                    Status = "Status 2",
                    DeliveryWindow = "Delivery Win 2",
                    DeliveryInstructions = "Instructions 2",
                    DeliveryCost = (decimal)2.11,
                    FoodCost = (decimal)2.12,
                    OTCMedCost = (decimal)2.13,
                    PrescriptionCost = (decimal)2.14,
                    Tax = (decimal)2.50,
                    AuthCode = "authcode2",
                    TransactionKey = "key2",
                    CardNumber = "22222222",
                    OrderInitiatedWhen = DateTime.Now,
                    NewOrderCreatedWhen = DateTime.Now,
                    ReadyForPaymentWhen = DateTime.Now,
                    ReadyForPackagingWhen = DateTime.Now,
                    ReadyForPickupWhen = DateTime.Now,
                    OutForDeliveryWhen = DateTime.Now,
                    DeliveredWhen = DateTime.Now,
                    CanceledWhen = DateTime.Now,
                    CanceledReason = "cancelreason2",
                    ReturnedWhen = DateTime.Now,
                    ReturnedReason = "returnreason2"
                });

                newOrder = context.P2U_Order.Add(new P2U_Order()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    CustomerID = 153,
                    PharmacyID = 3,
                    DeliveryCompanyID = 3,
                    ProviderUsername = "Provider3",
                    Status = "Status3",
                    DeliveryWindow = "Delivery Win3",
                    DeliveryInstructions = "Instruction3",
                    DeliveryCost = (decimal)3.11,
                    FoodCost = (decimal)3.12,
                    OTCMedCost = (decimal)3.13,
                    PrescriptionCost = (decimal)3.14,
                    Tax = (decimal)3.50,
                    AuthCode = "authcode3",
                    TransactionKey = "key3",
                    CardNumber = "33333333",
                    OrderInitiatedWhen = DateTime.Now,
                    NewOrderCreatedWhen = DateTime.Now,
                    ReadyForPaymentWhen = DateTime.Now,
                    ReadyForPackagingWhen = DateTime.Now,
                    ReadyForPickupWhen = DateTime.Now,
                    OutForDeliveryWhen = DateTime.Now,
                    DeliveredWhen = DateTime.Now,
                    CanceledWhen = DateTime.Now,
                    CanceledReason = "cancelreason3",
                    ReturnedWhen = DateTime.Now,
                    ReturnedReason = "returnreason3"
                });


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
        }

        #endregion

        #region OrderFood
        public void CreateOrderFood()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                P2U_OrderFood newOrderFood = context.P2U_OrderFood.Add(new P2U_OrderFood()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 1,
                    FoodID = 2,
                    Price = (decimal)1.11,
                    Qty = 1,
                    Taxable = true

                });

                // Build the Delivery area table
                newOrderFood = context.P2U_OrderFood.Add(new P2U_OrderFood()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 2,
                    FoodID = 3,
                    Price = (decimal)3.33,
                    Qty = 3,
                    Taxable = true

                });

                newOrderFood = context.P2U_OrderFood.Add(new P2U_OrderFood()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 3,
                    FoodID = 4,
                    Price = (decimal)4.44,
                    Qty = 4,
                    Taxable = true

                });


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
        }



        #endregion

        #region Order OTC Meds
        public void CreateOrderOTCMeds()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                P2U_OrderOTCMeds newOTCMeds = context.P2U_OrderOTCMeds.Add(new P2U_OrderOTCMeds()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 1,
                    OTCMedID = 2,
                    Price = (decimal)1.11,
                    Qty = 1,
                    Taxable = true

                });

                // Build the Delivery area table
                newOTCMeds = context.P2U_OrderOTCMeds.Add(new P2U_OrderOTCMeds()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 2,
                    OTCMedID = 3,
                    Price = (decimal)3.33,
                    Qty = 3,
                    Taxable = true

                });

                newOTCMeds = context.P2U_OrderOTCMeds.Add(new P2U_OrderOTCMeds()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    OrderID = 3,
                    OTCMedID = 4,
                    Price = (decimal)4.44,
                    Qty = 4,
                    Taxable = true

                });



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
        }



        #endregion

        #region OTC Medication

        public void CreateOTCMedication()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Food table
                P2U_OTCMedication newOTCMed = context.P2U_OTCMedication.Add(new P2U_OTCMedication()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Aspirin",
                    Description = "An aspirin description",
                    Price = (decimal)1.11,
                    Taxable = true,
                });

                // Build the Food table
                newOTCMed = context.P2U_OTCMedication.Add(new P2U_OTCMedication()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Pepto Bismol",
                    Description = "A pepto description",
                    Price = (decimal)2.22,
                    Taxable = true,
                });

                // Build the Food table
                newOTCMed = context.P2U_OTCMedication.Add(new P2U_OTCMedication()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Alka Seltzer",
                    Description = "A pad thai description",
                    Price = (decimal)5.00,
                    Taxable = false,
                });

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
        }

        #endregion

        #region Pharmacy

        public void CreatePharmacy()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the Delivery area table
                P2U_Pharmacy newPharmacy = context.P2U_Pharmacy.Add(new P2U_Pharmacy()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Pharm1",
                    Address = "Pharm1 Address",
                    Zip = "11111",
                    Phone = "111-111-1111",
                    UseGlobalPricing = true,
                    GlobalDeliveryPrice = (decimal)10.00,
                    UseMinDeliveryAmt = true,
                    MinDeliveryAmt = (decimal) 20.00,
                    OrderTimeout = null,
                    PaymentTimeout = null,
                    GLNumber = "GLString1",
                    DefaultDeliveryCompany = 1,
                    TaxRate = null,
                    OrderEmailAddress = "Email Address 1",
                    OrderEmailSubject = "Email Subject 1"

                });

                // Build the Delivery area table
                newPharmacy = context.P2U_Pharmacy.Add(new P2U_Pharmacy()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Pharm2",
                    Address = "Pharm2 Address",
                    Zip = "22222",
                    Phone = "222-222-2222",
                    UseGlobalPricing = true,
                    GlobalDeliveryPrice = (decimal)20.00,
                    UseMinDeliveryAmt = true,
                    MinDeliveryAmt = (decimal)40.00,
                    OrderTimeout = null,
                    PaymentTimeout = null,
                    GLNumber = "GLString2",
                    DefaultDeliveryCompany = 2,
                    TaxRate = null,
                    OrderEmailAddress = "Email Address 2",
                    OrderEmailSubject = "Email Subject 2"

                });

                // Build the Delivery area table
                newPharmacy = context.P2U_Pharmacy.Add(new P2U_Pharmacy()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Name = "Pharm3",
                    Address = "Pharm3 Address",
                    Zip = "33333",
                    Phone = "333-333-3333",
                    UseGlobalPricing = true,
                    GlobalDeliveryPrice = (decimal)30.00,
                    UseMinDeliveryAmt = true,
                    MinDeliveryAmt = (decimal)60.00,
                    OrderTimeout = null,
                    PaymentTimeout = null,
                    GLNumber = "GLString3",
                    DefaultDeliveryCompany = 1,
                    TaxRate = null,
                    OrderEmailAddress = "Email Address 3",
                    OrderEmailSubject = "Email Subject 3"

                });

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
        }


        #endregion

        #region Provider

        public void CreateProvider()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the provider table
                P2U_Provider newProvider = context.P2U_Provider.Add(new P2U_Provider()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    ProviderID = "Provider 1",
                    FullName = "FullName 1",
                    Email = "email1"

                });

                newProvider = context.P2U_Provider.Add(new P2U_Provider()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    ProviderID = "Provider 2",
                    FullName = "FullName 2",
                    Email = "email2"

                });


                newProvider = context.P2U_Provider.Add(new P2U_Provider()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    ProviderID = "Provider 3",
                    FullName = "FullName 3",
                    Email = "email3"

                });


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
        }


        #endregion

        #region Returned Reason
        public void CreateReturnedReasons()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the cancellation table
                P2U_ReturnedReason newReturnedReason = context.P2U_ReturnedReason.Add(new P2U_ReturnedReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "I never placed this order"
                });

                newReturnedReason = context.P2U_ReturnedReason.Add(new P2U_ReturnedReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "Aliens have invaded"
                });

                newReturnedReason = context.P2U_ReturnedReason.Add(new P2U_ReturnedReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "No one home"
                });

                newReturnedReason = context.P2U_ReturnedReason.Add(new P2U_ReturnedReason()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Reason = "Changed my mind!"
                });

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
        }
        #endregion

        #region Statuses

        public void CreateStatuses()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // Build the cancellation table
                P2U_Statuses newStatus = context.P2U_Statuses.Add(new P2U_Statuses()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Status = "Completed",
                    ActiveStatus = true,
                    DisplayText = "This order is completed."
                });

                // Build the cancellation table
                newStatus = context.P2U_Statuses.Add(new P2U_Statuses()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Status = "ReadyForDelivery",
                    ActiveStatus = false,
                    DisplayText = "This order is ready for delivery."
                });

                // Build the cancellation table
                newStatus = context.P2U_Statuses.Add(new P2U_Statuses()
                {
                    ItemCreatedBy = 1,
                    ItemCreatedWhen = DateTime.Now,
                    ItemModifiedBy = 1,
                    ItemModifiedWhen = DateTime.Now,
                    ItemOrder = null,
                    ItemGUID = Guid.NewGuid(),
                    Status = "Ready for packaging",
                    ActiveStatus = false,
                    DisplayText = "This order is ready for packaging."
                });

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
        }
        #endregion

        #region Zip Codes
        public void CreateZipCodes()
        {
            using (Pharm2UEntities context = new Pharm2UEntities())
            {
                // create a new random instance for faking zipcode data
                Random ziprand = new Random();
                for (int i = 0; i < 10; i++)
                {
                    // Create a fake zipcode string
                    int ziprandom = ziprand.Next(1, 100000);
                    string zip = ziprandom.ToString();

                    // Build the zipcode table
                    P2U_ZipCodes newOrder = context.P2U_ZipCodes.Add(new P2U_ZipCodes()
                    {
                        ItemCreatedBy = 1,
                        ItemCreatedWhen = DateTime.Now,
                        ItemModifiedBy = 1,
                        ItemModifiedWhen = DateTime.Now,
                        ItemOrder = null,
                        ItemGUID = Guid.NewGuid(),
                        Zip = zip,
                        City = "Evansville",
                        County = "Vanderburgh",
                        State = "IN",
                        Country = "USA",
                        Latitude = 41.37,
                        Longitude = 56.54
                    });
                }

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
            //CreateDatabaseDatas();
    
        }
    }
}
