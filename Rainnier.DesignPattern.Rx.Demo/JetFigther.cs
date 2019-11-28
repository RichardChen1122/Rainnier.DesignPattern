using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Rx.Demo
{
    public class JetFighter
    {
        private Subject<JetFighter> planeSpotted = new Subject<JetFighter>();

        public IObservable<JetFighter> PlaneSpotted
        {
            get { return this.planeSpotted; }
        }

        public string Name { get; private set; }

        public void AllPlanesSpotted()
        {
            this.planeSpotted.OnCompleted();
        }

        public void SpotPlane(JetFighter jetFighter)
        {
            try
            {
                if (string.Equals(jetFighter.Name, "UFO"))
                {
                    throw new Exception("UFO Found");
                }

                this.planeSpotted.OnNext(jetFighter);
            }
            catch (Exception exception)
            {
                this.planeSpotted.OnError(exception);
            }
        }
    }
}
