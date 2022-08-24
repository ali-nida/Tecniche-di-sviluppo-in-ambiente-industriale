using System.Collections.Generic;
using System.ServiceModel;
using Server.Classi;

namespace Server
{
    [ServiceContract]
    public interface IECommerce
    {
        [OperationContract]
        User register(User user);

        [OperationContract]
        User login(User user);

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
