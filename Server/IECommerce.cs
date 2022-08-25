using System.Collections.Generic;
using System.ServiceModel;
using Server.Classi;

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
        List<Product> viewProducts();

        [OperationContract]
        List<Sale> viewSales(User user);

        [OperationContract]
        List<User> viewUsers(User user);

        /*[OperationContract]
        List<Cart> viewCarts(User user);*/
    }
}
