﻿using Server.Classi;
using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
    [ServiceContract]
    public interface IECommerce
    {
        [OperationContract]
        (User, string) register(string username, string email, string password);

        [OperationContract]
        (User, string) login(string email, string password);

        [OperationContract]
        (List<Product>, string) viewProducts(bool admin, int offset = 0);

        [OperationContract]
        (int, string) addProduct(Product product);

        [OperationContract]
        (Product, string) viewProductDetails(int prod_id);

        [OperationContract]
        (bool, string) createCart(int prod_id, int user_id, int quantity);

        [OperationContract]
        (List<Cart>, string) viewCarts(int user_id);

        [OperationContract]
        (bool, string) removeCart(int cart_id);

        [OperationContract]
        (bool, string) buy(string address, int zip_code, string credit_card);

        [OperationContract]
        List<Sale> viewSales(User user);

        [OperationContract]
        List<User> viewUsers(User user);
    }
}
