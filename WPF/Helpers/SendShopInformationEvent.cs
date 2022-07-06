using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.Helpers
{
    public class SendShopInformationEvent : PubSubEvent<Shop>
    {
    }
}
