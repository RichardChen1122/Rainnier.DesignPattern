using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Rx.Demo
{
    public class BomberControl : IDisposable
    {
        private IDisposable planeSpottedSubscription;

        public BomberControl(JetFighter jetFighter)
        {
            this.planeSpottedSubscription = jetFighter.PlaneSpotted.Subscribe(this.OnPlaneSpotted);
        }

        public void Dispose()
        {
            this.planeSpottedSubscription.Dispose();
        }

        private void OnPlaneSpotted(JetFighter jetFighter)
        {
            JetFighter spottedPlane = jetFighter;
        }
    }
}
