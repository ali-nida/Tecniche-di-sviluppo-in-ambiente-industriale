using Server.Classi;
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
        List<Sale> viewSales(User user);

        [OperationContract]
        List<User> viewUsers(User user);

        /*[OperationContract]
        List<Cart> viewCarts(User user);*/
    }
}
