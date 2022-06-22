using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfMyStoreService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetData(int id);

        [OperationContract]
        string AddProduct(Product product);

        // TODO: Add your service operations here
    }
}
