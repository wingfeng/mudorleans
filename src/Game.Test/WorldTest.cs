using Game.Facility.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.TestingHost;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Test
{
    [TestClass]
    public class WorldTest
    {
        [TestMethod]
        public async Task LoginTest()
        {
            //Task.Run(() => LocalTestSiloClient.createSilo());
            //Thread.Sleep(3000);
            var client =await LocalTestSiloClient.createClient();
           var world= client.GetGrain<IWorld>(0);
          var result= await world.PlayerLogin("wing","aks");
            Assert.AreEqual<bool>(result, true);
       

        }

        [TestMethod]
        public async Task GetRoomTest()
        {
            //Task.Run(() => LocalTestSiloClient.createSilo());
            //Thread.Sleep(3000);
            var client = await LocalTestSiloClient.createClient();
            var world = client.GetGrain<IWorld>(0);
            //var result = await world.GetRoom("");
            //Assert.AreEqual<string>(result.Id, "Game.MudLib.d.fy.fysquare");
         

        }
    }
}
