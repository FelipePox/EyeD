using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities;

public sealed class HMDs : Entity
{
    private HMDs() { }

    public HMDs(Description description, IPV4 ipv4, SKU sku, MacAddress macAddress) : base()
    {
        Description = description;        
        IPV4 = ipv4;
        SKU = sku;
        MacAddress = macAddress;

        AddNotifications(Description,IPV4,SKU,MacAddress);
    }
    public SKU SKU { get; private set; }
    public IPV4 IPV4 { get; private set; }
    public Description Description { get; private set; }
    public MacAddress MacAddress { get; private set; }

    public void Update(Description description, IPV4 ipv4, SKU sku, MacAddress macAddress)
    {
        Description = description;
        IPV4 = ipv4;
        SKU = sku;
        MacAddress = macAddress;

        AddNotifications(Description, IPV4, SKU, MacAddress);

        if (IsValid)
            AtualizadoEm = DateTime.Now.ToLocalTime();
    }
}
