using System.Diagnostics;
using Bodoconsult.App.Windows.Network.Dns;
using Bodoconsult.App.Windows.Test.Helpers;
using NUnit.Framework;

namespace Bodoconsult.App.Windows.Test;

[TestFixture]
public class UnitTestDnsServer
{
    [Test]
    public void TestGetListOfDomains()
    {
        var settings = TestHelper.GetAppSettings();

        var pwd = TestHelper.GetSecureString(settings.Password);

        var d = new DnsServer(settings.DomainServer, settings.Domain, settings.UserName, pwd);

        Debug.Print($"DNS structure {settings.DomainServer}");

        Debug.Print("DNS domains");
        foreach (var domain in d.GetListOfDomains())
        {
            Debug.Print($"\t{domain.Name} ({domain.ZoneType}{(domain.ReverseZone ? ", Reverse zone" : "")})");
            //and a list of all the records in the domain:-
            foreach (var record in d.GetRecordsForDomain(domain.Name))
            {
                Debug.Print($"\t\t{record}");
                //any domains we are primary for we could go and edit the record now!
            }
        }
    }
}